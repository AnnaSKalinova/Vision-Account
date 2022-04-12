namespace AccountingProgram.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Models.Api.Customers;
    using AccountingProgram.Services.Customers;
    using AccountingProgram.Services.Customers.Models;

    [ApiController]
    [Route("api/customers")]
    public class CustomersApiController : ControllerBase
    {
        private readonly ICustomerService customers;

        public CustomersApiController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [HttpGet]
        public CustomerQueryServiceModel All([FromQuery] AllCustomersApiRequestModel query)
        {
            return this.customers.All(
                query.Chain,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.CustomersPerPage);
        }
    }
}
