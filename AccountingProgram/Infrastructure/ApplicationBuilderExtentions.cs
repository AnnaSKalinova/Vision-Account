namespace AccountingProgram.Infrastructure
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;

    using static AccountingProgram.Areas.ChefAccountant.ChefAccountantConstants;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app) 
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedItemCategories(services);
            SeedChefAccountant(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<AccountingDbContext>();

            data.Database.Migrate();
        }

        private static void SeedItemCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<AccountingDbContext>();

            if (data.ItemCategories.Any())
            {
                return;
            }

            data.ItemCategories.AddRange(new[]
            {
                new ItemCategory { Name = "Sandwiches", Items = new List<Item>() },
                new ItemCategory { Name = "Wraps", Items = new List<Item>() },
                new ItemCategory { Name = "Salads", Items = new List<Item>() },
                new ItemCategory { Name = "Ready Meals", Items = new List<Item>() },
                new ItemCategory { Name = "Soups", Items = new List<Item>() },
                new ItemCategory { Name = "Desserts", Items = new List<Item>() },
                new ItemCategory { Name = "Services", Items = new List<Item>() },
            });

            data.SaveChanges();
        }

        private static void SeedChefAccountant(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.
                Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(ChefAccountantRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = ChefAccountantRoleName };

                    await roleManager.CreateAsync(role);

                    const string ChefAccountantEmail = "admin@visionaccount.com";
                    const string ChefAccountantPassword = "admin12";

                    var user = new User
                    {
                        Email = ChefAccountantEmail,
                        UserName = ChefAccountantEmail,
                        FullName = ChefAccountantRoleName
                    };

                    await userManager.CreateAsync(user, ChefAccountantPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
