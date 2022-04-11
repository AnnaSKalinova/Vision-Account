namespace AccountingProgram.Services.SalesInvoices
{
    using System.ComponentModel.DataAnnotations;

    public class SalesInvoiceDetailsServiceModel : SalesInvoiceServiceModel
    {
        public string DueDate { get; init; }

        public string Item { get; init; }
        public int ItemId { get; init; }

        public int Count { get; init; }

        [Display(Name = "VAT")]
        public decimal Vat { get; init; }

        public int CustomerId { get; init; }
        public string CustomerName { get; init; }

        public int AccountantId { get; init; }
        public string AccountantName { get; init; }

        public string UserId { get; init; }
    }
}
