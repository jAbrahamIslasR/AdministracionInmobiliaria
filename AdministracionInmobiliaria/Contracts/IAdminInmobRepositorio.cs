using AdministracionInmobiliaria.ViewModels;
using AdministracionInmobiliaria.ViewModels.Peticiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionInmobiliaria.Contracts
{
    public interface IAdminInmobRepositorio
    {
        /// <summary>
        /// Método para que un usuario obtenga acceso al sistema
        /// </summary>
        /// <param name="infoUsuario">Información del login del usuario</param>
        /// <returns>Objeto de tipo "LoginRequetsViewModel"</returns>
        Task<LoginRequetsViewModel> ObtenerAcceso(PeticionLoginViewModel infoUsuario);

        /// <summary>
        /// Método que se ocupa para el login del usuario "Admin", a fin de facilitar las pruebas del sistema y presentaciones
        /// </summary>
        /// <param name="infoUsuario">Información del login del usuario</param>
        /// <returns>Objeto de tipo "LoginRequetsViewModel"</returns>
        Task<LoginRequetsViewModel> ObtenerAccesoAdmin(PeticionLoginViewModel infoUsuario);

        Task<int> AgregarPropiedad(AgregarPropiedadViewModel datosPropiedad);

        Task<List<ConsultaPropiedadesViewModel>> ObtenerPropiedades();

        Task<int> CambiarDisponibilidad(ModificarPropiedadViewModel infoPropiedad);
    }
}
