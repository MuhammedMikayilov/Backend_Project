#pragma checksum "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73f4142ab9f5f49975c73d0ce3090b4101461fc8"
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
#line 1 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\_ViewImports.cshtml"
using Backend_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\_ViewImports.cshtml"
using Backend_Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\_ViewImports.cshtml"
using Backend_Project.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73f4142ab9f5f49975c73d0ce3090b4101461fc8", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"647252969bb92e82798997f2fa4907e13b0434a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("default-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "About", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Teacher", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("section-title"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    string ind;
    string[] month = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    int count = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Background Area Start -->\r\n<section id=\"slider-container\" class=\"slider-area two\">\r\n    <div class=\"slider-owl owl-theme owl-carousel\">\r\n");
#nullable restore
#line 11 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
         foreach (Slider slide in Model.Sliders)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <!-- Start Slingle Slide -->\r\n            <div class=\"single-slide item\"");
            BeginWriteAttribute("style", " style=\"", 494, "\"", 548, 4);
            WriteAttributeValue("", 502, "background-image:", 502, 17, true);
            WriteAttributeValue(" ", 519, "url(img/slider/", 520, 16, true);
#nullable restore
#line 14 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
WriteAttributeValue("", 535, slide.Image, 535, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 547, ")", 547, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">
                <!-- Start Slider Content -->
                <div class=""slider-content-area"">
                    <div class=""container"">
                        <div class=""row"">
                            <div class=""col-md-10 col-md-offset-1"">
                                <div class=""slide-content-wrapper"">
                                    <div class=""slide-content text-center"">
                                        <h2>");
#nullable restore
#line 22 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                                       Write(slide.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n                                        <p> ");
#nullable restore
#line 23 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                                       Write(slide.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73f4142ab9f5f49975c73d0ce3090b4101461fc87825", async() => {
                WriteLiteral("Learn more");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Start Slider Content -->
            </div>
            <!-- End Slingle Slide -->
");
#nullable restore
#line 34 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</section>\r\n<!-- Background Area End -->\r\n<!-- Service Start -->\r\n<div class=\"service-area two pt-150 pb-150\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 42 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
             foreach (Service service in Model.Services)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-4 col-sm-4 col-xs-12\">\r\n                    <div class=\"single-service\">\r\n                        <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73f4142ab9f5f49975c73d0ce3090b4101461fc810460", async() => {
#nullable restore
#line 46 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                                                                      Write(service.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h3>\r\n                        <p>");
#nullable restore
#line 47 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                      Write(service.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 50 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n<!-- Service End -->\r\n<!-- About Start -->\r\n<div class=\"about-area pb-155\">\r\n    ");
#nullable restore
#line 57 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("Eduhome"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<!-- About End -->\r\n<!-- Courses Area Start -->\r\n<div class=\"courses-area two pt-150 pb-150 text-center\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-xs-12\">\r\n                <div class=\"section-title\">\r\n");
#nullable restore
#line 66 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                     if (Model.Titles.ElementAt(0).IsDelete == false)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "73f4142ab9f5f49975c73d0ce3090b4101461fc813706", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2651, "~/img/icon/", 2651, 11, true);
#nullable restore
#line 68 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 2662, Model.Titles.ElementAt(0).Icon, 2662, 31, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <h2>");
#nullable restore
#line 69 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                       Write(Model.Titles.ElementAt(0).Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 70 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n            ");
#nullable restore
#line 77 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("Course", 3));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Courses Area End -->\r\n<!-- Notice Start -->\r\n<section class=\"notice-area two pt-140\">\r\n    ");
#nullable restore
#line 84 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("Notice"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</section>
<!-- Notice End -->
<!-- Event Area Start -->
<div class=""event-area two text-center pt-100 pb-145"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-xs-12"">
                <div class=""section-title"">
");
#nullable restore
#line 93 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                     if (Model.Titles.ElementAt(1).IsDelete == false)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "73f4142ab9f5f49975c73d0ce3090b4101461fc817325", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3507, "~/img/icon/", 3507, 11, true);
#nullable restore
#line 95 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 3518, Model.Titles.ElementAt(1).Icon, 3518, 31, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <h2>");
#nullable restore
#line 96 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                       Write(Model.Titles.ElementAt(1).Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 97 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            ");
#nullable restore
#line 103 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("Events", 4));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Event Area End -->\r\n<!-- Testimonial Area Start -->\r\n<div class=\"testimonial-area pt-110 pb-105 text-center\">\r\n    ");
#nullable restore
#line 110 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("Testimonial"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</div>
<!-- Testimonial Area End -->
<!-- Blog Area Start -->
<div class=""blog-area pt-150 pb-150"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-xs-12"">
                <div class=""section-title text-center"">
");
#nullable restore
#line 119 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                     if (Model.Titles.ElementAt(2).IsDelete == false)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "73f4142ab9f5f49975c73d0ce3090b4101461fc820972", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4390, "~/img/icon/", 4390, 11, true);
#nullable restore
#line 121 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 4401, Model.Titles.ElementAt(2).Icon, 4401, 31, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <h2>");
#nullable restore
#line 122 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                       Write(Model.Titles.ElementAt(2).Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 123 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            ");
#nullable restore
#line 128 "C:\Users\maham\OneDrive\Desktop\Project\Backend_Project\Backend Project\Backend Project\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("Blogs", 3));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Blog Area End -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
