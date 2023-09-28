using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BLL;
using ENTITY;

namespace Presentacion
{
    public class Program
    {
        static void Main(string[] args)
        {
            int edad;
            string nombre;
            string sexo;
            string identificacion;

            int opcion = 0;

            while (opcion != 5)
            {
                menu();
                opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("REGISTRO DE PULSACIONES");
                        Console.WriteLine("Digite la identificacion");
                        identificacion = Console.ReadLine();

                        Console.WriteLine("Digite el nombre");
                        nombre = Console.ReadLine();

                        Console.WriteLine("Digite el sexo");
                        sexo = Console.ReadLine();

                        Console.WriteLine("Digite la edad");
                        edad = int.Parse(Console.ReadLine());

                        Persona persona = new Persona(identificacion, nombre, edad, sexo);
                        PersonaService personaService = new PersonaService();
                        persona.CalcularPulsacion();
                        Console.WriteLine($"Su Pulsacion es {persona.Pulsacion} ");
                        personaService.Guardar(persona);
                        Console.WriteLine("Datos registrados Exitosamente!");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("INFORME GENERAL DE REGISTROS");
                        PersonaService personaService2 = new PersonaService();
                        Consultar(personaService2);

                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("BUSCAR REGISTRO POR IDENTIFICACION");
                        Console.WriteLine("Digite la identificacion a consultar: ");
                        identificacion = Console.ReadLine() ;
                        PersonaService personaService4 = new PersonaService();

                        PersonaResponse personaResponse = personaService4.BuscarPorIdentificacion(identificacion);

                        if (personaResponse.PersonaEncontrada == true)
                        {
                            Console.WriteLine(personaResponse.Persona.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Usuario no registrado!");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("ELIMINAR REGISTRO");
                        Console.WriteLine("Digite la identificacion");
                        identificacion = Console.ReadLine();
                        PersonaService personaService3 = new PersonaService();
                        string messageEliminacion = personaService3.Eliminar(identificacion);
                        Console.WriteLine(messageEliminacion);
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        Console.ReadKey();
                        return;
                }

                Console.WriteLine();
            }

        }

        private static void Consultar(PersonaService personaService)
        {
            ConsultaPersonaResponse consultaPersonaResponse = personaService.ConsultarTodos();
            if (consultaPersonaResponse.Encontrado == true)
            {
                Console.WriteLine();
                foreach (var item in consultaPersonaResponse.Personas)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine(consultaPersonaResponse.Message);
            }
        }
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("MENU DE OPCIONES");
            Console.WriteLine("1. REGISTRAR DATOS");
            Console.WriteLine("2. INFORME GENERAL DE REGISTROS");
            Console.WriteLine("3. CONSULTAR POR IDENTIFICACION");
            Console.WriteLine("4. ELIMINAR REGISTRO");
            Console.WriteLine("5. Salir");
        }

        static int LeerOpcion()
        {
            Console.Write("Selecciona una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());
            return opcion;
        }

        public static void menu()
        {
            Console.Clear();
            Console.SetCursorPosition(6, 6); Console.WriteLine("Lee atentamente el menu para escoger tu opción;");
            Console.SetCursorPosition(10, 8); Console.WriteLine("|------|"); Console.SetCursorPosition(10, 9); Console.WriteLine("| MENU |"); Console.SetCursorPosition(10, 10); Console.WriteLine("|------|");
            Console.SetCursorPosition(6, 12); Console.WriteLine("1.REGISTRAR DATOS"); 
            Console.SetCursorPosition(6, 13); Console.WriteLine("2.INFORME GENERAL DE REGISTROS"); 
            Console.SetCursorPosition(6, 14); Console.WriteLine("3.CONSULTAR POR IDENTIFICACION"); 
            Console.SetCursorPosition(6, 15); Console.WriteLine("4.ELIMINAR REGISTRO"); 
            Console.SetCursorPosition(6, 17); Console.WriteLine("5.SALIR");

        }
    }
}
