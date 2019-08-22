using System;
using System.Collections.Generic;

namespace AdministracionInmobiliaria.Models.Entities
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            UsuariosPermisos = new HashSet<UsuariosPermisos>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordEncrypted { get; set; }

        public ICollection<UsuariosPermisos> UsuariosPermisos { get; set; }
    }
}
