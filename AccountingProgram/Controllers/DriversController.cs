namespace AccountingProgram.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
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

            return RedirectToAction("Index", "Home");
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