namespace AccountingProgram.Models.Routes
{    
    using System.Collections.Generic;

    public class SearchRoutesQueryModel
    {
        public const int RoutesPerPage = 2;

        public int CurrentPage { get; init; } = 1;

        public int TotalRoutes { get; set; }

        public IEnumerable<RouteListingViewModel> Routes { get; set; }
    }
}
