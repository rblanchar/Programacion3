using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioConsumos
    {
        public string ruta = "ImpuestosConsumos.txt";
        public List<ImpuestoConsumo> GetAll()
        {
            StreamReader sr = new StreamReader(ruta);
            //string linea;
            List<ImpuestoConsumo> Consumos = new List<ImpuestoConsumo>();
            while (!sr.EndOfStream)
            {
                //linea = sr.ReadLine();
                Consumos.Add(Mappear(sr.ReadLine()));
            }
            return Consumos;
        }

        public ImpuestoConsumo Mappear(string lineaDatos)
        {
            ImpuestoConsumo a = new ImpuestoConsumo();

            a.NumLiquidacion = int.Parse((lineaDatos.Split(';')[0]));
            a.Nit = int.Parse(lineaDatos.Split(';')[1]);
            a.RazonSocial = (lineaDatos.Split(';')[2]);
            a.BaseGravable = double.Parse((lineaDatos.Split(';')[3]));
            a.Tarifa = double.Parse((lineaDatos.Split(';')[4]));
            a.Valor = double.Parse(lineaDatos.Split(';')[5]);

            return a;
        }
    }
}
