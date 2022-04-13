namespace AccountingProgram.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using AccountingProgram.Models.Home;
    using AccountingProgram.Services.Statistics;
    

    public class HomeController : Controller
    {
        private readonly IStatisticsService statistics;
        private readonly IMemoryCache cache;

        public HomeController(IStatisticsService statistics, IMemoryCache cache)
        {
            this.statistics = statistics;
            this.cache = cache;
        }

        public IActionResult Index()
        {
            /*var drivers = this.data
                .Drivers
                .OrderByDescending(d => d.Id)
                .ProjectTo<DriverServiceModel>(this.mapper)
                .Take(3)
                .ToList();*/

            const string totalStatisticsCacheKey = "TotalStatisticsCacheKey";

            var totalStatistics = this.cache.Get<StatisticsServiceModel>(totalStatisticsCacheKey);

            if (totalStatistics == null)
            {
                totalStatistics = this.statistics.Total();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                this.cache.Set(totalStatisticsCacheKey, totalStatistics, cacheOptions);
            }

            return View(totalStatistics);
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
