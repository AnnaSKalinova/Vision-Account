namespace AccountingProgram.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Data;
    using AccountingProgram.Models.Accountants;
    using System.Linq;
    using AccountingProgram.Infrastructure;
    using AccountingProgram.Data.Models;

    public class AccountantsController : Controller
    {
        private readonly AccountingDbContext data;

        public AccountantsController(AccountingDbContext data)
        {
            this.data = data;
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

            var userIsAlreadyAccountant = this.data
                .Accountants
                .Any(a => a.UserId == userId);

            if (userIsAlreadyAccountant)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(accountant);    
            }

            var accountantData = new Accountant
            {
                Name = accountant.Name,
                PhoneNumber = accountant.PhoneNumber,
                UserId = userId
            };

            this.data.Accountants.Add(accountantData);

            this.data.SaveChanges();

            return RedirectToAction("All", "SalesInvoices");
        }
    }
}
