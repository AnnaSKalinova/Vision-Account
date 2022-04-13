namespace AccountingProgram.Services.Items
{
    using System.Collections.Generic;
    using System.Linq;

    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Data.Models.Enums;
    using AccountingProgram.Models.Items;
    using AccountingProgram.Services.Items.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class ItemService : IItemService
    {
        private readonly AccountingDbContext data;
        private readonly IConfigurationProvider mapper;

        public ItemService(AccountingDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }

        public ItemQueryServiceModel All(
            string category, 
            string searchTerm, 
            ItemSorting sorting, 
            int currentPage = 1, 
            int itemsPerPage = int.MaxValue)
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
                .ProjectTo<ItemServiceModel>(this.mapper)
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
                .ProjectTo<ItemServiceModel>(mapper)
                .ToList();
        }

        public IEnumerable<ItemCategoryServiceModel> AllItemsCategories()
        {
            return this.data
                .ItemCategories
                .ProjectTo<ItemCategoryServiceModel>(this.mapper)
                .ToList();
        }

        public int Create(string name, int itemType, int measure, int itemCategoryId, decimal unitPriceExclVat, int vatGroup, decimal unitCost)
        {
            var unitPriceInclVat = unitPriceExclVat + (unitPriceExclVat * vatGroup / 100);
            var profit = (1 - unitCost / unitPriceExclVat) * 100;

            var itemData = new Item
            {
                Name = name,
                ItemType = (ItemType)itemType,
                Measure = (Measure)measure,
                ItemCategoryId = itemCategoryId,
                UnitPriceExclVat = unitPriceExclVat,
                VatGroup = (VatGroup)vatGroup,
                UnitPriceInclVat = unitPriceInclVat,
                UnitCost = unitCost,
                Profit = profit
            };

            this.data.Items.Add(itemData);

            this.data.SaveChanges();

            return itemData.Id;
        }

        public ItemDetailsServiceModel Details(int id)
        {
            return this.data
                .Items
                .Where(i => i.Id == id)
                .ProjectTo<ItemDetailsServiceModel>(this.mapper)
                .FirstOrDefault();
        }

        public bool ItemCategoryExists(int id)
        {
            return !this.data.ItemCategories.Any(ic => ic.Id == id);
        }

        public bool ItemExists(int id)
        {
            return !this.data.Items.Any(i => i.Id == id);
        }
    }
}
