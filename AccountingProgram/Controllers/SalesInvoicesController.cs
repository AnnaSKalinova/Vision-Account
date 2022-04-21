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
    using static Data.DataConstants.SalesInvoices;
    using static Data.DataConstants.Customer;
    using static Data.DataConstants.Item;
    using static Data.DataConstants.Accountant;

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

        public IActionResult All(
            [FromQuery] string chain,
            [FromQuery] string searchTerm,
            [FromQuery] SalesInvoiceSorting sorting,
            [FromQuery] int currentPage = 1,
            [FromQuery] int salesInvoicesPerPage = SearchSalesInvoicesQueryModel.SalesInvoicesPerPage)
        {
            var queryResult = this.salesInvoices.All(
                chain,
                searchTerm,
                sorting,
                currentPage,
                salesInvoicesPerPage);

            var salesInvoiceChains = this.salesInvoices.AllSalesInvoicesChains();

            SearchSalesInvoicesQueryModel query = new SearchSalesInvoicesQueryModel
            {
                Chain = chain,
                SearchTerm = searchTerm,
                Sorting = sorting,
                CurrentPage = currentPage
            };

            query.TotalSalesInvoices = queryResult.TotalSalesInvoices;
            query.Chains = salesInvoiceChains;
            query.SalesInvoices = queryResult.SalesInvoices.Select(si => new SalesInvoiceServiceModel
            {
                Id = si.Id,
                CustomerName = si.CustomerName,
                PostingDate = si.PostingDate,
                TotalPriceExclVat = si.TotalPriceExclVat,
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
                this.ModelState.AddModelError(nameof(salesInvoice.AccountantId), ErrorAccountantDoesNotExist);
            }

            if (!this.customers.CustomerExists(salesInvoice.CustomerId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.CustomerId), ErrorCustomerDoesNotExist);
            }

            if (!this.items.ItemExists(salesInvoice.ItemId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.ItemId), ErrorItemDoesNotExist);
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

            TempData[GlobalMessageKey] = AddedSalesInvoiceMessage;

            return RedirectToAction(nameof(this.Mine));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id, string information)
        {
            var userId = this.User.GetId();

            if (!this.accountants.IsUserAccountant(userId) && !User.IsChiefAccountant())
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

            if (accountantId == 0 && !User.IsChiefAccountant())
            {
                return BadRequest();
            }

            if (!this.customers.CustomerExists(salesInvoice.CustomerId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.CustomerId), ErrorCustomerDoesNotExist);
            }

            if (!this.items.ItemExists(salesInvoice.ItemId))
            {
                this.ModelState.AddModelError(nameof(salesInvoice.ItemId), ErrorItemDoesNotExist);
            }

            if (!this.salesInvoices.IsByAccountant(id, accountantId) && !User.IsChiefAccountant())
            {
                return BadRequest();
            }

            this.salesInvoices.Edit(
                id,
                salesInvoice.CustomerId,
                salesInvoice.PostingDate,
                salesInvoice.ItemId,
                salesInvoice.Count,
                this.User.IsChiefAccountant());

            TempData[GlobalMessageKey] = $"You eddited the sales invoice successfully! {(this.User.IsChiefAccountant() ? string.Empty : "It is now waiting for approval!")}";

            return RedirectToAction(nameof(this.Mine));
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

            return RedirectToAction(nameof(this.Mine));
        }
    }
}
