namespace AccountingProgram.Services.SalesInvoices
{
    using System.Collections.Generic;
    
    public class SalesInvoiceQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int TotalSalesInvoices { get; init; }

        public int SalesInvoicesPerPage { get; init; }

        public IEnumerable<SalesInvoiceServiceModel> SalesInvoices { get; init; }
    }
}
