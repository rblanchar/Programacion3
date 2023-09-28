using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Logica
{
    public class LiquidacionService
    {
        List<Responsabilidad> listaResponsables;
        LiquidacionRepository liquidacionRepository = new LiquidacionRepository();
        public LiquidacionService()
        {
            listaResponsables = liquidacionRepository.InformeLiquidaciones();
        }

        public void Registrar()
        {
            Console.Clear();
            Console.WriteLine("ALCALDIA DE LAS FLORES DEL CAMPO");            
            Console.WriteLine("REGISTRAR LIQUIDACION ");
            Console.WriteLine("");
            Console.Write("Ingrese la Identificacion del Establecimiento: ");
            string Identificacion = Console.ReadLine();
            if (BuscarId(Identificacion) != null)
            {
                Console.WriteLine("La Identificacion ingresada Ya existe!");
               
            }
            else
            {

                Console.Write("Ingrese el Nombre del Establecimiento: ");
                string Nombre = Console.ReadLine().ToUpper();

                Console.Write("Ingrese el Valor de Ingresos Anuales: ");
                double ValorIngresosAnuales = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ingrese el Valor de Gastos Anuales: ");
                double ValorGastosAnuales = Convert.ToDouble((Console.ReadLine()));

                Console.Write("Ingrese el Tiempo de Funcionamiento en años: ");
                double TiempoFuncionamiento = Convert.ToDouble((Console.ReadLine()));

                Console.WriteLine("Tipo de Responsabilidad");
                Console.WriteLine("");
                Console.WriteLine("1. Responsable de IVA");
                Console.WriteLine("2. No Responsable de IVA");
                Console.WriteLine("3. Regimen Simple de Tributacion (RST)");
                Console.WriteLine("Escoja una opcion:");
                int opcion = Convert.ToInt16(Console.ReadLine());
                string TipoResponsabilidad="";

                double Ganancia = ValorIngresosAnuales - ValorGastosAnuales;
                double ValorImpuesto = 0;
                int UVT = 30000;
                double Tarifa = 0.0;
                double ValorEnUVT = 0;
                ValorEnUVT = Ganancia / UVT;

                while (opcion < 0 || opcion > 3)
                {
                    Console.WriteLine("Opcion Invalida!");

                }

                if (opcion == 1)
                {

                    TipoResponsabilidad = "RESPONSABLE DE IVA";
                    if (Ganancia < 0)
                    {
                        Tarifa = 0;
                        ValorImpuesto = (Ganancia * 0.0);
                    }
                    else if (Ganancia < (100 * UVT))
                    {
                        Tarifa = (0.05);
                        ValorImpuesto = (Ganancia * Tarifa);
                    }
                    else if (Ganancia >= (100 * UVT) && Ganancia < (200 * UVT))
                    {
                        Tarifa = (0.10);
                        ValorImpuesto = (Ganancia * Tarifa);
                    }
                    else if (Ganancia >= (200 * UVT))
                    {
                        Tarifa = (0.15);
                        ValorImpuesto = (Ganancia * Tarifa);
                    }
                }
                    else if( opcion ==2)
                    {
                        TipoResponsabilidad = "NO RESPONSABLE DE IVA";
                        if (Ganancia > (100 * UVT))
                        {
                            if (TiempoFuncionamiento < 6)
                            {
                                Tarifa = 0.1;
                                ValorImpuesto = (Ganancia * Tarifa);
                            }
                            else if (TiempoFuncionamiento >= 6 && TiempoFuncionamiento < 10)
                            {
                                Tarifa = 0.2;
                                ValorImpuesto = (Ganancia * Tarifa);
                            }
                            else if (TiempoFuncionamiento >= 10)
                            {
                                Tarifa = 0.3;
                                ValorImpuesto = Ganancia * Tarifa;
                            }

                        }
                        else
                        {
                            ValorImpuesto = Ganancia * 0.0;
                        }
                    }   else if ( opcion ==3)
                        {
                            TipoResponsabilidad = "REGIMEN SIMPLE (RST)";
                            if (Ganancia> 50*UVT)
                            {
                                Tarifa = 0.05;
                                ValorImpuesto = Ganancia * Tarifa;
                            }   else
                                {
                                    ValorImpuesto = Ganancia * 0.0;
                                }
                        }

                Responsabilidad responsable = new Responsabilidad(Identificacion, Nombre, ValorIngresosAnuales, ValorGastosAnuales, TiempoFuncionamiento, TipoResponsabilidad, Ganancia, ValorEnUVT, Tarifa, ValorImpuesto);
                Console.WriteLine("EL IMPUESTO A CANCELAR ES DE: " + ValorImpuesto);
                Console.WriteLine(liquidacionRepository.GuardarLiquidacion(responsable));
                listaResponsables = liquidacionRepository.InformeLiquidaciones();
                Console.ReadKey();
            }
        }
        public List<Responsabilidad> InformeLiquidaciones()
        {
            return listaResponsables;
        }

        public void Informe()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 1); Console.WriteLine("ALCALDIA DE LAS FLORES DEL CAMPO");
            Console.SetCursorPosition(40, 2); Console.Write("INFORME GENERAL DE LIQUIDACIONES");
            Console.SetCursorPosition(0, 4); Console.Write("ID");
            Console.SetCursorPosition(8, 4); Console.Write("NOMBRE");
            Console.SetCursorPosition(17, 4); Console.Write("VALOR ING");
            Console.SetCursorPosition(18, 5); Console.Write("ANUALES");
            Console.SetCursorPosition(29, 4); Console.Write("VALOR GASTOS");
            Console.SetCursorPosition(31, 5); Console.Write("ANUALES");
            Console.SetCursorPosition(43, 4); Console.Write("TIEMPO DE ");
            Console.SetCursorPosition(43, 5); Console.Write("FUNC.(AÑOS)");
            Console.SetCursorPosition(59, 4); Console.Write("TIPO DE ");
            Console.SetCursorPosition(57, 5); Console.Write("RESPONSABILIDAD");
            Console.SetCursorPosition(77, 4); Console.Write("GANANCIA");
            Console.SetCursorPosition(88, 4); Console.Write("VALOR UVT");
            Console.SetCursorPosition(87, 5); Console.Write("(1UVT=25000)");
            Console.SetCursorPosition(102, 4); Console.Write("TARIFA");
            Console.SetCursorPosition(104, 5); Console.Write("%");
            Console.SetCursorPosition(111, 4); Console.Write("VALOR DEL");
            Console.SetCursorPosition(111, 5); Console.Write("IMPUESTO");
            for (int l= 0; l <=119;l++)
            {
                Console.SetCursorPosition(l, 6); Console.Write("_");
            }


            int posicion = 2;
            foreach (var item in InformeLiquidaciones())
            {

                Console.SetCursorPosition(0, 5 + posicion); Console.Write(item.Identificacion);
                Console.SetCursorPosition(8, 5 + posicion); Console.Write(item.Nombre);
                Console.SetCursorPosition(18, 5 + posicion); Console.Write(item.ValorIngresosAnuales);
                Console.SetCursorPosition(31, 5 + posicion); Console.Write(item.ValorGastosAnuales);
                Console.SetCursorPosition(46, 5 + posicion); Console.Write(item.TiempoFuncionamiento);
                Console.SetCursorPosition(53, 5 + posicion); Console.Write(item.TipoResponsabilidad);
                Console.SetCursorPosition(78, 5 + posicion); Console.Write(item.Ganancias);
                Console.SetCursorPosition(90, 5 + posicion); Console.Write(item.ValorEnUVT.ToString("0.0"));
                Console.SetCursorPosition(102, 5 + posicion); Console.Write(item.Tarifa*100);
                Console.SetCursorPosition(111, 5 + posicion); Console.Write(item.ValorImpuesto);
                
                Console.Write("");
                posicion++;
            }
            Console.ReadKey();
        }

        public string Eliminar(Responsabilidad responsabilidad)
        {
            if (responsabilidad == null)
            {
                return "La Identificacion ingresada No existe!";
            }
            var buscado = BuscarId(responsabilidad.Identificacion);
            if (buscado != null)
            {
                listaResponsables.Remove(buscado);
                Actualizar(listaResponsables);
                return "Registro ELiminado!";
            }
            return "";
        }

        public void Actualizar(List<Responsabilidad> responsabilidades)
        {
            //var msg = 
                liquidacionRepository.Actualizar(responsabilidades);
            listaResponsables = liquidacionRepository.InformeLiquidaciones();
            //return msg;
        }

        public Responsabilidad BuscarId(string id)
        {
            foreach (var item in listaResponsables)
            {
                if (item.Identificacion == id)
                {
                    return item;
                }

            }
            return null;
        }

    }
}
