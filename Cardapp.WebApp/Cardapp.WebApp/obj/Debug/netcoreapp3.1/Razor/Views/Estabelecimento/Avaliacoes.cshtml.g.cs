#pragma checksum "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\Estabelecimento\Avaliacoes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1942b85b05ce5c9898a6e0a552b97464876cd41e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Estabelecimento_Avaliacoes), @"mvc.1.0.view", @"/Views/Estabelecimento/Avaliacoes.cshtml")]
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
#line 1 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\_ViewImports.cshtml"
using Cardapp.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\_ViewImports.cshtml"
using Cardapp.WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\Estabelecimento\Avaliacoes.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1942b85b05ce5c9898a6e0a552b97464876cd41e", @"/Views/Estabelecimento/Avaliacoes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"867d6b0efb098ce782bed22ba9e0a87f842f4211", @"/Views/_ViewImports.cshtml")]
    public class Views_Estabelecimento_Avaliacoes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Avaliacao>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_BotoesSessao", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\Estabelecimento\Avaliacoes.cshtml"
  
    ViewData["Title"] = "Avaliações";
    Layout = "_LayoutNavSide";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1942b85b05ce5c9898a6e0a552b97464876cd41e4142", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div style=\"display: flex; flex-direction: column; min-width: 90%;\" class=\"right-content mb-5\">\r\n    <h2 style=\"display: flex; justify-content: center;\" class=\"mb-5 mt-3\">Avaliações - ");
#nullable restore
#line 14 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\Estabelecimento\Avaliacoes.cshtml"
                                                                                  Write(HttpContextAccessor.HttpContext.Session.GetString("NomeEstabelecimento"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n    <div class=\"d-flex align-self-end border-danger\" style=\"flex-wrap: wrap; min-width: 85%; margin-left: 10%\">\r\n");
#nullable restore
#line 17 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\Estabelecimento\Avaliacoes.cshtml"
         foreach (var a in ViewBag.avaliacoes)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card d-flex flex-column col-3 border-danger\" style=\"padding: 4%; margin: 1%; border-radius: 15px; box-shadow: 5px 4px 12px #333\">\r\n                <div>\r\n                    <h5>Avaliação de ");
#nullable restore
#line 21 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\Estabelecimento\Avaliacoes.cshtml"
                                Write(a.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p>E-mail: ");
#nullable restore
#line 22 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\Estabelecimento\Avaliacoes.cshtml"
                          Write(a.UserEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <p style=\"font-size: 1.5rem\" class=\"text-center\">");
#nullable restore
#line 24 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\Estabelecimento\Avaliacoes.cshtml"
                                                            Write(a.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"material-icons text-warning mt-2\">star</span></p>\r\n                <div class=\"d-flex\">\r\n                    <b class=\"mr-2\">Avaliação: </b>\r\n                    <p>");
#nullable restore
#line 27 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\Estabelecimento\Avaliacoes.cshtml"
                   Write(a.Text != "" ? a.Text : "-------");

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 30 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\Estabelecimento\Avaliacoes.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Avaliacao> Html { get; private set; }
    }
}
#pragma warning restore 1591
