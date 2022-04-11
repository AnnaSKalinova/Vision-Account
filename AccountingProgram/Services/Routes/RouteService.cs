namespace AccountingProgram.Services.Routes
{
    using System.Collections.Generic;
    using System.Linq;

    using AccountingProgram.Data;
    using AccountingProgram.Models.Routes;

    public class RouteService : IRouteService
    {
        private readonly AccountingDbContext data;

        public RouteService(AccountingDbContext data)
        {
            this.data = data;
        }

        public RouteQueryServiceModel All(char code, RouteSorting sorting, int currentPage, int routesPerPage)
        {
            var routesQuery = this.data.Routes.AsQueryable();

            if (code != '\0')
            {
                routesQuery = routesQuery.Where(r =>
                    r.Code == code);
            }

            routesQuery = sorting switch
            {
                RouteSorting.Code => routesQuery.OrderBy(r => r.Code),
                RouteSorting.Customers => routesQuery.OrderBy(r => r.Customers.Count()),
                _ => routesQuery.OrderBy(r => r.Code)
            };

            var totalRoutes = routesQuery.Count();

            var routes = routesQuery
                .Skip((currentPage - 1) * routesPerPage)
                .Take(routesPerPage)
                .OrderBy(r => r.Code)
                .Select(r => new RouteServiceModel
                {
                    Code = r.Code,
                    Customers = r.Customers.Count
                })
                .ToList();

            return new RouteQueryServiceModel
            {
                CurrentPage = currentPage,
                TotalRoutes = totalRoutes,
                Routes = routes,
                RoutesPerPage = routesPerPage
            };
        }

        public IEnumerable<char> AllRoutesCodes()
        {
            return this.data
                .Routes
                .Select(r => r.Code)
                .OrderBy(r => r)
                .Distinct()
                .ToList();
        }
    }
}
