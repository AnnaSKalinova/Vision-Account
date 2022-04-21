namespace AccountingProgram.Services.Customers.Models
{
    using System.Collections.Generic;

    using AccountingProgram.Services.SalesInvoices.Models;

    public class CustomerServiceModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public char RouteCode { get; init; }

        public int PaymentTerm { get; init; }

        public ICollection<SalesInvoiceDetailsServiceModel> SalesInvoices { get; init; }
    }
}
