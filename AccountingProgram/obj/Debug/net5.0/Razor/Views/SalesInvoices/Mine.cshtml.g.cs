#pragma checksum "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\SalesInvoices\Mine.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a227faa996f33b9be968239daaf0c21979a05bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SalesInvoices_Mine), @"mvc.1.0.view", @"/Views/SalesInvoices/Mine.cshtml")]
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
#line 1 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Customers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.SalesInvoices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Items;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Drivers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Routes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.SalesInvoices.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Accountants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Statistics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Customers.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Items.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Routes.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a227faa996f33b9be968239daaf0c21979a05bd", @"/Views/SalesInvoices/Mine.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9049c2dc10a73d107e34d06a6976cd5f389765b9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SalesInvoices_Mine : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SalesInvoiceServiceModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_SalesInvoicesPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\SalesInvoices\Mine.cshtml"
  
    ViewBag.Title = "All Sales Invoices";
    ViewBag.AllowSalesInvoiceEdit = true;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2a227faa996f33b9be968239daaf0c21979a05bd7300", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 9 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\SalesInvoices\Mine.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 11 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\SalesInvoices\Mine.cshtml"
  
    if (!Model.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2 class=\"text-center\">You have no sales invoices yet!</h2>\r\n");
#nullable restore
#line 15 "E:\AnNI\Programming\Final Project\18 More more tests\AccountingProgram\AccountingProgram\Views\SalesInvoices\Mine.cshtml"
    }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SalesInvoiceServiceModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
