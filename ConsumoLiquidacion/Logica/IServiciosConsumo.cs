using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Logica
{
    public class IServiciosConsumo : IServiciosImpuesto<ImpuestoConsumo>
    {
        Archivo a = new Archivo();
        RepositorioConsumos b = new RepositorioConsumos();
        List<ImpuestoConsumo> ListaConsumo = new List<ImpuestoConsumo>();
        string ruta = "ImpuestosConsumos.txt";

        public IServiciosConsumo()
        {
            //ListaConsumo = b.GetAll();
        }
        public void Add(ImpuestoConsumo Impuesto)
        {
            Console.WriteLine(a.Guardar(Impuesto.ToString(), ruta));
        }


        List<ImpuestoConsumo> IServiciosImpuesto<ImpuestoConsumo>.GetAll2()
        {
            return ListaConsumo;
        }

        public List<ImpuestoConsumo> GetAll()
        {
            ListaConsumo = b.GetAll();
            return ListaConsumo;
        }




    }
}
