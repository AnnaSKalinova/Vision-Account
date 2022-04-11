using AccountingProgram.Models.Items;

namespace AccountingProgram.Models.Api.Items
{
    public class AllItemsApiRequestModel
    {
        public string Category { get; init; }

        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int ItemsPerPage { get; init; } = 6;

        public int TotalItems { get; init; }

        public ItemSorting Sorting { get; init; }
    }
}
