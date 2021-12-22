namespace PanonicaV1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PanonicaV1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PanonicaV1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PanonicaV1.Models.ApplicationDbContext context)
        {

            context.Seasons.AddOrUpdate(x => x.Id, 
            new Season() { Id=1, Name= "Summer", Duration= 3},
            new Season() { Id = 2, Name = "Winter", Duration = 3 },
            new Season() { Id = 3, Name = "Autumn", Duration = 3 },
            new Season() { Id = 4, Name = "Spring", Duration = 3 },
            new Season() { Id = 5, Name = "All-season", Duration = 12 }
            );

            context.Packages.AddOrUpdate(x => x.Id,
            new Packaging() { Id = 1, Name = "Aurora", Material = "Glass", Price = 35, Volume = 750},
            new Packaging() { Id = 2, Name = "Sfinga", Material = "Glass", Price = 22, Volume = 350 },
            new Packaging() { Id = 3, Name = "Antika", Material = "Glass", Price = 43, Volume = 250 },
            new Packaging() { Id = 4, Name = "Africa", Material = "Plastic", Price = 50, Volume = 1000}
            );


            context.Products.AddOrUpdate(x => x.Id,
            new Product() { Id = 1, Name = "Paradajz sok - Mild", ProductionDate = new DateTime(2020,2,9), Price = 210,Quantity = 50, PackagingId = 1, SeasonId = 2},
            new Product() { Id = 2, Name = "Sos Paradajz - Ruzmarin",ProductionDate =  new DateTime(2020, 2, 9), Price = 350, Quantity = 45, PackagingId = 2, SeasonId = 5 },
            new Product() { Id = 3, Name = "Sos Paradajz - Persun", ProductionDate = new DateTime(2020, 2, 9), Price = 350, Quantity = 55, PackagingId = 2, SeasonId = 5 },
            new Product() { Id = 4, Name = "Potaz Bundeva", ProductionDate = new DateTime(2020, 2, 9), Price = 270, Quantity = 60, PackagingId = 1, SeasonId = 3 },
            new Product() { Id = 5, Name = "Potaz Grasak", ProductionDate = new DateTime(2020, 2, 9), Price = 270, Quantity = 30, PackagingId = 1, SeasonId = 1 }
            );

            context.ClientCompanies.AddOrUpdate(x => x.Id,
            new ClientCompany() { Id = 1, Name = "Moja Pijaca", PIB = 29957746 },
            new ClientCompany() { Id = 2, Name = "Mercator", PIB = 29967746 },
            new ClientCompany() { Id = 3, Name = "Samo Domace", PIB = 28857746 }
            );



        }
    }
}
