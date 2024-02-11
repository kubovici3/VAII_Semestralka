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
			Random randMat = new Random();
			var produkty = new List<Produkt>
			{
				new Produkt()
				{
					Typ = TypProduktu.Kuchyna,
					Opis = "Parádna kuchyna 1",
					Obrazok = "/images/Kuchyna/kuchyna.jpg",
					Plosne_materialy = new List<Plosny_material>()
					{
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count)),
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count))
					},
					UdajeProduktu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}

				},
				new Produkt()
				{
					Typ = TypProduktu.Kuchyna,
					Opis = "Parádna kuchyna 2",
					Obrazok = "/images/Kuchyna/kuchyna2.jpg",
					Plosne_materialy = new List<Plosny_material>()
					{
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count)),
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count))
					},
					UdajeProduktu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}

				},
				new Produkt()
				{
					Typ = TypProduktu.Kuchyna,
					Opis = "Parádna kuchyna 1",
					Obrazok = "/images/Kuchyna/kuchyna3.jpg",
					Plosne_materialy = new List<Plosny_material>()
					{
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count)),
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count))
					},
					UdajeProduktu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}

				},
				new Produkt()
				{
					Typ = TypProduktu.Kuchyna,
					Opis = "Parádna kuchyna 2",
					Obrazok = "/images/Kuchyna/kuchyna4.jpg",
					Plosne_materialy = new  List<Plosny_material>()
					{
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count)),
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count))
					},
					UdajeProduktu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}

				},
				new Produkt()
				{
					Typ = TypProduktu.Obyvacia_izba,
					Opis = "Parádna Obyvacia izba  1",
					Obrazok = "/images/Obyvacia_izba/obyvacia_izba1.jpg",
					Plosne_materialy = new List<Plosny_material>()
					{
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count)),
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count))
					},
					UdajeProduktu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}

				},
				new Produkt()
				{
					Typ = TypProduktu.Obyvacia_izba,
					Opis = "Parádna Obyvacia izba 2",
					Obrazok = "/images/Obyvacia_izba/obyvacia_izba2.jpg",
					Plosne_materialy = new List<Plosny_material>()
					{
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count)),
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count))
					},
					UdajeProduktu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}

				},
				new Produkt()
				{
					Typ = TypProduktu.Obyvacia_izba,
					Opis = "Parádna Obyvacia izba 3",
					Obrazok = "/images/Obyvacia_izba/obyvacia_izba3.jpg",
					Plosne_materialy = new List<Plosny_material>()
					{
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count)),
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count))
					},
					UdajeProduktu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}

				},
				new Produkt()
				{
					Typ = TypProduktu.Obyvacia_izba,
					Opis = "Parádna Obyvacia izba 4",
					Obrazok = "/images/Obyvacia_izba/obyvacia_izba4.jpg",
					Plosne_materialy = new List<Plosny_material>()
					{
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count)),
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count))
					},
					UdajeProduktu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}

				},
				new Produkt()
				{
					Typ = TypProduktu.Pracovna,
					Opis = "Parádna pracovna 1",
					Obrazok = "/images/Pracovna/pracovna1.jpg",
					Plosne_materialy = new List<Plosny_material>()
					{
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count)),
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count))
					},
					UdajeProduktu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}

				},
				new Produkt()
				{
					Typ = TypProduktu.Pracovna,
					Opis = "Parádna pracovna 2",
					Obrazok = "/images/Pracovna/pracovna2.jpg",
					Plosne_materialy = new List<Plosny_material>()
					{
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count)),
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count))
					},
					UdajeProduktu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}

				},
				new Produkt()
				{
					Typ = TypProduktu.Pracovna,
					Opis = "Parádna pracovna 3",
					Obrazok = "/images/Pracovna/pracovna3.jpg",
					Plosne_materialy = new List<Plosny_material>()
					{
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count)),
						plosneMaterialy.ElementAt(randMat.Next(0, plosneMaterialy.Count))
					},
					UdajeProduktu = new Udaje()
					{
						CasVytvorenia = DateTime.Now,
						CasPoslednejZmeny = DateTime.Now
					}

				}
			};


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

