using AdministracionInmobiliaria.Auxiliares;
using AdministracionInmobiliaria.Contracts;
using AdministracionInmobiliaria.Models.Entities;
using AdministracionInmobiliaria.ViewModels;
using AdministracionInmobiliaria.ViewModels.Genericos;
using AdministracionInmobiliaria.ViewModels.Peticiones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AdministracionInmobiliaria.Auxiliares.Enumeradores.EnumeradoresControlErrores;

namespace AdministracionInmobiliaria.Services
{
    public class LoginServices : ILoginServices
    {
        private AdministracionInmobiliariaContext context;
        private AuxiliarControlMensajesError auxiliarErrores = new AuxiliarControlMensajesError();
        private IAdminInmobRepositorio repositorio;

        public LoginServices(AdministracionInmobiliariaContext contexto, IAdminInmobRepositorio repo)
        {
            this.context = contexto;
            this.repositorio = repo;
        }

        public async Task<object> ObtenerAcceso(PeticionLoginViewModel infoUsuario)
        {
            var respuesta = new LoginRequetsViewModel();
            var respuestaError = new ServerResponseViewModel();

            if (infoUsuario.Email == "Admin")
            {
                respuesta = await repositorio.ObtenerAccesoAdmin(infoUsuario);
            }
            else
            {
                respuesta = await repositorio.ObtenerAcceso(infoUsuario);
            }

            //Si no se encuentra información del usuario
            if (respuesta == null)
            {
                respuestaError = auxiliarErrores.ControlMensajesError(ListaErrores.ERROR_LOGIN);
                return respuestaError;
            }

            return respuesta;
        }
    }
}
