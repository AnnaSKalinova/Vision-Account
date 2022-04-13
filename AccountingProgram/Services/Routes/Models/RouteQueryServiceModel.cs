namespace AccountingProgram.Services.Routes.Models
{
    using System.Collections.Generic;
    
    public class RouteQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int TotalRoutes { get; init; }

        public int RoutesPerPage { get; init; }

        public IEnumerable<RouteServiceModel> Routes { get; init; }
    }
}
