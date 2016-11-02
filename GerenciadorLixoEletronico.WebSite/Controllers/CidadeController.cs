using GerenciadorLixoEletronico.NH.Config;
using GerenciadorLixoEletronico.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorLixoEletronico.WebSite.Controllers
{
    public class CidadeController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            var cidades = ConfigDB.Instance.CidadeRepository.GetAll();
            return View(cidades);
        }

        public ActionResult Novo()
        {
            var estados = ConfigDB.Instance.EstadoRepository.GetAll();
            var lstEstados = new SelectList(estados, "Id", "Nome");
            ViewBag.lstEstados = lstEstados;

            return View();
        }

        public ActionResult Alterar(int id)
        {
            var cidade = ConfigDB.Instance.CidadeRepository.GetAll().FirstOrDefault(e => e.Id == id);
            
            if (cidade != null)
            {
                var estados = ConfigDB.Instance.EstadoRepository.GetAll();
                ViewBag.lstEstados = new SelectList(estados, "Id", "Nome");

                return View(cidade);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Gravar(Cidade cidade)
        {
            ModelState.Remove("Estado.Nome");
            ModelState.Remove("Estado.Pais");
            cidade.Estado = ConfigDB.Instance.EstadoRepository.GetAll().FirstOrDefault(x => x.Id == cidade.Estado.Id);

            if (ModelState.IsValid)
            {
                ConfigDB.Instance.CidadeRepository.Gravar(cidade);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Alterar", cidade);
        }

        public ActionResult ConfirmaDelete(int id)
        {
            var cidade = ConfigDB.Instance.CidadeRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if (cidade != null)
            {
                return View(cidade);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int id)
        {
            var cidade = ConfigDB.Instance.CidadeRepository.GetAll().FirstOrDefault(x => x.Id == id);

            if (cidade != null)
            {
                ConfigDB.Instance.CidadeRepository.Excluir(cidade);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Visualizar(int id)
        {
            var cidade = ConfigDB.Instance.CidadeRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if (cidade != null)
            {
                return View(cidade);
            }

            return RedirectToAction("Index");
        }
    }
}