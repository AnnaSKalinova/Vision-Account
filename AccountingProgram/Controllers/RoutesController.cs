namespace AccountingProgram.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

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

        public IActionResult All([FromQuery] SearchRoutesQueryModel query)
        {
            var routesQuery = this.data.Routes.AsQueryable();

            var totalRoutes = routesQuery.Count();

            var routes = routesQuery
                .Skip((query.CurrentPage - 1) * SearchRoutesQueryModel.RoutesPerPage)
                .Take(SearchRoutesQueryModel.RoutesPerPage)
                .OrderBy(r => r.Code)
                .Select(r => new RouteListingViewModel
                {
                    Code = r.Code,
                    Customers = r.Customers.Count
                })
                .ToList();

            query.TotalRoutes = totalRoutes;
            query.Routes = routes;

            return View(query);
        }

        [HttpPost]
        [Authorize]
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