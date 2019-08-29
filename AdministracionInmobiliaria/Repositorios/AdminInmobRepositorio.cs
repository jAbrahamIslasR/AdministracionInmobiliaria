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

        #region Métodos para el servicio de Login

        /// <summary>
        /// Método para que un usuario obtenga acceso al sistema
        /// </summary>
        /// <param name="infoUsuario">Información del login del usuario</param>
        /// <returns>Objeto de tipo "LoginRequetsViewModel"</returns>
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

        /// <summary>
        /// Método que se ocupa para el login del usuario "Admin", a fin de facilitar las pruebas del sistema y presentaciones
        /// </summary>
        /// <param name="infoUsuario">Información del login del usuario</param>
        /// <returns>Objeto de tipo "LoginRequetsViewModel"</returns>
        public async Task<LoginRequetsViewModel> ObtenerAccesoAdmin(PeticionLoginViewModel infoUsuario)
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

        #endregion

        #region Métodos para el servicio de Propiedades

        public async Task<int> AgregarPropiedad(AgregarPropiedadViewModel datosPropiedad)
        {
            //Variable de tipo int para devolver la respuesta de acción
            int retorno = 0;

            try
            {
                //Generar el objeto Propiedad del contexto de datos
                Propiedades nuevaPropiedad = new Propiedades();

                nuevaPropiedad.Numero = datosPropiedad.Numero;
                nuevaPropiedad.IdDesarrollo = datosPropiedad.Desarrollo;
                nuevaPropiedad.Area = datosPropiedad.Area;
                nuevaPropiedad.Notas = datosPropiedad.Notas;
                nuevaPropiedad.CostoMensual = datosPropiedad.CostoMensual;
                nuevaPropiedad.Adicional = datosPropiedad.Adicional;
                nuevaPropiedad.Disponible = datosPropiedad.Disponible;

                await context.Propiedades.AddAsync(nuevaPropiedad);
                await context.SaveChangesAsync();

                retorno = nuevaPropiedad.Id;

                return retorno;
            }
            catch (Exception ex)
            {
                //Retornar un valor 0 para identificar que hubo un error
                return retorno;
            }
        }

        public async Task<List<ConsultaPropiedadesViewModel>> ObtenerPropiedades()
        {
            //Objeto para retornar la lista de propiedades
            List<ConsultaPropiedadesViewModel> listaPropiedades = new List<ConsultaPropiedadesViewModel>();

            listaPropiedades = await context.Propiedades
                .Where(p => p.Disponible == true)
                .Select(p => new ConsultaPropiedadesViewModel()
                {
                    IdPropiedad = p.Id,
                    Inmueble = p.IdDesarrolloNavigation.Nombre,
                    Numero = p.Numero,
                    Area = p.Area,
                    Nota = p.Notas,
                    Renta = p.CostoMensual,
                    Adicional = p.Adicional
                })
                .ToListAsync();

            return listaPropiedades;
        }

        public async Task<int> CambiarDisponibilidad(ModificarPropiedadViewModel infoPropiedad)
        {
            int retorno = 0;

            try
            {
                Propiedades cambioPropiedad = new Propiedades();

                cambioPropiedad = await context.Propiedades
                    .Where(p => p.Id == infoPropiedad.IdPropiedad)
                    .FirstOrDefaultAsync();

                cambioPropiedad.Disponible = infoPropiedad.Disponible;

                await context.SaveChangesAsync();

                return retorno = 1;
            }
            catch (Exception ex)
            {
                return retorno = 0;
            }
        }

        #endregion
    }
}
