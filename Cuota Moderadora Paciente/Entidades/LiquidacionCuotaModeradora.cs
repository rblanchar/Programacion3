using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LiquidacionCuotaModeradora
    {
        public int NumLiquidacion { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public string IdPaciente { get; set; }
        public string TipoLiquidacion { get; set; }
        public double Salario { get; set; }
        public double ValorServicio { get; set; }
        public double Tarifa { get; set; }
        public double ValorLiquidadoReal { get; set; }
        public double TopeMaximo { get; set; }
        public double CuotaModeradora { get; set; }

        public LiquidacionCuotaModeradora()
        {
        }

        public LiquidacionCuotaModeradora(int numLiquidacion, DateTime fechaLiquidacion, string idPaciente, string tipoLiquidacion, double salario, double valorServicio, double tarifa, double valorLiquidadoReal, double topeMaximo, double cuotaModeradora)
        {
            NumLiquidacion = numLiquidacion;
            FechaLiquidacion = fechaLiquidacion;
            IdPaciente = idPaciente;
            TipoLiquidacion = tipoLiquidacion;
            Salario = salario;
            ValorServicio = valorServicio;
            Tarifa = tarifa;
            ValorLiquidadoReal = valorLiquidadoReal;
            TopeMaximo = topeMaximo;
            CuotaModeradora = cuotaModeradora;
        }

        public LiquidacionCuotaModeradora(string Identificacion)
        {
        }

        public override string ToString()
        {
            return $"{NumLiquidacion};{FechaLiquidacion};{IdPaciente};{TipoLiquidacion};{Salario};{ValorServicio};{Tarifa};{ValorLiquidadoReal};" +
                $"{TopeMaximo};{CuotaModeradora}";
        }

        public virtual double CalcularCuotaModeradora(double Salario, double ValorServicio)
        {
            //CuotaModeradora = Salario * Tarifa;
            return CuotaModeradora;
        }
        public virtual double CalcularCuotaModeradoraC(double ValorServicio)
        {
           // CuotaModeradora = Salario * Tarifa;
            return CuotaModeradora;
        }
    }
}
