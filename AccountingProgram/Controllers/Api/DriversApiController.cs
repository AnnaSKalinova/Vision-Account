namespace AccountingProgram.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Models.Api.Drivers;
    using AccountingProgram.Services.Drivers;

    [ApiController]
    [Route("api/drivers")]
    public class DriversApiController : ControllerBase
    {
        private readonly IDriverService drivers;

        public DriversApiController(IDriverService drivers)
        {
            this.drivers = drivers;
        }

        [HttpGet]
        public DriverQueryServiceModel All([FromQuery] AllDriversApiRequestModel query)
        {
            return this.drivers.All(
                query.Route,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.DriversPerPage);
        }
    }
}
