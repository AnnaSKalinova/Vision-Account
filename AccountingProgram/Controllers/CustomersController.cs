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

    public class CustomersController : Controller
    {
        private readonly AccountingDbContext data;

        public CustomersController(AccountingDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            return View(new AddCustomerFormModel
            {
                Routes = GetRoutes()
            });
        }

        public IActionResult All([FromQuery]SearchCustomersQueryModel query)
        {
            var customersQuery = this.data.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Chain))
            {
                customersQuery = customersQuery.Where(c =>
                    c.ChainName == query.Chain);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                customersQuery = customersQuery.Where(c =>
                    c.Name.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            customersQuery = query.Sorting switch
            {
                CustomerSorting.Id => customersQuery.OrderBy(c => c.Id),
                CustomerSorting.Name => customersQuery.OrderBy(c => c.Name),
                CustomerSorting.Chain => customersQuery.OrderBy(c => c.ChainName),
                CustomerSorting.Route => customersQuery.OrderBy(c => c.Route.Code),
                CustomerSorting.TotalInvoices => customersQuery.OrderBy(c => c.SalesInvoices.Count),
                _ => customersQuery.OrderBy(c => c.Id)
            };

            var totalCustomers = customersQuery.Count();

            var customers = customersQuery
                .Skip((query.CurrentPage - 1) * SearchCustomersQueryModel.CustomersPerPage)
                .Take(SearchCustomersQueryModel.CustomersPerPage)
                .Select(c => new CustomerListingViewModel
                {
                    Name = c.Name,
                    Route = c.Route.Code,
                    SalesInvoices = c.SalesInvoices.Count
                })
                .ToList();

            var customerChains = this.data
                .Customers
                .Select(c => c.ChainName)
                .OrderBy(c => c)
                .Distinct()
                .ToList();

            query.TotalCustomers = totalCustomers;
            query.Chains = customerChains;
            query.Customers = customers;

            return View(query);
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

            return RedirectToAction("Index", "Home");
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
