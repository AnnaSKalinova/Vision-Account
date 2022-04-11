namespace AccountingProgram.Services.SalesInvoices
{
    using System.ComponentModel.DataAnnotations;

    public class ItemServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Range(1, 100)]
        public int Measure { get; set; }

        public decimal UnitPriceExclVat { get; set; }

        public int VatGroup { get; set; }
    }
}
