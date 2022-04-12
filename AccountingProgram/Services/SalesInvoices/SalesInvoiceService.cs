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
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class SalesInvoiceService : ISalesInvoiceService
    {
        private readonly AccountingDbContext data;
        private readonly IConfigurationProvider mapper;

        public SalesInvoiceService(AccountingDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
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
                .ProjectTo<SalesInvoiceDetailsServiceModel>(this.mapper)
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
                    TotalAmountInclVat = si.Item.UnitPriceIncVat * si.Count,
                })
                .ToList();
        }

        public int Create(int customerId, string postingDate, int itemId, int count, int accountantId)
        {
            DateTime salesInvPostingDate;
            DateTime.TryParseExact(postingDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out salesInvPostingDate);

            var salesInvoiceData = new SalesInvoice
            {
                CustomerId = customerId,
                PostingDate = salesInvPostingDate,
                ItemId = itemId,
                Count = count,
                AccountantId = accountantId
            };

            this.data.SalesInvoices.Add(salesInvoiceData);

            this.data.SaveChanges();

            return salesInvoiceData.Id;
        }

        public bool Edit(int id, int customerId, string postingDate, int itemId, int count)
        {
            var salesInvoiceData = this.data.SalesInvoices.Find(id);

            if (salesInvoiceData == null)
            {
                return false;
            }

            DateTime salesInvPostingDate;
            DateTime.TryParseExact(postingDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out salesInvPostingDate);

            salesInvoiceData.CustomerId = customerId;
            salesInvoiceData.PostingDate = salesInvPostingDate;
            salesInvoiceData.ItemId = itemId;
            salesInvoiceData.Count = count;

            this.data.SaveChanges();

            return true;
        }

        public bool IsByAccountant(int salesInvoiceId, int accountantId)
        {
            return this.data
                .SalesInvoices
                .Any(si => si.Id == salesInvoiceId && si.AccountantId == accountantId);
        }
    }
}
