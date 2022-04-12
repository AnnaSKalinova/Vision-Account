namespace AccountingProgram.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Models.Api.SalesInvoices;
    using AccountingProgram.Services.SalesInvoices;
    using AccountingProgram.Services.SalesInvoices.Models;

    [ApiController]
    [Route("api/salesInvoices")]
    public class SalesInvoicesApiController : ControllerBase
    {
        private readonly ISalesInvoiceService salesInvoices;

        public SalesInvoicesApiController(ISalesInvoiceService salesInvoices)
        {
            this.salesInvoices = salesInvoices;
        }

        [HttpGet]
        public SalesInvoiceQueryServiceModel All([FromQuery] AllSalesInvoicesApiRequestModel query)
        {
            return this.salesInvoices.All(
                query.Chain,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.SalesInvoicesPerPage);
        }
    }
}
