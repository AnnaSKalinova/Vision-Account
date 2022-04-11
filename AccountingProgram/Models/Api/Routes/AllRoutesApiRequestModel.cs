using AccountingProgram.Models.Routes;

namespace AccountingProgram.Models.Api.Routes
{
    public class AllRoutesApiRequestModel
    {
        public char Code { get; init; }

        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int RoutesPerPage { get; init; } = 6;

        public int TotalRoutes { get; init; }

        public RouteSorting Sorting { get; init; }
    }
}
