#pragma checksum "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c4948e59afaede9b4da2e3961e746a38f6f9ca4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#line 1 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\_ViewImports.cshtml"
using AlikHalafim;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\_ViewImports.cshtml"
using AlikHalafim.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c4948e59afaede9b4da2e3961e746a38f6f9ca4", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"500de47709fcaeb81899ff96a4c0ae81d0ecb11e", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Index";
    var message = ViewBag.message;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
 if (message != null && message.Length != 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
     if (message.Equals("added"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            var notification = alertify.notify(\'מוצר הוסף לסל הקניות\', \'success\', 5, function () { });\r\n            $(\"#cart-item\").addClass(\"animated bounce\");\r\n        </script>\r\n");
#nullable restore
#line 14 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            var notification = alertify.notify(\'מוצר אזל מהמלאי\', \'success\', 5, function () { });\r\n            $(\"#cart-item\").addClass(\"animated bounce\");\r\n        </script>\r\n");
#nullable restore
#line 21 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row justify-content-center\">\r\n        <div class=\"col-lg-6 col-sm-12 text-center\" style=\"margin-bottom:10px;\">\r\n            <img class=\"product-image-detail\"");
            BeginWriteAttribute("src", " src=\"", 811, "\"", 840, 2);
            WriteAttributeValue("", 817, "/../", 817, 4, true);
#nullable restore
#line 27 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
WriteAttributeValue("", 821, Model.ProductImage, 821, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-lg-6 col-sm-12 justify-content-center\">\r\n            <div class=\"product-info text-center\">\r\n                <h1 class=\"center-mob\" dir=\"rtl\">");
#nullable restore
#line 31 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
                                            Write(Model.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                <span class=\"manufacture-product\" dir=\"rtl\">יצרן: ");
#nullable restore
#line 32 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
                                                             Write(Model.Manufacturer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <h4 class=\"price-productpage\">&#8362; ");
#nullable restore
#line 33 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
                                                 Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c4948e59afaede9b4da2e3961e746a38f6f9ca47942", async() => {
                WriteLiteral("\r\n                    <div class=\"form-group form-add\">\r\n                        <input hidden name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 1451, "\"", 1468, 1);
#nullable restore
#line 38 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
WriteAttributeValue("", 1459, Model.Id, 1459, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                        <input type=""number"" class=""form-control text-center input-quan""
                               min=""1""
                               name=""quantity""
                               value=""1"">
                        <button type=""submit"" class=""add-btn"">
                            להוסיף לסל
                        </button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""row"">
                    <div class=""col-12"">
                        <div style=""width: 100%;text-align: right;"">
                            <p style=""font-weight: bold;"">פרטים</p>
                        </div>

                        <div style=""width:100%;border-top:1px solid silver;text-align: right;"">
                            <p style=""padding:15px;"" dir=""rtl"">
                                ");
#nullable restore
#line 56 "C:\Users\user\source\repos\AlikHalafim\AlikHalafim\Views\Product\Index.cshtml"
                           Write(Model.BigDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
