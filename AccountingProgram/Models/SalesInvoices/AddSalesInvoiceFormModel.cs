namespace AccountingProgram.Models.SalesInvoices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AccountingProgram.Views.SalesInvoices;

    public class AddSalesInvoiceFormModel
    {
        public int CustomerId { get; init; }
        public IEnumerable<CustomerViewModel> Customers { get; set; }

        [Required]
        [Display(Name = "Posting Date")]
        [Range(typeof(DateTime), "01.01.2022", "31.12.2022",
                    ErrorMessage = "Posting Date must be a date in year 2022")]
        public string PostingDate { get; init; }

        public int ItemId { get; init; }
        public IEnumerable<ItemViewModel> Items { get; set; }

        [Range(1, int.MaxValue)]
        public int Count { get; init; }
    }
}
