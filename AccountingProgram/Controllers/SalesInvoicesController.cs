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
    using AccountingProgram.Services.SalesInvoices;

    public class SalesInvoicesController : Controller
    {
        private readonly ISalesInvoiceService salesInvoices;
        private readonly AccountingDbContext data;

        public SalesInvoicesController(AccountingDbContext data, ISalesInvoiceService salesInvoices)
        {
            this.data = data;
            this.salesInvoices = salesInvoices;
        }

        public IActionResult All([FromQuery]SearchSalesInvoicesQueryModel query)
        {
            var queryResult = this.salesInvoices.All(
                query.Chain,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                SearchSalesInvoicesQueryModel.SalesInvoicesPerPage);

            var salesInvoiceChains = this.salesInvoices.AllSalesInvoicesChains();

            query.TotalSalesInvoices = queryResult.TotalSalesInvoices;
            query.Chains = salesInvoiceChains;
            query.SalesInvoices = queryResult.SalesInvoices.Select(si => new SalesInvoiceServiceModel
            {
                Id = si.Id,
                Customer = si.Customer,
                PostingDate = si.PostingDate,
                TotalAmountExclVat = si.TotalAmountExclVat,
                TotalAmountInclVat = si.TotalAmountInclVat
            });

            return View(query);
        }

        public IActionResult Add()
        {
            return View(new AddSalesInvoiceFormModel
            {
                Customers = this.GetCustomers(),
                Items = this.GetItems()
            });
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
