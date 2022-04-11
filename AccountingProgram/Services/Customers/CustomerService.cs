namespace AccountingProgram.Services.Customers
{
    using System.Collections.Generic;
    using System.Linq;

    using AccountingProgram.Data;
    using AccountingProgram.Models.Customers;

    public class CustomerService : ICustomerService
    {
        private readonly AccountingDbContext data;

        public CustomerService(AccountingDbContext data)
        {
            this.data = data;
        }

        public CustomerQueryServiceModel All(string chain, string searchTerm, CustomerSorting sorting, int currentPage, int customersPerPage)
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
                .Select(c => new CustomerServiceModel
                {
                    Name = c.Name,
                    Route = c.Route.Code,
                    SalesInvoices = c.SalesInvoices.Count
                })
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
                .Select(c => new CustomerServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    PaymentTerm = (int)c.PaymentTerm
                })
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

        public bool CustomerExists(int id)
        {
            return !this.data.Customers.Any(c => c.Id == id);
        }
    }
}
