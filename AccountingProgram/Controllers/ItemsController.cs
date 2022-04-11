namespace AccountingProgram.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Models.Items;
    using AccountingProgram.Data;
    using AccountingProgram.Data.Models;
    using AccountingProgram.Data.Models.Enums;
    
    public class ItemsController : Controller
    {
        private readonly AccountingDbContext data;

        public ItemsController(AccountingDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            return View(new AddItemFormModel
            { 
                ItemCategories = this.GetItemCategories()
            });
        }

        public IActionResult All([FromQuery]SearchItemsQueryModel query)
        {
            var itemsQuery = this.data.Items.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Category))
            {
                itemsQuery = itemsQuery.Where(i =>
                    i.ItemCategory.Name == query.Category);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                itemsQuery = itemsQuery.Where(i =>
                    i.Name.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            itemsQuery = query.Sorting switch
            {
                ItemSorting.Name => itemsQuery.OrderBy(i => i.Name),
                ItemSorting.Category => itemsQuery.OrderBy(i => i.ItemCategory.Name),
                ItemSorting.UnitPriceExclVat => itemsQuery.OrderBy(i => i.UnitPriceExclVat),
                ItemSorting.UnitCost => itemsQuery.OrderBy(i => i.UnitCost),
                _ => itemsQuery.OrderBy(i => i.Name)
            };

            var totalItems = itemsQuery.Count();

            var items = itemsQuery
                .Skip((query.CurrentPage - 1) * SearchItemsQueryModel.ItemsPerPage)
                .Take(SearchItemsQueryModel.ItemsPerPage)
                .Select(i => new ItemListingViewModel
                {
                    Name = i.Name,
                    ItemCategory = i.ItemCategory.Name,
                    UnitPriceExclVat = i.UnitPriceExclVat,
                    UnitCost = i.UnitCost
                })
                .ToList();

            var itemsCategories = this.data
                .Items
                .Select(i => i.ItemCategory.Name)
                .OrderBy(i => i)
                .Distinct()
                .ToList();

            query.TotalItems = totalItems;
            query.Categories = itemsCategories;
            query.Items = items;

            return View(query);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddItemFormModel item)
        {
            if (!this.data.ItemCategories.Any(c => c.Id == item.ItemCategoryId))
            {
                this.ModelState.AddModelError(nameof(item.ItemCategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                item.ItemCategories = this.GetItemCategories();

                return View(item);
            }

            var itemData = new Item
            {
                Name = item.Name,
                ItemType = (ItemType)item.ItemType,
                Measure = (Measure)item.Measure,
                ItemCategoryId = item.ItemCategoryId,
                UnitPriceExclVat = item.UnitPriceExclVat,
                VatGroup = (VatGroup)item.VatGroup,
                UnitCost = item.UnitCost,
                //VendorId = item.VendorId
            };

            this.data.Items.Add(itemData);

            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<ItemCategoryViewModel> GetItemCategories()
        {
            return this.data
                .ItemCategories
                .Select(c => new ItemCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
        }
    }
}
