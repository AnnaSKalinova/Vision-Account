namespace AccountingProgram.Models.Routes
{
    using System.Collections.Generic;

    using AccountingProgram.Services.Routes.Models;

    using static AccountingProgram.Data.DataConstants;

    public class SearchRoutesQueryModel
    {
        public const int RoutesPerPage = CountPerPage;

        public char Code { get; init; }

        public IEnumerable<char> Codes { get; set; }

        public int CurrentPage { get; init; } = 1;

        public int TotalRoutes { get; set; }

        public RouteSorting Sorting { get; init; }

        public IEnumerable<RouteServiceModel> Routes { get; set; }
    }
}
