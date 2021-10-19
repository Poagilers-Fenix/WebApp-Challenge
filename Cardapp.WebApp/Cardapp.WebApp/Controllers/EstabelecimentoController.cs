using FireSharp.Interfaces;
using FireSharp.Config;
using Microsoft.AspNetCore.Mvc;
using System;
using Cardapp.WebApp.Models;
using FireSharp.Response;
using Microsoft.AspNetCore.Http;
using Cardapp.WebApp.SessionHelper;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Cardapp.WebApp.Controllers
{
    public class EstabelecimentoController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "wvg4O1GNPzXqpGK95uGjhVValAjRiLX4iIM3P6YK",
            BasePath = "https://cardapp-d8eba-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        [HttpGet]
        public IActionResult Index()
        {
            client = new FireSharp.FirebaseClient(config);

            Estabelecimento estab = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
            if (estab == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            FirebaseResponse response = client.Get("/suggestMusic/");
            JObject json = JObject.Parse(response.Body);
            var lista = new List<Musica>();
            foreach(var m in json)
            {
                var musica = m.Value.ToObject<Musica>();
                if (musica.EstabId == estab.CodigoEstabelecimento)
                {
                    lista.Add(musica);
                }
            }
            ViewBag.sugestoes = lista;
            return View(estab);
        }

        [HttpGet]
        public IActionResult Avaliacoes()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("/rating/");
            JObject json = JObject.Parse(response.Body);
            var lista = new List<Avaliacao>();
            Estabelecimento estab = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");

            foreach (var a in json)
            {
                var avaliacao = a.Value.ToObject<Avaliacao>();
                if (avaliacao.EstabId == estab.CodigoEstabelecimento)
                {
                    lista.Add(avaliacao);
                }
            }
            ViewBag.avaliacoes = lista;
            return View();
        }

        [HttpGet]
        public IActionResult CadastroGerente()
        {
            var estabelecimento = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");

            if (estabelecimento == null)
            {
                return RedirectToAction("CadastroEstabelecimento");
            }
            return View();

        }

        [HttpPost]
        public IActionResult CadastroGerente(Gerente gerente)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    client = new FireSharp.FirebaseClient(config);
                    FirebaseResponse response = client.Get("/gerente/");
                    if (response.Body != "null")
                    {
                        JObject json = JObject.Parse(response.Body);

                        foreach (var i in json)
                        {
                            var gerenteReceived = i.Value.ToObject<Gerente>();
                            if (gerenteReceived.Email == gerente.Email)
                            {
                                TempData["Erro"] = "Erro ao cadastrar o gerente, esse email já foi cadastrado por outro gerente.";
                                return View();
                            }
                        }

                    }

                    var estabelecimento = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
                    PushResponse responseEstab = client.Push("estab/", estabelecimento);
                    estabelecimento.CodigoEstabelecimento = responseEstab.Result.name;
                    SetResponse setResponseEstab = client.Set("estab/" + estabelecimento.CodigoEstabelecimento, estabelecimento);

                    Relatorio relatorio = new Relatorio
                    {
                        CodigoEstabelecimento = responseEstab.Result.name,
                        NomeItemMaisAcessado = ""
                        
                    };
                    PushResponse responseRelatorio = client.Push("Relatorio/", relatorio);
                    relatorio.CodigoRelatorio = responseRelatorio.Result.name;
                    SetResponse setResponseRelatorio = client.Set("Relatorio/" + relatorio.CodigoRelatorio, relatorio);

                    var data = gerente;
                    gerente.CodigoEstabelecimento = estabelecimento.CodigoEstabelecimento;
                    PushResponse responseGerente = client.Push("gerente/", data);
                    data.CodigoGerente = responseGerente.Result.name;
                    SetResponse setResponseGerente = client.Set("gerente/" + data.CodigoGerente, data);

                    TempData["Sucesso"] = "Bem vindo(a) ao Cardapp!";


                    // Guardar estab na sessão novamente
                    HttpContext.Session.SetObjectAsJson("EstabelecimentoSessao", estabelecimento);
                    HttpContext.Session.SetObjectAsJson("GerenteSessao", gerente);
                    return RedirectToAction("index");

                }
                catch (Exception)
                {
                    TempData["Erro"] = "Erro ao cadastrar!";
                    return View();
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult EditarGerente()
        {
            if (HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao") == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            Gerente gerente = HttpContext.Session.GetObjectFromJson<Gerente>("GerenteSessao");

            return View(gerente);
        }

        [HttpPost]
        public IActionResult EditarGerente(Gerente gerente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client = new FireSharp.FirebaseClient(config);
                    Gerente gerenteSessao = HttpContext.Session.GetObjectFromJson<Gerente>("GerenteSessao");

                        if (gerenteSessao.Email == gerente.Email && gerenteSessao.CodigoGerente != gerente.CodigoGerente)
                        {
                            TempData["Erro"] = "Erro ao editar o gerente, esse email já foi cadastrado por outro gerente.";
                            return View();
                        }
                        if (gerenteSessao.CodigoGerente == gerente.CodigoGerente)
                        {
                            if (gerente.Senha != gerenteSessao.Senha)
                            {
                                TempData["Erro"] = "A senha informada está incorreta.";
                                return RedirectToAction("EditarGerente");
                            }
                        }
                    client.Update("/gerente/" + gerente.CodigoGerente, gerente);
                    HttpContext.Session.SetObjectAsJson("GerenteSessao", gerente);
                    TempData["Sucesso"] = "Alterações salvas com sucesso!";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception)
            {
                Console.WriteLine("Entrou no catch");
                TempData["Erro"] = "Não foi possível salvar as alterações!";
                return RedirectToAction("EditarGerente");
            }
        }

        [HttpGet]
        public IActionResult EditarSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditarSenha(string novaSenha)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                Gerente gerenteSessao = HttpContext.Session.GetObjectFromJson<Gerente>("GerenteSessao");

                string senha = Request.Form["senhaAtual"];
                if (senha != gerenteSessao.Senha)
                {
                    TempData["Erro"] = "A senha informada está incorreta.";
                    return RedirectToAction("EditarGerente");
                }
                gerenteSessao.Senha = novaSenha;
                Console.WriteLine(gerenteSessao.Senha);
                client.Update("/gerente/" + gerenteSessao.CodigoGerente, gerenteSessao);
                HttpContext.Session.SetObjectAsJson("GerenteSessao", gerenteSessao);
                TempData["Sucesso"] = "Alterações salvas com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Erro"] = "Houve um erro ao tentar atualizar senha.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult CadastroEstabelecimento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroEstabelecimento(Estabelecimento estab)
        {
            if (ModelState.IsValid)
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("/estab/");
                if (response.Body != "null")
                {
                    JObject json = JObject.Parse(response.Body);
                    foreach (var i in json)
                    {
                        var estabelecimento = i.Value.ToObject<Estabelecimento>();
                        if (estabelecimento.Cnpj == estab.Cnpj)
                        {
                            TempData["Erro"] = "Erro ao cadastrar o estabelecimento, esse CNPJ já foi cadastrado por outro estabelecimento.";
                            return View();
                        }
                        else if(estabelecimento.Email == estab.Email)
                        {
                            TempData["Erro"] = "Erro ao cadastrar o estabelecimento, esse email já foi cadastrado por outro estabelecimento.";
                            return View();
                        }
                        else if (estabelecimento.Telefone == estab.Telefone)
                        {
                            TempData["Erro"] = "Erro ao cadastrar o estabelecimento, esse telefone já foi cadastrado por outro estabelecimento.";
                            return View();
                        }
                    }
                }
                HttpContext.Session.SetObjectAsJson("EstabelecimentoSessao", estab);
                HttpContext.Session.SetString("NomeEstabelecimento", estab.NomeFantasia);
                return RedirectToAction("CadastroGerente");
            }
            TempData["Erro"] = "Erro ao cadastrar o estabelecimento, cheque se as informações estão corretas e tente novamente.";
            return View();
        }

        [HttpGet]
        public IActionResult EditarEstabelecimento()
        {
            Estabelecimento estab = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
            if(estab == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            return View(estab);
        }

        [HttpPost]
        public IActionResult EditarEstabelecimento(Estabelecimento estab)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client = new FireSharp.FirebaseClient(config);
                    FirebaseResponse response = client.Get("/estab/");
                    JObject json = JObject.Parse(response.Body);
                    foreach (var i in json)
                    {
                        var estabelecimento = i.Value.ToObject<Estabelecimento>();
                        if (estabelecimento.Cnpj == estab.Cnpj && estabelecimento.CodigoEstabelecimento != estab.CodigoEstabelecimento)
                        {
                            TempData["Erro"] = "Erro ao editar o estabelecimento, esse CNPJ já foi cadastrado por outro estabelecimento.";
                            return View();
                        }
                        else if (estabelecimento.Email == estab.Email && estabelecimento.CodigoEstabelecimento != estab.CodigoEstabelecimento)
                        {
                            TempData["Erro"] = "Erro ao editar o estabelecimento, esse email já foi cadastrado por outro estabelecimento.";
                            return View();
                        }
                        else if (estabelecimento.Telefone == estab.Telefone && estabelecimento.CodigoEstabelecimento != estab.CodigoEstabelecimento)
                        {
                            TempData["Erro"] = "Erro ao editar o estabelecimento, esse telefone já foi cadastrado por outro estabelecimento.";
                            return View();
                        }
                    }
                    client.Update("/estab/" + estab.CodigoEstabelecimento, estab);
                    HttpContext.Session.SetObjectAsJson("EstabelecimentoSessao", estab);
                    HttpContext.Session.SetString("NomeEstabelecimento", estab.NomeFantasia);
                    TempData["Sucesso"] = "Alterações salvas com sucesso!";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception)
            {
                TempData["Erro"] = "Não foi possível salvar as alterações!";
                return RedirectToAction("EditarEstabelecimento");
            }
        }

        [HttpPost]
        public IActionResult Remover()
        {
            client = new FireSharp.FirebaseClient(config);
            Gerente gerente = HttpContext.Session.GetObjectFromJson<Gerente>("GerenteSessao");
            FirebaseResponse response = client.Get("/itemCardapio/");
            if (response.Body != "null")
            {
                JObject json = JObject.Parse(response.Body);

                foreach (var i in json)
                {
                    var item = i.Value.ToObject<Item>();
                    if (item.CodigoEstabelecimento == gerente.CodigoEstabelecimento)
                    {
                        client.Delete("/itemCardapio/" + item.CodigoItem);
                    }
                }

            }
            client.Delete("/gerente/" + gerente.CodigoGerente);
            client.Delete("/estab/" + gerente.CodigoEstabelecimento);

            //GetItems(out items, out estab, out json);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Relatorio()
        {
            client = new FireSharp.FirebaseClient(config);
            Estabelecimento estab = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
            FirebaseResponse response = client.Get("/Relatorio/");
            JObject json = JObject.Parse(response.Body);
            foreach (var i in json)
            {
                var Relatorio = i.Value.ToObject<Relatorio>();
                if (Relatorio.CodigoEstabelecimento == estab.CodigoEstabelecimento)
                {
                    return View(Relatorio);

                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult ApagarNotificacao(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            client.Delete("/suggestMusic/" + id);
            TempData["Sucesso"] = "Sugestão apagada com sucesso!";
            return RedirectToAction("Index");
        }

    }
}