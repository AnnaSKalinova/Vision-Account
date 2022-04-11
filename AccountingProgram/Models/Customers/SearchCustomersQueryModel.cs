namespace AccountingProgram.Models.Customers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AccountingProgram.Services.Customers;
    
    public class SearchCustomersQueryModel
    {
        public const int CustomersPerPage = 6;

        public string Chain { get; init; }

        public IEnumerable<string> Chains { get; set; }

        [Display(Name = "Customer name")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalCustomers { get; set; }

        public CustomerSorting Sorting { get; init; }

        public IEnumerable<CustomerServiceModel> Customers { get; set; }
    }
}
