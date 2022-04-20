namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Models.Drivers;
    using AccountingProgram.Services.Drivers;
    using AccountingProgram.Services.Routes;
    using AccountingProgram.Services.Drivers.Models;

    using static WebConstants;

    public class DriversController : Controller
    {
        private readonly IDriverService drivers;
        private readonly IRouteService routes;

        public DriversController(IDriverService drivers, IRouteService routes)
        {
            this.drivers = drivers;
            this.routes = routes;
        }

        public IActionResult All(
            [FromQuery] char route,
            [FromQuery] string searchTerm,
            [FromQuery] DriverSorting sorting,
            [FromQuery] int currentPage = 1,
            [FromQuery] int driversPerPage = SearchDriversQueryModel.DriversPerPage) 
        {
            var queryResult = this.drivers.All(
                route,
                searchTerm,
                sorting,
                currentPage,
                driversPerPage);

            var driverRoutes = this.drivers.AllDriversRoutes();

            SearchDriversQueryModel query = new SearchDriversQueryModel
            {
                Route = route,
                SearchTerm = searchTerm,
                Sorting = sorting,
                CurrentPage = currentPage
            };

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
                Routes = this.routes.AllRoutes()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddDriverFormModel driver)
        {
            if (!this.routes.RouteExists(driver.RouteId))
            {
                this.ModelState.AddModelError(nameof(driver.RouteId), "Route does not exist!");
            }

            if (!ModelState.IsValid)
            {
                driver.Routes = this.routes.AllRoutes();

                return View(driver);
            }

            this.drivers.Create(
                driver.Name,
                driver.RouteId);

            TempData[GlobalMessageKey] = "You successfully added a new driver!";

            return RedirectToAction(nameof(All));
        }
    }
}