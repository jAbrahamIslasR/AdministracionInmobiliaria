using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionInmobiliaria.Auxiliares.Enumeradores
{
    public class EnumeradoresControlErrores
    {
        public enum ListaErrores
        {
            //Errores en servicio Login
            ERROR_LOGIN = 101,

            //Errores en servicio de Propiedades
            ERROR_VALOR_COSTO_MENSUAL = 102,
            ERROR_VALOR_IDDESARROLLO = 103,
            ERROR_AGREGAR_PROPIEDAD = 104,
            ERROR_CONSULTA_PROPIEDADES = 105,
            ERROR_CAMBIAR_DISPONIBILIDAD_PROPIEDAD = 106
        }

        public enum ListaMensajesExito
        {
            AGREGAR_PROPIEDAD = 10,
            CAMBIAR_DISPONIBILIDAD_PROPIEDAD = 11
        }
    }
}
