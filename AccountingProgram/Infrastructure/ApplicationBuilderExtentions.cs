namespace AccountingProgram.Infrastructure
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;

    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    
    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app) 
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<AccountingDbContext>();

            data.Database.Migrate();

            SeedItemCategories(data);
            //SeedRoutes(data);
            //SeedDrivers(data);

            return app;
        }

        private static void SeedItemCategories(AccountingDbContext data)
        {
            if (data.ItemCategories.Any())
            {
                return;
            }

            data.ItemCategories.AddRange(new[]
            {
                new ItemCategory { Name = "Sandwiches", Items = new List<Item>() },
                new ItemCategory { Name = "Wraps", Items = new List<Item>() },
                new ItemCategory { Name = "Salads", Items = new List<Item>() },
                new ItemCategory { Name = "ReadyMeals", Items = new List<Item>() },
                new ItemCategory { Name = "Soups", Items = new List<Item>() },
                new ItemCategory { Name = "Desserts", Items = new List<Item>() },
            });

            data.SaveChanges();
        }


        /*private static void SeedRoutes(AccountingDbContext data)
        {
            if (data.Routes.Any())
            {
                return;
            }

            data.Routes.AddRange(new[]
            {
                new Route { Code = 'A', Description = "Airport and Pick up", DriverId = 1 },
                new Route { Code = 'B', Description = "Downtown", DriverId = 2 },
                new Route { Code = 'C', Description = "Kringlan", DriverId = 3 },
                new Route { Code = 'D', Description = "Breidholt", DriverId = 4 },
                new Route { Code = 'E', Description = "Keflavik", DriverId = 5 },
                new Route { Code = 'F', Description = "Countryside East", DriverId = 6 },
                new Route { Code = 'L', Description = "Countryside North", DriverId = 7 },
                new Route { Code = 'M', Description = "Countryside Sounth", DriverId = 8 },
                new Route { Code = 'R', Description = "Hafnarfjordur", DriverId = 9 },
            });

            data.SaveChanges();
        }

        private static void SeedDrivers(AccountingDbContext data)
        {
            if (data.Drivers.Any())
            {
                return;
            }

            data.Drivers.AddRange(new[]
            {
                new Driver { Name = "Georgi Georgiev", RouteId = 1 },
                new Driver { Name = "Petur Petrov", RouteId = 2 },
                new Driver { Name = "Stamat Stamatov", RouteId = 3 },
                new Driver { Name = "Asen Asenov", RouteId = 4 },
                new Driver { Name = "Dimitur Dimitrov", RouteId = 5 },
                new Driver { Name = "Ivan Ivanov", RouteId = 6 },
                new Driver { Name = "Kiril Kirilov", RouteId = 7 },
                new Driver { Name = "Todor Todorov", RouteId = 8 },
                new Driver { Name = "Vasil Vasilev", RouteId = 9 },
            });

            data.SaveChanges();
        }*/
    }
}
