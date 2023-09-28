using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ImpuestoConsumo : Impuesto
    {
        
        public double Tarifa { get; set; }
        public int tipo { get; set; }
        //1 Cervezas y sifones
        //2  Mezclas y refajos
        public void Valor1(double Base, int Tipo)
        {
            double Porcentaje=0;
            if (Tipo == 1)
            {
                Porcentaje = 0.48;
            } else if (Tipo == 2)
            {
                Porcentaje = 0.2;
            }

            Tarifa = Base * Porcentaje;
            Valor = Tarifa * Base;
        }

        public override string ToString()
        {
            return $"{NumLiquidacion};{Nit};{RazonSocial};{BaseGravable};{Tarifa};{Valor}";
        }


    }
}
