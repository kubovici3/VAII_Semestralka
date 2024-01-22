using Microsoft.AspNetCore.Identity;
using System;
using System.Diagnostics;
using System.Net;
using VAII_Semestralka.Models;

namespace VAII_Semestralka.Data
{
    public class InicializacneData
    {
		public static void Inicializuj(IServiceProvider serviceProvider)
		{
			using (var scope = serviceProvider.CreateScope())
			{
				var scopedServiceProvider = scope.ServiceProvider;
				var roleManager = scopedServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
				var userManager = scopedServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

				InicializujData(scopedServiceProvider);
				InicializujRole(roleManager);
				InicializujPouzivatelov(userManager);
			}

		}
		public static void InicializujData(IServiceProvider scopedServiceProvider)
        {
	        var dbContext = scopedServiceProvider.GetRequiredService<AppDbContext>();

	        var produkty = new List<Produkt>
	        {
		        new Produkt()
		        {
			        Typ = "Kuchyna",
			        Opis = "Parádna kuchyna 1",
			        Obrazok = "/images/kuchyne/kuchyna.jpg",
			        MaterialID = 1.ToString(),
			        UdajeProduktu = new Udaje()
			        {
				        CasVytvorenia = DateTime.Now,
				        CasPoslednejZmeny = DateTime.Now
			        }

		        },
		        new Produkt()
		        {
			        Typ = "Kuchyna",
			        Opis = "Parádna kuchyna 2",
			        Obrazok = "/images/kuchyne/kuchyna2.jpg",
			        MaterialID = 3.ToString(),
			        UdajeProduktu = new Udaje()
			        {
				        CasVytvorenia = DateTime.Now,
				        CasPoslednejZmeny = DateTime.Now
			        }

		        },
		        new Produkt()
		        {
			        Typ = "Kuchyna",
			        Opis = "Parádna kuchyna 1",
			        Obrazok = "/images/kuchyne/kuchyna3.jpg",
			        MaterialID = 2.ToString(),
			        UdajeProduktu = new Udaje()
			        {
				        CasVytvorenia = DateTime.Now,
				        CasPoslednejZmeny = DateTime.Now
			        }

		        },
		        new Produkt()
		        {
			        Typ = "Kuchyna",
			        Opis = "Parádna kuchyna 2",
			        Obrazok = "/images/kuchyne/kuchyna4.jpg",
			        MaterialID = 4.ToString(),
			        UdajeProduktu = new Udaje()
			        {
				        CasVytvorenia = DateTime.Now,
				        CasPoslednejZmeny = DateTime.Now
			        }

		        },
		        new Produkt()
		        {
			        Typ = "Obyvacia_izba",
			        Opis = "Parádna Obyvacia izba  1",
			        Obrazok = "/images/obyvacie_izby/obyvacia_izba1.jpg",
			        MaterialID = 5.ToString(),
			        UdajeProduktu = new Udaje()
			        {
				        CasVytvorenia = DateTime.Now,
				        CasPoslednejZmeny = DateTime.Now
			        }

		        },
		        new Produkt()
		        {
			        Typ = "Obyvacia_izba",
			        Opis = "Parádna Obyvacia izba 2",
			        Obrazok = "/images/obyvacie_izby/obyvacia_izba2.jpg",
			        MaterialID = 2.ToString(),
			        UdajeProduktu = new Udaje()
			        {
				        CasVytvorenia = DateTime.Now,
				        CasPoslednejZmeny = DateTime.Now
			        }

		        },
		        new Produkt()
		        {
			        Typ = "Obyvacia_izba",
			        Opis = "Parádna Obyvacia izba 3",
			        Obrazok = "/images/obyvacie_izby/obyvacia_izba3.jpg",
			        MaterialID = 3.ToString(),
			        UdajeProduktu = new Udaje()
			        {
				        CasVytvorenia = DateTime.Now,
				        CasPoslednejZmeny = DateTime.Now
			        }

		        },
		        new Produkt()
		        {
			        Typ = "Obyvacia_izba",
			        Opis = "Parádna Obyvacia izba 4",
			        Obrazok = "/images/obyvacie_izby/obyvacia_izba4.jpg",
			        MaterialID = 1.ToString(),
			        UdajeProduktu = new Udaje()
			        {
				        CasVytvorenia = DateTime.Now,
				        CasPoslednejZmeny = DateTime.Now
			        }

		        },
		        new Produkt()
		        {
			        Typ = "Pracovna",
			        Opis = "Parádna pracovna 1",
			        Obrazok = "/images/pracovne/pracovna1.jpg",
			        MaterialID = 2.ToString(),
			        UdajeProduktu = new Udaje()
			        {
				        CasVytvorenia = DateTime.Now,
				        CasPoslednejZmeny = DateTime.Now
			        }

		        },
		        new Produkt()
		        {
			        Typ = "Pracovna",
			        Opis = "Parádna pracovna 2",
			        Obrazok = "/images/pracovne/pracovna2.jpg",
			        MaterialID = 3.ToString(),
			        UdajeProduktu = new Udaje()
			        {
				        CasVytvorenia = DateTime.Now,
				        CasPoslednejZmeny = DateTime.Now
			        }

		        },
		        new Produkt()
		        {
			        Typ = "Pracovna",
			        Opis = "Parádna pracovna 3",
			        Obrazok = "/images/pracovne/pracovna3.jpg",
			        MaterialID = 1.ToString(),
			        UdajeProduktu = new Udaje()
			        {
				        CasVytvorenia = DateTime.Now,
				        CasPoslednejZmeny = DateTime.Now
			        }

		        }
	        };
			var plosneMaterialy = new List<Plosny_material>()
			{
				new Plosny_material()
				{
					Typ = "UNI Farby",
					Obrazok = "/images/materialy/mat1.jpg",
					UdajeMaterialu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}
				},
				new Plosny_material()
				{
					Typ = "UNI Farby",
					Obrazok = "/images/materialy/mat2.jpg",
					UdajeMaterialu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}
				},
				new Plosny_material()
				{
					Typ = "UNI Farby",
					Obrazok = "/images/materialy/mat3.jpg",
					UdajeMaterialu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}
				},
				new Plosny_material()
				{
					Typ = "UNI Farby",
					Obrazok = "/images/materialy/mat4.jpg",
					UdajeMaterialu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}
				},
				new Plosny_material()
				{
					Typ = "UNI Farby",
					Obrazok = "/images/materialy/mat5.jpg",
					UdajeMaterialu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}
				},
				new Plosny_material()
				{
					Typ = "UNI Farby",
					Obrazok = "/images/materialy/mat6.jpg",
					UdajeMaterialu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}
				},

			};


			// Přidání produktů do databáze, pokud databáze je prázdná
			if (!dbContext.Produkty.Any())
	        {
		        dbContext.Produkty.AddRange(produkty);
		        dbContext.SaveChanges();
	        }

			if (!dbContext.Materialy.Any())
			{
				dbContext.Materialy.AddRange(plosneMaterialy);
				dbContext.SaveChanges();
			}

		}

		private static void InicializujRole(RoleManager<IdentityRole> roleManager)
		{
			if (!roleManager.RoleExistsAsync("Admin").Result)
			{
				IdentityRole rola = new IdentityRole
				{
					Name = "Admin"
				};
				IdentityResult vyslednaRola = roleManager.CreateAsync(rola).Result;
			}

			if (!roleManager.RoleExistsAsync("Pouzivatel").Result)
			{
				IdentityRole rola = new IdentityRole
				{
					Name = "Pouzivatel"
				};
				IdentityResult vyslednaRola = roleManager.CreateAsync(rola).Result;
			}
		}
		private static void InicializujPouzivatelov(UserManager<IdentityUser> userManager)
		{
			if (userManager.FindByNameAsync("admin").Result == null)
			{
				IdentityUser user = new IdentityUser
				{
					UserName = "admin",
					Email = "admin@example.com"
				};

				IdentityResult result = userManager.CreateAsync(user, "Admin123!").Result;

				if (result.Succeeded)
				{
					userManager.AddToRoleAsync(user, "Admin").Wait();
				}
			}
		}
	}
}

