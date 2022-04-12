namespace AccountingProgram.Services.SalesInvoices
{
    using System.Collections.Generic;

    using AccountingProgram.Models.SalesInvoices;
    using AccountingProgram.Services.SalesInvoices.Models;

    public interface ISalesInvoiceService
    {
        SalesInvoiceQueryServiceModel All(
            string chain, 
            string searchTerm, 
            SalesInvoiceSorting sorting, 
            int currentPage, 
            int salesInvoicesPerPage);

        SalesInvoiceDetailsServiceModel Details(int id);

        int Create(
                int customerId,
                string postingDate,
                int itemId,
                int count,
                int accountantId);

        bool Edit(
                int id,
                int customerId,
                string postingDate,
                int itemId,
                int count);

        IEnumerable<SalesInvoiceServiceModel> ByUser(string userId);

        bool IsByAccountant(int salesInvoiceId, int accountantId);

        IEnumerable<string> AllSalesInvoicesChains();
    }
}
