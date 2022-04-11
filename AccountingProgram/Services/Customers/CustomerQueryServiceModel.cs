namespace AccountingProgram.Services.Customers
{
    using System.Collections.Generic;
    
    public class CustomerQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int TotalCustomers { get; init; }

        public int CustomersPerPage { get; init; }

        public IEnumerable<CustomerServiceModel> Customers { get; init; }
    }
}
