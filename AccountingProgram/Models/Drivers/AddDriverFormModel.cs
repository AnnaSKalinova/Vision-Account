namespace AccountingProgram.Models.Drivers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static AccountingProgram.Data.DataConstants.Driver;

    public class AddDriverFormModel
    {
        [Required]
        [StringLength(
            DriverNameMaxLength,
            MinimumLength = DriverNameMinLength,
            ErrorMessage = ErrorDriverNameLength)]
        public string Name { get; init; }

        [Display(Name = "Route")]
        public int RouteId { get; init; }
        public IEnumerable<RouteDriverViewModel> Routes { get; set; }
    }
}
