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

        public ServerResponseViewModel ControlMensajesError(ListaErrores error)
        {
            var valor = (int)error;

            switch (valor)
            {
                case 101:
                    mensajeError.Header = "Error al consultar información";
                    mensajeError.Message = "El nombre de usuario o contraseña no son correctos, favor de verificarlos.";
                    mensajeError.Succeded = false;
                    break;
                default:
                    break;
            }

            return mensajeError;
        }
    }
}
