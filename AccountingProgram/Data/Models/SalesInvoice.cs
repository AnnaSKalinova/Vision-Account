namespace AccountingProgram.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static AccountingProgram.Data.DataConstants.Item;

    public class SalesInvoice
    {
        public int Id { get; init; }

        public int CustomerId { get; set; }
        public Customer Customer { get; init; }

        public DateTime PostingDate { get; set; }

        public DateTime DueDate { get; set; }

        public int ItemId { get; set; }
        public Item Item{ get; init; }

        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        [Range(1, double.MaxValue)]
        [Column(TypeName = DecimalTypeAttribute)]
        public decimal TotalPriceExclVat { get; set; }

        [Range(1, double.MaxValue)]
        [Column(TypeName = DecimalTypeAttribute)]
        public decimal Vat { get; set; }

        [Range(1, double.MaxValue)]
        [Column(TypeName = DecimalTypeAttribute)]
        public decimal TotalPriceInclVat { get; set; }

        public int AccountantId { get; init; }
        public Accountant Accountant { get; init; }

        [Range(1, double.MaxValue)]
        [Column(TypeName = DecimalTypeAttribute)]
        public decimal Profit { get; set; }

        public bool isPosted { get; set; }
    }
}
