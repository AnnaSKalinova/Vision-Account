namespace AccountingProgram.Models.Customers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AccountingProgram.Services.Customers.Models;

    using static AccountingProgram.Data.DataConstants.Customer;
    using static AccountingProgram.Data.DataConstants.Item;

    public class AddCustomerFormModel
    {
        [Required]
        [StringLength(
            CustomerNameMaxLength, 
            MinimumLength = CustomerNameMinLength,
            ErrorMessage = ErrorCustomerNameLength)]
        public string Name { get; init; }

        [Display(Name = ChainNameAttribute)]
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

        [Display(Name = ContactNameAttribute)]
        [StringLength(
            ContactNameMaxLength,
            MinimumLength = ContactNameMinLength,
            ErrorMessage = ErrorContactNameLength)]
        public string ContactName { get; init; }

        [EmailAddress(ErrorMessage = ErrorEmailFormat)]
        public string Email { get; init; }

        [Range(RangeMinValueInt, RangeMaxValueInt,
            ErrorMessage = ErrorPaymentTermRequired)]
        [Display(Name = PaymentTermAttribute)]
        public int PaymentTerm { get; set; }

        public int RouteId { get; init; }
        public IEnumerable<RouteCustomerServiceModel> Routes { get; set; }
    }
}
