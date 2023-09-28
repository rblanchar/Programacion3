using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ImpuestoLicores: Impuesto
    {
        public double Tarifa { get; set; }

        public void Valor1(double Base)
        {
            int tarifa = 0;
            if (Base <= 35)
            {
                tarifa = 272;
            }
            else if (Base > 35)
            {
                tarifa = 446;
            }

            Tarifa = tarifa;
            Valor = Tarifa * Base;
        }
        public override string ToString()
        {
            return $"{NumLiquidacion};{Nit};{RazonSocial};{BaseGravable};{Tarifa};{Valor}";
        }
    }
}
