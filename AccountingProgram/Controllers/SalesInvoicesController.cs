namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
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
