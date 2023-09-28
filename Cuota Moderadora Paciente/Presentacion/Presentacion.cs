using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Presentacion
{
    internal class Presentacion
    {
        LiquidacionCuotaModeradoraService liquidacionCuotaModeradoraService = new LiquidacionCuotaModeradoraService();
        public void menu()
        {

            int opc = 0;

            while (opc != 8)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(40, 1); Console.WriteLine("         **   * IPS MAS SALUD Y VIDA *   **    ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(40, 2); Console.WriteLine(" ________________________________________________");
                Console.SetCursorPosition(40, 3); Console.WriteLine("| \t\t  MENU PRINCIPAL \t\t |");
                Console.SetCursorPosition(40, 4); Console.WriteLine("|------------------------------------------------|");
                Console.SetCursorPosition(40, 5); Console.WriteLine("| 1. REGISTRAR LIQUIDACION PACIENTE \t\t |");
                Console.SetCursorPosition(40, 6); Console.WriteLine("| 2. INFORME GENERAL DE LIQUIDACIONES \t\t |");
                Console.SetCursorPosition(40, 7); Console.WriteLine("| 3. CONSULTA POR TIPO DE AFILIACION \t\t |");
                Console.SetCursorPosition(40, 8); Console.WriteLine("| 4. CONSULTA VALOR TOTAL DE CUOTA MODERADORA \t |");
                Console.SetCursorPosition(40, 9); Console.WriteLine("| 5. CONSULTA LIQUIDACIONES POR MES Y AÑO \t |");
                //Console.SetCursorPosition(40, 10); Console.WriteLine("| 6. CONSULTA LIQUIDACIONES POR NOMBRE \t\t |");
                Console.SetCursorPosition(40, 10); Console.WriteLine("| 6. MODIFICAR POR VALOR DEL SERVICIO \t\t |");
                Console.SetCursorPosition(40, 11); Console.WriteLine("| 7. ELIMINAR LIQUIDACION \t\t\t |");
                Console.SetCursorPosition(40, 12); Console.WriteLine("| 8. SALIR \t\t\t\t\t |");
                Console.SetCursorPosition(40, 13); Console.WriteLine("|  \t\t\t\t\t\t |");
                Console.SetCursorPosition(40, 14); Console.Write("| Escoja una opcion: \t\t\t\t |");

                Console.SetCursorPosition(40, 15); Console.WriteLine(" ------------------------------------------------");
                Console.SetCursorPosition(61, 14); opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        liquidacionCuotaModeradoraService.Agregar();
                        break;
                    case 2:
                        liquidacionCuotaModeradoraService.Informe();
                        break;
                    case 3:
                        liquidacionCuotaModeradoraService.MostrarLiquidacionesPorTipo();
                        break;
                    case 4:liquidacionCuotaModeradoraService.TotalCuotasModeradoras();
                        break;
                    case 5:liquidacionCuotaModeradoraService.InformeMesAño();
                        break;
                    case 6:
                        liquidacionCuotaModeradoraService.Modificar();
                        break;
                    case 7:
                        liquidacionCuotaModeradoraService.Eliminar();
                        break;
                    case 8:
                        Console.SetCursorPosition(43, 17); Console.WriteLine("¡ Gracias por Utilizar nuestros servicios !");                        
                        break;
                    default:
                        Console.SetCursorPosition(50, 17); Console.WriteLine("¡ Opcion Invalida !");
                        break;
                }
                Console.ReadKey();
            }
        }


        
    }
}
