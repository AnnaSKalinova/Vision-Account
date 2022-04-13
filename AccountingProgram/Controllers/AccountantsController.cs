namespace AccountingProgram.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    using AccountingProgram.Models.Accountants;
    using AccountingProgram.Infrastructure;
    using AccountingProgram.Services.Accountants;

    using static WebConstants;

    public class AccountantsController : Controller
    {
        private readonly IAccountantService accountants;

        public AccountantsController(IAccountantService accountants)
        {
            this.accountants = accountants;
        }

        [Authorize]
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeAccountantFormModel accountant)
        {
            var userId = this.User.GetId();

            var userIsAlreadyAccountant = this.accountants.UserIsAlreadyAccountant(userId);

            if (userIsAlreadyAccountant)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(accountant);
            }

            this.accountants.Create(
                accountant.Name,
                accountant.PhoneNumber,
                userId);

            TempData[GlobalMessageKey] = "You are already Accountant!";

            return RedirectToAction("Index", "Home");
        }
    }
}
