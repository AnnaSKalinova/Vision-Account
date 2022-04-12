namespace AccountingProgram.Models.Items
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AccountingProgram.Services.Items;
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

        [Display(Name = "Item Type")]
        [Range(1, 100)]
        public int ItemType { get; init; }

        [Range(0, 100)]
        public int Measure { get; init; }

        [Display(Name = "Item Category")]
        public int ItemCategoryId { get; init; }
        public IEnumerable<ItemCategoryServiceModel> ItemCategories { get; set; }

        [Display(Name = "Unit Price excl. VAT")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPriceExclVat { get; init; }

        [Display(Name = "VAT Group")]
        [Range(0, 100)]
        public int VatGroup { get; init; }

        [Display(Name = "Unit Price incl. VAT")]
        public decimal UnitPriceInclVat
        {
            get
            {
                return (this.UnitPriceExclVat + (int)this.VatGroup * this.UnitPriceExclVat / 100);
            }
        }

        [Display(Name = "Unit Cost")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitCost { get; init; }

        [Display(Name = "Profit %")]
        public decimal Profit
        {
            get
            {
                return ((1 - this.UnitCost / this.UnitPriceExclVat) * 100);
            }
        }
    }
}
