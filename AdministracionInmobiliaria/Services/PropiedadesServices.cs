using AdministracionInmobiliaria.Auxiliares;
using AdministracionInmobiliaria.Contracts;
using AdministracionInmobiliaria.ViewModels;
using AdministracionInmobiliaria.ViewModels.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AdministracionInmobiliaria.Auxiliares.Enumeradores.EnumeradoresControlErrores;

namespace AdministracionInmobiliaria.Services
{
    public class PropiedadesServices : IPropiedadesServices
    {
        private AuxiliarControlMensajesError auxiliarErrores = new AuxiliarControlMensajesError();
        private IAdminInmobRepositorio repositorio;

        public PropiedadesServices(IAdminInmobRepositorio repo)
        {
            this.repositorio = repo;
        }

        public async Task<object> AgregarPropiedad(AgregarPropiedadViewModel datosPropiedad)
        {
            var respuesta = new ServerResponseViewModel();

            //Validar la información de la propiedad que se quiere agregar
            if (datosPropiedad.Desarrollo == 0 || datosPropiedad.Desarrollo < 0)
            {
                respuesta = auxiliarErrores.ControlMensajesError(ListaErrores.ERROR_VALOR_IDDESARROLLO);
                return respuesta;
            }

            if (datosPropiedad.CostoMensual == 0 || datosPropiedad.CostoMensual < 0)
            {
                respuesta = auxiliarErrores.ControlMensajesError(ListaErrores.ERROR_VALOR_COSTO_MENSUAL);
                return respuesta;
            }

            //En caso de pasar las validaciones, agregar la propiedad
            respuesta.Id = await repositorio.AgregarPropiedad(datosPropiedad);

            if (respuesta.Id <= 0)
            {
                respuesta = auxiliarErrores.ControlMensajesError(ListaErrores.ERROR_AGREGAR_PROPIEDAD);
                return respuesta;
            }
            else
            {
                respuesta = auxiliarErrores.ControlMensajesExito(ListaMensajesExito.AGREGAR_PROPIEDAD);
                return respuesta;
            }
        }

        public async Task<object> ConsultarPropiedades()
        {
            List<ConsultaPropiedadesViewModel> listaPropiedades = new List<ConsultaPropiedadesViewModel>();
            ServerResponseViewModel respuesta = new ServerResponseViewModel();

            //Consultar las propiedades
            listaPropiedades = await repositorio.ObtenerPropiedades();

            if (listaPropiedades == null || listaPropiedades.Count == 0)
            {
                respuesta = auxiliarErrores.ControlMensajesError(ListaErrores.ERROR_CONSULTA_PROPIEDADES);
                return respuesta;
            }
            else
            {
                return listaPropiedades;
            }
        }

        public async Task<object> CambiarDisponibilidadPropiedad(ModificarPropiedadViewModel infoPropiedad)
        {
            ServerResponseViewModel respuesta = new ServerResponseViewModel();

            //Cambiar disponibilidad de la propiedad
            respuesta.Id = await repositorio.CambiarDisponibilidad(infoPropiedad);

            if (respuesta.Id <= 0)
            {
                respuesta = auxiliarErrores.ControlMensajesError(ListaErrores.ERROR_CAMBIAR_DISPONIBILIDAD_PROPIEDAD);
                return respuesta;
            }
            else
            {
                respuesta = auxiliarErrores.ControlMensajesExito(ListaMensajesExito.CAMBIAR_DISPONIBILIDAD_PROPIEDAD);
                return respuesta;
            }
        }
    }
}
