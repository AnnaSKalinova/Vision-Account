namespace AccountingProgram.Services.SalesInvoices
{
    using System.Collections.Generic;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Models.SalesInvoices;
    using AccountingProgram.Services.SalesInvoices.Models;

    public interface ISalesInvoiceService
    {
        SalesInvoiceQueryServiceModel All(
            string chain = null,
            string searchTerm = null,
            SalesInvoiceSorting sorting = SalesInvoiceSorting.Id,
            int currentPage = 1,
            int salesInvoicesPerPage = int.MaxValue,
            bool postedOnly = true);

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
                int count,
                bool isPosted);

        void ChangeStatus(int id);

        IEnumerable<SalesInvoiceServiceModel> ByUser(string userId);

        bool IsByAccountant(int salesInvoiceId, int accountantId);

        IEnumerable<string> AllSalesInvoicesChains();
    }
}
