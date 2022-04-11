namespace AccountingProgram.Models.Items
{    
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SearchItemsQueryModel
    {
        public const int ItemsPerPage = 2;

        public string Category { get; init; }

        public IEnumerable<string> Categories { get; set; }

        [Display(Name = "Item name")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalItems { get; set; }

        public ItemSorting Sorting { get; init; }

        public IEnumerable<ItemListingViewModel> Items { get; set; }
    }
}
