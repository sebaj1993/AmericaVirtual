using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace WebChallenge.Models
{
    public class ChallengeDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(WebChallenge.Models.ApplicationDbContext context)
        {
            Country argentina = new Country()
            {
                Id = 1,
                Name = "Argentina"
            };

            Country brasil = new Country()
            {
                Id = 2,
                Name = "Brasil"
            };

            context.Countries.AddOrUpdate(x => x.Id, argentina, brasil);

            City laPlata = new City()
            {
                Id = 1,
                Name = "La Plata",
                CountryId = 1,
                CityIdApi = 3432043
            };

            City caba = new City()
            {
                Id = 2,
                Name = "Ciudad Autonoma de Buenos Aires",
                CountryId = 1,
                CityIdApi = 3433955
            };

            City rioDeJaneiro = new City()
            {
                Id = 3,
                Name = "Rio de Janeiro",
                CountryId = 2,
                CityIdApi = 3451189
            };

            context.Cities.AddOrUpdate(x => x.Id, laPlata, caba, rioDeJaneiro);

            base.Seed(context);
        }
    }
}