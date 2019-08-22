using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministracionInmobiliaria.Contracts;
using AdministracionInmobiliaria.ViewModels;
using AdministracionInmobiliaria.ViewModels.Peticiones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionInmobiliaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginServices servicio;

        public LoginController(ILoginServices service)
        {
            this.servicio = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Milo", "Cabra" };
        }

        [HttpPost]
        [Route("ObtenerAcceso")]
        public async Task<IActionResult> ObtenerAcceso(PeticionLoginViewModel infoUsuario)
        {
            LoginRequetsViewModel respuesta = new LoginRequetsViewModel();
            respuesta = await servicio.ObtenerAcceso(infoUsuario);
            return Ok(respuesta);
        }
    }
}