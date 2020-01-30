using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RowUpTest.Models;

namespace RowUpTest.Controllers
{
    public class CadastroUsuarioController : Controller
    {
        // GET: CadastroUsuario
        public ActionResult Index()
        {
            return View("DadosUsuario");
        }

        [HttpPost]
        public ActionResult Inserir([Bind(Include = "Nome")] Usuario usuario)
        {
            RowupBD.Inserir(usuario);

            return View("DadosUsuario");
        }

        [HttpGet]
        public ActionResult TodosAscendente()
        {
            return View("TodosUsuarios", RowupBD.GetUsuarios("asc"));
        }

        [HttpGet]
        public ActionResult TodosDescendente()
        {
            return View("TodosUsuarios", RowupBD.GetUsuarios("desc"));
        }

        [HttpGet]
        public ActionResult TodosEFAscendente()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (RowupCxt cxt = new RowupCxt())
            {
                var ordenados = from usuario in cxt.Usuarios orderby usuario.Nome ascending select usuario;
                
                foreach (var ordenado in ordenados)
                {
                    usuarios.Add(ordenado);
                }
            }

            return View("TodosUsuarios", usuarios);
        }

        [HttpGet]
        public ActionResult TodosEFDescendente()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (RowupCxt cxt = new RowupCxt())
            {
                var ordenados = from usuario in cxt.Usuarios orderby usuario.Nome descending select usuario;

                foreach (var ordenado in ordenados)
                {
                    usuarios.Add(ordenado);
                }
            }

            return View("TodosUsuarios", usuarios);
        }
    }
}