using AdministracionInmobiliaria.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionInmobiliaria.Contracts
{
    public interface IPropiedadesServices
    {
        Task<object> AgregarPropiedad(AgregarPropiedadViewModel datosPropiedad);

        Task<object> ConsultarPropiedades();

        Task<object> CambiarDisponibilidadPropiedad(ModificarPropiedadViewModel infoPropiedad);
    }
}
