namespace AccountingProgram.Areas.ChefAccountant.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ChefAccountantConstants;

    [Area(AreaName)]
    [Authorize(Roles = ChefAccountantRoleName)]
    public abstract class ChefAccountantController : Controller
    {

    }
}
