namespace AccountingProgram.Services.Routes
{
    using System.Collections.Generic;

    using AccountingProgram.Models.Routes;
    using AccountingProgram.Services.Routes.Models;

    public interface IRouteService
    {
        RouteQueryServiceModel All(char code, RouteSorting sorting, int currentPage, int routesPerPage);

        IEnumerable<char> AllRoutesCodes();

        IEnumerable<RouteServiceModel> AllRoutes();

        bool RouteExists(int id);

        int Create(
            char code, 
            string description);
    }
}
