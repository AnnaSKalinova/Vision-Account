namespace AccountingProgram.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using AccountingProgram.Services.Statistics;

    using static WebConstants.Cache;

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
            const string totalStatisticsCacheKey = TotalStatisticsCacheKey;

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
