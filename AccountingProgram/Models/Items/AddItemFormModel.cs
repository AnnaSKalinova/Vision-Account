namespace AccountingProgram.Models.Items
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AccountingProgram.Services.Items.Models;

    using static AccountingProgram.Data.DataConstants.Item;

    public class AddItemFormModel
    {
        [Required]
        [MaxLength(ItemNameMaxLength)]
        [StringLength(
            ItemNameMaxLength,
            MinimumLength = ItemNameMinLength,
            ErrorMessage = ErrorItemNameLength)]
        public string Name { get; init; }

        [Display(Name = ItemTypeAttribute)]
        [Range(RangeMinValueInt, RangeMaxValueInt,
            ErrorMessage = ErrorItemTypeRequired)]
        public int ItemType { get; init; }

        [Range(RangeMinValueInt, RangeMaxValueInt,
            ErrorMessage = ErrorMeasureRequired)]
        public int Measure { get; init; }

        [Range(RangeMinValueInt, RangeMaxValueInt,
            ErrorMessage = ErrorItemCategoryRequired)]
        [Display(Name = ItemCategoryAttribute)]
        public int ItemCategoryId { get; init; }
        public IEnumerable<ItemCategoryServiceModel> ItemCategories { get; set; }

        [Display(Name = UnitPriceExclVatAttribute)]
        [Column(TypeName = DecimalTypeAttribute)]
        [Range(RangeMinValueDecimal, RangeMaxValueInt,
            ErrorMessage = ErrorUnitPriceExclVatRequired)]
        public decimal UnitPriceExclVat { get; init; }

        [Display(Name = VatGroupAttribute)]
        [Range(RangeMinValueInt, RangeMaxValueInt,
            ErrorMessage = ErrorVatGroupRequired)]
        public int VatGroup { get; init; }

        [Display(Name = UnitPriceInclVatAttribute)]
        [Range(RangeMinValueDecimal, RangeMaxValueInt)]
        public decimal UnitPriceInclVat
        {
            get
            {
                return (this.UnitPriceExclVat + (int)this.VatGroup * this.UnitPriceExclVat / 100);
            }
        }

        [Display(Name = UnitCostAttribute)]
        [Column(TypeName = DecimalTypeAttribute)]
        [Range(RangeMinValueDecimal, RangeMaxValueInt,
            ErrorMessage = ErrorUnitCostRequired)]
        public decimal UnitCost { get; init; }

        [Display(Name = ProfitAttribute)]
        [Column(TypeName = DecimalTypeAttribute)]
        [Range(RangeMinValueDecimal, RangeMaxValueInt,
            ErrorMessage = ErrorUnitCostRequired)]
        public decimal Profit
        {
            get
            {
                if (this.UnitPriceExclVat == 0)
                {
                    return 0;
                }

                return (1 - this.UnitCost / this.UnitPriceExclVat) * 100;
            }
        }
    }
}
