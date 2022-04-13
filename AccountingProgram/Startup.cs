namespace AccountingProgram
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Data;
    using AccountingProgram.Infrastructure;
    using AccountingProgram.Services.Statistics;
    using AccountingProgram.Services.SalesInvoices;
    using AccountingProgram.Services.Customers;
    using AccountingProgram.Services.Items;
    using AccountingProgram.Services.Drivers;
    using AccountingProgram.Services.Routes;
    using AccountingProgram.Services.Accountants;
    using AccountingProgram.Data.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AccountingDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AccountingDbContext>();

            services.AddAutoMapper(typeof(Startup));

            services.AddMemoryCache();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            services.AddTransient<IStatisticsService, StatisticsService>();
            services.AddTransient<ISalesInvoiceService, SalesInvoiceService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IDriverService, DriverService>();
            services.AddTransient<IRouteService, RouteService>();
            services.AddTransient<IAccountantService, AccountantService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection()
               .UseStaticFiles()
               .UseRouting()
               .UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapControllerRoute(
                       name: "Areas",
                       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                   endpoints.MapControllerRoute(
                       name: "Customer Details",
                       pattern: "Customers/Details/{id}/{information}",
                       defaults: new { controller = "Customers", action = "Details" });
                   endpoints.MapControllerRoute(
                       name: "Driver Details",
                       pattern: "Drivers/Details/{id}/{information}",
                       defaults: new { controller = "Drivers", action = "Details" });
                   endpoints.MapControllerRoute(
                       name: "Item Details",
                       pattern: "Items/Details/{id}/{information}",
                       defaults: new { controller = "Items", action = "Details" });
                   endpoints.MapControllerRoute(
                       name: "Route Details",
                       pattern: "Routes/Details/{id}/{information}",
                       defaults: new { controller = "Routes", action = "Details" });
                   endpoints.MapControllerRoute(
                       name: "Sales Invoice Details",
                       pattern: "SalesInvoices/Details/{id}/{information}",
                       defaults: new { controller = "SalesInvoices", action = "Details" });
                   endpoints.MapDefaultControllerRoute();
                   endpoints.MapRazorPages();
               });
        }
    }
}
