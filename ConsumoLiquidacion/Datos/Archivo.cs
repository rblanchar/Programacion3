using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class Archivo
    {
        //public string ruta = "Archivo.txt";
        public string Guardar(string Impuesto, string ruta)
        {
            StreamWriter sw = new StreamWriter(ruta, true);
            sw.WriteLine(Impuesto);
            sw.Close();
            return $"almacenado correctamente .. ";
            //{ contacto.Nombre}
        }


    }
}
