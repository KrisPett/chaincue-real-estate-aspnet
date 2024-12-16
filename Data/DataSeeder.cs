using chaincue_real_estate_aspnet.Models;
using System;

namespace chaincue_real_estate_aspnet.Data
{
    public class DataSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Add Brokers
            //var broker = new Broker { Name = "Default Broker" };
            //context.Brokers.Add(broker);

            // Add Countries
            var countries = new List<Country>
        {
            new Country { Name = "Sweden" },
            new Country { Name = "Spain" }
        };
            context.Countries.AddRange(countries);

            // Add Houses
            var houses = new List<House>();
            for (int i = 1; i <= 18; i++)
            {
                var house = new House
                {
                    HouseTypes = "Villa",
                    Location = "Spain, Málaga",
                    NumberRooms = 3,
                    Beds = 2,
                    Price = "$969,384",
                    Src = ""
                };

                // Add Images for Each House
                //for (int j = 1; j <= 7; j++)
                //{
                //    house.Images.Add(new HouseImage
                //    {
                //        ImageUrl = $"https://example.com/house{i}/image{j}.jpg"
                //    });
                //}

                houses.Add(house);
            }
            context.Houses.AddRange(houses);

            context.SaveChanges();
        }
    }
}
