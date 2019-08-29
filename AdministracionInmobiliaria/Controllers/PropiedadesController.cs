using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdministracionInmobiliaria.Contracts;
using AdministracionInmobiliaria.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionInmobiliaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadesController : ControllerBase
    {
        private IPropiedadesServices servicio;

        public PropiedadesController(IPropiedadesServices service)
        {
            this.servicio = service;
        }

        [HttpPost]
        [Route("AgregarPropiedad")]
        public async Task<IActionResult> AgregarPropiedad(AgregarPropiedadViewModel datosPropiedad)
        {
            var respuesta = await servicio.AgregarPropiedad(datosPropiedad);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("ConsultarPropiedades")]
        public async Task<IActionResult> ConsultarPropiedades()
        {
            var respuesta = await servicio.ConsultarPropiedades();
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("CambiarDisponibilidadPropiedad")]
        public async Task<IActionResult> CambiarDisponibilidadPropiedad(ModificarPropiedadViewModel infoPropiedad)
        {
            var respuesta = await servicio.CambiarDisponibilidadPropiedad(infoPropiedad);
            return Ok(respuesta);
        }
    }
}