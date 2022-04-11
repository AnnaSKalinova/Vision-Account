using AccountingProgram.Models.Customers;

namespace AccountingProgram.Models.Api.Customers
{
    public class AllCustomersApiRequestModel
    {
        public string Chain { get; init; }

        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int CustomersPerPage { get; init; } = 6;

        public int TotalCustomers { get; init; }

        public CustomerSorting Sorting { get; init; }
    }
}
