using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RegimenContributivo:LiquidacionCuotaModeradora
    {
        double SalarioMinimo = 1160000;

        public override double CalcularCuotaModeradora(double Salario, double ValorServicio)
        {
            double Tope1 = 250000;
            double Tope2 = 900000;
            double Tope3 = 1500000;

            if (Salario < (SalarioMinimo * 2))
            {
                Tarifa = 0.15;
                TopeMaximo = Tope1;
                ValorLiquidadoReal = ValorServicio * Tarifa;
                if (ValorLiquidadoReal > TopeMaximo)
                {
                    CuotaModeradora = TopeMaximo;
                    
                }
                else
                {
                    CuotaModeradora = ValorLiquidadoReal;
                    TopeMaximo = 0;
                }
            }
            else if (Salario >= (SalarioMinimo * 2) && Salario <= (SalarioMinimo * 5))
            {
                Tarifa = 0.20;
                TopeMaximo = Tope2;
                ValorLiquidadoReal = ValorServicio * Tarifa;
                if (ValorLiquidadoReal > TopeMaximo)
                {
                    CuotaModeradora = TopeMaximo;
                    
                }
                else
                {
                    CuotaModeradora = ValorLiquidadoReal;
                    TopeMaximo = 0;
                }
            }
            else if (Salario > (SalarioMinimo * 5))
            {
                Tarifa = 0.25;
                TopeMaximo = Tope3;
                ValorLiquidadoReal = ValorServicio * Tarifa;
                if (ValorLiquidadoReal > TopeMaximo)
                {
                    CuotaModeradora = TopeMaximo;

                }
                else
                {
                    CuotaModeradora = ValorLiquidadoReal;
                    TopeMaximo = 0;
                }
            }


            return base.CalcularCuotaModeradora(Salario, ValorServicio);
        }
    }
}
