namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Models.Home;
    using AccountingProgram.Services.Statistics;
    using AccountingProgram.Services.Drivers;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;
        private readonly IConfigurationProvider mapper;

        public HomeController(IStatisticsService statistics, IMapper mapper)
        {
            this.statistics = statistics;
            this.mapper = mapper.ConfigurationProvider;
        }

        public IActionResult Index()
        {
            /*var drivers = this.data
                .Drivers
                .OrderByDescending(d => d.Id)
                .ProjectTo<DriverServiceModel>(this.mapper)
                .Take(3)
                .ToList();*/

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
