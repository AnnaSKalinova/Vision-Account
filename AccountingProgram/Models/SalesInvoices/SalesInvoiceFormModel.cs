namespace AccountingProgram.Models.SalesInvoices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AccountingProgram.Services.Customers.Models;
    using AccountingProgram.Services.Items.Models;

    using static Data.DataConstants.Customer;

    public class SalesInvoiceFormModel
    {
        [Display(Name = "Customer")]
        public int CustomerId { get; init; }
        public IEnumerable<CustomerServiceModel> Customers { get; set; }

        [Required]
        [Display(Name = "Posting Date")]
        [Range(typeof(DateTime), "01.01.2022", "31.12.2022",
                    ErrorMessage = ErrorValuePostingDate)]
        public string PostingDate { get; init; }

        public int VatGroup { get; init; }

        [Display(Name = "Item")]
        public int ItemId { get; init; }
        public IEnumerable<ItemServiceModel> Items { get; set; }

        [Range(1, int.MaxValue)]
        public int Count { get; init; }

        public int AccountantId { get; init; }

        public decimal Profit { get; init; }
    }
}
