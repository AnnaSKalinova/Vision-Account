namespace AccountingProgram.Models.Routes
{
    using System.Collections.Generic;

    using AccountingProgram.Services.Routes;
    using AccountingProgram.Services.Routes.Models;

    public class SearchRoutesQueryModel
    {
        public const int RoutesPerPage = 6;

        public char Code { get; init; }

        public IEnumerable<char> Codes { get; set; }

        public int CurrentPage { get; init; } = 1;

        public int TotalRoutes { get; set; }

        public RouteSorting Sorting { get; init; }

        public IEnumerable<RouteServiceModel> Routes { get; set; }
    }
}
