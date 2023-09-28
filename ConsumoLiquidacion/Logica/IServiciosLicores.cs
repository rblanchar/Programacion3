using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class IServiciosLicores : IServiciosImpuesto<ImpuestoLicores>
    {
        Archivo a= new Archivo();
        RepositorioLicores b = new RepositorioLicores();
        string ruta = "ImpuestosLicores.txt";
        List<ImpuestoLicores> ListaLicores = new List<ImpuestoLicores>();

        public IServiciosLicores()
        {
            //ListaLicores = b.GetAll();
        }

        public void Add(ImpuestoLicores licores)
        {
            Console.WriteLine(a.Guardar(licores.ToString(), ruta)); 
        }


        List<ImpuestoLicores> IServiciosImpuesto<ImpuestoLicores>.GetAll2()
        {
            return ListaLicores;
        }

        public List<ImpuestoLicores> GetAll()
        {
            ListaLicores = b.GetAll();
            return ListaLicores;
        }
    }
}
