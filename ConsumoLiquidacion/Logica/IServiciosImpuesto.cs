﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface IServiciosImpuesto<T>
    {
        void Add(T Impuesto);
        List<T> GetAll2();
    }
}
