using GerenciadorLixoEletronico.NH.Model;
using GerenciadorLixoEletronico.NH.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorLixoEletronico.WebSite.Models
{
    public class UsuariosUtils
    {
        public static Usuario Usuario
        {
            get
            {
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    var usuario = (Usuario)HttpContext.Current.Session["Usuario"];
                    return usuario;
                }
                return null;
            }
        }

        public static bool isLogado
        {
            get
            {
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    var usuario = (Usuario)HttpContext.Current.Session["Usuario"];
                    return true;
                }
                return false;
            }
        }

        public static void Logar(string login, string senha)
        {
            try
            {
                var usuario = ConfigDB.Instance.UsuarioRepository.GetAll()
                    .FirstOrDefault(f => f.Senha == senha && f.Login == login);
                if (usuario != null)
                {
                    HttpContext.Current.Session["Usuario"] = usuario;
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static void Deslogar()
        {
            HttpContext.Current.Session["Usuario"] = null;
            HttpContext.Current.Session.Remove("Usuario");
        }
    }
}