namespace AccountingProgram.Areas.ChefAccountant.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Services.SalesInvoices;

    using static AccountingProgram.Areas.ChefAccountant.ChefAccountantConstants;

    [Area(AreaName)]
    [Authorize(Roles = ChefAccountantRoleName)]
    public class SalesInvoicesController : ChefAccountantController
    {
        private readonly ISalesInvoiceService salesInvoices;

        public SalesInvoicesController(ISalesInvoiceService salesInvoices)
        {
            this.salesInvoices = salesInvoices;
        }

        public IActionResult All()
        {
            return View(this.salesInvoices
                .All(postedOnly: false)
                .SalesInvoices);
        }

        public IActionResult ChangeStatus(int id)
        {
            this.salesInvoices.ChangeStatus(id);

            return RedirectToAction(nameof(All));
        }
    }
}
