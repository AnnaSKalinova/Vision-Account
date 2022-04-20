namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Models.Routes;
    using AccountingProgram.Services.Routes;
    using AccountingProgram.Services.Routes.Models;

    using static WebConstants;

    public class RoutesController : Controller
    {
        private readonly IRouteService routes;

        public RoutesController(IRouteService routes)
        {
            this.routes = routes;
        }

        public IActionResult All(
            [FromQuery] char code,
            [FromQuery] RouteSorting sorting,
            [FromQuery] int currentPage = 1,
            [FromQuery] int routesPerPage = SearchRoutesQueryModel.RoutesPerPage)
        {
            var queryResult = this.routes.All(
                code,
                sorting,
                currentPage,
                routesPerPage);

            var routesCodes = this.routes.AllRoutesCodes();

            SearchRoutesQueryModel query = new SearchRoutesQueryModel
            {
                Code = code,
                Sorting = sorting,
                CurrentPage = currentPage
            };

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

            TempData[GlobalMessageKey] = "You successfully added a new route!";

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id, string information)
        {
            var route = this.routes.Details(id);

            if (route == null)
            {
                return NotFound();
            }

            if (!information.Contains(route.Code))
            {
                return BadRequest();
            }

            return View(route);
        }
    }
}