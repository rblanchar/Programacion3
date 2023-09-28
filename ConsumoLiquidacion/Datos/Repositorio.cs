using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    internal interface Repositorio
    {
        List<Impuesto> GetAll();
        Impuesto Mappear(string lineaDatos);
    }
}
