using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Prueba
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Familiar familiar = new Familiar();
            //familiar.Id = 1;
            //familiar.Nombre = "Carlo";
            //familiar.Telefono = "1232412";

            Archivo archivo = new Archivo();
            //Console.WriteLine("HELLO WORD");
            //Console.WriteLine(archivo.Guardar(familiar.ToString()));



            foreach (var Familiar in archivo.GetAll())
            {
                //Console.WriteLine("ID:"+item.Id + " - Nombre:" + item.Nombre + " - Telefono:" + item.Telefono);
                //Console.WriteLine(Familiar.MostrarDatos());
                //familiar=Familiar;
                archivo.Guardar(Familiar.ToString());
            }
            
            Console.ReadKey();
            

        }
    }
}
