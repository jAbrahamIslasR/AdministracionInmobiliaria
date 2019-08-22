using System;
using System.Collections.Generic;

namespace AdministracionInmobiliaria.Models.Entities
{
    public partial class Propiedades
    {
        public Propiedades()
        {
            Pagos = new HashSet<Pagos>();
            Rentas = new HashSet<Rentas>();
        }

        public int Id { get; set; }
        public string Numero { get; set; }
        public int IdDesarrollo { get; set; }
        public string Area { get; set; }
        public string Notas { get; set; }
        public decimal CostoMensual { get; set; }
        public string Adicional { get; set; }
        public bool? Disponible { get; set; }

        public Desarrollos IdDesarrolloNavigation { get; set; }
        public ICollection<Pagos> Pagos { get; set; }
        public ICollection<Rentas> Rentas { get; set; }
    }
}
