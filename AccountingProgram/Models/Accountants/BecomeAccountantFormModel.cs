namespace AccountingProgram.Models.Accountants
{
    using System.ComponentModel.DataAnnotations;

    using static AccountingProgram.Data.DataConstants.Accountant;

    public class BecomeAccountantFormModel
    {
        [Required]
        [StringLength(
            AccountantNameMaxLength,
            MinimumLength = AccountantNameMinLength,
            ErrorMessage = ErrorAccountantNameLength)]
        public string Name { get; init; }

        [Required]
        [Display(Name = "Phone number")]
        [RegularExpression(PhoneNumberRegex,
            ErrorMessage = ErrorPhoneNumberRegex)]
        public string PhoneNumber { get; init; }

        public string UserId { get; init; }
    }
}
