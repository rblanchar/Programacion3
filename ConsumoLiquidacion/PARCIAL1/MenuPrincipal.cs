using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL1
{
    internal class MenuPrincipal
    {
        public double ValorTotaL1 { get; private set; }

        public void VerPrincipal(int l, int t)
        {


            int op;
            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();

                Console.SetCursorPosition(l, t - 2); Console.WriteLine("MENU PRINCIPAL REGISTRO DE LIQUIDACIONES");
                Console.SetCursorPosition(l, t + 2); Console.WriteLine("1. AGREGAR lIQUIDACION");
                Console.SetCursorPosition(l, t + 3); Console.WriteLine("2. CONSULTAR LIQUIDACION");
                Console.SetCursorPosition(l, t + 4); Console.WriteLine("3. liquidaciones del Impuesto al consumo de cervezas, sifones y refajos");
                Console.SetCursorPosition(l, t + 5); Console.WriteLine("4. liquidaciones del Impuestos de Licores, vinos y aperitivos");
                Console.SetCursorPosition(l, t + 6); Console.WriteLine("5. Total recaudado por Liquidaciones");
                //Console.SetCursorPosition(l, t + 5); Console.WriteLine("6. Total recaudado por Liquidaciones");


                Console.SetCursorPosition(l, t + 8); Console.WriteLine("6. SALIR");
                Console.SetCursorPosition(l, t + 10); Console.WriteLine("Digite una opcion: ");
                Console.SetCursorPosition(l + 19, t + 10); op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Agregar(15, 5);
                        break;
                    case 2:
                        EjecutarListar(1, 1);
                        break;
                    case 3:
                        new PresentacionConsumo().EjecutarListar(1, 1);
                        break;
                    case 4:
                        new PresentacionLicores().EjecutarListar(1, 1);
                        break;

                    case 5:
                        ValorTotal(15, 5);
                        break;

                    case 6:
                        Console.Clear();
                        Console.SetCursorPosition(l, t - 2); Console.WriteLine("GRACIAS, VUELVA PRONTO");
                        Console.SetCursorPosition(l + 22, t - 2); Console.ReadKey();
                        break;
                }

            } while (op != 6);
        }

        public void Agregar(int l, int t)
        {


            int op;
            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();


                Console.SetCursorPosition(l, t - 2); Console.WriteLine("MENU REGISRAR LIQUIDACION ");
                Console.SetCursorPosition(l, t + 2); Console.WriteLine("1. AGREGAR liquidaciones del Impuesto al consumo de cervezas, sifones y refajos");
                Console.SetCursorPosition(l, t + 3); Console.WriteLine("2. AGREGAR liquidaciones del Impuestos de Licores, vinos y aperitivos");
                Console.SetCursorPosition(l, t + 5); Console.WriteLine("3. SALIR");
                Console.SetCursorPosition(l, t + 7); Console.WriteLine("Digite una opcion: ");
                Console.SetCursorPosition(l + 19, t + 7); op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        new PresentacionConsumo().EjecutarAgregar(15, 5);
                        break;
                    case 2:
                        new PresentacionLicores().EjecutarAgregar(15, 5);
                        break;

                    case 3:
                        VerPrincipal(25, 5);
                        break;
                }

            } while (op != 6);
        }


        public void EjecutarListar(int l, int t)
        {
            Console.Clear();
            IServiciosConsumo consumo = new IServiciosConsumo();
            IServiciosLicores Licores = new IServiciosLicores();
            int i = 2;
            int b = 3;
            Console.SetCursorPosition(l, t);
            Console.WriteLine("N° Liquidacion");

            Console.SetCursorPosition(l + 20, t);
            Console.WriteLine("Nit");

            Console.SetCursorPosition(l + 35, t);
            Console.WriteLine("Nombre o RazonSocial");

            Console.SetCursorPosition(l + 65, t);
            Console.WriteLine("Base Gravable");

            Console.SetCursorPosition(l + 90, t);
            Console.WriteLine("Tarifa");

            Console.SetCursorPosition(l + 105, t);
            Console.WriteLine("Valor");

            foreach (var item in consumo.GetAll())
            {
                Console.SetCursorPosition(l, i);
                Console.WriteLine(item.NumLiquidacion);

                Console.SetCursorPosition(l + 20, i);
                Console.WriteLine(item.Nit);

                Console.SetCursorPosition(l + 35, i );
                Console.WriteLine(item.RazonSocial);

                Console.SetCursorPosition(l + 65, i);
                Console.WriteLine(item.BaseGravable);

                Console.SetCursorPosition(l + 90, i);
                Console.WriteLine(item.Tarifa);

                Console.SetCursorPosition(l + 105, i);
                Console.WriteLine(item.Valor);
                i=i+2;

            }

            foreach (var item in Licores.GetAll())
            {
                    Console.SetCursorPosition(l, b);
                    Console.WriteLine(item.NumLiquidacion);

                    Console.SetCursorPosition(l + 20, b);
                    Console.WriteLine(item.Nit);

                    Console.SetCursorPosition(l + 35, b);
                    Console.WriteLine(item.RazonSocial);

                    Console.SetCursorPosition(l + 65, b);
                    Console.WriteLine(item.BaseGravable);

                    Console.SetCursorPosition(l + 90, b);
                    Console.WriteLine(item.Tarifa);

                    Console.SetCursorPosition(l + 105, b);
                    Console.WriteLine(item.Valor);
                    b=b+2;

             }
            Console.ReadKey();
        }

        public void ValorTotal(int l, int t)
        {
            Console.Clear();
            IServiciosConsumo consumo = new IServiciosConsumo();
            IServiciosLicores Licores = new IServiciosLicores();

            double Valor1 = 0;
            double Valor2 = 0;

            foreach (var item in Licores.GetAll())
            {
                Valor1 = Valor1 + item.Valor;
            }

            foreach (var item in consumo.GetAll())
            {
                Valor2 = Valor2 + item.Valor;
            }
            double ValorTotal = Valor1 + Valor2;
            Console.SetCursorPosition(l, t + 2); Console.WriteLine("VALOR TOTAL LIQUIDACION =" + ValorTotal );
            Console.ReadKey();
        }

    }
}




