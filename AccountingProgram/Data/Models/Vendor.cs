namespace AccountingProgram.Data.Models
{
    using AccountingProgram.Data.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Vendor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(VendorNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(VendorAddressMaxLength)]
        public string Address { get; set; }

        [MaxLength(ContactNameMaxLength)]
        public string ContactName { get; set; }

        [MaxLength(VendorEmailMaxLength)]
        public string Email { get; set; }

        public PaymentTerm PaymentTerm { get; set; }

        public ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }
}
