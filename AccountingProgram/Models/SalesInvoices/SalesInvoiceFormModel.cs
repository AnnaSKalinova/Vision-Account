namespace AccountingProgram.Models.SalesInvoices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AccountingProgram.Services.Customers;
    using AccountingProgram.Services.Items;

    public class SalesInvoiceFormModel
    {
        public int CustomerId { get; init; }
        public IEnumerable<CustomerServiceModel> Customers { get; set; }

        [Required]
        [Display(Name = "Posting Date")]
        [Range(typeof(DateTime), "01.01.2022", "31.12.2022",
                    ErrorMessage = "Posting Date must be a date in year 2022")]
        public string PostingDate { get; init; }

        public int ItemId { get; init; }
        public IEnumerable<ItemServiceModel> Items { get; set; }

        [Range(1, int.MaxValue)]
        public int Count { get; init; }

        public int AccountantId { get; init; }
    }
}
