namespace AccountingProgram.Services.SalesInvoices
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using AccountingProgram.Data;
    using AccountingProgram.Models.SalesInvoices;

    public class SalesInvoiceService : ISalesInvoiceService
    {
        private readonly AccountingDbContext data;

        public SalesInvoiceService(AccountingDbContext data)
        {
            this.data = data;
        }

        public SalesInvoiceQueryServiceModel All(string chain, string searchTerm, SalesInvoiceSorting sorting, int currentPage, int salesInvoicesPerPage)
        {
            var salesInvoicesQuery = this.data.SalesInvoices.AsQueryable();

            if (!string.IsNullOrWhiteSpace(chain))
            {
                salesInvoicesQuery = salesInvoicesQuery.Where(s =>
                    s.Customer.ChainName == chain);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                salesInvoicesQuery = salesInvoicesQuery.Where(s =>
                    s.Customer.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            salesInvoicesQuery = sorting switch
            {
                SalesInvoiceSorting.Id => salesInvoicesQuery.OrderBy(si => si.Id),
                SalesInvoiceSorting.Customer => salesInvoicesQuery.OrderBy(si => si.Customer.Name),
                SalesInvoiceSorting.PostingDate => salesInvoicesQuery.OrderBy(si => si.PostingDate),
                SalesInvoiceSorting.TotalAmountExclVat => salesInvoicesQuery.OrderBy(si => si.Item.UnitPriceExclVat * si.Count),
                _ => salesInvoicesQuery.OrderBy(si => si.Id)
            };

            var totalSalesInvoices = salesInvoicesQuery.Count();

            var salesInvoices = salesInvoicesQuery
                .Skip((currentPage - 1) * salesInvoicesPerPage)
                .Take(salesInvoicesPerPage)
                .Select(si => new SalesInvoiceServiceModel
                {
                    Id = si.Id,
                    Customer = si.Customer.Name,
                    PostingDate = si.PostingDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                    TotalAmountExclVat = si.Item.UnitPriceExclVat * si.Count,
                    TotalAmountInclVat = si.Item.UnitPriceIncVat * si.Count,
                })
                .ToList();

            return new SalesInvoiceQueryServiceModel
            {
                CurrentPage = currentPage,
                SalesInvoices = salesInvoices,
                SalesInvoicesPerPage = salesInvoicesPerPage,
                TotalSalesInvoices = totalSalesInvoices
            };
        }

        public IEnumerable<string> AllSalesInvoicesChains()
        {
            return this.data
                .SalesInvoices
                .Select(si => si.Customer.ChainName)
                .OrderBy(si => si)
                .Distinct()
                .ToList();
        }
    }
}
