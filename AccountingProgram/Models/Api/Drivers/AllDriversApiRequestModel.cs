using AccountingProgram.Models.Drivers;

namespace AccountingProgram.Models.Api.Drivers
{
    public class AllDriversApiRequestModel
    {
        public char Route { get; init; }

        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int DriversPerPage { get; init; } = 6;

        public int TotalDrivers { get; init; }

        public DriverSorting Sorting { get; init; }
    }
}
