namespace AccountingProgram.Services.Customers
{
    using System.Collections.Generic;
    using System.Linq;

    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Data.Models.Enums;
    using AccountingProgram.Models.Customers;
    using AccountingProgram.Services.Customers.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class CustomerService : ICustomerService
    {
        private readonly AccountingDbContext data;
        private readonly IConfigurationProvider mapper;

        public CustomerService(AccountingDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }

        public CustomerQueryServiceModel All(
            string chain, 
            string searchTerm, 
            CustomerSorting sorting, 
            int currentPage = 1, 
            int customersPerPage = SearchCustomersQueryModel.CustomersPerPage)
        {
            var customersQuery = this.data.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(chain))
            {
                customersQuery = customersQuery.Where(c =>
                    c.ChainName == chain);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                customersQuery = customersQuery.Where(c =>
                    c.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            customersQuery = sorting switch
            {
                CustomerSorting.Id => customersQuery.OrderBy(c => c.Id),
                CustomerSorting.Name => customersQuery.OrderBy(c => c.Name),
                CustomerSorting.Chain => customersQuery.OrderBy(c => c.ChainName),
                CustomerSorting.Route => customersQuery.OrderBy(c => c.Route.Code),
                CustomerSorting.TotalInvoices => customersQuery.OrderBy(c => c.SalesInvoices.Count),
                _ => customersQuery.OrderBy(c => c.Id)
            };

            var totalCustomers = customersQuery.Count();

            var customers = customersQuery
                .Skip((currentPage - 1) * customersPerPage)
                .Take(customersPerPage)
                .ProjectTo<CustomerServiceModel>(this.mapper)
                .ToList();

            return new CustomerQueryServiceModel
            {
                CurrentPage = currentPage,
                Customers = customers,
                CustomersPerPage = customersPerPage,
                TotalCustomers = totalCustomers
            };
        }

        public IEnumerable<CustomerServiceModel> AllCustomers()
        {
            return this.data
                .Customers
                .ProjectTo<CustomerServiceModel>(this.mapper)
                .ToList();
        }

        public IEnumerable<string> AllCustomersChains()
        {
            return this.data
                .Customers
                .Select(c => c.ChainName)
                .OrderBy(c => c)
                .Distinct()
                .ToList();
        }

        public int Create(string name, string chainName, string address, string contactName, string email, int paymentTerm, int routeId)
        {
            var customerData = new Customer
            {
                Name = name,
                ChainName = chainName,
                Address = address,
                ContactName = contactName,
                Email = email,
                PaymentTerm = (PaymentTerm)paymentTerm,
                RouteId = routeId
            };

            this.data.Customers.Add(customerData);

            this.data.SaveChanges();

            return customerData.Id;
        }

        public bool CustomerExists(int id)
        {
            return this.data.Customers.Any(c => c.Id == id);
        }

        public IEnumerable<RouteCustomerServiceModel> GetRoutes()
        {
            return this.data
                .Routes
                .ProjectTo<RouteCustomerServiceModel>(this.mapper)
                .ToList();
        }

        public CustomerDetailsServiceModel Details(int id)
        {
            return this.data
                .Customers
                .Where(c => c.Id == id)
                .ProjectTo<CustomerDetailsServiceModel>(this.mapper)
                .FirstOrDefault();
        }
    }
}
