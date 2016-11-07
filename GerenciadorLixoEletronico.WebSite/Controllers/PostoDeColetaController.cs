using GerenciadorLixoEletronico.NH.Config;
using GerenciadorLixoEletronico.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorLixoEletronico.WebSite.Controllers
{    
    public class PostoDeColetaController : Controller
    {
        // GET: PostoDeColeta
        public ActionResult Index()
        {
            var postosDeColeta = ConfigDB.Instance.PostoDeColetaRepository.GetAll();
            return View(postosDeColeta);
        }

        public ActionResult NovoP1()
        {
            
            var paises = ConfigDB.Instance.PaisRepository.GetAll();
            var lstPaises = new SelectList(paises, "Id", "Nome");
            ViewBag.lstPaises = lstPaises;

            return View(new Pais());
        }

        [HttpPost]
        public ActionResult NovoP2(Pais pais)
        {
            var estados = ConfigDB.Instance.EstadoRepository.GetAll().Where(x=>x.Pais.Id == pais.Id);
            var lstEstados = new SelectList(estados, "Id", "Nome");
            ViewBag.lstEstados = lstEstados;

            return View(new Estado());
        }

        [HttpPost]
        public ActionResult NovoPosto(Estado estado)
        {

            var cidades = ConfigDB.Instance.CidadeRepository.GetAll().Where(x => x.Estado.Id == estado.Id);
            var lstCidades = new SelectList(cidades, "Id", "Nome");
            ViewBag.lstCidades = lstCidades;

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Gravar(PostoDeColeta posto)
        {
            posto.Endereco.Cidade = ConfigDB.Instance.CidadeRepository.GetAll().FirstOrDefault(x => x.Id == posto.Endereco.Cidade.Id);
            posto.Endereco.Estado = posto.Endereco.Cidade.Estado.Nome;
            posto.Endereco.Pais = posto.Endereco.Cidade.Estado.Pais.Nome;

            ConfigDB.Instance.EnderecoRepository.Gravar(posto.Endereco);
            ConfigDB.Instance.PostoDeColetaRepository.Gravar(posto);


            return RedirectToAction("Index"); 
        }  

        public ActionResult Visualizar(int id)
        {
            var posto = ConfigDB.Instance.PostoDeColetaRepository.GetAll().FirstOrDefault(x => x.Id == id);
            
            if(posto != null)
            {
                
                return View(posto);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ConfirmaDelete(int id)
        {
            var posto = ConfigDB.Instance.PostoDeColetaRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if(posto != null)
            {
               return View(posto);
            }

            return RedirectToAction("Index");

        }

        public ActionResult Excluir(int id)
        {
            var posto = ConfigDB.Instance.PostoDeColetaRepository.GetAll().FirstOrDefault(x => x.Id == id);

            if (posto != null)
            {
                ConfigDB.Instance.EnderecoRepository.Excluir(posto.Endereco);
                ConfigDB.Instance.PostoDeColetaRepository.Excluir(posto);
            }

            return RedirectToAction("Index");
        }
    }
}