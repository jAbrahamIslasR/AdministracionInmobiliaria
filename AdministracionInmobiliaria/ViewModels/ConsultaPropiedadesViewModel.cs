using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionInmobiliaria.ViewModels
{
    public class ConsultaPropiedadesViewModel
    {
        public int IdPropiedad { get; set; }
        public string Inmueble { get; set; }
        public string Numero { get; set; }
        public string Area { get; set; }
        public string Nota { get; set; }
        public decimal Renta { get; set; }
        public string Adicional { get; set; }

        public ConsultaPropiedadesViewModel()
        {
            Inmueble = string.Empty;
            Numero = string.Empty;
            Area = string.Empty;
            Adicional = string.Empty;
        }
    }
}
