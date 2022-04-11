namespace AccountingProgram.Data.Models
{
    using System;

    public class SalesInvoice
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime PostingDate { get; set; }

        public DateTime DueDate { get; }

        public int ItemId { get; set; }
        public Item Item{ get; set; }

        public int Count { get; set; }

        public decimal TotalAmountExclVat { get; }

        public decimal Vat { get; }

        public decimal TotalAmountInclVat { get; }
    }
}
