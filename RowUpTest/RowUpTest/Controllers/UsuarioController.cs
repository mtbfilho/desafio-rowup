using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RowUpTest.Models;

namespace RowUpTest.Controllers
{
    public class UsuarioController : ApiController
    {
        public List<Usuario> GetUsuarios()
        {
            return RowupBD.GetUsuarios();
        }
    }
}
