using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionInmobiliaria.ViewModels.Genericos
{
    public class ServerResponseViewModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
        public bool Succeded { get; set; }

        public ServerResponseViewModel()
        {
            Id = 0;
            Header = string.Empty;
            Message = string.Empty;
            Succeded = true;
        }
    }
}
