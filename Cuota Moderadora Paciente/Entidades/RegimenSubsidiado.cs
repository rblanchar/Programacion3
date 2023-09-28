using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RegimenSubsidiado:LiquidacionCuotaModeradora
    {
        double TopeMaximo1 = 200000;
        public override double CalcularCuotaModeradoraC(double ValorServicio)
        {
            Tarifa = 0.05;
            TopeMaximo = TopeMaximo1;
            if (ValorServicio <= TopeMaximo1)
            {
                ValorLiquidadoReal = ValorServicio * Tarifa;
                if (ValorLiquidadoReal > TopeMaximo)
                {
                    CuotaModeradora = TopeMaximo;
                }
                else
                {
                    CuotaModeradora = ValorLiquidadoReal;
                }
            }
            else 
            {
                ValorLiquidadoReal = ValorServicio * Tarifa;
                CuotaModeradora = ValorLiquidadoReal;
            }

            return CuotaModeradora;
        }

    }
}
