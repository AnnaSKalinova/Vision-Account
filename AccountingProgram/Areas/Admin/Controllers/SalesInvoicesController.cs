namespace AccountingProgram.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using AccountingProgram.Services.SalesInvoices;

    public class SalesInvoicesController : AdminController
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
