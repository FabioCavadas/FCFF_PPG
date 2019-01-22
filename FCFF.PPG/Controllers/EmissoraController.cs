using Entidades;
using FCFF.PPG.Models.DAO;
using FCFF.PPG.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCFF.PPG.Controllers
{
    public class EmissoraController : Controller
    {
        // GET: Emissora
        public ActionResult Index()
        {
            return View();
        }

        // GET: Emissora/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(EmissoraView model)
        {
            try
            {
                EmissoraDAO dao = new EmissoraDAO();

                if (ModelState.IsValid)
                {
                    if (!dao.EmissoraExistente(model.Nome))
                    {
                        Emissora e = new Emissora();
                        e.Nome = model.Nome;

                        dao.Cadastrar(e);

                        ModelState.Clear();

                        ViewBag.Mensagem = $"Emissora {model.Nome}, cadastrada com sucesso.";
                    }
                    else
                    {
                        ViewBag.Mensagem = $"A emissora {model.Nome}, já foi cadastrado.";
                    }
                }

            }
            catch (Exception e)
            {

                ViewBag.Mensagem = "Erro: " + e.Message;
            }
            return View();
        }

        //// GET: Emissora/Atualizar       
        public ActionResult Atualizar(int id)
        {
            EmissoraView model = new EmissoraView();
            try
            {
                EmissoraDAO dao = new EmissoraDAO();
                Emissora e = dao.ObterPorId(id);

                model.Id = e.Id;
                model.Nome = e.Nome;
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View(model);
        }

        // POST:Emissora/Atualizar
        [HttpPost]
        public ActionResult Atualizar(EmissoraView model)
        {
            if (ModelState.IsValid)
            {               
                try
                {
                    EmissoraView e = new EmissoraView();
                    e.Id = model.Id;
                    e.Nome = model.Nome;
                    EmissoraDAO dao = new EmissoraDAO();
                    dao.Edicao(e);

                    ModelState.Clear();

                    TempData["MensagemEdicao"] = $"Autor {e.Nome}, atualizado com sucesso.";
                    return RedirectToAction("Consulta");
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View();
        }

        // GET: Excluir/Emissora
        public ActionResult Excluir(int id)
        {
            try
            {
                EmissoraDAO dao = new EmissoraDAO();

                Emissora e = dao.ObterPorId(id);
                dao.Remover(e.Id);

                ModelState.Clear();
                TempData["Mensagem"] = "Emissora" + e.Nome + " foi excluido com sucesso.";               

            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }
            return RedirectToAction("Consulta");
        }

        [HttpPost]
        public ActionResult Excluir(EmissoraView model)
        {
            try
            {
                EmissoraDAO dao = new EmissoraDAO();
                dao.Remover(model.Id);

                ModelState.Clear();
                TempData["MensagemExclusao"] = $"Autor {model.Nome}, excluido com sucesso.";                
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View();
        }


        // GET: Consulta/Emissora
        public ActionResult Consulta()
        {
            var lista = new List<EmissoraView>();
            try
            {
                EmissoraDAO dao = new EmissoraDAO();
                foreach(Emissora e in dao.ListarTodas())
                {
                    var model = new EmissoraView();
                    model.Id = e.Id;
                    model.Nome = e.Nome;

                    lista.Add(model);
                }

            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View(lista);
        }
    }
}