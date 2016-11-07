using GerenciadorLixoEletronico.NH.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorLixoEletronico.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostoDeColeta()
        {
            ViewBag.PostosDeColeta = ConfigDB.Instance.PostoDeColetaRepository.GetAll();
            return View();
        }

        public ActionResult SolicitaColeta()
        {
            return View();
        }

        public ActionResult VisualizarPostoDeColeta(int id)
        {
            var posto = ConfigDB.Instance.PostoDeColetaRepository.GetAll().FirstOrDefault(x => x.Id == id);

            if (posto != null)
            {

                return View(posto);
            }
            return RedirectToAction("Index");
        }
    }
}