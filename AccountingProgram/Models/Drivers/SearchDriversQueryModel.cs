namespace AccountingProgram.Models.Drivers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AccountingProgram.Services.Drivers.Models;

    using static AccountingProgram.Data.DataConstants;
   
    public class SearchDriversQueryModel
    {
        public const int DriversPerPage = CountPerPage;

        public char Route { get; init; }

        public IEnumerable<char> Routes { get; set; }

        [Display(Name = "Driver name")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalDrivers { get; set; }

        public DriverSorting Sorting { get; init; }

        public IEnumerable<DriverServiceModel> Drivers { get; set; }
    }
}
