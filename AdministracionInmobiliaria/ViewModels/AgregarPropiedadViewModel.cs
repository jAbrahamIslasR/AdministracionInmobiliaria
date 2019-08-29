using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionInmobiliaria.ViewModels
{
    public class AgregarPropiedadViewModel
    {
        [Required(ErrorMessage = "Se requiere un número para poder agregar una propiedad")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Se requiere proporcionar a que desarrollo pertenece la propiedad")]
        public int Desarrollo { get; set; }
        public string Area { get; set; }
        public string Notas { get; set; }
        public decimal CostoMensual { get; set; }
        public string Adicional { get; set; }
        public bool Disponible { get; set; }

        public AgregarPropiedadViewModel()
        {
            Numero = string.Empty;
            Area = string.Empty;
            Notas = string.Empty;
            Adicional = string.Empty;
            Disponible = true;
        }
    }
}
