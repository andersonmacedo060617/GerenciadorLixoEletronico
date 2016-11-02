using GerenciadorLixoEletronico.NH.Config;
using GerenciadorLixoEletronico.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorLixoEletronico.WebSite.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            var estados = ConfigDB.Instance.EstadoRepository.GetAll();
            return View(estados);
        }

        public ActionResult Novo()
        {
            var paises = ConfigDB.Instance.PaisRepository.GetAll();
            var lstPaises = new SelectList(paises, "Id", "Nome");
            ViewBag.lstPaises = lstPaises;

            return View();
        }

        public ActionResult Alterar(int id)
        {
            var estado = ConfigDB.Instance.EstadoRepository.GetAll().FirstOrDefault(e => e.Id == id);
            

            if (estado != null)
            {
                var paises = ConfigDB.Instance.PaisRepository.GetAll();
                ViewBag.lstPaises = new SelectList(paises, "Id", "Nome");

                return View(estado);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Gravar(Estado estado)
        {
            ModelState.Remove("Pais.Nome");
            estado.Pais = ConfigDB.Instance.PaisRepository.GetAll().FirstOrDefault(x => x.Id == estado.Pais.Id);
            
            if (ModelState.IsValid)
            {
                ConfigDB.Instance.EstadoRepository.Gravar(estado);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Alterar", estado);
        }

        public ActionResult ConfirmaDelete(int id)
        {
            var estado = ConfigDB.Instance.EstadoRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if (estado != null && estado.Cidades.Count == 0)
            {
                return View(estado);
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

    }
}