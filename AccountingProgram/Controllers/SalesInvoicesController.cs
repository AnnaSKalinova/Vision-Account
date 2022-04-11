namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Models.SalesInvoices;
    using AccountingProgram.Services.SalesInvoices;
    using AccountingProgram.Infrastructure;
    using AccountingProgram.Services.Accountants;
    using AccountingProgram.Services.Items;
    using AccountingProgram.Services.Customers;

    public class SalesInvoicesController : Controller
    {
        private readonly ISalesInvoiceService salesInvoices;
        private readonly IAccountantService accountants;
        private readonly IItemService items;
        private readonly ICustomerService customers;

        public SalesInvoicesController(
            IAccountantService accountants,
            ISalesInvoiceService salesInvoices,
            IItemService items,
            ICustomerService customers)
        {
            this.accountants = accountants;
            this.salesInvoices = salesInvoices;
            this.items = items;
            this.customers = customers;
        }

        public IActionResult All([FromQuery] SearchSalesInvoicesQueryModel query)
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

        [Authorize]
        public IActionResult Mine()
        {
            var mySalesInvoices = this.salesInvoices.ByUser(this.User.GetId());

            return View(mySalesInvoices);
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!this.accountants.IsAccountant(this.User.GetId()))
            {
                return RedirectToAction(nameof(AccountantsController.Become), "Accountants");
            }

            return View(new SalesInvoiceFormModel
            {
                Customers = this.customers.AllCustomers(),
                Items = this.items.AllItems()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(SalesInvoiceFormModel salesInvoice)
        {
            var accountantId = this.accountants.GetIdByUser(this.User.GetId());

            if (accountantId == 0)
            {
                return RedirectToAction(nameof(AccountantsController.Become), "Accountants");
            }

            if (this.customers.CustomerExists(salesInvoice.CustomerId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.CustomerId), "Customer does not exist!");
            }

            if (this.items.ItemExists(salesInvoice.ItemId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.ItemId), "Item does not exist!");
            }


            if (!ModelState.IsValid)
            {
                salesInvoice.Customers = this.customers.AllCustomers();
                salesInvoice.Items = this.items.AllItems();

                return View(salesInvoice);
            }

            this.salesInvoices.Create(
                salesInvoice.CustomerId,
                salesInvoice.PostingDate,
                salesInvoice.ItemId,
                salesInvoice.Count,
                salesInvoice.AccountantId);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var userId = this.User.GetId();

            if (!this.accountants.IsAccountant(userId))
            {
                return RedirectToAction(nameof(AccountantsController.Become), "Accountants");
            }

            var salesInvoice = this.salesInvoices.Details(id);

            if (salesInvoice.UserId != userId)
            {
                return Unauthorized();
            }

            return View(new SalesInvoiceFormModel
            {
                Customers = this.customers.AllCustomers(),
                Items = this.items.AllItems(),
                PostingDate = salesInvoice.PostingDate,
                AccountantId = salesInvoice.AccountantId,
                Count = salesInvoice.Count,
                CustomerId = salesInvoice.CustomerId,
                ItemId = salesInvoice.ItemId
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, SalesInvoiceFormModel salesInvoice)
        {
            var accountantId = this.accountants.GetIdByUser(this.User.GetId());

            if (accountantId == 0)
            {
                return RedirectToAction(nameof(AccountantsController.Become), "Accountants");
            }

            if (this.customers.CustomerExists(salesInvoice.CustomerId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.CustomerId), "Customer does not exist!");
            }

            if (this.items.ItemExists(salesInvoice.ItemId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.ItemId), "Item does not exist!");
            }

            if (!this.salesInvoices.IsByAccountant(id, accountantId))
            {
                return BadRequest();
            }

            this.salesInvoices.Edit(
                id,
                salesInvoice.CustomerId,
                salesInvoice.PostingDate,
                salesInvoice.ItemId,
                salesInvoice.Count);

            return RedirectToAction(nameof(All));
        }
    }
}
