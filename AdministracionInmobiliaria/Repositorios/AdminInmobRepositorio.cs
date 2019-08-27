using AdministracionInmobiliaria.Contracts;
using AdministracionInmobiliaria.Models.Entities;
using AdministracionInmobiliaria.ViewModels;
using AdministracionInmobiliaria.ViewModels.Peticiones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionInmobiliaria.Repositorios
{
    public class AdminInmobRepositorio : IAdminInmobRepositorio
    {
        private AdministracionInmobiliariaContext context;

        public AdminInmobRepositorio(AdministracionInmobiliariaContext contexto)
        {
            this.context = contexto;
        }

        public async Task<LoginRequetsViewModel> ObtenerAcceso(PeticionLoginViewModel infoUsuario)
        {
            LoginRequetsViewModel salida = new LoginRequetsViewModel();

            salida = await context.UsuariosPermisos
                .Where(u => u.IdUsuarioNavigation.UserName == infoUsuario.Email
                            && u.IdUsuarioNavigation.PasswordEncrypted == infoUsuario.Password)
                .Select(u => new LoginRequetsViewModel()
                {
                    UserName = u.IdUsuarioNavigation.UserName,
                    Permiso = u.IdPermisoNavigation.Nombre
                })
                .FirstOrDefaultAsync();

            return salida;
        }
    }
}
