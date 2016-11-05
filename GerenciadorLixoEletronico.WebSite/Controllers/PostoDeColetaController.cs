using GerenciadorLixoEletronico.NH.Config;
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

    }
}