﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Modelos.Repositorios
{
    public interface IUnidadTrabajo : IDisposable
    {
        Task<int> Complete();
    }
}
