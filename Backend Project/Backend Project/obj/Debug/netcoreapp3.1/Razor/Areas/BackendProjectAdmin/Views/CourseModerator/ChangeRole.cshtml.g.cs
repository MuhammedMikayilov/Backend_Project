#pragma checksum "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "739d28c4191f4dc970c4a3ee6ad48e7631829041"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_BackendProjectAdmin_Views_CourseModerator_ChangeRole), @"mvc.1.0.view", @"/Areas/BackendProjectAdmin/Views/CourseModerator/ChangeRole.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"739d28c4191f4dc970c4a3ee6ad48e7631829041", @"/Areas/BackendProjectAdmin/Views/CourseModerator/ChangeRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cacefd90d69dbe23071a50f2ad97991d157d92f6", @"/Areas/BackendProjectAdmin/Views/_ViewImports.cshtml")]
    public class Areas_BackendProjectAdmin_Views_CourseModerator_ChangeRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
  
    ViewData["Title"] = "ChangeRole";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container bg-white pb-5"">
    <div class=""row w-100"">
        <table class=""table table-striped table-dark"">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Surname</th>
                    <th>Username</th>
                    <th>Emain</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>");
#nullable restore
#line 19 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 20 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
                   Write(Model.Lastname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
                   Write(Model.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
                   Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n    <div class=\"row mt-3 p-5\">\r\n        <div class=\"col-md-8\">\r\n            <h3>Roles</h3> <br />\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "739d28c4191f4dc970c4a3ee6ad48e76318290417475", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 31 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
                 foreach (string item in Model.Roles)
                {
                    if (item == Model.Role)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input type=\"radio\" name=\"Role\" checked");
                BeginWriteAttribute("value", " value=\"", 1056, "\"", 1069, 1);
#nullable restore
#line 35 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
WriteAttributeValue("", 1064, item, 1064, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />");
#nullable restore
#line 35 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
                                                                           Write(item);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <br /> <br />\r\n");
#nullable restore
#line 36 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input type=\"radio\" name=\"Role\"");
                BeginWriteAttribute("value", " value=\"", 1221, "\"", 1234, 1);
#nullable restore
#line 39 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
WriteAttributeValue("", 1229, item, 1229, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />");
#nullable restore
#line 39 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
                                                                   Write(item);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <br /> <br />\r\n");
#nullable restore
#line 40 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Areas\BackendProjectAdmin\Views\CourseModerator\ChangeRole.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                <br /> <br />\r\n                <button type=\"submit\" class=\"btn btn-primary ml-2\">Change Role</button>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "739d28c4191f4dc970c4a3ee6ad48e763182904110707", async() => {
                    WriteLiteral("Go back");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
