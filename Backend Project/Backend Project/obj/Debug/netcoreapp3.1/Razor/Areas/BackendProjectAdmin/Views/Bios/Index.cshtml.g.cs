#pragma checksum "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2940bc6e9c2965c354557b3c2253d23f1dadbfe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BackendProjectAdmin_Views_Bios_Index), @"mvc.1.0.view", @"/Areas/BackendProjectAdmin/Views/Bios/Index.cshtml")]
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
#line 1 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\_ViewImports.cshtml"
using Backend_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\_ViewImports.cshtml"
using Backend_Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\_ViewImports.cshtml"
using Backend_Project.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\_ViewImports.cshtml"
using Backend_Project.Areas.BackendProjectAdmin.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c2940bc6e9c2965c354557b3c2253d23f1dadbfe", @"/Areas/BackendProjectAdmin/Views/Bios/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cacefd90d69dbe23071a50f2ad97991d157d92f6", @"/Areas/BackendProjectAdmin/Views/_ViewImports.cshtml")]
    public class Areas_BackendProjectAdmin_Views_Bios_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Bios>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "BackendProjectAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Bios", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table table-striped table-dark"">
    <thead>
        <tr>
            <th>Main Phone</th>
            <th>Phone Number</th>
            <th>Phone Number 2</th>
            <th>Address</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>");
#nullable restore
#line 17 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
           Write(Model.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 18 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
           Write(Model.Phono1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 19 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
           Write(Model.Phone2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 20 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
           Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>

        </tr>
    </tbody>
</table>

<table class=""table table-striped table-dark mt-5"">
    <thead>
        <tr>
            <th>Email</th>
            <th>Facebook</th>
            <th>Pinterest</th>
            <th>Vimeo</th>
            <th>Twitter</th>
            <th>Our site</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>");
#nullable restore
#line 39 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
           Write(Model.EmailUs);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 40 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
           Write(Model.Facebook);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 41 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
           Write(Model.Pinterest);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 42 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
           Write(Model.Vimeo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 43 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
           Write(Model.Twitter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 44 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
           Write(Model.OurSite);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
        </tr>
    </tbody>
</table>

<table class=""table table-striped table-dark mt-5"">
    <thead>
        <tr>
            <th>Header</th>
            <th>Description</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c2940bc6e9c2965c354557b3c2253d23f1dadbfe9920", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1315, "~/img/logo/", 1315, 11, true);
#nullable restore
#line 58 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
AddHtmlAttributeValue("", 1326, Model.HeaderLogo, 1326, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 59 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
           Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n\r\n<div class=\"row justify-content-center mt-4\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2940bc6e9c2965c354557b3c2253d23f1dadbfe11971", async() => {
                WriteLiteral("Update");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\Bios\Index.cshtml"
                                                                                                       WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Bios> Html { get; private set; }
    }
}
#pragma warning restore 1591
