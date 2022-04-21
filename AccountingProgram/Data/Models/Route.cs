namespace AccountingProgram.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Route;

    public class Route
    {
        public int Id { get; init; }
        
        [Required]
        [RegularExpression(RouteCodeRegex,
            ErrorMessage = ErrorRouteCodeRegex)]
        public char Code { get; set; }

        [Required]
        [MaxLength(RouteDescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<Customer> Customers { get; init; } = new HashSet<Customer>();
    }
}
