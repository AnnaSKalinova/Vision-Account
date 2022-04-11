namespace AccountingProgram.Models.Routes
{
    using System.ComponentModel.DataAnnotations;

    using static AccountingProgram.Data.DataConstants.Route;

    public class AddRouteFormModel
    {
        [Required]
        [RegularExpression(RouteCodeRegex,
            ErrorMessage = ErrorRouteCodeRegex)]
        public char Code { get; init; }

        [Required]
        [StringLength(
            RouteDescriptionMaxLength,
            MinimumLength = RouteDescriptionMinLength,
            ErrorMessage = ErrorRouteDescriptionLength)]
        public string Description { get; init; }
    }
}
