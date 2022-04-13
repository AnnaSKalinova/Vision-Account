namespace AccountingProgram.Services.SalesInvoices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SalesInvoiceDetailsServiceModel : SalesInvoiceServiceModel
    {
        public string DueDate { get; init; }

        public string ItemName { get; init; }
        public int ItemId { get; init; }

        public int Count { get; init; }

        [Display(Name = "VAT")]
        public decimal Vat { get; init; }

        [Display(Name = "Total amount incl. VAT")]
        public decimal TotalAmountInclVat { get; init; }

        public int CustomerId { get; init; }

        public int AccountantId { get; init; }
        public string AccountantName { get; init; }

        public string UserId { get; init; }

        public decimal Profit { get; init; }
    }
}
