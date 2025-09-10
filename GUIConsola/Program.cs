using System;
using Service;
using Entity;
using System.Collections.Generic;

namespace GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PedidoService service = new PedidoService();
            bool seguir = true;

            while (seguir)
            {
                Console.Clear();
                MostrarTitulo("SISTEMA DE GESTIÓN DE PEDIDOS DE LIBROS", ConsoleColor.Cyan);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Registrar un nuevo pedido");
                Console.WriteLine("2. Consultar todos los pedidos");
                Console.WriteLine("3. Salir");
                Console.ResetColor();

                Console.WriteLine("========================================");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarPedido(service);
                        break;
                    case "2":
                        ConsultarPedidos(service);
                        break;
                    case "3":
                        seguir = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nSaliendo del sistema... ¡Hasta luego!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n⚠ Opción no válida. Presione una tecla para continuar...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void RegistrarPedido(PedidoService service)
        {
            Console.Clear();
            MostrarTitulo("REGISTRAR NUEVO PEDIDO", ConsoleColor.Magenta);

            Console.Write("Ingrese el nombre del Estudiante: ");
            string estudiante = Console.ReadLine();

            Console.Write("Ingrese el nombre del Libro: ");
            string libro = Console.ReadLine();

            string resultado = service.SavePedido(estudiante, libro);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{resultado}");
            Console.ResetColor();

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void ConsultarPedidos(PedidoService service)
        {
            Console.Clear();
            MostrarTitulo("LISTADO DE PEDIDOS", ConsoleColor.Blue);

            List<Pedido> pedidos = service.GetPedidos();

            if (pedidos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("(No hay pedidos aún)");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ID | Estudiante | Libro | Fecha");
                Console.WriteLine("------------------------------------------");
                Console.ResetColor();

                foreach (var pedido in pedidos)
                {
                    Console.WriteLine($"{pedido.IdPedido} | {pedido.Estudiante} | {pedido.Libro} | {pedido.Fecha}");
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Método para mostrar títulos centrados y con color
        private static void MostrarTitulo(string texto, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            string linea = new string('=', texto.Length + 10);
            Console.WriteLine(linea.PadLeft((Console.WindowWidth + linea.Length) / 2));
            Console.WriteLine(texto.PadLeft((Console.WindowWidth + texto.Length) / 2));
            Console.WriteLine(linea.PadLeft((Console.WindowWidth + linea.Length) / 2));
            Console.ResetColor();
        }
    }
}
