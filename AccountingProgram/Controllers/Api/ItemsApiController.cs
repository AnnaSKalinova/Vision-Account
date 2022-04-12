namespace AccountingProgram.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Models.Api.Items;
    using AccountingProgram.Services.Items;
    using AccountingProgram.Services.Items.Models;

    [ApiController]
    [Route("api/items")]
    public class ItemsApiController : ControllerBase
    {
        private readonly IItemService items;

        public ItemsApiController(IItemService items)
        {
            this.items = items;
        }

        [HttpGet]
        public ItemQueryServiceModel All([FromQuery] AllItemsApiRequestModel query)
        {
            return this.items.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.ItemsPerPage);
        }
    }
}
