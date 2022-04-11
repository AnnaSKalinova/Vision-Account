namespace AccountingProgram.Services.Drivers
{
    using System.Collections.Generic;
    
    public class DriverQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int TotalDrivers { get; init; }

        public int DriversPerPage { get; init; }

        public IEnumerable<DriverServiceModel> Drivers { get; init; }
    }
}
