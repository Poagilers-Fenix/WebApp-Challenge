#pragma checksum "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "937b4e0d986d3b2a656264feae000e0edf3cad36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ItemCardapio__ListItems), @"mvc.1.0.view", @"/Views/ItemCardapio/_ListItems.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"937b4e0d986d3b2a656264feae000e0edf3cad36", @"/Views/ItemCardapio/_ListItems.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"867d6b0efb098ce782bed22ba9e0a87f842f4211", @"/Views/_ViewImports.cshtml")]
    public class Views_ItemCardapio__ListItems : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<Item>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Cadastrar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger my-3 py-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 20%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BuscarTodos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex btn btn-dark my-3 py-2 text align-items-center justify-content-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mb-3 btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Editar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "remover", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<style>\r\n    .input:focus {\r\n        outline: none;\r\n        box-shadow: none;\r\n    }\r\n</style>\r\n\r\n<div class=\"d-flex justify-content-between\">\r\n\r\n    <div class=\"btn-group mx-auto my-3\" role=\"group\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "937b4e0d986d3b2a656264feae000e0edf3cad366453", async() => {
                WriteLiteral("\r\n            Adicionar um novo item ao card??pio\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "937b4e0d986d3b2a656264feae000e0edf3cad367838", async() => {
                WriteLiteral("\r\n            Listar todos os itens\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 20 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
     if (ViewBag.nomeItem != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"my-auto mr-3\">\r\n            <p style=\"border: 2px #ccc solid; padding: 5px 5px 5px 10px; border-radius: 5px; display: flex\">\r\n                ");
#nullable restore
#line 24 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
           Write(ViewBag.nomeItem);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "937b4e0d986d3b2a656264feae000e0edf3cad369952", async() => {
                WriteLiteral("\r\n                <span class=\"material-icons d-flex align-content-center text-danger ml-3\">cancel</span>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </p>\r\n    </div>\r\n");
#nullable restore
#line 30 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>


<row>
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">Foto</th>
                <th scope=""col"">Nome</th>
                <th scope=""col"">Descri????o</th>
                <th scope=""col"">Pre??o</th>
                <th scope=""col"">Valor cal??rico</th>
                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 47 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td width=\"250px\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1553, "\"", 1731, 1);
#nullable restore
#line 51 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
WriteAttributeValue("", 1559, item.Foto == null ? "https://raw.githubusercontent.com/Poagilers-Fenix/WebApp-Challenge/main/Imagens/no-image-found.png?token=AOXNWKVBRD3WDDJKASDBZT3BHUBDY" : @item.Foto, 1559, 172, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 300px; height: 150px\" class=\"img-thumbnail\" alt=\"...\">\r\n                    </td>\r\n                    <td class=\"align-middle\">");
#nullable restore
#line 53 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
                                        Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle\" width=\"480px\">");
#nullable restore
#line 54 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
                                                      Write(item.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle\" width=\"200px\">R$ ");
#nullable restore
#line 55 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
                                                         Write(item.Preco);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle\" width=\"200px\">");
#nullable restore
#line 56 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
                                                       Write(item.ValCalorico != 0 ? $"{@item.ValCalorico} Kcal" : "----------" );

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"align-middle\">\r\n                        <div style=\"display: flex; flex-direction: column; margin-right: 2vw;\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "937b4e0d986d3b2a656264feae000e0edf3cad3614718", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
                                                                               WriteLiteral(item.CodigoItem);

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
            WriteLiteral("\r\n                            <button");
            BeginWriteAttribute("onclick", " onclick=\"", 2489, "\"", 2540, 5);
            WriteAttributeValue("", 2499, "idItemCardapio.value", 2499, 20, true);
            WriteAttributeValue(" ", 2519, "=", 2520, 2, true);
            WriteAttributeValue(" ", 2521, "\'", 2522, 2, true);
#nullable restore
#line 60 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
WriteAttributeValue("", 2523, item.CodigoItem, 2523, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2539, "\'", 2539, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" type=""button"" class=""mb-3 btn btn-danger"" data-toggle=""modal"" data-target=""#modalConfirma"">
                                Remover
                            </button>
                        </div>
                    </td>
                </tr>
");
#nullable restore
#line 66 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n\r\n");
#nullable restore
#line 69 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
         if (Model.Count == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tbody>\r\n                <tr>\r\n                    <td colspan=\"6\" class=\"text-info ml-4\">  N??o h?? nada por aqui!</td>\r\n                </tr>\r\n            </tbody>\r\n");
#nullable restore
#line 76 "D:\Arquivos de Programas (x86)\Git-Hub\WebApp-Challenge\Cardapp.WebApp\Cardapp.WebApp\Views\ItemCardapio\_ListItems.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </table>
</row>



<!-- Modal -->
<div class=""modal fade"" id=""modalConfirma"" tabindex=""-1"" aria-labelledby=""modalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"" style=""background-color: #23272B; color: white"">
                <h5 class=""modal-title"" id=""modalLabel"">Confirma????o</h5>
            </div>
            <div class=""modal-body"" style=""background-color: powderblue"">
                <p>Voc?? tem certeza que deseja deletar o registro desse item do card??pio?</p>
            </div>
            <div class=""modal-footer border-top-0"" style=""background-color: powderblue; color: white"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "937b4e0d986d3b2a656264feae000e0edf3cad3619770", async() => {
                WriteLiteral(@"
                    <input type=""hidden"" name=""id"" id=""idItemCardapio"" />
                    <button type=""button"" class=""btn btn-dark"" data-dismiss=""modal"">N??o</button>
                    <button type=""submit"" class=""btn btn-danger"">Sim, delete o item do card??pio</button>
                ");
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
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<Item>> Html { get; private set; }
    }
}
#pragma warning restore 1591
