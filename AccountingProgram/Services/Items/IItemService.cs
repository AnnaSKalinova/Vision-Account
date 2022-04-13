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
            int salesInvoicesPerPage = int.MaxValue);

        IEnumerable<ItemCategoryServiceModel> AllItemsCategories();

        IEnumerable<ItemServiceModel> AllItems();

        ItemDetailsServiceModel Details(int id);

        bool ItemExists(int id);

        bool ItemCategoryExists(int id);

        int Create(
            string name, 
            int itemType, 
            int measure, 
            int itemCategoryId, 
            decimal unitPriceExclVat, 
            int vatGroup, 
            decimal unitCost);

    }
}
