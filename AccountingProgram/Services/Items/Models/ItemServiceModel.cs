namespace AccountingProgram.Services.Items.Models
{
    public class ItemServiceModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string Measure { get; set; }

        public string ItemCategory { get; init; }

        public decimal UnitPriceExclVat { get; init; }

        public int VatGroup { get; init; }

        public decimal UnitCost { get; init; }
    }
}
