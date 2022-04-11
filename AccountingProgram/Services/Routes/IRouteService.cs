namespace AccountingProgram.Services.Routes
{
    using System.Collections.Generic;

    using AccountingProgram.Models.Routes;

    public interface IRouteService
    {
        RouteQueryServiceModel All(char code, RouteSorting sorting, int currentPage, int routesPerPage);

        IEnumerable<char> AllRoutesCodes();
    }
}
