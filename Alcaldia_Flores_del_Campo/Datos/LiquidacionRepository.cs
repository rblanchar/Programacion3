using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class LiquidacionRepository
    {
        string fileName = "Liquidaciones.txt";
        public string GuardarLiquidacion(Responsabilidad responsabilidad)
        {


            //1 abrimos el archivo
            var escritor = new StreamWriter(fileName, true);
            //2 opereacion deescritura
            escritor.WriteLine(responsabilidad.ToString());
            //3 cerrar - guardar los datos en el disco
            escritor.Close();

            return "Liquidacion guardada con Exito!";
        }



        public string Guardar(List<Responsabilidad> responsabilidades)
        {

            var escritor = new StreamWriter(fileName, false);
            foreach (var item in responsabilidades)
            {
                escritor.WriteLine(item.ToString());
            }
            escritor.Close();

            return "datos actalizados";
        }

        public List<Responsabilidad> InformeLiquidaciones()
        {
            List<Responsabilidad> responsabilidades = new List<Responsabilidad>();
            try
            {
                StreamReader lector = new StreamReader(fileName);
                while (!lector.EndOfStream)
                {
                    var linea = lector.ReadLine();
                    responsabilidades.Add(Map(linea));

                }
                lector.Close();

                return responsabilidades;
            }
            catch (Exception)
            {
                return null;
            }

        }

        private Responsabilidad Map(string linea)
        {
            Responsabilidad responsabilidad = new Responsabilidad();
            var datos = linea.Split(';');
            responsabilidad.Identificacion = (datos[0]);
            responsabilidad.Nombre = (datos[1]);
            responsabilidad.ValorIngresosAnuales = double.Parse(datos[2]);
            responsabilidad.ValorGastosAnuales = double.Parse(datos[3]);
            responsabilidad.TiempoFuncionamiento = double.Parse(datos[4]);
            responsabilidad.TipoResponsabilidad = (datos[5]);
            responsabilidad.Ganancias = double.Parse(datos[6]);
            responsabilidad.ValorEnUVT = double.Parse(datos[7]);
            responsabilidad.Tarifa= double.Parse(datos[8]);
            responsabilidad.ValorImpuesto = double.Parse(datos[9]);
            
            

            return responsabilidad;
        }

        public string Actualizar(List<Responsabilidad> responsabilidades)
        {

            var escritor = new StreamWriter(fileName, false);
            foreach (var item in responsabilidades)
            {
                escritor.WriteLine(item.ToString());
            }
            escritor.Close();

            return "Liquidaciones Actalizadas";
        }
    }
}
