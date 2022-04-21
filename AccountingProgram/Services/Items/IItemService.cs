namespace AccountingProgram.Services.Items
{
    using System.Collections.Generic;
    using AccountingProgram.Models.Items;
    using AccountingProgram.Services.Items.Models;

    public interface IItemService
    {
        ItemQueryServiceModel All(
            string category, 
            string searchTerm, 
            ItemSorting sorting,
            int currentPage = 1,
            int itemsPerPage = SearchItemsQueryModel.ItemsPerPage);

        int Create(
            string name,
            int itemType,
            int measure,
            int itemCategoryId,
            decimal unitPriceExclVat,
            int vatGroup,
            decimal unitCost);

        ItemDetailsServiceModel Details(int id);

        IEnumerable<ItemCategoryServiceModel> AllItemsCategories();

        IEnumerable<ItemServiceModel> AllItems();

        bool ItemExists(int id);

        bool ItemCategoryExists(int id);


        bool ItemNameExists(string name);
    }
}
