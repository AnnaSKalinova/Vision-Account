namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Models.Items;
    using AccountingProgram.Services.Items;
    using AccountingProgram.Services.Items.Models;

    using static WebConstants;

    public class ItemsController : Controller
    {
        private readonly IItemService items;

        public ItemsController(IItemService items)
        {
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
                ItemCategories = this.items.AllItemsCategories()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddItemFormModel item)
        {
            if (this.items.ItemCategoryExists(item.ItemCategoryId))
            {
                this.ModelState.AddModelError(nameof(item.ItemCategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                item.ItemCategories = this.items.AllItemsCategories();

                return View(item);
            }

            this.items.Create(
                item.Name,
                item.ItemType,
                item.Measure,
                item.ItemCategoryId,
                item.UnitPriceExclVat,
                item.VatGroup,
                item.UnitCost);

            TempData[GlobalMessageKey] = "You successfully added a new item!";

            return RedirectToAction(nameof(All));
        }
    }
}
