namespace AccountingProgram.Models.Drivers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AccountingProgram.Services.Routes.Models;

    using static AccountingProgram.Data.DataConstants.Driver;

    public class AddDriverFormModel
    {
        [Required]
        [StringLength(
            DriverNameMaxLength,
            MinimumLength = DriverNameMinLength,
            ErrorMessage = ErrorDriverNameLength)]
        public string Name { get; init; }

        [Display(Name = RoutesAttribute)]
        public int RouteId { get; init; }
        public IEnumerable<RouteServiceModel> Routes { get; set; }
    }
}
