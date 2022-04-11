namespace AccountingProgram.Services.SalesInvoices
{
    using System.Collections.Generic;

    using AccountingProgram.Models.SalesInvoices;
    
    public interface ISalesInvoiceService
    {
        SalesInvoiceQueryServiceModel All(string chain, string searchTerm, SalesInvoiceSorting sorting, int currentPage, int salesInvoicesPerPage);

        IEnumerable<string> AllSalesInvoicesChains();
    }
}
