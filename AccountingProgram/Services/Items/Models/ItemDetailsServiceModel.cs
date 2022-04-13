namespace AccountingProgram.Services.Items.Models
{
    public class ItemDetailsServiceModel: ItemServiceModel
    {
        public string ItemType { get; init; }

        public decimal UnitPriceInclVat { get; init; }

        public decimal Profit { get; set; }
    }
}
