namespace AccountingProgram.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
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
