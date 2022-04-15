namespace AccountingProgram.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static AccountingProgram.Data.DataConstants.Accountant;

    public class Accountant
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(AccountantNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserId { get; set; }

        public IEnumerable<SalesInvoice> SalesInvoices { get; init; } = new List<SalesInvoice>();
    }
}
