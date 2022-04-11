namespace AccountingProgram.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Models.Routes;
    using AccountingProgram.Services.Routes;
    
    public class RoutesController : Controller
    {
        private readonly IRouteService routes;
        private readonly AccountingDbContext data;

        public RoutesController(AccountingDbContext data, IRouteService routes)
        {
            this.data = data;
            this.routes = routes;
        }

        public IActionResult All([FromQuery] SearchRoutesQueryModel query)
        {
            var queryResult = this.routes.All(
                query.Code,
                query.Sorting,
                query.CurrentPage,
                SearchRoutesQueryModel.RoutesPerPage);

            var routesCodes = this.routes.AllRoutesCodes();

            query.TotalRoutes = queryResult.TotalRoutes;
            query.Codes = routesCodes;
            query.Routes = queryResult.Routes.Select(r => new RouteServiceModel
            {
                Id = r.Id,
                Code = r.Code,
                Customers = r.Customers
            });

            return View(query);
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
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

            return RedirectToAction("All", "Routes");
        }

        private IEnumerable<RouteCodeViewModel> GetRoutes()
        {
            return this.data
                .Routes
                .Select(r => new RouteCodeViewModel
                {
                    Id = r.Id,
                    Code = r.Code
                })
                .ToList();
        }
    }
}