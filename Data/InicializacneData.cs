using Microsoft.AspNetCore.Identity;
using System;
using System.Diagnostics;
using System.Net;
using VAII_Semestralka.Models;

namespace VAII_Semestralka.Data
{
    public class InicializacneData
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Produkty.Any())
                {
                    context.Produkty.AddRange(new List<Produkt>()
                    {
                        new Produkt()
                        {
                            Typ = "Kuchyna",
                            Opis = "Parádna kuchyna 1",
                            Obrazok = "/images/kuchyne/kuchyna.jpg",
                            MaterialID = 1.ToString(),

                         },
                        new Produkt()
                        {
                            Typ = "Kuchyna",
                            Opis = "Parádna kuchyna 2",
                            Obrazok = "/images/kuchyne/kuchyna2.jpg",
                            MaterialID = 3.ToString(),

                        },
                        new Produkt()
                        {
                            Typ = "Kuchyna",
                            Opis = "Parádna kuchyna 1",
                            Obrazok = "/images/kuchyne/kuchyna3.jpg",
                            MaterialID = 2.ToString(),

                        },
                        new Produkt()
                        {
                            Typ = "Kuchyna",
                            Opis = "Parádna kuchyna 2",
                            Obrazok = "/images/kuchyne/kuchyna4.jpg",
                            MaterialID = 4.ToString(),

                        },
                        new Produkt()
                        {
                            Typ = "Obyvacia_izba",
                            Opis = "Parádna Obyvacia izba  1",
                            Obrazok = "/images/obyvacie_izby/obyvacia_izba1.jpg",
                            MaterialID = 5.ToString(),

                        },
                        new Produkt()
                        {
                            Typ = "Obyvacia_izba",
                            Opis = "Parádna Obyvacia izba 2",
                            Obrazok = "/images/obyvacie_izby/obyvacia_izba2.jpg",
                            MaterialID = 2.ToString(),

                        },
                        new Produkt()
                        {
                            Typ = "Obyvacia_izba",
                            Opis = "Parádna Obyvacia izba 3",
                            Obrazok = "/images/obyvacie_izby/obyvacia_izba3.jpg",
                            MaterialID = 3.ToString(),

                        },
                        new Produkt()
                        {
                            Typ = "Obyvacia_izba",
                            Opis = "Parádna Obyvacia izba 4",
                            Obrazok = "/images/obyvacie_izby/obyvacia_izba4.jpg",
                            MaterialID = 1.ToString(),

                        },
                        new Produkt()
                        {
                            Typ = "Pracovna",
                            Opis = "Parádna pracovna 1",
                            Obrazok = "/images/pracovne/pracovna1.jpg",
                            MaterialID = 2.ToString(),

                        },
                        new Produkt()
                        {
                            Typ = "Pracovna",
                            Opis = "Parádna pracovna 2",
                            Obrazok = "/images/pracovne/pracovna2.jpg",
                            MaterialID = 3.ToString(),

                        },
                        new Produkt()
                        {
                            Typ = "Pracovna",
                            Opis = "Parádna pracovna 3",
                            Obrazok = "/images/pracovne/pracovna3.jpg",
                            MaterialID = 1.ToString(),

                        },

                    });
                    context.SaveChanges();
                }
                //Races
                if (!context.Materialy.Any())
                {
                    context.Materialy.AddRange(new List<Plosny_material>()
                    {
                        new Plosny_material()
                        {
                            Typ = "UNI Farby",
                            Obrazok = "/images/materialy/mat1.jpg",
                        },
                        new Plosny_material()
                        {
                            Typ = "UNI Farby",
                            Obrazok = "/images/materialy/mat2.jpg",
                        },
                        new Plosny_material()
                        {
                            Typ = "UNI Farby",
                            Obrazok = "/images/materialy/mat3.jpg",
                        },
                        new Plosny_material()
                        {
                            Typ = "UNI Farby",
                            Obrazok = "/images/materialy/mat4.jpg",
                        },
                        new Plosny_material()
                        {
                            Typ = "UNI Farby",
                            Obrazok = "/images/materialy/mat5.jpg",
                        },
                        new Plosny_material()
                        {
                            Typ = "UNI Farby",
                            Obrazok = "/images/materialy/mat6.jpg",
                        },

                    });
                    context.SaveChanges();
                }
            }
        }

    }
}

