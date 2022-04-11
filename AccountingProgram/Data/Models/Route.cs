namespace AccountingProgram.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Route
    {
        public int Id { get; set; }
        
        [Required]
        [RegularExpression(RouteCodeRegex,
            ErrorMessage = ErrorRouteCodeRegex)]
        public char Code { get; set; }

        [Required]
        [MaxLength(RouteDescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
    }
}
