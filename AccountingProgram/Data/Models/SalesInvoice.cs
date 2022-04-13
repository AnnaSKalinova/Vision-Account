namespace AccountingProgram.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SalesInvoice
    {
        public int Id { get; init; }

        public int CustomerId { get; set; }
        public Customer Customer { get; init; }

        public DateTime PostingDate { get; set; }

        public DateTime DueDate { get; set; }

        public int ItemId { get; set; }
        public Item Item{ get; init; }

        public int Count { get; set; }

        public decimal TotalAmountExclVat { get; set; }

        public decimal Vat { get; set; }

        public decimal TotalAmountInclVat { get; set; }

        public int AccountantId { get; init; }
        public Accountant Accountant { get; init; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Profit { get; init; }
    }
}
