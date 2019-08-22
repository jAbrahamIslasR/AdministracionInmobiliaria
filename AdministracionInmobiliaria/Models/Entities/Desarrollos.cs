using System;
using System.Collections.Generic;

namespace AdministracionInmobiliaria.Models.Entities
{
    public partial class Desarrollos
    {
        public Desarrollos()
        {
            Propiedades = new HashSet<Propiedades>();
            Rentas = new HashSet<Rentas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public ICollection<Propiedades> Propiedades { get; set; }
        public ICollection<Rentas> Rentas { get; set; }
    }
}
