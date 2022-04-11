namespace AccountingProgram.Services.Items
{
    public class ItemServiceModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string ItemCategory { get; init; }

        public decimal UnitPriceExclVat { get; init; }

        public decimal VatGroup { get; init; }

        public decimal UnitCost { get; init; }
    }
}
