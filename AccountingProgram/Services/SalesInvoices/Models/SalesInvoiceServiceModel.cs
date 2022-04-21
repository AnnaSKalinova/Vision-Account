namespace AccountingProgram.Services.SalesInvoices.Models
{
    using System.ComponentModel.DataAnnotations;

    using static AccountingProgram.Data.DataConstants.SalesInvoices;

    public class SalesInvoiceServiceModel
    {
        public int Id { get; init; }

        public string CustomerName { get; init; }

        public string PostingDate { get; init; }

        [Display(Name = TotalPriceExclVatAttribute)]
        public decimal TotalPriceExclVat { get; init; }

        public bool IsPosted { get; init; }
    }
}
