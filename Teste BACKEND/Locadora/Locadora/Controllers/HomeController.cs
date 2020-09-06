using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Locadora.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            Usuario usuario = new Usuario();
            usuario.ID = 123;
            usuario.Nome = "Admin";

            ViewBag.Usuario = usuario;
            return View();
        }

        public ActionResult CadastroCliente()
        {
            Usuario usuario = new Usuario();
            usuario.ID = 123;
            usuario.Nome = "Admin";

            ViewBag.Usuario = usuario;
            return View();
        }

        public ActionResult CadastroFilme()
        {
            Usuario usuario = new Usuario();
            usuario.ID = 123;
            usuario.Nome = "Admin";

            ViewBag.Usuario = usuario;
            return View();
        }

        public ActionResult Locar()
        {
            Usuario usuario = new Usuario();
            usuario.ID = 123;
            usuario.Nome = "Admin";

            ViewBag.Usuario = usuario;
            return View();
        }

        public ActionResult Devolver()
        {
            Usuario usuario = new Usuario();
            usuario.ID = 123;
            usuario.Nome = "Admin";

            ViewBag.Usuario = usuario;
            return View();
        }
    }
}