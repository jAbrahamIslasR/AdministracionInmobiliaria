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

        public LoginServices(AdministracionInmobiliariaContext contexto)
        {
            this.context = contexto;
        }

        public async Task<object> ObtenerAcceso(PeticionLoginViewModel infoUsuario)
        {
            var respuesta = new LoginRequetsViewModel();
            var respuestaError = new ServerResponseViewModel();

            respuesta = await context.UsuariosPermisos
                .Where(u => u.IdUsuarioNavigation.UserName == infoUsuario.Email
                            && u.IdUsuarioNavigation.Password == infoUsuario.Password)
                .Select(u => new LoginRequetsViewModel()
                {
                    UserName = u.IdUsuarioNavigation.UserName,
                    Permiso = u.IdPermisoNavigation.Nombre
                })
                .FirstOrDefaultAsync();

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
