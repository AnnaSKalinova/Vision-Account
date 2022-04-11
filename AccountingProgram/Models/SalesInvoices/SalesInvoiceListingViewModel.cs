namespace AccountingProgram.Models.SalesInvoices
{
    public class SalesInvoiceListingViewModel
    {
        public int Id { get; init; }

        public string Customer { get; init; }

        public string PostingDate { get; init; }

        public decimal TotalAmountExclVat { get; init; }

        public decimal TotalAmountInclVat { get; init; }
    }
}
