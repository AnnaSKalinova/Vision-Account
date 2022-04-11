namespace AccountingProgram.Services.Customers
{
    using System.Collections.Generic;

    using AccountingProgram.Models.Customers;

    public interface ICustomerService
    {
        CustomerQueryServiceModel All(string chain, string searchTerm, CustomerSorting sorting, int currentPage, int customersPerPage);

        IEnumerable<string> AllCustomersChains();
    }
}
