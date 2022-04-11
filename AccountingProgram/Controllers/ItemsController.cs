namespace AccountingProgram.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
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
