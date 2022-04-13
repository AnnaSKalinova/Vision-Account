namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Models.SalesInvoices;
    using AccountingProgram.Services.SalesInvoices.Models;
    using AccountingProgram.Infrastructure;
    using AccountingProgram.Services.Accountants;
    using AccountingProgram.Services.Items;
    using AccountingProgram.Services.Customers;
    using AccountingProgram.Services.SalesInvoices;
    using AutoMapper;

    using static WebConstants;
    using System.Globalization;

    public class SalesInvoicesController : Controller
    {
        private readonly ISalesInvoiceService salesInvoices;
        private readonly IAccountantService accountants;
        private readonly IItemService items;
        private readonly ICustomerService customers;
        private readonly IMapper mapper;

        public SalesInvoicesController(
            IAccountantService accountants,
            ISalesInvoiceService salesInvoices,
            IItemService items,
            ICustomerService customers, 
            IMapper mapper)
        {
            this.accountants = accountants;
            this.salesInvoices = salesInvoices;
            this.items = items;
            this.customers = customers;
            this.mapper = mapper;
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
                CustomerName = si.CustomerName,
                PostingDate = si.PostingDate,
                TotalAmountExclVat = si.TotalAmountExclVat,
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
            if (!this.accountants.UserIsAlreadyAccountant(this.User.GetId()))
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
                accountantId);

            TempData[GlobalMessageKey] = "You successfully added a new sales invoice!";

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var userId = this.User.GetId();

            if (!this.accountants.UserIsAlreadyAccountant(userId) && !User.IsAdmin())
            {
                return RedirectToAction(nameof(AccountantsController.Become), "Accountants");
            }

            var salesInvoice = this.salesInvoices.Details(id);

            var salesInvoiceForm = this.mapper.Map<SalesInvoiceFormModel>(salesInvoice);

            salesInvoiceForm.Customers = this.customers.AllCustomers();
            salesInvoiceForm.Items = this.items.AllItems();

            return View(salesInvoiceForm);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, SalesInvoiceFormModel salesInvoice)
        {
            var accountantId = this.accountants.GetIdByUser(this.User.GetId());

            if (accountantId == 0 && !User.IsAdmin())
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

            if (!this.salesInvoices.IsByAccountant(id, accountantId) && !User.IsAdmin())
            {
                return BadRequest();
            }

            this.salesInvoices.Edit(
                id,
                salesInvoice.CustomerId,
                salesInvoice.PostingDate,
                salesInvoice.ItemId,
                salesInvoice.Count);

            TempData[GlobalMessageKey] = "You successfully edited the invoice!";

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id, string information)
        {
            var salesInvoice = this.salesInvoices.Details(id);

            if (!information.Contains(salesInvoice.CustomerName) || !information.Contains(salesInvoice.PostingDate))
            {
                return BadRequest();
            }

            return View(salesInvoice);
        }
    }
}
