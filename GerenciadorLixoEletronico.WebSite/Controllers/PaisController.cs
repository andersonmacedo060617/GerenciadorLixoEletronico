using GerenciadorLixoEletronico.NH.Config;
using GerenciadorLixoEletronico.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorLixoEletronico.WebSite.Controllers
{
    public class PaisController : Controller
    {
        // GET: Pais
        public ActionResult Index()
        {
            var paises = ConfigDB.Instance.PaisRepository.GetAll();
            return View(paises);
        }

        public ActionResult Alterar(int id)
        {
            var pais = ConfigDB.Instance.PaisRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if(pais != null)
            {
                return View(pais);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Gravar(Pais pais)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Alterar", pais);
            }

            ConfigDB.Instance.PaisRepository.Gravar(pais);

            return RedirectToAction("Index");
        }

        public ActionResult ConfirmaDelete(int id)
        {
            var pais = ConfigDB.Instance.PaisRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if(pais != null && pais.Estados.Count == 0)
            {
                return View(pais);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int id)
        {
            var pais = ConfigDB.Instance.PaisRepository.GetAll().FirstOrDefault(x => x.Id == id);
            
            if (pais != null)
            {
                ConfigDB.Instance.PaisRepository.Excluir(pais);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Visualizar(int id)
        {
            var pais = ConfigDB.Instance.PaisRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if(pais != null)
            {
                return View(pais);
            }
            
            return RedirectToAction("Index");
        }
    }
}