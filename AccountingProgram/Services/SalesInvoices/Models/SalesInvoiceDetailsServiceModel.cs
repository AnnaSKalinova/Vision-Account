namespace AccountingProgram.Services.SalesInvoices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SalesInvoiceDetailsServiceModel
    {
        public int Id { get; init; }

        public string CustomerName { get; init; }

        public string PostingDate { get; init; }

        [Display(Name = "Total amount excl. VAT")]
        public decimal TotalAmountExclVat { get; init; }

        public bool IsPosted { get; init; }

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
