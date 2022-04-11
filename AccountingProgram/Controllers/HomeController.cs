namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Data;
    using AccountingProgram.Models.Home;
    using AccountingProgram.Services.Statistics;
    using AccountingProgram.Services.Drivers;

    public class HomeController : Controller
    {
        private readonly AccountingDbContext data;
        private readonly IStatisticsService statistics;

        public HomeController(AccountingDbContext data, IStatisticsService statistics)
        {
            this.data = data;
            this.statistics = statistics;
        }

        public IActionResult Index()
        {
            var drivers = this.data
                .Drivers
                .OrderByDescending(d => d.Id)
                .Select(d => new DriverServiceModel
                {
                    Name = d.Name,
                    Route = d.Route.Code
                })
                .Take(3)
                .ToList();

            var totalStatistics = this.statistics.Total();

            return View(new IndexViewModel
            {
                TotalCustomers = totalStatistics.TotalCustomers,
                TotalDrivers = totalStatistics.TotalDrivers,
                TotalItems = totalStatistics.TotalItems,
                TotalSalesInvoices = totalStatistics.TotalSalesInvoices
            });
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
