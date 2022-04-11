namespace AccountingProgram.Data.Models
{    
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AccountingProgram.Data.Models.Enums;

    using static DataConstants;

    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ItemNameMaxLength)]
        public string Name { get; set; }

        public ItemType ItemType { get; set; }

        public Measure Measure { get; set; }

        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPriceExclVat { get; set; }

        public VatGroup VatGroup { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPriceIncVat { get; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitCost { get; set; }

        //public int VendorId { get; set; }
        //public Vendor Vendor { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Profit { get; }
    }
}
