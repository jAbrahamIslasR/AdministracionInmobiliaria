using System;
using System.Collections.Generic;

namespace AdministracionInmobiliaria.Models.Entities
{
    public partial class Pagos
    {
        public int Id { get; set; }
        public int IdPropiedad { get; set; }
        public decimal CantidadPagada { get; set; }
        public DateTime FechaReal { get; set; }
        public string MesPago { get; set; }
        public string Cuenta { get; set; }

        public Propiedades IdPropiedadNavigation { get; set; }
    }
}
