using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Entidad;
using System.Diagnostics;

namespace Presentacion
{
    internal class Presentacion
    {
        LiquidacionService liquidacionService = new LiquidacionService();
        public void menu()
        {

            int opc = 0;

            while (opc != 6)
            {

                Console.Clear();
                Console.WriteLine("ALCALDIA DE LAS FLORES DEL CAMPO");
                Console.WriteLine("");
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("");
                Console.WriteLine("1. REGISTRAR LIQUIDACION");
                Console.WriteLine("2. INFORME GENERAL DE LIQUIDACIONES");
                Console.WriteLine("3. ELIMINAR LIQUIDACION");

                Console.WriteLine("6. SALIR");
                Console.WriteLine("");
                Console.Write("Escoja una opcion: ");
                opc = Convert.ToInt32(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        liquidacionService.Registrar();
                        break;
                    case 2:
                        liquidacionService.Informe();
                        break;
                    case 3:
                        Eliminar();
                        break;
                    case 4:
                        
                        break;
                    case 5: break;
                    case 6:
                        Console.WriteLine("Gracias por Utilizar nuestros servicios!");
                        //Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcion Invalida !");
                        break;
                }
                Console.ReadKey();
            }
        }


        public void Eliminar()
        {
            Console.Clear();
            Console.WriteLine("ELIMINAR REGISTRO DE LIQUIDACION");
            Console.WriteLine("");

            Console.Write("Ingrese la identificacion: ");
            string cedula = Console.ReadLine();
            Responsabilidad responsabilidad = new Responsabilidad(cedula);

            if (liquidacionService.BuscarId(cedula)!= null)
            {
                Console.WriteLine("Registro Eliminado!");
                Console.WriteLine("Click o Enter para continuar....");
                Console.ReadKey();
                liquidacionService.Informe();
                Console.WriteLine(liquidacionService.Eliminar(responsabilidad));
                Console.WriteLine("");
                liquidacionService.Informe();

            }   else
                {
                Console.WriteLine("Identificacion No encontrada");
                }
            


        }
    }
}
