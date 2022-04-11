namespace AccountingProgram.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Models.Routes;
    using System.Linq;

    public class RoutesController : Controller
    {
        private readonly AccountingDbContext data;

        public RoutesController(AccountingDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddRouteFormModel route)
        {
            if (!ModelState.IsValid)
            {
                return View(route);
            }

            var routeData = new Route
            {
                Code = route.Code,
                Description = route.Description,
                Customers = new List<Customer>()
            };

            this.data.Routes.Add(routeData);

            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}