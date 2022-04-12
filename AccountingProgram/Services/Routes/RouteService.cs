namespace AccountingProgram.Services.Routes
{
    using System.Collections.Generic;
    using System.Linq;

    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Models.Routes;
    using AccountingProgram.Services.Routes.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class RouteService : IRouteService
    {
        private readonly AccountingDbContext data;
        private readonly IConfigurationProvider mapper;

        public RouteService(AccountingDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
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
                .ProjectTo<RouteServiceModel>(this.mapper)
                .ToList();

            return new RouteQueryServiceModel
            {
                CurrentPage = currentPage,
                TotalRoutes = totalRoutes,
                Routes = routes,
                RoutesPerPage = routesPerPage
            };
        }

        public IEnumerable<RouteServiceModel> AllRoutes()
        {
            return this.data
                .Routes
                .ProjectTo<RouteServiceModel>(this.mapper)
                .ToList();
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

        public int Create(char code, string description)
        {
            var routeData = new Route
            {
                Code = code,
                Description = description,
                Customers = new List<Customer>()
            };

            this.data.Routes.Add(routeData);

            this.data.SaveChanges();

            return routeData.Id;
        }

        public bool RouteExists(int id)
        {
            return !this.data.Routes.Any(r => r.Id == id);
        }
    }
}
