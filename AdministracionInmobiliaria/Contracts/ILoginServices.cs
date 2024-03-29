﻿using AdministracionInmobiliaria.ViewModels;
using AdministracionInmobiliaria.ViewModels.Peticiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionInmobiliaria.Contracts
{
    public interface ILoginServices
    {
        Task<object> ObtenerAcceso(PeticionLoginViewModel infoUsuario);
    }
}
