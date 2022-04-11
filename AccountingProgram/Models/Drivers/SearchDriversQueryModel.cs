namespace AccountingProgram.Models.Drivers
{    
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SearchDriversQueryModel
    {
        public const int DriversPerPage = 2;

        public char Route { get; init; }

        public IEnumerable<char> Routes { get; set; }

        [Display(Name = "Driver name")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalDrivers { get; set; }

        public DriverSorting Sorting { get; init; }

        public IEnumerable<DriverListingViewModel> Drivers { get; set; }
    }
}
