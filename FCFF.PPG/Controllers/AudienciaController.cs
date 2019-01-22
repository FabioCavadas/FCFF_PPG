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
    public class AudienciaController : Controller
    {
        // GET: Audiencia
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cadastro/Audiencia
        public ActionResult Cadastro()
        {
            AudienciaView viewModel = new AudienciaView();
            viewModel.ListagemEmissoras = ObterEmissoras();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Cadastro(AudienciaView model)
        {
            try
            {
                AudienciaDAO dao = new AudienciaDAO();

                if (!dao.AudienciaExistente(model.Id))
                {
                    Audiencia a = new Audiencia();

                    a.Pontos = model.Pontos;
                    a.DataHora = model.DataHora;
                    a.IdEmissora = model.IdEmissora;

                    dao.Cadastrar(a);

                    ViewBag.Mensagem = $"Audiência cadastrada com sucesso.";
                    ModelState.Clear();
                    
                }
                else
                {
                    ViewBag.Mensagem = $"Audiência já foi cadastrado.";
                }

            }
            catch (Exception e)
            {

                ViewBag.Mensagem = "Erro: " + e.Message;
            }

            AudienciaView viewModel = new AudienciaView();
            viewModel.ListagemEmissoras = ObterEmissoras();
            return View(viewModel);
        }

        // GET: 
        public ActionResult ConsultaAudienciaData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConsultaAudienciaData(DateTime dti, DateTime dtf)
        {
            if (ModelState.IsValid)
            {
                var lista = new List<AudienciaView>();
                try
                {
                    AudienciaDAO dao = new AudienciaDAO();

                    foreach (AudienciaView av in dao.PesquisaAudienciaData(dti, dtf))
                    {
                        var model = new AudienciaView();
                        model.Nome = av.Nome;                        
                        model.Pontos = av.Pontos;
                        model.DataHora = av.DataHora;                        

                        lista.Add(model);
                    }
                    return View(lista);

                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View();
        }

        // GET: 
        public ActionResult ConsultaSomatorioAudiencia(string nome, DateTime data)
        {
            if (ModelState.IsValid)
            {
                var lista = new List<AudienciaView>();
                try
                {
                    AudienciaDAO dao = new AudienciaDAO();

                    foreach (AudienciaView av in dao.PesquisaSomatorioMediaAudiencia(nome,data))
                    {
                        var model = new AudienciaView();

                        model.Nome = av.Nome;
                        model.Somatorio = av.Somatorio;
                        model.DataHora = av.DataHora;

                        lista.Add(model);
                    }
                    return View(lista);
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View();
        }

        // GET: 
        public ActionResult ConsultaMediaAudiencia(string nome, DateTime data)
        {
            if (ModelState.IsValid)
            {
                var lista = new List<AudienciaView>();
                try
                {
                    AudienciaDAO dao = new AudienciaDAO();

                    foreach (AudienciaView av in dao.PesquisaSomatorioMediaAudiencia(nome, data))
                    {
                        var model = new AudienciaView();
                        model.Nome = av.Nome;
                        model.Media = av.Media;
                        model.DataHora = av.DataHora.Date;

                        lista.Add(model);
                    }
                    return View(lista);
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View();
        }

        private List<SelectListItem> ObterEmissoras()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            EmissoraDAO dao = new EmissoraDAO();

            foreach (Emissora emissora in dao.ListarTodas())
            {
                SelectListItem item = new SelectListItem();
                item.Value = emissora.Id.ToString();
                item.Text = emissora.Nome;

                lista.Add(item);
            }

            return lista;
        }
    }
}