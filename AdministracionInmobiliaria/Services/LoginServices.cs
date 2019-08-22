using AdministracionInmobiliaria.Contracts;
using AdministracionInmobiliaria.Models.Entities;
using AdministracionInmobiliaria.ViewModels;
using AdministracionInmobiliaria.ViewModels.Peticiones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionInmobiliaria.Services
{
    public class LoginServices : ILoginServices
    {
        private AdministracionInmobiliariaContext context;

        public LoginServices(AdministracionInmobiliariaContext contexto)
        {
            this.context = contexto;
        }

        public async Task<LoginRequetsViewModel> ObtenerAcceso(PeticionLoginViewModel infoUsuario)
        {
            var respuesta = new LoginRequetsViewModel();

            respuesta = await context.UsuariosPermisos
                .Where(u => u.IdUsuarioNavigation.UserName == infoUsuario.Email
                            && u.IdUsuarioNavigation.Password == infoUsuario.Password)
                .Select(u => new LoginRequetsViewModel()
                {
                    UserName = u.IdUsuarioNavigation.UserName,
                    Permiso = u.IdPermisoNavigation.Nombre
                })
                .FirstOrDefaultAsync();

            return respuesta;
        }
    }
}
