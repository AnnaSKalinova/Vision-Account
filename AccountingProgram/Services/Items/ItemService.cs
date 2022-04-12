namespace AccountingProgram.Services.Items
{
    using System.Collections.Generic;
    using System.Linq;

    using AccountingProgram.Data;
    using AccountingProgram.Models.Items;

    public class ItemService : IItemService
    {
        private readonly AccountingDbContext data;

        public ItemService(AccountingDbContext data)
        {
            this.data = data;
        }

        public ItemQueryServiceModel All(string category, string searchTerm, ItemSorting sorting, int currentPage, int itemsPerPage)
        {
            var itemsQuery = this.data.Items.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                itemsQuery = itemsQuery.Where(i =>
                    i.ItemCategory.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                itemsQuery = itemsQuery.Where(i =>
                    i.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            itemsQuery = sorting switch
            {
                ItemSorting.Name => itemsQuery.OrderBy(i => i.Name),
                ItemSorting.Category => itemsQuery.OrderBy(i => i.ItemCategory.Name),
                ItemSorting.UnitPriceExclVat => itemsQuery.OrderBy(i => i.UnitPriceExclVat),
                ItemSorting.UnitCost => itemsQuery.OrderBy(i => i.UnitCost),
                _ => itemsQuery.OrderBy(i => i.Name)
            };

            var totalItems = itemsQuery.Count();

            var items = itemsQuery
                .Skip((currentPage - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(i => new ItemServiceModel
                {
                    Name = i.Name,
                    ItemCategory = i.ItemCategory.Name,
                    UnitPriceExclVat = i.UnitPriceExclVat,
                    UnitCost = i.UnitCost
                })
                .ToList();

            return new ItemQueryServiceModel
            {
                CurrentPage = currentPage,
                Items = items,
                ItemsPerPage = itemsPerPage,
                TotalItems = totalItems
            };
        }

        public IEnumerable<ItemServiceModel> AllItems()
        {
            return this.data
                .Items
                .Select(i => new ItemServiceModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    UnitPriceExclVat = i.UnitPriceExclVat,
                    VatGroup = (int)i.VatGroup
                })
                .ToList();
        }

        public IEnumerable<string> AllItemsCategories()
        {
            return this.data
                .Items
                .Select(c => c.ItemCategory.Name)
                .OrderBy(c => c)
                .Distinct()
                .ToList();
        }

        public bool ItemExists(int id)
        {
            return !this.data.Items.Any(i => i.Id == id);
        }
    }
}
