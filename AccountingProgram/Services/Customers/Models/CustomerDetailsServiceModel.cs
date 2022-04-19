namespace AccountingProgram.Services.Customers.Models
{
    using AccountingProgram.Services.SalesInvoices.Models;
    using System.Collections.Generic;

    public class CustomerDetailsServiceModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public char RouteCode { get; init; }

        public int PaymentTerm { get; init; }

        public string ChainName { get; init; }

        public string Address { get; init; }

        public string ContactName { get; init; }

        public string Email { get; init; }
    }
}
