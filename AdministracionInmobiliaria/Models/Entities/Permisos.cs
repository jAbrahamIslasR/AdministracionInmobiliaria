using System;
using System.Collections.Generic;

namespace AdministracionInmobiliaria.Models.Entities
{
    public partial class Permisos
    {
        public Permisos()
        {
            UsuariosPermisos = new HashSet<UsuariosPermisos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<UsuariosPermisos> UsuariosPermisos { get; set; }
    }
}
