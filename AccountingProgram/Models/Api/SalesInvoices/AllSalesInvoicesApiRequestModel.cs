using AccountingProgram.Models.SalesInvoices;

namespace AccountingProgram.Models.Api.SalesInvoices
{
    public class AllSalesInvoicesApiRequestModel
    {
        public string Chain { get; init; }

        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int SalesInvoicesPerPage { get; init; } = 6;

        public int TotalSalesInvoices { get; init; }

        public SalesInvoiceSorting Sorting { get; init; }
    }
}
