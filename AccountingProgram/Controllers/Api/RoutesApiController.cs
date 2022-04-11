namespace AccountingProgram.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Models.Api.Routes;
    using AccountingProgram.Services.Routes;

    [ApiController]
    [Route("api/routes")]
    public class RoutesApiController : ControllerBase
    {
        private readonly IRouteService routes;

        public RoutesApiController(IRouteService routes)
        {
            this.routes = routes;
        }

        [HttpGet]
        public RouteQueryServiceModel All([FromQuery] AllRoutesApiRequestModel query)
        {
            return this.routes.All(
                query.Code,
                query.Sorting,
                query.CurrentPage,
                query.RoutesPerPage);
        }
    }
}
