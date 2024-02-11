using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using VAII_Semestralka.Data;
using VAII_Semestralka.Models;

namespace VAII_Semestralka.Controllers
{
	public class UcetController : Controller
	{
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;

		public UcetController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;

		}

		[HttpGet]
		public IActionResult Prihlasenie()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Prihlasenie(PrihlasenieViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Meno, model.Heslo, isPersistent: false, lockoutOnFailure: false);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home"); // Přesměrujte kamkoli po úspěšném přihlášení
				}

				if (result.IsLockedOut)
				{
					ModelState.AddModelError(string.Empty, "Účet bol zablokovaný.");
				}
				else if (result.IsNotAllowed)
				{
					ModelState.AddModelError(string.Empty, "Pre tento účet neni povolené prihlásenie.");
				}
				else if (result.RequiresTwoFactor)
				{
					ModelState.AddModelError(string.Empty, "Vyžaduje se dvojfaktorová autentizácia.");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Neplatné prihlasovacie údaje.");
				}
			}


			return View(model);
		}
			
		[HttpGet]
		public async Task<IActionResult> Odhlasenie()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home"); 
		}

		[HttpGet]
		public IActionResult Registracia()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Registracia(RegistraciaViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new IdentityUser { UserName = model.Meno, Email = model.Email};
				IdentityResult result = _userManager.CreateAsync(user, model.Heslo).Result;


				if (result.Succeeded)
				{
					_userManager.AddToRoleAsync(user, "Pouzivatel").Wait();
					_signInManager.SignInAsync(user, isPersistent: false).Wait();

					return RedirectToAction("Index", "Home");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> SpravaUdajov()
		{
			var user = await _userManager.GetUserAsync(User);

			if (user == null)
			{
				return NotFound();
			}

			var model = new UpravaViewModel()
			{
				Meno = user.UserName,
				Email = user.Email,
			};

			return View(model);
		}

		[HttpPost]	//daj na HttpPost ak nebude fungovat put
		public async Task<IActionResult> SpravaUdajov(UpravaViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.GetUserAsync(User);

				if (user == null)
				{
					return NotFound();
				}

				var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.StareHeslo);

				if (!isPasswordValid)
				{
					ModelState.AddModelError(string.Empty, "Zadali ste nesprávné aktuálne heslo.");
					return View(model);
				}

				user.UserName = model.Meno;
				user.Email = model.Email;

				if (!string.IsNullOrEmpty(model.NoveHeslo))
				{
					var result = await _userManager.ChangePasswordAsync(user, model.StareHeslo, model.NoveHeslo);

					if (!result.Succeeded)
					{
						foreach (var error in result.Errors)
						{
							ModelState.AddModelError(string.Empty, error.Description);
						}

						return View(model);
					}
				}

				var updateResult = await _userManager.UpdateAsync(user);

				if (updateResult.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}

			}
			return View(model);
		}

		[HttpDelete]
		public async Task<IActionResult> OdstranitUcet()
		{
			var user = await _userManager.GetUserAsync(User);

			if (user == null)
			{
				return NotFound();
			}

			var result = await _userManager.DeleteAsync(user);

			if (result.Succeeded)
			{
				await _signInManager.SignOutAsync();
				return RedirectToAction("Index", "Home");
			}

			return RedirectToAction("SpravaUdajov", "Ucet");

		}

		[HttpPost]
		public JsonResult ValidaciaRegistracnehoFormulara(RegistraciaViewModel model)
		{
			// Validate the model
			var context = new ValidationContext(model, serviceProvider: null, items: null);
			var results = new List<ValidationResult>();
			bool isValid = Validator.TryValidateObject(model, context, results, true);

			// If the model is not valid, return the validation errors
			if (!isValid)
			{
				Debug.WriteLine("Validation errors: " + string.Join(", ", results.Select(r => r.ErrorMessage)));
				return Json(results.Select(r => new { propertyName = r.MemberNames.First(), errorMessage = r.ErrorMessage }));
			}

			// If we made it this far, the model is valid
			return Json(new { isValid = true });
		}
	}
}
