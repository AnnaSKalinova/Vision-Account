namespace AccountingProgram.Models.Items
{    
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AccountingProgram.Services.Items.Models;

    using static AccountingProgram.Data.DataConstants.Item;
    using static AccountingProgram.Data.DataConstants;

    public class SearchItemsQueryModel
    {
        public const int ItemsPerPage = CountPerPage;

        public string Category { get; init; }

        public IEnumerable<ItemCategoryServiceModel> Categories { get; set; }

        [Display(Name = ItemNameAttribute)]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalItems { get; set; }

        public ItemSorting Sorting { get; init; }

        public IEnumerable<ItemServiceModel> Items { get; set; }
    }
}
