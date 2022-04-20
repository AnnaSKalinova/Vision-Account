namespace AccountingProgram.Services.SalesInvoices
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Models.SalesInvoices;
    using AccountingProgram.Services.SalesInvoices.Models;

    public class SalesInvoiceService : ISalesInvoiceService
    {
        private readonly AccountingDbContext data;

        public SalesInvoiceService(AccountingDbContext data)
        {
            this.data = data;
        }

        public SalesInvoiceQueryServiceModel All(
            string chain = null,
            string searchTerm = null,
            SalesInvoiceSorting sorting = SalesInvoiceSorting.Id,
            int currentPage = 1,
            int salesInvoicesPerPage = SearchSalesInvoicesQueryModel.SalesInvoicesPerPage,
            bool postedOnly = true)
        {
            var salesInvoicesQuery = this.data.SalesInvoices
                .Where(si => !postedOnly || si.isPosted);

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

            var salesInvoices = GetSalesInvoices(salesInvoicesQuery
                .Skip((currentPage - 1) * salesInvoicesPerPage)
                .Take(salesInvoicesPerPage));

            return new SalesInvoiceQueryServiceModel
            {
                CurrentPage = currentPage,
                SalesInvoices = salesInvoices,
                SalesInvoicesPerPage = salesInvoicesPerPage,
                TotalSalesInvoices = totalSalesInvoices
            };
        }

        public SalesInvoiceDetailsServiceModel Details(int id)
        {
            return this.data
                .SalesInvoices
                .Where(si => si.Id == id)
                .Select(si => new SalesInvoiceDetailsServiceModel
                { 
                    Id = si.Id,
                    CustomerName = si.Customer.Name,
                    CustomerId = si.CustomerId,
                    PostingDate = si.PostingDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                    DueDate = si.DueDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ItemName = si.Item.Name,
                    ItemId = si.ItemId,
                    Count = si.Count,
                    TotalAmountExclVat = si.TotalAmountExclVat,
                    Vat = si.Vat,
                    TotalAmountInclVat = si.TotalAmountInclVat,
                    AccountantName = si.Accountant.Name,
                    UserId = si.AccountantId.ToString(),
                    Profit = si.Profit
                })
                .FirstOrDefault();
        }

        public IEnumerable<SalesInvoiceServiceModel> ByUser(string userId)
        {
            return this.GetSalesInvoices(this.data
                .SalesInvoices
                .Where(si => si.Accountant.UserId == userId));
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

        private IEnumerable<SalesInvoiceServiceModel> GetSalesInvoices(IQueryable<SalesInvoice> salesInvoiceQuery)
        { 
            return salesInvoiceQuery
                .Select(si => new SalesInvoiceServiceModel
                {
                    Id = si.Id,
                    CustomerName = si.Customer.Name,
                    PostingDate = si.PostingDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                    TotalAmountExclVat = si.Item.UnitPriceExclVat * si.Count,
                    IsPosted = si.isPosted
                })
                .ToList();
        }

        public int Create(int customerId, string postingDate, int itemId, int count, int accountantId)
        {
            DateTime salesInvPostingDate;
            DateTime.TryParseExact(postingDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out salesInvPostingDate);

            var customer = this.data.Customers
                .Where(c => c.Id == customerId)
                .FirstOrDefault();

            var item = this.data.Items
                .Where(i => i.Id == itemId)
                .FirstOrDefault();

            var totalAmountExclVat = item.UnitPriceExclVat * count;
            var vat = totalAmountExclVat * ((int)item.VatGroup) * 0.01m;
            var totalAmountInclVat = totalAmountExclVat + vat;
            var profit = totalAmountExclVat - count * item.UnitCost;

            var salesInvoiceData = new SalesInvoice
            {
                CustomerId = customerId,
                PostingDate = salesInvPostingDate,
                DueDate = salesInvPostingDate.AddDays((int)customer.PaymentTerm),
                ItemId = itemId,
                Count = count,
                TotalAmountExclVat = totalAmountExclVat,
                Vat = vat,
                TotalAmountInclVat = totalAmountInclVat,
                AccountantId = accountantId,
                Profit = profit,
                isPosted = false
            };

            this.data.SalesInvoices.Add(salesInvoiceData);

            this.data.SaveChanges();

            return salesInvoiceData.Id;
        }

        public bool Edit(
            int id, 
            int customerId, 
            string postingDate, 
            int itemId, 
            int count,
            bool isPosted)
        {
            var salesInvoiceData = this.data.SalesInvoices.Find(id);

            if (salesInvoiceData == null)
            {
                return false;
            }

            DateTime salesInvPostingDate;
            DateTime.TryParseExact(postingDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out salesInvPostingDate);

            var customer = this.data
                .Customers
                .Where(c => c.Id == customerId)
                .FirstOrDefault();

            var item = this.data.Items
                .Where(i => i.Id == itemId)
                .FirstOrDefault();

            var totalAmountExclVat = item.UnitPriceExclVat * count;
            var vat = totalAmountExclVat * ((int)item.VatGroup) * 0.01m;
            var totalAmountInclVat = totalAmountExclVat + vat;
            var profit = totalAmountExclVat - count * item.UnitCost;

            salesInvoiceData.CustomerId = customerId;
            salesInvoiceData.PostingDate = salesInvPostingDate;
            salesInvoiceData.DueDate = salesInvPostingDate.AddDays((int)customer.PaymentTerm);
            salesInvoiceData.ItemId = itemId;
            salesInvoiceData.Count = count;
            salesInvoiceData.TotalAmountExclVat = totalAmountExclVat;
            salesInvoiceData.Vat = vat;
            salesInvoiceData.TotalAmountInclVat = totalAmountInclVat;
            salesInvoiceData.Profit = profit;
            salesInvoiceData.isPosted = false;

            this.data.SaveChanges();

            return true;
        }

        public bool IsByAccountant(int salesInvoiceId, int accountantId)
        {
            return this.data
                .SalesInvoices
                .Any(si => si.Id == salesInvoiceId && si.AccountantId == accountantId);
        }

        public void ChangeStatus(int id)
        {
            var salesInvoice = this.data.SalesInvoices.Find(id);

            salesInvoice.isPosted = !salesInvoice.isPosted;

            this.data.SaveChanges();
        }

        public void Delete(int id)
        {
            var salesInvoice = this.data
                .SalesInvoices
                .Where(si => si.Id == id)
                .FirstOrDefault();

            this.data.Remove(salesInvoice);

            this.data.SaveChanges();
        }
    }
}
