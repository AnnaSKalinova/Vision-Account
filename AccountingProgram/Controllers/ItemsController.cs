namespace AccountingProgram.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using AccountingProgram.Models.Items;
    using AccountingProgram.Services.Items;
    using AccountingProgram.Services.Items.Models;

    using static WebConstants;
    using static Data.DataConstants.Item;
    using static Data.DataConstants.Category;

    public class ItemsController : Controller
    {
        private readonly IItemService items;

        public ItemsController(IItemService items)
        {
            this.items = items;
        }

        public IActionResult All(
            [FromQuery] string category,
            [FromQuery] string searchTerm,
            [FromQuery] ItemSorting sorting,
            [FromQuery] int currentPage = 1,
            [FromQuery] int itemsPerPage = SearchItemsQueryModel.ItemsPerPage)
        {
            var queryResult = this.items.All(
                category,
                searchTerm,
                sorting,
                currentPage,
                itemsPerPage);

            var itemsCategories = this.items.AllItemsCategories();

            SearchItemsQueryModel query = new SearchItemsQueryModel
            {
                Category = category,
                SearchTerm = searchTerm,
                Sorting = sorting,
                CurrentPage = currentPage
            };

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
            if (this.items.ItemNameExists(item.Name))
            {
                this.ModelState.AddModelError(nameof(item.Name), ErrorItemNameExist);
            }

            if (!this.items.ItemCategoryExists(item.ItemCategoryId))
            {
                this.ModelState.AddModelError(nameof(item.ItemCategoryId), ErrorCategoryDoesNotExist);
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

            TempData[GlobalMessageKey] = AddedItemMessage;

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id, string information)
        {
            var item = this.items.Details(id);

            if (item == null)
            {
                return NotFound();
            }

            if (!information.Contains(item.Name) || !information.Contains(item.ItemCategory))
            {
                return BadRequest();
            }

            return View(item);
        }
    }
}
