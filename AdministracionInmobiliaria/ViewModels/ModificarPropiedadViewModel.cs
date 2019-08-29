using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionInmobiliaria.ViewModels
{
    public class ModificarPropiedadViewModel
    {
        [Required(ErrorMessage = "Es necesario proporcionar un Id de propiedad para poder modificarla")]
        public int IdPropiedad { get; set; }
        public bool Disponible { get; set; }
    }
}
