namespace AccountingProgram.Services.Drivers
{
    using System.Collections.Generic;

    using AccountingProgram.Models.Drivers;
    using AccountingProgram.Services.Drivers.Models;

    public interface IDriverService
    {
        DriverQueryServiceModel All(
            char route, 
            string searchTerm, 
            DriverSorting sorting,
            int currentPage = 1,
            int driversPerPage = SearchDriversQueryModel.DriversPerPage);

        IEnumerable<char> AllDriversRoutes();

        int Create(
            string name, 
            int routeId);
    }
}
