using AdministracionInmobiliaria.ViewModels.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AdministracionInmobiliaria.Auxiliares.Enumeradores.EnumeradoresControlErrores;

namespace AdministracionInmobiliaria.Auxiliares
{
    public class AuxiliarControlMensajesError
    {
        private ServerResponseViewModel mensajeError = new ServerResponseViewModel();
        private ServerResponseViewModel mensajeExito = new ServerResponseViewModel();

        public ServerResponseViewModel ControlMensajesError(ListaErrores error)
        {
            var valor = (int)error;

            switch (valor)
            {
                //Casos de error de servicio Login
                case 101:
                    mensajeError.Header = "Error al consultar información";
                    mensajeError.Message = "El nombre de usuario o contraseña no son correctos, favor de verificarlos.";
                    mensajeError.Succeded = false;
                    break;

                //Casos de error de servicio de Propiedades
                case 102:
                    mensajeError.Header = "Error al agregar propiedad";
                    mensajeError.Message = "El valor del costo mensual debe ser mayor a 0, favor de verificarlo.";
                    mensajeError.Succeded = false;
                    break;

                case 103:
                    mensajeError.Header = "Error al agregar propiedad";
                    mensajeError.Message = "Se debe seleccionar el desarrollo al cual pertenece la propiedad, favor de verificarlo.";
                    mensajeError.Succeded = false;
                    break;

                case 104:
                    mensajeError.Header = "Error al agregar propiedad";
                    mensajeError.Message = "Ocurrió un error inesperado al agregar una propiedad, favor de reintentarlo.";
                    mensajeError.Succeded = false;
                    break;

                case 105:
                    mensajeError.Header = "Error al consultar propiedades";
                    mensajeError.Message = "No existen propiedades disponibles para mostrar.";
                    mensajeError.Succeded = false;
                    break;

                case 106:
                    mensajeError.Header = "Error al modificar propiedad";
                    mensajeError.Message = "Ocurrió un error al tratar de cambiar la disponibilidad de la propiedad, favor de reintentarlo.";
                    mensajeError.Succeded = false;
                    break;

                default:
                    break;
            }

            return mensajeError;
        }

        public ServerResponseViewModel ControlMensajesExito(ListaMensajesExito exito)
        {
            var valor = (int)exito;

            switch (valor)
            {
                //Casos de error de servicio de Propiedades
                case 10:
                    mensajeExito.Header = "Agregar propiedad";
                    mensajeExito.Message = "La propiedad fue agregada correctamente.";
                    mensajeExito.Succeded = true;
                    break;

                case 11:
                    mensajeExito.Header = "Modificar propiedad";
                    mensajeExito.Message = "La disponibilidad de la propiedad fue cambiada correctamente.";
                    mensajeExito.Succeded = true;
                    break;

                default:
                    break;
            }

            return mensajeExito;
        }
    }
}
