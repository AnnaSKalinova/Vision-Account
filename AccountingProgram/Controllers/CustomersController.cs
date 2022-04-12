namespace AccountingProgram.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Models.Customers;
    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Data.Models.Enums;
    using AccountingProgram.Models.Drivers;
    using AccountingProgram.Services.Customers;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;
        private readonly AccountingDbContext data;

        public CustomersController(AccountingDbContext data, ICustomerService customers)
        {
            this.data = data;
            this.customers = customers;
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
            query.Customers = queryResult.Customers.Select(c => new CustomerServiceModel
            {
                Id = c.Id,
                Name = c.Name,
                Route = c.Route
            });

            return View(query);
        }

        [Authorize]
        public IActionResult Add()
        {
            return View(new AddCustomerFormModel
            {
                Routes = GetRoutes()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCustomerFormModel customer)
        {
            if (!this.data.Routes.Any(r => r.Id == customer.RouteId))
            {
                this.ModelState.AddModelError(nameof(customer.RouteId), "Route does not exist!");
            }

            if (!ModelState.IsValid)
            {
                customer.Routes = this.GetRoutes();

                return View(customer);
            }

            var customerData = new Customer
            {
                Name = customer.Name,
                ChainName = customer.ChainName,
                Address = customer.Address,
                ContactName = customer.ContactName,
                Email = customer.Email,
                PaymentTerm = (PaymentTerm)customer.PaymentTerm,
                RouteId = customer.RouteId
            };

            this.data.Customers.Add(customerData);

            this.data.SaveChanges();

            return RedirectToAction("All", "Customers");
        }

        private IEnumerable<RouteCustomerViewModel> GetRoutes()
        {
            return this.data
                .Routes
                .Select(r => new RouteCustomerViewModel
                {
                    Id = r.Id,
                    Code = r.Code
                })
                .ToList();
        }
    }
}
