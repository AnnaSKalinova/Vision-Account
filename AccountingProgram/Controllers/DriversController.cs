namespace AccountingProgram.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Data;
    using AccountingProgram.Models.Drivers;
    using AccountingProgram.Data.Models;
    
    public class DriversController : Controller
    {
        private readonly AccountingDbContext data;

        public DriversController(AccountingDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            return View(new AddDriverFormModel
            {
                Routes = GetRoutes()
            });
        }

        public IActionResult All([FromQuery]SearchDriversQueryModel query) 
        {
            var driverQuery = this.data.Drivers.AsQueryable();

            if (query.Route != '\0')
            {
                driverQuery = driverQuery.Where(d =>
                    d.Route.Code == query.Route);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                driverQuery = driverQuery.Where(d =>
                    d.Name.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            driverQuery = query.Sorting switch
            {
                DriverSorting.Name => driverQuery.OrderBy(d => d.Name),
                DriverSorting.Route => driverQuery.OrderBy(d => d.Route.Code),
                _ => driverQuery.OrderBy(d => d.Id)
            };

            var totalDrivers = driverQuery.Count();

            var drivers = driverQuery
                .Skip((query.CurrentPage - 1) * SearchDriversQueryModel.DriversPerPage)
                .Take(SearchDriversQueryModel.DriversPerPage)
                .Select(d => new DriverListingViewModel
                {
                    Name = d.Name,
                    Route = d.Route.Code
                })
                .ToList();

            var driverRoutes = this.data
                .Drivers
                .Select(d => d.Route.Code)
                .OrderBy(d => d)
                .Distinct()
                .ToList();

            query.TotalDrivers = totalDrivers;
            query.Routes = driverRoutes;
            query.Drivers = drivers;

            return View(query);
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