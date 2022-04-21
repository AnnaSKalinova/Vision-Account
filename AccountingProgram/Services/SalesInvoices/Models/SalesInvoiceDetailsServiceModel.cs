namespace AccountingProgram.Services.SalesInvoices.Models
{
    using System.ComponentModel.DataAnnotations;

    using static AccountingProgram.Data.DataConstants.SalesInvoices;

    public class SalesInvoiceDetailsServiceModel
    {
        public int Id { get; init; }

        public string CustomerName { get; init; }

        public string PostingDate { get; init; }

        [Display(Name = TotalPriceExclVatAttribute)]
        public decimal TotalPriceExclVat { get; init; }

        public bool IsPosted { get; init; }

        public string DueDate { get; init; }

        public string ItemName { get; init; }
        public int ItemId { get; init; }

        public int Count { get; init; }

        [Display(Name = VatAttribute)]
        public decimal Vat { get; init; }

        [Display(Name = TotalPriceInclVatAttribute)]
        public decimal TotalPriceInclVat { get; init; }

        public int CustomerId { get; init; }

        public int AccountantId { get; init; }
        public string AccountantName { get; init; }

        public string UserId { get; init; }

        public decimal Profit { get; init; }
    }
}
