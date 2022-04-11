namespace AccountingProgram.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AccountingProgram.Data.Models.Enums;

    using static DataConstants.Customer;

    public class Customer
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(CustomerNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(ChainNameMaxLength)]
        public string ChainName { get; set; }

        [MaxLength(CustomerAddressMaxLength)]
        public string Address { get; set; }

        [MaxLength(ContactNameMaxLength)]
        public string ContactName { get; set; }

        public string Email { get; set; }

        public PaymentTerm PaymentTerm { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }

        public ICollection<SalesInvoice> SalesInvoices { get; set; } = new HashSet<SalesInvoice>();
    }
}
