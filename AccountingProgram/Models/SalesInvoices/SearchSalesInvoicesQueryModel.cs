namespace AccountingProgram.Models.SalesInvoices
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AccountingProgram.Services.SalesInvoices;
    
    public class SearchSalesInvoicesQueryModel
    {
        public const int SalesInvoicesPerPage = 6;

        public string Chain { get; init; }

        public IEnumerable<string> Chains { get; set; }

        [Display(Name = "Customer name")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalSalesInvoices { get; set; }

        public SalesInvoiceSorting Sorting { get; init; }

        public IEnumerable<SalesInvoiceServiceModel> SalesInvoices { get; set; }
    }
}
