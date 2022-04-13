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
            int salesInvoicesPerPage = int.MaxValue);

        IEnumerable<char> AllRoutesCodes();

        IEnumerable<RouteServiceModel> AllRoutes();

        RouteDetailsServiceModel Details(int id);

        bool RouteExists(int id);

        int Create(
            char code, 
            string description);
    }
}
