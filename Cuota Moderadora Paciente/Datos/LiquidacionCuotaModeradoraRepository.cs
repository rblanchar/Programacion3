using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class LiquidacionCuotaModeradoraRepository
    {
        string fileName = "Taller.txt";
        //private object liquidacionCuotaModeradora;

        public string Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            var escritor = new StreamWriter(fileName, true);
            escritor.WriteLine(liquidacionCuotaModeradora.ToString());
            escritor.Close();

            Console.SetCursorPosition(38,19); return "Liquidacion Registrada Exitoxamente!";
        }

        public string Guardarl(List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras)
        {
            var escritor = new StreamWriter(fileName, false);
            foreach (var item in liquidacionCuotaModeradoras)
            {
                escritor.WriteLine(item.ToString());
            }
            escritor.Close();
            return "Datos Ingresados correctamente";
        }

        public List<LiquidacionCuotaModeradora> ConsultarInformacion()
        {
            List <LiquidacionCuotaModeradora> liquidacionCuotaModeradoras = new List<LiquidacionCuotaModeradora>();

            try
            {
                StreamReader lector = new StreamReader(fileName);
                while (!lector.EndOfStream)
                {
                    var linea = lector.ReadLine();
                    liquidacionCuotaModeradoras.Add(Map(linea));
                }
                lector.Close();
                return liquidacionCuotaModeradoras;
            }
            catch (Exception)
            {

                return null;
            }
        }


        public LiquidacionCuotaModeradora Map(string linea)
        {
            LiquidacionCuotaModeradora liquidacionCuotaModeradora = new LiquidacionCuotaModeradora();
            var datos = linea.Split(';');
            liquidacionCuotaModeradora.NumLiquidacion = int.Parse(datos[0]);
            liquidacionCuotaModeradora.FechaLiquidacion = DateTime.Parse(datos[1]);
            liquidacionCuotaModeradora.IdPaciente = datos[2];
            liquidacionCuotaModeradora.TipoLiquidacion = datos[3];
            liquidacionCuotaModeradora.Salario = double.Parse(datos[4]);
            liquidacionCuotaModeradora.ValorServicio = double.Parse(datos[5]);
            liquidacionCuotaModeradora.Tarifa = double.Parse(datos[6]);
            liquidacionCuotaModeradora.ValorLiquidadoReal = double.Parse(datos[7]);
            liquidacionCuotaModeradora.TopeMaximo = double.Parse(datos[8]);
            liquidacionCuotaModeradora.CuotaModeradora = double.Parse(datos[9]);

            return liquidacionCuotaModeradora;

        }
        public string Actualizar(List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras)
        {
            var escritor = new StreamWriter(fileName, false);
            foreach (var item in liquidacionCuotaModeradoras)
            {
                escritor.WriteLine(item.ToString());
            }
            escritor.Close();

            return "Liquidaciones Actalizadas";
        }
    }
}
