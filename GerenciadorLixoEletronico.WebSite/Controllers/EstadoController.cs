using GerenciadorLixoEletronico.NH.Config;
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
            return View();
        }
    }
}