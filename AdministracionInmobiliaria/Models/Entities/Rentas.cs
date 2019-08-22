using System;
using System.Collections.Generic;

namespace AdministracionInmobiliaria.Models.Entities
{
    public partial class Rentas
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int IdDesarrollo { get; set; }
        public int IdPropiedad { get; set; }
        public string Arrendatario { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public decimal CostoTotal { get; set; }

        public Desarrollos IdDesarrolloNavigation { get; set; }
        public Propiedades IdPropiedadNavigation { get; set; }
    }
}
