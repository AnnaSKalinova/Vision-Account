namespace AccountingProgram.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Data;
    using AccountingProgram.Models.Drivers;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Services.Drivers;

    public class DriversController : Controller
    {
        private readonly IDriverService drivers;
        private readonly AccountingDbContext data;

        public DriversController(AccountingDbContext data, IDriverService drivers)
        {
            this.data = data;
            this.drivers = drivers;
        }

        public IActionResult All([FromQuery]SearchDriversQueryModel query) 
        {
            var queryResult = this.drivers.All(
                query.Route,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                SearchDriversQueryModel.DriversPerPage);

            var driverRoutes = this.drivers.AllDriversRoutes();

            query.TotalDrivers = queryResult.TotalDrivers;
            query.Routes = driverRoutes;
            query.Drivers = queryResult.Drivers.Select(d => new DriverServiceModel
            {
                Id = d.Id,
                Name = d.Name,
                RouteCode = d.RouteCode
            });

            return View(query);
        }

        [Authorize]
        public IActionResult Add()
        {
            return View(new AddDriverFormModel
            {
                Routes = GetRoutes()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddDriverFormModel driver)
        {
            if (!this.data.Routes.Any(r => r.Id == driver.RouteId))
            {
                this.ModelState.AddModelError(nameof(driver.RouteId), "Route does not exist!");
            }

            if (!ModelState.IsValid)
            {
                driver.Routes = this.GetRoutes();

                return View(driver);
            }

            var driverData = new Driver
            {
                Name = driver.Name,
                RouteId = driver.RouteId
            };

            this.data.Drivers.Add(driverData);

            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private IEnumerable<RouteDriverViewModel> GetRoutes()
        {
            return this.data
                .Routes
                .Select(r => new RouteDriverViewModel
                {
                    Id = r.Id,
                    Code = r.Code
                })
                .ToList();
        }
    }
}