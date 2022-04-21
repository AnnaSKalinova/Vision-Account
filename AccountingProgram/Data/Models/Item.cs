namespace AccountingProgram.Data.Models
{    
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AccountingProgram.Data.Models.Enums;

    using static DataConstants.Item;

    public class Item
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ItemNameMaxLength)]
        public string Name { get; set; }

        public ItemType ItemType { get; set; }

        public Measure Measure { get; set; }

        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; init; }

        [Range(RangeMinValueDecimal, double.MaxValue)]
        [Column(TypeName = DecimalTypeAttribute)]
        public decimal UnitPriceExclVat { get; set; }

        public VatGroup VatGroup { get; set; }

        [Range(RangeMinValueDecimal, int.MaxValue)]
        [Column(TypeName = DecimalTypeAttribute)]
        public decimal UnitPriceInclVat { get; set; }

        [Range(RangeMinValueDecimal, double.MaxValue)]
        [Column(TypeName = DecimalTypeAttribute)]
        public decimal UnitCost { get; set; }

        [Range(RangeMaxValueInt, double.MaxValue)]
        [Column(TypeName = DecimalTypeAttribute)]
        public decimal Profit { get; set; }
    }
}
