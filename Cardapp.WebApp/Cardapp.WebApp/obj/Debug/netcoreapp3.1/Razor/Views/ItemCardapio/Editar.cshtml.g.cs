#pragma checksum "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\Editar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ff3e0be6123ecac698bbaca62e0827b6c72e08e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ItemCardapio_Editar), @"mvc.1.0.view", @"/Views/ItemCardapio/Editar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ff3e0be6123ecac698bbaca62e0827b6c72e08e", @"/Views/ItemCardapio/Editar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"867d6b0efb098ce782bed22ba9e0a87f842f4211", @"/Views/_ViewImports.cshtml")]
    public class Views_ItemCardapio_Editar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Item>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/form-card.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_BotoesSessao", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_FormCreateUpdate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger px-5"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Editar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Checkpoint.TagHelpers.FeedbackTagHelper __Checkpoint_TagHelpers_FeedbackTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\Editar.cshtml"
  
    ViewData["Title"] = "Edite o item do cardápio";
    Layout = "_LayoutNavSide";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ff3e0be6123ecac698bbaca62e0827b6c72e08e6878", async() => {
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ff3e0be6123ecac698bbaca62e0827b6c72e08e7996", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n<div style=\"display: flex; flex-direction: column; justify-content: center; margin-left: 8%;\">\r\n");
#nullable restore
#line 14 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\Editar.cshtml"
     if (@TempData["Sucesso"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Feedback", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ff3e0be6123ecac698bbaca62e0827b6c72e08e9506", async() => {
            }
            );
            __Checkpoint_TagHelpers_FeedbackTagHelper = CreateTagHelper<global::Checkpoint.TagHelpers.FeedbackTagHelper>();
            __tagHelperExecutionContext.Add(__Checkpoint_TagHelpers_FeedbackTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\Editar.cshtml"
             WriteLiteral(TempData["Sucesso"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Checkpoint_TagHelpers_FeedbackTagHelper.Texto = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("Texto", __Checkpoint_TagHelpers_FeedbackTagHelper.Texto, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 16 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\Editar.cshtml"
__Checkpoint_TagHelpers_FeedbackTagHelper.IsError = false;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("is-error", __Checkpoint_TagHelpers_FeedbackTagHelper.IsError, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 17 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\Editar.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Feedback", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ff3e0be6123ecac698bbaca62e0827b6c72e08e11790", async() => {
            }
            );
            __Checkpoint_TagHelpers_FeedbackTagHelper = CreateTagHelper<global::Checkpoint.TagHelpers.FeedbackTagHelper>();
            __tagHelperExecutionContext.Add(__Checkpoint_TagHelpers_FeedbackTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\Editar.cshtml"
             WriteLiteral(TempData["Erro"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Checkpoint_TagHelpers_FeedbackTagHelper.Texto = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("Texto", __Checkpoint_TagHelpers_FeedbackTagHelper.Texto, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 20 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\Editar.cshtml"
__Checkpoint_TagHelpers_FeedbackTagHelper.IsError = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("is-error", __Checkpoint_TagHelpers_FeedbackTagHelper.IsError, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 21 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\Editar.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2 style=\"display: flex; justify-content: center;\" class=\"my-5\">Edite o item escolhido</h2>\r\n    <div class=\"card cardStyle mx-auto\" style=\"width: 70%; padding: 3%\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ff3e0be6123ecac698bbaca62e0827b6c72e08e14238", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ff3e0be6123ecac698bbaca62e0827b6c72e08e14509", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 25 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\Editar.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.CodigoItem);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ff3e0be6123ecac698bbaca62e0827b6c72e08e16264", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <row>\r\n                <div class=\"form-row formRowStyleButton\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ff3e0be6123ecac698bbaca62e0827b6c72e08e17545", async() => {
                    WriteLiteral("Cancelar");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    <input type=\"submit\" value=\"Salvar\" class=\"btn btn-info mx-3 px-5\" />\r\n                </div>\r\n            </row>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Item> Html { get; private set; }
    }
}
#pragma warning restore 1591
