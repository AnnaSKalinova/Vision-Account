namespace AccountingProgram.Data.Models
{
    using System;

    public class SalesInvoice
    {
        public int Id { get; init; }

        public int CustomerId { get; set; }
        public Customer Customer { get; init; }

        public DateTime PostingDate { get; set; }

        public DateTime DueDate { get; }

        public int ItemId { get; set; }
        public Item Item{ get; init; }

        public int Count { get; set; }

        public decimal TotalAmountExclVat { get; }

        public decimal Vat { get; }

        public decimal TotalAmountInclVat { get; }

        public int AccountantId { get; init; }
        public Accountant Accountant { get; init; }
    }
}
