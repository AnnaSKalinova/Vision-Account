namespace AccountingProgram.Services.Drivers
{
    using System.Collections.Generic;
    using System.Linq;

    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Models.Drivers;
    using AccountingProgram.Services.Drivers.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class DriverService : IDriverService
    {
        private readonly AccountingDbContext data;
        private readonly IConfigurationProvider mapper;

        public DriverService(AccountingDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }

        public DriverQueryServiceModel All(char route, string searchTerm, DriverSorting sorting, int currentPage, int driversPerPage)
        {
            var driverQuery = this.data.Drivers.AsQueryable();

            if (route != '\0')
            {
                driverQuery = driverQuery.Where(d =>
                    d.Route.Code == route);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                driverQuery = driverQuery.Where(d =>
                    d.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            driverQuery = sorting switch
            {
                DriverSorting.Name => driverQuery.OrderBy(d => d.Name),
                DriverSorting.Route => driverQuery.OrderBy(d => d.Route.Code),
                _ => driverQuery.OrderBy(d => d.Id)
            };

            var totalDrivers = driverQuery.Count();

            var drivers = driverQuery
                .Skip((currentPage - 1) * driversPerPage)
                .Take(driversPerPage)
                .ProjectTo<DriverServiceModel>(this.mapper)
                .ToList();

            return new DriverQueryServiceModel
            {
                CurrentPage = currentPage,
                Drivers = drivers,
                DriversPerPage = driversPerPage,
                TotalDrivers = totalDrivers
            };
        }

        public IEnumerable<char> AllDriversRoutes()
        {
            return this.data
                .Drivers
                .Select(d => d.Route.Code)
                .OrderBy(d => d)
                .Distinct()
                .ToList();
        }

        public int Create(string name, int routeId)
        {
            var driverData = new Driver
            {
                Name = name,
                RouteId = routeId
            };

            this.data.Drivers.Add(driverData);

            this.data.SaveChanges();

            return driverData.Id;
        }
    }
}
