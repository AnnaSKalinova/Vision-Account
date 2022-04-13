namespace AccountingProgram.Services.SalesInvoices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SalesInvoiceServiceModel
    {
        public int Id { get; init; }

        public string CustomerName { get; init; }

        public string PostingDate { get; init; }

        [Display(Name = "Total amount excl. VAT")]
        public decimal TotalAmountExclVat { get; init; }

        public bool IsPosted { get; init; }
    }
}
