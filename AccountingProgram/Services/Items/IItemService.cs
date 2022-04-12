namespace AccountingProgram.Services.Items
{
    using System.Collections.Generic;
    using AccountingProgram.Models.Items;
    using AccountingProgram.Services.Items.Models;

    public interface IItemService
    {
        ItemQueryServiceModel All(string category, string searchTerm, ItemSorting sorting, int currentPage, int itemsPerPage);

        IEnumerable<ItemCategoryServiceModel> AllItemsCategories();

        IEnumerable<ItemServiceModel> AllItems();

        bool ItemExists(int id);

        bool ItemCategoryExists(int id);

        int Create(
            string name, 
            int itemType, 
            int measure, 
            int itemCategoryId, 
            decimal UnitPriceExclVat, 
            int vatGroup, 
            decimal unitCost);

    }
}
