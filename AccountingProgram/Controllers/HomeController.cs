namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Data;
    using AccountingProgram.Models.Drivers;
    using AccountingProgram.Models.Home;

    public class HomeController : Controller
    {
        private readonly AccountingDbContext data;

        public HomeController(AccountingDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var totalDrivers = this.data.Drivers.Count();
            var totalSalesInvoices = this.data.SalesInvoices.Count();
            var totalItems = this.data.Items.Count();
            var totaCustomers = this.data.Customers.Count();

            var drivers = this.data
                .Drivers
                .OrderByDescending(d => d.Id)
                .Select(d => new DriverListingViewModel
                {
                    Name = d.Name,
                    Route = d.Route.Code
                })
                .Take(3)
                .ToList();

            return View(new IndexViewModel
            {
                TotalCustomers = totaCustomers,
                TotalDrivers = totalDrivers,
                TotalItems = totalItems,
                TotalSalesInvoices = totalSalesInvoices
            });

            
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
