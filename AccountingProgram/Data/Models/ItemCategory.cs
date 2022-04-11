namespace AccountingProgram.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class ItemCategory
    {
        public int Id { get; set; }   

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
