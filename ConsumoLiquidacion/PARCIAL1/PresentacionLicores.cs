using Datos;
using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL1
{ }
internal class PresentacionLicores
{
    public void EjecutarAgregar(int l, int t)
    {

        Console.Clear();
        Console.SetCursorPosition(l, t - 4);
        Console.WriteLine("Impuesto de Licores, vinos y aperitivos ");

        Console.SetCursorPosition(l, t - 2);
        Console.WriteLine("Número de liquidación: ");
        Console.SetCursorPosition(l + 50, t - 2);
        int NumLiqui = int.Parse((Console.ReadLine()));

        Console.SetCursorPosition(l, t - 1);
        Console.WriteLine("Identificación o Nit del contribuyente: ");
        Console.SetCursorPosition(l + 50, t - 1);
        int Nit = int.Parse(Console.ReadLine());

        Console.SetCursorPosition(l, t - 0);
        Console.WriteLine("Nombre o razón social del contribuyente: ");
        Console.SetCursorPosition(l + 50, t - 0);
        string RazonSocial = Console.ReadLine();

        Console.SetCursorPosition(l, t + 1);
        Console.WriteLine("Base gravable - Grado de alcohol: ");
        Console.SetCursorPosition(l + 50, t + 1);
        double Base = double.Parse(Console.ReadLine());


        ImpuestoLicores b = new ImpuestoLicores();
        b.NumLiquidacion = NumLiqui;
        b.Nit = Nit;
        b.RazonSocial = RazonSocial;
        b.BaseGravable = Base;
        b.Valor1(Base);

        Console.SetCursorPosition(l, t + 9);
        new Logica.IServiciosLicores().Add(b);

        Console.SetCursorPosition(l, t + 5);
        Console.ReadKey();

    }
    public void EjecutarListar(int l, int t)
    {
        Console.Clear();
        IServiciosLicores Licores = new IServiciosLicores();
        int i = 2;
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

        foreach (var item in Licores.GetAll())
        {
            Console.SetCursorPosition(l, i);
            Console.WriteLine(item.NumLiquidacion);

            Console.SetCursorPosition(l + 20, i);
            Console.WriteLine(item.Nit);

            Console.SetCursorPosition(l + 35, i);
            Console.WriteLine(item.RazonSocial);

            Console.SetCursorPosition(l + 65, i);
            Console.WriteLine(item.BaseGravable);

            Console.SetCursorPosition(l + 90, i);
            Console.WriteLine(item.Tarifa);

            Console.SetCursorPosition(l + 105, i);
            Console.WriteLine(item.Valor);
            i++;

        }
        Console.ReadKey();
    }
}
