namespace AccountingProgram.Models.Items
{
    public class ItemListingViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ItemCategory { get; set; }

        public decimal UnitPriceExclVat { get; set; }
                
        public decimal UnitCost { get; set; }
    }
}
