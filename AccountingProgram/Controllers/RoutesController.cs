namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Data;
    using AccountingProgram.Models.Routes;
    using AccountingProgram.Services.Routes;
    using AccountingProgram.Services.Routes.Models;

    public class RoutesController : Controller
    {
        private readonly IRouteService routes;

        public RoutesController(IRouteService routes)
        {
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

            this.routes.Create(
                route.Code,
                route.Description);

            return RedirectToAction(nameof(All));
        }
    }
}