namespace AccountingProgram.Services.Routes
{
    using System.Collections.Generic;

    using AccountingProgram.Models.Routes;
    using AccountingProgram.Services.Routes.Models;

    public interface IRouteService
    {
        RouteQueryServiceModel All(
            char code, 
            RouteSorting sorting,
            int currentPage = 1,
            int routesPerPage = SearchRoutesQueryModel.RoutesPerPage);

        int Create(
            char code,
            string description);

        RouteDetailsServiceModel Details(int id);

        IEnumerable<char> AllRoutesCodes();

        IEnumerable<RouteServiceModel> AllRoutes();

        bool RouteExists(int id);

        bool RouteCodeExists(char code);
    }
}
