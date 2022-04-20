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
                IsPosted = si.IsPosted
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
                this.ModelState.AddModelError(nameof(salesInvoice.AccountantId), "Accountant does not exist!");
            }

            if (!this.customers.CustomerExists(salesInvoice.CustomerId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.CustomerId), "Customer does not exist!");
            }

            if (!this.items.ItemExists(salesInvoice.ItemId))
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

            TempData[GlobalMessageKey] = "You created the sales invoice successfully. It is now waiting for approval!";

            return RedirectToAction(nameof(this.Mine));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id, string information)
        {
            var userId = this.User.GetId();

            if (!this.accountants.IsUserAccountant(userId) && !User.IsChefAccountant())
            {
                return BadRequest();
            }

            var salesInvoice = this.salesInvoices.Details(id);

            if (!information.Contains(salesInvoice.CustomerName) || !information.Contains(salesInvoice.PostingDate))
            {
                return BadRequest();
            }

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

            if (accountantId == 0 && !User.IsChefAccountant())
            {
                return BadRequest();
            }

            if (!this.customers.CustomerExists(salesInvoice.CustomerId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.CustomerId), "Customer does not exist!");
            }

            if (!this.items.ItemExists(salesInvoice.ItemId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.ItemId), "Item does not exist!");
            }

            if (!this.salesInvoices.IsByAccountant(id, accountantId) && !User.IsChefAccountant())
            {
                return BadRequest();
            }

            this.salesInvoices.Edit(
                id,
                salesInvoice.CustomerId,
                salesInvoice.PostingDate,
                salesInvoice.ItemId,
                salesInvoice.Count,
                this.User.IsChefAccountant());

            TempData[GlobalMessageKey] = $"You eddited the sales invoice successfully! {(this.User.IsChefAccountant() ? string.Empty : "It is now waiting for approval!")}";

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id, string information)
        {
            var salesInvoice = this.salesInvoices.Details(id);

            if (salesInvoice == null)
            {
                return NotFound();
            }

            if (!information.Contains(salesInvoice.CustomerName) || !information.Contains(salesInvoice.PostingDate))
            {
                return BadRequest();
            }

            return View(salesInvoice);
        }

        public IActionResult Delete(int id)
        {
            this.salesInvoices.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
