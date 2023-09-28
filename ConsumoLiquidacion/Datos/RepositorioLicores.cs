using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioLicores
    {
        public string ruta = "ImpuestosLicores.txt";
        public List<ImpuestoLicores> GetAll()
        {
            StreamReader sr = new StreamReader(ruta);
            //string linea;
            List<ImpuestoLicores> Licores = new List<ImpuestoLicores>();
            while (!sr.EndOfStream)
            {
                //linea = sr.ReadLine();
                Licores.Add(Mappear(sr.ReadLine()));
            }
            return Licores;
        }

        public ImpuestoLicores Mappear(string lineaDatos)
        {
            ImpuestoLicores a = new ImpuestoLicores();
 
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
