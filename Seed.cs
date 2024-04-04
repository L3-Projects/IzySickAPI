using izySick.Models;
using IzySickAPI.Data;
using System.Diagnostics.Metrics;
using System.Text;

namespace IzySickAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Docteurss.Any() || !dataContext.Patientss.Any() || !dataContext.Receptionnistess.Any() || !dataContext.Medicamentss.Any() || !dataContext.MedicamentVenduss.Any())
            {
                var random = new Random();


                  

                var patient = new Patient
                {
                    Nom = "RASOA",
                    Prenom = "fitia",
                    Age = random.Next(18, 80),
                    Sexe = 0, // Alterner entre 0 (masculin) et 1 (féminin)
                    Adresse = "rreagrg34cef",
                    Maladie = "AVC", 
                    Telephone = "0345675656", 
                    Email = "rasoa@gmail.com",
                    Batiment = "A",
                    Etage = 2,
                    Chambre = 12,
                    DateHosp = new DateTime(2023,11,04), 
                    Image = Encoding.UTF8.GetBytes("ImageRasoafitia"), 
                    

                    // Initialisez les autres propriétés du patient avec des valeurs spécifiques
                };

                    dataContext.Patientss.Add(patient);
                var docteur1 = new Docteur
                {
                    Specialisation = "Pediatre",
                    Image = Encoding.UTF8.GetBytes("ImageRAKOTOFitiavana"),
                    Nom = "RAKOTO",
                    Prenom = "Fitiavana",
                    Sexe = 1,
                    Age = random.Next(18, 80),
                    Email = "rakotofitia@gmail.com",
                    Telephone = "0321212331",
                    Mdp = "doc1",
                    Poste = "docteur",
                    Patients = new List<Patient> { patient },


                    // Initialisez les autres propriétés du docteur avec des valeurs spécifiques
                };

                dataContext.Docteurss.Add(docteur1);

                var receptionniste = new Receptionniste { 
                        Nom = "RABE", 
                        Age = random.Next(18, 50), 
                        Prenom = " Niriana", Mdp = "weq12", 
                        Image = Encoding.UTF8.GetBytes("ImageRabeNiriana"), 
                        Email="niriana@gmail.com", Sexe=0,
                        Telephone = "0345612322", 
                        Poste = "receptionniste"
                    };
                    dataContext.Receptionnistess.Add(receptionniste);
                // Ajoutez d'autres entités ou adaptez-les en conséquence

              
                var medicament = new Medicaments
                {
                    NomMedicament = "Paracetamol",
                    Type = "x",
                    Description = "A prendre chaque repas ",
                    Prix = 600,
                    NbEnStock = 50, 
                };
                dataContext.Medicamentss.Add(medicament);

                var medVendu = new MedicamentVendu
                {
                    QuantiteVendu = 12,
                };
                dataContext.MedicamentVenduss.Add(medVendu);

                var medicament2 = new Medicaments
                {
                    NomMedicament = "Charbon",
                    Type = "y",
                    Description = "A prendre chaque repas ",
                    Prix = 1000,
                    NbEnStock = 150, MedVendu  = new List<MedicamentVendu> { medVendu },

                };
                dataContext.Medicamentss.Add(medicament2);

                

                    dataContext.SaveChanges();
            }
        }
    }
    //public class Seed
    //{
    //    private readonly DataContext dataContext;
    //    public Seed(DataContext context)
    //    {
    //        this.dataContext = context;
    //    }
    //    public void SeedDataContext()
    //    {
    //        if (!dataContext.PokemonOwners.Any())
    //        {
    //            var pokemonOwners = new List<PokemonOwner>()
    //            {
    //                new PokemonOwner()
    //                {
    //                    Pokemon = new Pokemon()
    //                    {
    //                        Name = "Pikachu",
    //                        BirthDate = new DateTime(1903,1,1),
    //                        PokemonCategories = new List<PokemonCategory>()
    //                        {
    //                            new PokemonCategory { Category = new Category() { Name = "Electric"}}
    //                        },
    //                        Reviews = new List<Review>()
    //                        {
    //                            new Review { Title="Pikachu",Text = "Pickahu is the best pokemon, because it is electric", Rating = 5,
    //                            Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
    //                            new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
    //                            Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
    //                            new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
    //                            Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
    //                        }
    //                    },
    //                    Owner = new Owner()
    //                    {
    //                        FirstName = "Jack",
    //                        LastName = "London",
    //                        Gym = "Brocks Gym",
    //                        Country = new Country()
    //                        {
    //                            Name = "Kanto"
    //                        }
    //                    }
    //                },
    //                new PokemonOwner()
    //                {
    //                    Pokemon = new Pokemon()
    //                    {
    //                        Name = "Squirtle",
    //                        BirthDate = new DateTime(1903,1,1),
    //                        PokemonCategories = new List<PokemonCategory>()
    //                        {
    //                            new PokemonCategory { Category = new Category() { Name = "Water"}}
    //                        },
    //                        Reviews = new List<Review>()
    //                        {
    //                            new Review { Title= "Squirtle", Text = "squirtle is the best pokemon, because it is electric", Rating = 5,
    //                            Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
    //                            new Review { Title= "Squirtle",Text = "Squirtle is the best a killing rocks", Rating = 5,
    //                            Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
    //                            new Review { Title= "Squirtle", Text = "squirtle, squirtle, squirtle", Rating = 1,
    //                            Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
    //                        }
    //                    },
    //                    Owner = new Owner()
    //                    {
    //                        FirstName = "Harry",
    //                        LastName = "Potter",
    //                        Gym = "Mistys Gym",
    //                        Country = new Country()
    //                        {
    //                            Name = "Saffron City"
    //                        }
    //                    }
    //                },
    //                                new PokemonOwner()
    //                {
    //                    Pokemon = new Pokemon()
    //                    {
    //                        Name = "Venasuar",
    //                        BirthDate = new DateTime(1903,1,1),
    //                        PokemonCategories = new List<PokemonCategory>()
    //                        {
    //                            new PokemonCategory { Category = new Category() { Name = "Leaf"}}
    //                        },
    //                        Reviews = new List<Review>()
    //                        {
    //                            new Review { Title="Veasaur",Text = "Venasuar is the best pokemon, because it is electric", Rating = 5,
    //                            Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
    //                            new Review { Title="Veasaur",Text = "Venasuar is the best a killing rocks", Rating = 5,
    //                            Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
    //                            new Review { Title="Veasaur",Text = "Venasuar, Venasuar, Venasuar", Rating = 1,
    //                            Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
    //                        }
    //                    },
    //                    Owner = new Owner()
    //                    {
    //                        FirstName = "Ash",
    //                        LastName = "Ketchum",
    //                        Gym = "Ashs Gym",
    //                        Country = new Country()
    //                        {
    //                            Name = "Millet Town"
    //                        }
    //                    }
    //                }
    //            };
    //            dataContext.PokemonOwners.AddRange(pokemonOwners);
    //            dataContext.SaveChanges();
    //        }
    //    }
    //}
}
﻿

