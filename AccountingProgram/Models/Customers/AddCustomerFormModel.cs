namespace AccountingProgram.Models.Customers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AccountingProgram.Models.Drivers;
    using static AccountingProgram.Data.DataConstants;

    public class AddCustomerFormModel
    {
        [Required]
        [StringLength(
            CustomerNameMaxLength, 
            MinimumLength = CustomerNameMinLength,
            ErrorMessage = ErrorCustomerNameLength)]
        public string Name { get; init; }

        [Display(Name = "Chain Name")]
        [StringLength(
            ChainNameMaxLength, 
            MinimumLength = ChainNameMinLength,
            ErrorMessage = ErrorChainNameLength)]
        public string ChainName { get; init; }

        [StringLength(
            CustomerAddressMaxLength,
            MinimumLength = CustomerAddressMinLength,
            ErrorMessage = ErrorAddressLength)]
        public string Address { get; init; }

        [Display(Name = "Contact Name")]
        [StringLength(
            ContactNameMaxLength,
            MinimumLength = ContactNameMinLength,
            ErrorMessage = ErrorContactNameLength)]
        public string ContactName { get; init; }

        [EmailAddress(ErrorMessage = ErrorEmailFormat)]
        public string Email { get; init; }

        [Range(0, 100)]
        [Display(Name = "Payment Terms Code")]
        public int PaymentTerm { get; set; }

        public int RouteId { get; init; }
        public IEnumerable<RouteCustomerViewModel> Routes { get; set; }
    }
}
