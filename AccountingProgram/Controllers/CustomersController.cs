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

    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;
        private readonly IRouteService routes;

        public CustomersController(ICustomerService customers, IRouteService routes)
        {
            this.customers = customers;
            this.routes = routes;
        }

        public IActionResult All([FromQuery]SearchCustomersQueryModel query)
        {
            var queryResult = this.customers.All(
                query.Chain,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                SearchCustomersQueryModel.CustomersPerPage);

            var customersChains = this.customers.AllCustomersChains();

            query.TotalCustomers = queryResult.TotalCustomers;
            query.Chains = customersChains;
            query.Customers = queryResult
                .Customers
                .Select(c => new CustomerServiceModel
            {
                Id = c.Id,
                Name = c.Name,
                RouteCode = c.RouteCode,
                SalesInvoices = c.SalesInvoices
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
            if (this.routes.RouteExists(customer.RouteId))
            {
                this.ModelState.AddModelError(nameof(customer.RouteId), "Route does not exist!");
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

            TempData[GlobalMessageKey] = "You successfully added a new customer!";

            return RedirectToAction(nameof(All));
        }
    }
}
