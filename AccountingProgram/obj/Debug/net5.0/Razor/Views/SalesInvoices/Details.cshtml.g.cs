#pragma checksum "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb928afc2bcf8f63f638d5d48a52cb6dc08354e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SalesInvoices_Details), @"mvc.1.0.view", @"/Views/SalesInvoices/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Customers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.SalesInvoices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Items;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Drivers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Routes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Accountants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.SalesInvoices.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Accountants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Statistics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Customers.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Items.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Routes.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb928afc2bcf8f63f638d5d48a52cb6dc08354e0", @"/Views/SalesInvoices/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1881fc48b6d7c07e13f405ba0a4e466e76ba2af1", @"/Views/_ViewImports.cshtml")]
    public class Views_SalesInvoices_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SalesInvoiceDetailsServiceModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
  
    ViewBag.Title = "Sales invoice details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"heading-margin text-center\">");
#nullable restore
#line 7 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
                                  Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div class=\"container col-6\">\r\n    <table class=\"table table-striped\">\r\n        <thead>\r\n        </thead>\r\n        <tbody>\r\n            <tr>\r\n                <td class=\"font-weight-bold\">Customer</td>\r\n                <td>");
#nullable restore
#line 16 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
               Write(Model.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"font-weight-bold\">Posting date</td>\r\n                <td>");
#nullable restore
#line 20 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
               Write(Model.PostingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"font-weight-bold\">Due date</td>\r\n                <td>");
#nullable restore
#line 24 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
               Write(Model.DueDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"font-weight-bold\">Item</td>\r\n                <td>");
#nullable restore
#line 28 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
               Write(Model.ItemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"font-weight-bold\">Count</td>\r\n                <td>");
#nullable restore
#line 32 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
               Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"font-weight-bold\">Total amount excl. VAT</td>\r\n                <td>");
#nullable restore
#line 36 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
               Write(Model.TotalAmountExclVat.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" lv.</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"font-weight-bold\">VAT</td>\r\n                <td>");
#nullable restore
#line 40 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
               Write(Model.Vat.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" lv.</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"font-weight-bold\">Total amount incl. VAT</td>\r\n                <td>");
#nullable restore
#line 44 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
               Write(Model.TotalAmountInclVat.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" lv.</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"font-weight-bold\">Profit</td>\r\n                <td>");
#nullable restore
#line 48 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
               Write(Model.Profit.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" lv.</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"font-weight-bold\">Accountant</td>\r\n                <td>");
#nullable restore
#line 52 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\Details.cshtml"
               Write(Model.AccountantName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SalesInvoiceDetailsServiceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591