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
    using AccountingProgram.Services.Items;

    public class ItemsController : Controller
    {
        private readonly IItemService items;
        private readonly AccountingDbContext data;

        public ItemsController(AccountingDbContext data, IItemService items)
        {
            this.data = data;
            this.items = items;
        }

        public IActionResult All([FromQuery]SearchItemsQueryModel query)
        {
            var queryResult = this.items.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                SearchItemsQueryModel.ItemsPerPage);

            var itemsCategories = this.items.AllItemsCategories();

            query.TotalItems = queryResult.TotalItems;
            query.Categories = itemsCategories;
            query.Items = queryResult.Items.Select(i => new ItemServiceModel
            {
                Id = i.Id,
                Name = i.Name,
                ItemCategory = i.ItemCategory,
                UnitPriceExclVat = i.UnitPriceExclVat,
                UnitCost = i.UnitCost
            });

            return View(query);
        }

        [Authorize]
        public IActionResult Add()
        {
            return View(new AddItemFormModel
            {
                ItemCategories = this.GetItemCategories()
            });
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
