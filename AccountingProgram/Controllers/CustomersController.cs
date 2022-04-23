namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Models.Customers;
    using AccountingProgram.Services.Customers.Models;
    using AccountingProgram.Services.Routes;
    using AccountingProgram.Services.Customers;

    using static WebConstants;
    using static Data.DataConstants.Route;
    using static Data.DataConstants.Customer;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;
        private readonly IRouteService routes;

        public CustomersController(ICustomerService customers, IRouteService routes)
        {
            this.customers = customers;
            this.routes = routes;
        }

        public IActionResult All(
            [FromQuery]string chain,
            [FromQuery]string searchTerm,
            [FromQuery]CustomerSorting sorting,
            [FromQuery]int currentPage = 1,
            [FromQuery]int customersPerPage = SearchCustomersQueryModel.CustomersPerPage)
        {
            var queryResult = this.customers.All(
                chain,
                searchTerm,
                sorting,
                currentPage,
                customersPerPage);

            var customersChains = this.customers.AllCustomersChains();

            SearchCustomersQueryModel query = new SearchCustomersQueryModel
            {
                Chain = chain,
                SearchTerm = searchTerm,
                Sorting = sorting,
                CurrentPage = currentPage
            };

            query.TotalCustomers = queryResult.TotalCustomers;
            query.Chains = customersChains;
            query.Customers = queryResult
                .Customers
                .Select(c => new CustomerServiceModel
            {
                Id = c.Id,
                Name = c.Name,
                RouteCode = c.RouteCode,
                SalesInvoices = c.SalesInvoices.Where(si => si.IsPosted).ToList()
            });

            return View(query);
        }

        [Authorize]
        public IActionResult Add()
        {
            return View(new AddCustomerFormModel
            {
                Routes = this.customers.GetRoutes()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCustomerFormModel customer)
        {
            if (this.customers.CustomerNameExists(customer.Name))
            {
                this.ModelState.AddModelError(nameof(customer.Name), ErrorCustomerExists);
            }

            if (!this.routes.RouteExists(customer.RouteId))
            {
                this.ModelState.AddModelError(nameof(customer.RouteId), ErrorRouteExists);
            }

            if (!ModelState.IsValid)
            {
                customer.Routes = this.customers.GetRoutes();

                return View(customer);
            }

            this.customers.Create(
                customer.Name,
                customer.ChainName,
                customer.Address,
                customer.ContactName,
                customer.Email,
                customer.PaymentTerm,
                customer.RouteId);

            TempData[GlobalMessageKey] = AddedCustomerMessage;

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id, string information)
        {
            var customer = this.customers.Details(id);

            if (customer == null)
            {
                return NotFound();
            }

            if (!information.Contains(customer.Name) || !information.Contains(customer.RouteCode))
            {
                return BadRequest();
            }

            return View(customer);
        }
    }
}
