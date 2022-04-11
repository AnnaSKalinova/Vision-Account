namespace AccountingProgram.Services.Items
{
    using System.Collections.Generic;
    using AccountingProgram.Models.Items;

    public interface IItemService
    {
        ItemQueryServiceModel All(string category, string searchTerm, ItemSorting sorting, int currentPage, int itemsPerPage);

        IEnumerable<string> AllItemsCategories();
    }
}
