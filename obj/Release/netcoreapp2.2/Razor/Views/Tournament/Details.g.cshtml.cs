#pragma checksum "F:\profession\Asp.MVCCoreWeb\Asp.MVCCoreWeb\Views\Tournament\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "337cc86a0c684b7f0e05afa7b64a27bbdb90607c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tournament_Details), @"mvc.1.0.view", @"/Views/Tournament/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tournament/Details.cshtml", typeof(AspNetCore.Views_Tournament_Details))]
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
#line 1 "F:\profession\Asp.MVCCoreWeb\Asp.MVCCoreWeb\Views\_ViewImports.cshtml"
using Asp.MVCCoreWeb;

#line default
#line hidden
#line 2 "F:\profession\Asp.MVCCoreWeb\Asp.MVCCoreWeb\Views\_ViewImports.cshtml"
using Asp.MVCCoreWeb.Models;

#line default
#line hidden
#line 3 "F:\profession\Asp.MVCCoreWeb\Asp.MVCCoreWeb\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"337cc86a0c684b7f0e05afa7b64a27bbdb90607c", @"/Views/Tournament/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eac05bc060a9dfc7327d5caab474f005c32c58a7", @"/Views/_ViewImports.cshtml")]
    public class Views_Tournament_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Asp.MVCCoreWeb.Models.Tournaments>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/icons/Screenshot_1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\profession\Asp.MVCCoreWeb\Asp.MVCCoreWeb\Views\Tournament\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(87, 107, true);
            WriteLiteral("\r\n\r\n\r\n<div>\r\n    <br/>\r\n    <div class=\"card text-center\">\r\n        <div class=\"card-header\">\r\n            ");
            EndContext();
            BeginContext(194, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "337cc86a0c684b7f0e05afa7b64a27bbdb90607c4497", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(250, 88, true);
            WriteLiteral("\r\n\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title\">");
            EndContext();
            BeginContext(339, 11, false);
#line 17 "F:\profession\Asp.MVCCoreWeb\Asp.MVCCoreWeb\Views\Tournament\Details.cshtml"
                              Write(Model.title);

#line default
#line hidden
            EndContext();
            BeginContext(350, 287, true);
            WriteLiteral(@"</h5>
            <p class=""card-text"">With supporting text below as a natural lead-in to additional content.</p>
            <div class=""row"" style=""font-size:x-large"">
                <div class=""col-sm"">
                    <i class=""fas fa-clock""></i><br />
                    ");
            EndContext();
            BeginContext(638, 15, false);
#line 22 "F:\profession\Asp.MVCCoreWeb\Asp.MVCCoreWeb\Views\Tournament\Details.cshtml"
               Write(Model.Date_Time);

#line default
#line hidden
            EndContext();
            BeginContext(653, 140, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm\">\r\n                    <i class=\"fas fa-award\"></i><br />\r\n                    ");
            EndContext();
            BeginContext(794, 11, false);
#line 26 "F:\profession\Asp.MVCCoreWeb\Asp.MVCCoreWeb\Views\Tournament\Details.cshtml"
               Write(Model.Prize);

#line default
#line hidden
            EndContext();
            BeginContext(805, 140, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-sm\">\r\n                    <i class=\"fas fa-users\"></i><br />\r\n                    ");
            EndContext();
            BeginContext(946, 11, false);
#line 30 "F:\profession\Asp.MVCCoreWeb\Asp.MVCCoreWeb\Views\Tournament\Details.cshtml"
               Write(Model.Slots);

#line default
#line hidden
            EndContext();
            BeginContext(957, 148, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n           \r\n                <div class=\"col-sm\">\r\n                    <button class=\"btn btn-success\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1105, "\"", 1177, 3);
            WriteAttributeValue("", 1115, "javascript:location.replace(\'/Payment/startpayment/", 1115, 51, true);
#line 35 "F:\profession\Asp.MVCCoreWeb\Asp.MVCCoreWeb\Views\Tournament\Details.cshtml"
WriteAttributeValue("", 1166, Model.Id, 1166, 9, false);

#line default
#line hidden
            WriteAttributeValue("", 1175, "\')", 1175, 2, true);
            EndWriteAttribute();
            BeginContext(1178, 1339, true);
            WriteLiteral(@">Join</button>
                    <label>Go back to <a href=""/"" class="""">Home</a></label>

                </div>
               
            </div>
        <div class=""card-footer text-muted"">
            <table class=""table table-dark"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Players</th>
                        <th scope=""col"">Last</th>
                        <th scope=""col"">Handle</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope=""row"">1</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>mdo</td>
                    </tr>
                    <tr>
                        <th scope=""row"">2</th>
                        <td>Jacob</td>
                        <td>Thornton</td>
                        <td>fat</td>
                    </tr>
  ");
            WriteLiteral(@"                  <tr>
                        <th scope=""row"">3</th>
                        <td>Larry</td>
                        <td>the Bird</td>
                        <td>twitter</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
   
</div>

");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Asp.MVCCoreWeb.Models.Tournaments> Html { get; private set; }
    }
}
#pragma warning restore 1591
