#pragma checksum "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1494ea7b5e73d517884b8fc9a239542865170857"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Customers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.SalesInvoices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Items;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Drivers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Models.Routes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.SalesInvoices.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Accountants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Statistics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Customers.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Items.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\_ViewImports.cshtml"
using AccountingProgram.Services.Routes.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1494ea7b5e73d517884b8fc9a239542865170857", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79f23e52fd28c88fcdf029c5566b55b9d3c22320", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StatisticsServiceModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""carouselExampleSlidesOnly"" class=""carousel slide"" data-ride=""carousel"">
    <div class=""carousel-inner m-5"">
        <div class=""carousel-item active"">
            <h1 class=""col-md-11 text-center"">
                Vision Account
            </h1>
        </div>
        <div class=""carousel-item"">
            <h1 class=""col-md-11 text-center"">
                Total profit for year ");
#nullable restore
#line 16 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\Home\Index.cshtml"
                                 Write(DateTime.UtcNow.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n            </h1>\r\n            <h1 class=\"col-md-11 text-center font-weight-bold\">\r\n                ");
#nullable restore
#line 19 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\Home\Index.cshtml"
           Write(Model.TotalProfit.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" lv.\r\n            </h1>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"jumbotron m-5\">\r\n    <div class=\"row m-5\">\r\n        <h2 class=\"col-md-4 text-center\">\r\n            ");
#nullable restore
#line 28 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\Home\Index.cshtml"
       Write(Model.TotalSalesInvoices);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Sales Invoices\r\n        </h2>\r\n        <h2 class=\"col-md-3 text-center\">\r\n            ");
#nullable restore
#line 31 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\Home\Index.cshtml"
       Write(Model.TotalCustomers);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Customers\r\n        </h2>\r\n        <h2 class=\"col-md-2 text-center\">\r\n            ");
#nullable restore
#line 34 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\Home\Index.cshtml"
       Write(Model.TotalItems);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Items\r\n        </h2>\r\n        <h2 class=\"col-md-3 text-center\">\r\n            ");
#nullable restore
#line 37 "E:\AnNI\Programming\Final Project\19 More more more tests\AccountingProgram\AccountingProgram\Views\Home\Index.cshtml"
       Write(Model.TotalDrivers);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Drivers\r\n        </h2>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StatisticsServiceModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
