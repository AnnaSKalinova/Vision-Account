#pragma checksum "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "617a2cf13fc22b75a5c65d87dbd75e2ba5486e48"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SalesInvoices__SalesInvoicesPartial), @"mvc.1.0.view", @"/Views/SalesInvoices/_SalesInvoicesPartial.cshtml")]
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
#line 1 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Customers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.SalesInvoices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Items;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Drivers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Routes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Accountants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.SalesInvoices.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Accountants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Statistics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Customers.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Items.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Routes.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"617a2cf13fc22b75a5c65d87dbd75e2ba5486e48", @"/Views/SalesInvoices/_SalesInvoicesPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1881fc48b6d7c07e13f405ba0a4e466e76ba2af1", @"/Views/_ViewImports.cshtml")]
    public class Views_SalesInvoices__SalesInvoicesPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SalesInvoiceServiceModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "SalesInvoices", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeStatus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info ml-1 float-right disabled"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger float-right ml-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning float-right ml-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary float-right ml-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""container"">
    <div class=""row"">
        <table class=""table table-striped"">
            <thead>
                <tr>
                    <th scope=""col"">Number</th>
                    <th class=""text-center"" scope=""col"">Customer</th>
                    <th class=""text-center"" scope=""col"">Posting date</th>
                    <th class=""text-center"" scope=""col"">Total amount excl. VAT</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 16 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                 foreach (var salesInvoice in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
#nullable restore
#line 19 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                                   Write(salesInvoice.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 20 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                                           Write(salesInvoice.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 21 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                                           Write(salesInvoice.PostingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"text-center\">");
#nullable restore
#line 22 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                                           Write(salesInvoice.TotalAmountExclVat.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" lv.</td>\r\n                        <td>\r\n");
#nullable restore
#line 24 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                             if (ViewBag.AllowSalesInvoiceEdit == true || User.IsChefAccountant())
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "617a2cf13fc22b75a5c65d87dbd75e2ba5486e4813550", async() => {
#nullable restore
#line 26 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                                                                                                                                                                                   Write(salesInvoice.IsPosted ? "Posted" : "Unposted");

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                                                                                                          WriteLiteral(salesInvoice.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "617a2cf13fc22b75a5c65d87dbd75e2ba5486e4816804", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                                                                                        WriteLiteral(salesInvoice.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "617a2cf13fc22b75a5c65d87dbd75e2ba5486e4819409", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                                                                                      WriteLiteral(salesInvoice.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                                                                                                                                WriteLiteral(salesInvoice.CustomerName + "-" + salesInvoice.PostingDate);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["information"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-information", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["information"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 29 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "617a2cf13fc22b75a5c65d87dbd75e2ba5486e4823247", async() => {
                WriteLiteral("More details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                                                                                     WriteLiteral(salesInvoice.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                                                                                                                               WriteLiteral(salesInvoice.CustomerName + "-" + salesInvoice.PostingDate);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["information"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-information", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["information"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 33 "E:\AnNI\Programming\Final Project\12. Adding Post Unpost Buttons - Copy\AccountingProgram\AccountingProgram\Views\SalesInvoices\_SalesInvoicesPartial.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SalesInvoiceServiceModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
