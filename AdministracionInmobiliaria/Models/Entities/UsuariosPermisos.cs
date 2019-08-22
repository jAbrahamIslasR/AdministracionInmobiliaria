using System;
using System.Collections.Generic;

namespace AdministracionInmobiliaria.Models.Entities
{
    public partial class UsuariosPermisos
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPermiso { get; set; }

        public Permisos IdPermisoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
