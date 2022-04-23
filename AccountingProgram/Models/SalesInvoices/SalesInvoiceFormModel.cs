namespace AccountingProgram.Models.SalesInvoices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AccountingProgram.Services.Customers.Models;
    using AccountingProgram.Services.Items.Models;

    using static Data.DataConstants.Customer;
    using static Data.DataConstants.SalesInvoices;
    using static Data.DataConstants.Item;

    public class SalesInvoiceFormModel
    {
        public int Id { get; init; }

        [Display(Name = CustomerNameAttribute)]
        public int CustomerId { get; init; }
        public IEnumerable<CustomerServiceModel> Customers { get; set; }

        [Required]
        [Display(Name = PostingDateAttribute)]
        [Range(typeof(DateTime), StartDateAttribute, EndDateAttribute,
                    ErrorMessage = ErrorValuePostingDate)]
        public string PostingDate { get; init; }

        [Display(Name = VatGroupAttribute)]
        [Range(0, 100)]
        public int VatGroup { get; init; }

        [Display(Name = ItemNameAttribute)]
        public int ItemId { get; init; }
        public IEnumerable<ItemServiceModel> Items { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = ErrorCounRange)]
        public int Count { get; init; }

        public int AccountantId { get; init; }

        [Display(Name = PaymentTermAttribute)]
        public decimal Profit { get; init; }
    }
}
