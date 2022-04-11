namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Models.SalesInvoices;
    using AccountingProgram.Views.SalesInvoices;
    using System.Collections.Generic;
    using System;
    using System.Globalization;
    
    public class SalesInvoicesController : Controller
    {
        private readonly AccountingDbContext data;

        public SalesInvoicesController(AccountingDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            return View(new AddSalesInvoiceFormModel
            {
                Customers = this.GetCustomers(),
                Items = this.GetItems()
            });
        }

        public IActionResult All([FromQuery]SearchSalesInvoicesQueryModel query)
        {
            var salesInvoicesQuery = this.data.SalesInvoices.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Chain))
            {
                salesInvoicesQuery = salesInvoicesQuery.Where(s =>
                    s.Customer.ChainName == query.Chain);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                salesInvoicesQuery = salesInvoicesQuery.Where(s =>
                    s.Customer.Name.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            salesInvoicesQuery = query.Sorting switch
            {
                SalesInvoiceSorting.Id => salesInvoicesQuery.OrderBy(si => si.Id),
                SalesInvoiceSorting.Customer => salesInvoicesQuery.OrderBy(si => si.Customer.Name),
                SalesInvoiceSorting.PostingDate => salesInvoicesQuery.OrderBy(si => si.PostingDate),
                SalesInvoiceSorting.TotalAmountExclVat => salesInvoicesQuery.OrderBy(si => si.Item.UnitPriceExclVat * si.Count),
                _ => salesInvoicesQuery.OrderBy(si => si.Id)
            };

            var totalSalesInvoices = salesInvoicesQuery.Count();

            var salesInvoices = salesInvoicesQuery
                .Skip((query.CurrentPage - 1) * SearchSalesInvoicesQueryModel.SalesInvoicesPerPage)
                .Take(SearchSalesInvoicesQueryModel.SalesInvoicesPerPage)
                .Select(si => new SalesInvoiceListingViewModel
                {
                    Id = si.Id,
                    Customer = si.Customer.Name,
                    PostingDate = si.PostingDate.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture),
                    TotalAmountExclVat = si.Item.UnitPriceExclVat * si.Count,
                    TotalAmountInclVat = si.Item.UnitPriceIncVat * si.Count,
                })
                .ToList();

            var salesInvoiceChains = this.data
                .SalesInvoices
                .Select(si => si.Customer.ChainName)
                .OrderBy(si => si)
                .Distinct()
                .ToList();

            query.TotalSalesInvoices = totalSalesInvoices;
            query.Chains = salesInvoiceChains;
            query.SalesInvoices = salesInvoices;

            return View(query);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddSalesInvoiceFormModel salesInvoice)
        {
            if (!this.data.Customers.Any(c => c.Id == salesInvoice.CustomerId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.CustomerId), "Customer does not exist!");
            }

            if (!this.data.Items.Any(i => i.Id == salesInvoice.ItemId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.ItemId), "Item does not exist!");
            }


            if (!ModelState.IsValid)
            {
                salesInvoice.Customers = this.GetCustomers();
                salesInvoice.Items = this.GetItems();

                return View(salesInvoice);

            }

            DateTime salesInvPostingDate;
            bool isSalesInvPostingDateValid = DateTime.TryParseExact(salesInvoice.PostingDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out salesInvPostingDate);

            var salesInvoiceData = new SalesInvoice
            {
                CustomerId = salesInvoice.CustomerId,
                PostingDate = salesInvPostingDate,
                ItemId = salesInvoice.ItemId,
                Count = salesInvoice.Count
            };

            this.data.SalesInvoices.Add(salesInvoiceData);

            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<ItemViewModel> GetItems()
        {
            return this.data
                .Items
                .Select(i => new ItemViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Measure = (int)i.Measure,
                    UnitPriceExclVat = i.UnitPriceExclVat,
                    VatGroup = (int)i.VatGroup
                })
                .ToList();
        }

        private IEnumerable<CustomerViewModel> GetCustomers()
        {
            return this.data
                .Customers
                .Select(c => new CustomerViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    PaymentTerm = (int)c.PaymentTerm
                })
                .ToList();
        }
    }
}
