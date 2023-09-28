using Datos;
using Entidades;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LiquidacionCuotaModeradoraService
    {
        List<LiquidacionCuotaModeradora> listaModeradora;

        LiquidacionCuotaModeradoraRepository liquidacionCuotaModeradoraRepository = new LiquidacionCuotaModeradoraRepository();

        public LiquidacionCuotaModeradoraService()
        {
            listaModeradora = liquidacionCuotaModeradoraRepository.ConsultarInformacion();
        }

        RegimenContributivo regimen = new RegimenContributivo();
        RegimenSubsidiado regimens = new RegimenSubsidiado();
        public void Agregar()
        {
            int opcion;
            string TipoLiquidacion;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(40, 1); Console.WriteLine("         **   * IPS MAS SALUD Y VIDA *   **    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40,3);Console.WriteLine("Menu Registro de Liquidacion de Paciente");

            Console.SetCursorPosition(38,5);Console.Write("Digite el numero de liquidacion: ");
            int NumLiquidacion = int.Parse(Console.ReadLine());

            bool fechaValida = false;
            DateTime fechaLiquidacion = DateTime.MinValue;

            while (!fechaValida)
            {
                Console.ForegroundColor= ConsoleColor.White;
                Console.SetCursorPosition(38,6);Console.Write("Ingrese la fecha de liquidación (dd/MM/yyyy): ");
                string fechaIngresada = Console.ReadLine();

                if (DateTime.TryParseExact(fechaIngresada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaLiquidacion))
                {
                    fechaValida = true;
                    Console.SetCursorPosition(84, 6); Console.WriteLine($"{fechaLiquidacion:dd/MM/yyyy}");
                }
                else
                {
                    Console.SetCursorPosition(84,6); Console.WriteLine("          ");
                    
                    Console.SetCursorPosition(38,7); Console.WriteLine("Fecha de liquidación inválida. Por favor, ingrese la fecha en formato dd/MM/yyyy.");
                }
            }
            Console.SetCursorPosition(38, 7); Console.WriteLine("                                                                                   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(38,8);Console.Write("Digite el Id del paciente: ");
            string IdPaciente = Console.ReadLine();

            Console.SetCursorPosition(45,10);Console.WriteLine("TIPO DE REGIMEN");
            Console.SetCursorPosition(38,12);Console.WriteLine("1. CONTRIBUTIVO");
            Console.SetCursorPosition(38,13);Console.WriteLine("2. SUBSIDIADO");
            Console.SetCursorPosition(38,14); Console.Write("Escoja una opcion: "); opcion = int.Parse(Console.ReadLine());

            while (opcion <= 0 || opcion > 2)
            {
                Console.SetCursorPosition(57, 13); Console.Write("       ");
                Console.SetCursorPosition(38, 14); Console.Write("Escoja una opcion: "); opcion = int.Parse(Console.ReadLine());

                    Console.ForegroundColor=ConsoleColor.DarkRed;
                    Console.SetCursorPosition(29,8); Console.WriteLine("Fecha de liquidación inválida. Por favor, ingrese la fecha en formato dd/MM/yyyy.");
            }
            
            Console.SetCursorPosition(29, 8); Console.WriteLine("                                                                                   ");
            Console.ForegroundColor = ConsoleColor.White;


            if (opcion == 1)
            {
                TipoLiquidacion = "CONTRIBUTIVO";
            }
            else TipoLiquidacion = "SUBSIDIADO";

            Console.SetCursorPosition(38,15);Console.Write("Digite el salario del paciente: ");
            double Salario = double.Parse(Console.ReadLine());

            Console.SetCursorPosition(38,16);Console.Write("Digite el valor del servicio: ");
            double ValorServicio = double.Parse(Console.ReadLine());

            double tarifaCalculada = 0;
            double valorLiquidadoRealCalculado = 0;
            double cuotaModeradora = 0;
            double topeMaximo = 0;

            if (TipoLiquidacion == "CONTRIBUTIVO")
            {
                regimen.CalcularCuotaModeradora(Salario, ValorServicio);
                tarifaCalculada = regimen.Tarifa;
                valorLiquidadoRealCalculado = regimen.ValorLiquidadoReal;
                topeMaximo = regimen.TopeMaximo;
                cuotaModeradora = regimen.CuotaModeradora;
                
            }
            else if (TipoLiquidacion == "SUBSIDIADO")
            {
                regimens.CalcularCuotaModeradoraC(ValorServicio);
                tarifaCalculada = regimens.Tarifa;
                valorLiquidadoRealCalculado = regimens.ValorLiquidadoReal;
                topeMaximo = regimens.TopeMaximo;
                cuotaModeradora = regimens.CuotaModeradora;
              
            }

            LiquidacionCuotaModeradora liquidacionCuotaModeradora = new LiquidacionCuotaModeradora(NumLiquidacion, fechaLiquidacion, IdPaciente, TipoLiquidacion, Salario, ValorServicio, tarifaCalculada, valorLiquidadoRealCalculado, topeMaximo, cuotaModeradora);

            Console.SetCursorPosition(38,17); Console.WriteLine("Valor a cancelar de Cuota Moderadora es = " + cuotaModeradora);
            Console.Write(liquidacionCuotaModeradoraRepository.Guardar(liquidacionCuotaModeradora));
        }

        public void Informe()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(45, 2); Console.WriteLine("Informe general de liquidaciones");
            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.SetCursorPosition(2, 4); Console.Write("Numero de");
            Console.SetCursorPosition(2, 5); Console.Write("Liquidacion");
            Console.SetCursorPosition(15, 4); Console.Write("Fecha de ");
            Console.SetCursorPosition(15, 5); Console.Write("Liquidacion");
            Console.SetCursorPosition(29, 4); Console.Write("Id del");
            Console.SetCursorPosition(29, 5); Console.Write("Paciente");
            Console.SetCursorPosition(42, 4); Console.Write("Tipo de");
            Console.SetCursorPosition(42, 5); Console.Write("Liquidacion");
            Console.SetCursorPosition(57, 4); Console.Write("Salario");
            Console.SetCursorPosition(68, 4); Console.Write("Valor del");
            Console.SetCursorPosition(68, 5); Console.Write("Servicio");
            Console.SetCursorPosition(78, 4); Console.Write("Tarifa");
            Console.SetCursorPosition(88, 4); Console.Write("Valor");
            Console.SetCursorPosition(88, 5); Console.Write("Real");
            Console.SetCursorPosition(97, 4); Console.Write("Tope");
            Console.SetCursorPosition(97, 5); Console.Write("Maximo");
            Console.SetCursorPosition(107, 4); Console.Write("Cuota");
            Console.SetCursorPosition(107, 5); Console.Write("Moderadora");
            int posicion = 3;
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in liquidacionCuotaModeradoraRepository.ConsultarInformacion())
            {
                DateTime fechaSinHora = item.FechaLiquidacion.Date;
                string fechaFormateada = fechaSinHora.ToString("dd/MM/yyyy");

                Console.SetCursorPosition(2, 4 + posicion); Console.Write(item.NumLiquidacion);
                Console.SetCursorPosition(15, 4 + posicion); Console.Write(fechaFormateada);
                Console.SetCursorPosition(29, 4 + posicion); Console.Write(item.IdPaciente);
                Console.SetCursorPosition(42, 4 + posicion); Console.Write(item.TipoLiquidacion);
                Console.SetCursorPosition(57, 4 + posicion); Console.Write(item.Salario);
                Console.SetCursorPosition(68, 4 + posicion); Console.Write(item.ValorServicio);
                Console.SetCursorPosition(78, 4 + posicion); Console.Write(item.Tarifa);
                Console.SetCursorPosition(88, 4 + posicion); Console.Write(item.ValorLiquidadoReal);
                Console.SetCursorPosition(97, 4 + posicion); Console.Write(item.TopeMaximo);
                Console.SetCursorPosition(107, 4 + posicion); Console.Write(item.CuotaModeradora);
                posicion++;

            }
            Console.ReadKey();
        }

       
        public List<LiquidacionCuotaModeradora> BuscarPorTipoLiquidacion(string tipoLiquidacion)
        {
            List<LiquidacionCuotaModeradora> liquidacionesEncontradas = new List<LiquidacionCuotaModeradora>();

            foreach (var liquidacion in listaModeradora)
            {
                if (liquidacion.TipoLiquidacion.Equals(tipoLiquidacion, StringComparison.OrdinalIgnoreCase))
                {
                    liquidacionesEncontradas.Add(liquidacion);
                }
            }

            return liquidacionesEncontradas.Count > 0 ? liquidacionesEncontradas : null;
        }


        public void MostrarLiquidacionesPorTipo()
        {
            

            Console.Clear();
            int opcion;
            string TipoLiquidacion="";
            Console.WriteLine("TIPO DE REGIMEN A CONSULTAR");
            Console.WriteLine("1. CONTRIBUTIVO");
            Console.WriteLine("2. SUBSIDIADO");
            Console.Write("Escoja una opcion: "); opcion = int.Parse(Console.ReadLine());
            
            while (opcion < 1 || opcion > 2)
            {
                Console.Write("Escoja una opcion: "); opcion = int.Parse(Console.ReadLine());
            }
            if (opcion == 1)
            {
                TipoLiquidacion = "CONTRIBUTIVO";
            }
            else
            if (opcion == 2)
            {
                TipoLiquidacion = "SUBSIDIADO";

            }



            List<LiquidacionCuotaModeradora> liquidacionesEncontradas = BuscarPorTipoLiquidacion(TipoLiquidacion);

            if (liquidacionesEncontradas != null && liquidacionesEncontradas.Any())
            {

                Console.SetCursorPosition(35, 5); Console.WriteLine("**   * IPS MAS SALUD Y VIDA *   **");
                Console.SetCursorPosition(25, 6); Console.Write("INFORME GENERAL DE LIQUIDACIONES DE REGIMEN "+ TipoLiquidacion);
                Console.SetCursorPosition(3, 8); Console.Write("NUM");
                Console.SetCursorPosition(0, 9); Console.Write("LIQUIDACION");
                Console.SetCursorPosition(20, 8); Console.Write("ID");
                Console.SetCursorPosition(17, 9); Console.Write("PACIENTE");
                Console.SetCursorPosition(30, 8); Console.Write("SALARIO");
                Console.SetCursorPosition(42, 8); Console.Write("VALOR");
                Console.SetCursorPosition(41, 9); Console.Write("SERVICIO");
                Console.SetCursorPosition(58, 8); Console.Write("VALOR");
                Console.SetCursorPosition(54, 9); Console.Write("LIQUIDADO REAL");
                Console.SetCursorPosition(72, 8); Console.Write("TARIFA");
                Console.SetCursorPosition(84, 8); Console.Write("VALOR CUOTA");
                Console.SetCursorPosition(84, 9); Console.Write("MODERADORA");
                for (int l = 0; l <= 109; l++)
                {
                    Console.SetCursorPosition(l, 10); Console.Write("_");
                }

                int posicion = 2;
                foreach (var item in liquidacionesEncontradas)
                {
                    Console.SetCursorPosition(3, 9 + posicion); Console.Write(item.NumLiquidacion);
                    Console.SetCursorPosition(17, 9 + posicion); Console.Write(item.IdPaciente);
                    Console.SetCursorPosition(30, 9 + posicion); Console.Write(item.Salario);
                    Console.SetCursorPosition(41, 9 + posicion); Console.Write(item.ValorServicio);
                    Console.SetCursorPosition(57, 9 + posicion); Console.Write(item.ValorLiquidadoReal);
                    Console.SetCursorPosition(72, 9 + posicion); Console.Write(item.Tarifa);
                    Console.SetCursorPosition(84, 9 + posicion); Console.Write(item.CuotaModeradora);
                    Console.WriteLine();
                    posicion++;
                }
            }
            else
            {
                Console.WriteLine("No se encontraron liquidaciones de Regimen " + TipoLiquidacion);
            }
        }
        public void Eliminar()
        {
            Console.Clear();
            Console.WriteLine("ELIMINAR REGISTRO DE LIQUIDACION");
            Console.WriteLine("");
            Console.Write("Ingrese número de liquidación a eliminar: ");
            int numLiquidacion;
            if (int.TryParse(Console.ReadLine(), out numLiquidacion))
            {
                var liquidacionAEliminar = BuscarNum(numLiquidacion);
                if (liquidacionAEliminar != null)
                {
                    listaModeradora.Remove(liquidacionAEliminar);
                    liquidacionCuotaModeradoraRepository.Actualizar(listaModeradora);
                    Console.WriteLine("Registro Eliminado!");
                }
                else
                {
                    Console.WriteLine("Número de Liquidación No encontrada");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
            }
        }
    
      
        public void TotalCuotasModeradoras()
        {
            Console.Clear();
            double TotalCuotaModeradora=0;
            int ContadorCuotaModeradora=0;
            double TotalCuotaContributivo=0;
            double TotalCuotaSubsidiado=0;

            foreach (var item in liquidacionCuotaModeradoraRepository.ConsultarInformacion())
            {
                if (item.TipoLiquidacion=="CONTRIBUTIVO")
                {
                    TotalCuotaContributivo = TotalCuotaContributivo + item.CuotaModeradora;
                }
                else
                {
                    if (item.TipoLiquidacion == "SUBSIDIADO")
                    {
                        TotalCuotaSubsidiado = TotalCuotaSubsidiado + item.CuotaModeradora;
                    }
                }
                TotalCuotaModeradora = TotalCuotaModeradora + item.CuotaModeradora;
                ContadorCuotaModeradora = ContadorCuotaModeradora + 1;

            }
            Console.SetCursorPosition(35, 0); Console.WriteLine("**   * IPS MAS SALUD Y VIDA *   **");
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Total Liquidaciones Registradas: " + ContadorCuotaModeradora);
            Console.WriteLine("Valor Total Liquidado Regimen CONTRIBUTIVO: " + TotalCuotaContributivo);
            Console.WriteLine("Valor Total Liquidado Regimen SUBSIDIADO: " + TotalCuotaSubsidiado);
            Console.WriteLine("Valor Total Cuotas Moderadoras Liquidadas: " + TotalCuotaModeradora);
            Console.ReadKey();
        }

        public void InformeMesAño()
        {
            Console.Clear();
            Console.SetCursorPosition(35, 0); Console.WriteLine("**   * IPS MAS SALUD Y VIDA *   **");
            Console.WriteLine();
            Console.Write("Ingrese la Fecha a Consultar: ");
            string FechaConsultada = Console.ReadLine();

            Console.SetCursorPosition(25, 6); Console.Write("INFORME GENERAL DE LIQUIDACIONES POR MES Y AÑO");
            Console.SetCursorPosition(3,8); Console.WriteLine("FECHA");
            Console.SetCursorPosition(0, 9); Console.WriteLine("LIQUIDACION");
            Console.SetCursorPosition(18, 8); Console.Write("NUM");
            Console.SetCursorPosition(15, 9); Console.Write("LIQUIDACION");
            Console.SetCursorPosition(30, 8); Console.Write("ID");
            Console.SetCursorPosition(29, 9); Console.Write("PACIENTE");
            Console.SetCursorPosition(43, 8); Console.Write("SALARIO");
            Console.SetCursorPosition(54, 8); Console.Write("VALOR");
            Console.SetCursorPosition(53, 9); Console.Write("SERVICIO");
            Console.SetCursorPosition(68, 8); Console.Write("VALOR");
            Console.SetCursorPosition(65, 9); Console.Write("LIQUIDADO REAL");
            Console.SetCursorPosition(83, 8); Console.Write("TARIFA");
            Console.SetCursorPosition(93, 8); Console.Write("VALOR CUOTA");
            Console.SetCursorPosition(93, 9); Console.Write("MODERADORA");
            Console.SetCursorPosition(107, 9); Console.Write("REGIMEN");

            int posicion = 3;
            for (int l = 0; l <= 119; l++)
            {
                Console.SetCursorPosition(l, 10); Console.Write("_");
            }


            foreach (var item in liquidacionCuotaModeradoraRepository.ConsultarInformacion())
            {

                    DateTime fechaSinHora = item.FechaLiquidacion.Date;
                    string fechaFormateada = fechaSinHora.ToString("dd/MM/yyyy");

                if (fechaFormateada == FechaConsultada)
                {
                    Console.SetCursorPosition(3,8 +posicion); Console.Write(FechaConsultada);
                    Console.SetCursorPosition(18, 8 + posicion); Console.Write(item.NumLiquidacion);                    
                    Console.SetCursorPosition(30, 8 + posicion); Console.Write(item.IdPaciente);
                    Console.SetCursorPosition(43, 8 + posicion); Console.Write(item.Salario);
                    Console.SetCursorPosition(54, 8 + posicion); Console.Write(item.ValorServicio);
                    Console.SetCursorPosition(68, 8 + posicion); Console.Write(item.ValorLiquidadoReal);
                    Console.SetCursorPosition(85, 8 + posicion); Console.Write(item.Tarifa);
                    Console.SetCursorPosition(93, 8 + posicion); Console.Write(item.CuotaModeradora);
                    Console.SetCursorPosition(105, 8 + posicion); Console.Write(item.TipoLiquidacion);
                    posicion++;
                }

            }

            Console.ReadKey();
        }        


        public LiquidacionCuotaModeradora BuscarNum( int numLiquidacion)
        {
            foreach ( var item in listaModeradora )
            {
                if (item.NumLiquidacion == numLiquidacion)
                {
                    return item;
                }
                continue;
            }
            return null;
        }

        public void Actualizar(List<LiquidacionCuotaModeradora> liquidacionCuotaModeradora)
        {
            liquidacionCuotaModeradoraRepository.Actualizar(liquidacionCuotaModeradora);
           listaModeradora = liquidacionCuotaModeradoraRepository.ConsultarInformacion();
        }
        public void Modificar()
        {
            Console.Clear();
            Console.SetCursorPosition(35, 0); Console.WriteLine("**   * IPS MAS SALUD Y VIDA *   **");
            Console.SetCursorPosition(40, 1); Console.WriteLine("MODULO DE MODIFICAR ");
            Console.WriteLine();
            Console.Write("Ingrese el Numero de Liquidacion a Modificar: ");
            int NumLiquidacion = int.Parse(Console.ReadLine());



            int posicion = 3;

            if (BuscarNum(NumLiquidacion) != null)
            {
                Console.SetCursorPosition(32, 6); Console.Write("INFORME DETALLADA DE LIQUIDACION A MODIFICAR");
                Console.SetCursorPosition(3, 8); Console.WriteLine("FECHA");
                Console.SetCursorPosition(0, 9); Console.WriteLine("LIQUIDACION");
                Console.SetCursorPosition(18, 8); Console.Write("NUM");
                Console.SetCursorPosition(15, 9); Console.Write("LIQUIDACION");
                Console.SetCursorPosition(30, 8); Console.Write("ID");
                Console.SetCursorPosition(29, 9); Console.Write("PACIENTE");
                Console.SetCursorPosition(43, 8); Console.Write("SALARIO");
                Console.SetCursorPosition(54, 8); Console.Write("VALOR");
                Console.SetCursorPosition(53, 9); Console.Write("SERVICIO");
                Console.SetCursorPosition(68, 8); Console.Write("VALOR");
                Console.SetCursorPosition(65, 9); Console.Write("LIQUIDADO REAL");
                Console.SetCursorPosition(83, 8); Console.Write("TARIFA");
                Console.SetCursorPosition(93, 8); Console.Write("VALOR CUOTA");
                Console.SetCursorPosition(93, 9); Console.Write("MODERADORA");
                Console.SetCursorPosition(107, 9); Console.Write("REGIMEN");

                DateTime FechaLiquidacion= DateTime.MinValue;
                string IdPaciente="";
                string TipoLiquidacion="";
                double Salario=0;
                double ValorServicio=0;
                double Tarifa = 0;
                double ValorLiquidacionReal=0;
                double TopeMaximo = 0;
                double CuotaModeradora=0;

                for (int l = 0; l <= 119; l++)
                {
                    Console.SetCursorPosition(l, 10); Console.Write("_");
                }

                foreach (var item in liquidacionCuotaModeradoraRepository.ConsultarInformacion())
                {

                    DateTime FechaSinHora = item.FechaLiquidacion.Date;
                    string FechaFormateada = FechaSinHora.ToString("dd/MM/yyyy");

                    if (item.NumLiquidacion == NumLiquidacion)
                    {
                        Console.SetCursorPosition(3, 8 + posicion); Console.Write(FechaFormateada);
                        Console.SetCursorPosition(18, 8 + posicion); Console.Write(item.NumLiquidacion);
                        Console.SetCursorPosition(29, 8 + posicion); Console.Write(item.IdPaciente);
                        Console.SetCursorPosition(43, 8 + posicion); Console.Write(item.Salario);
                        Console.SetCursorPosition(54, 8 + posicion); Console.Write(item.ValorServicio);
                        Console.SetCursorPosition(68, 8 + posicion); Console.Write(item.ValorLiquidadoReal);
                        Console.SetCursorPosition(85, 8 + posicion); Console.Write(item.Tarifa);
                        Console.SetCursorPosition(93, 8 + posicion); Console.Write(item.CuotaModeradora);
                        Console.SetCursorPosition(105, 8 + posicion); Console.Write(item.TipoLiquidacion);
                        posicion++;
                        NumLiquidacion = item.NumLiquidacion;
                        FechaLiquidacion = item.FechaLiquidacion;
                        IdPaciente = item.IdPaciente;
                        TipoLiquidacion = item.TipoLiquidacion;
                        Salario = item.Salario;


                    }

                }


                Console.WriteLine(); Console.WriteLine();
                Console.Write("Digite el Nuevo valor del Servicio: "); double NuevoValorServicio= double.Parse(Console.ReadLine());

                if (TipoLiquidacion == "CONTRIBUTIVO")
                {
                    regimen.CalcularCuotaModeradora(Salario, NuevoValorServicio);
                    Tarifa = regimen.Tarifa;
                    ValorLiquidacionReal = regimen.ValorLiquidadoReal;
                    TopeMaximo = regimen.TopeMaximo;
                    CuotaModeradora = regimen.CuotaModeradora;

                }
                else if (TipoLiquidacion == "SUBSIDIADO")
                {
                    regimens.CalcularCuotaModeradoraC(NuevoValorServicio);
                    Tarifa = regimens.Tarifa;
                    ValorLiquidacionReal = regimens.ValorLiquidadoReal;
                    TopeMaximo = regimens.TopeMaximo;
                    CuotaModeradora = regimens.CuotaModeradora;

                }

                var liquidacionAEliminar = BuscarNum(NumLiquidacion);                
                listaModeradora.Remove(liquidacionAEliminar);
                liquidacionCuotaModeradoraRepository.Actualizar(listaModeradora);

                LiquidacionCuotaModeradora liquidacionCuotaModeradora = new LiquidacionCuotaModeradora(NumLiquidacion, FechaLiquidacion, IdPaciente, TipoLiquidacion, Salario, NuevoValorServicio, Tarifa, ValorLiquidacionReal, TopeMaximo, CuotaModeradora);

                Console.SetCursorPosition(38, 17); Console.WriteLine("El Nuevo Valor a cancelar de Cuota Moderadora es = " + CuotaModeradora);
                liquidacionCuotaModeradoraRepository.Guardar(liquidacionCuotaModeradora);
                Console.WriteLine("Registro Modificado Exitosamente !");
            }
            else
            {
                Console.WriteLine("Numero de Liquidacion No encontrada");
            }
        }

    }

}
