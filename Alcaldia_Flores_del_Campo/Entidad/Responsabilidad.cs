using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Responsabilidad
    {

        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public double ValorIngresosAnuales { get; set; }
        public double ValorGastosAnuales { get; set; }
        public double TiempoFuncionamiento { get; set; }
        public string TipoResponsabilidad { get; set; }
        public double Ganancias { get; set; }
        public double ValorEnUVT { get; set; }
        public double Tarifa { get; set; }
        public double ValorImpuesto { get; set; }
        
        
        public Responsabilidad()
        {
        }

        public Responsabilidad(string identificacion)
        {
            Identificacion = identificacion;
        }

        public Responsabilidad(string identificacion, string nombre, double valorIngresosAnuales, double valorGastosAnuales, 
            double tiempoFuncionamiento, string tipoResponsabilidad, double ganancias, double valorEnUVT, double tarifa, 
            double valorImpuesto) : this(identificacion)
        {
            Nombre = nombre;
            ValorIngresosAnuales = valorIngresosAnuales;
            ValorGastosAnuales = valorGastosAnuales;
            TiempoFuncionamiento = tiempoFuncionamiento;
            TipoResponsabilidad = tipoResponsabilidad;
            Ganancias = ganancias;
            ValorEnUVT = valorEnUVT;
            Tarifa = tarifa;
            ValorImpuesto = valorImpuesto;
        }

        public override string ToString()
        {
            return $"{Identificacion};{Nombre};{ValorIngresosAnuales};{ValorGastosAnuales};{TiempoFuncionamiento};{TipoResponsabilidad};" +
                $"{Ganancias};{ValorEnUVT};{Tarifa};{ValorImpuesto}";
        }
    }
}
