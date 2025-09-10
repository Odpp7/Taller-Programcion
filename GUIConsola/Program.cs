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

            do
            {
                Console.Clear();

                // ====== Título ======
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(45, 2); Console.Write("===================================");
                Console.SetCursorPosition(45, 3); Console.Write("   SISTEMA DE GESTIÓN DE PEDIDOS   ");
                Console.SetCursorPosition(45, 4); Console.Write("===================================");
                Console.ResetColor();

                // ====== Menú ======
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(45, 7); Console.Write("1. Registrar un nuevo pedido");
                Console.SetCursorPosition(45, 9); Console.Write("2. Consultar todos los pedidos");
                Console.SetCursorPosition(45, 11); Console.Write("3. Salir");
                Console.ResetColor();

                // ====== Opción ======
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(45, 14); Console.Write("Seleccione una opción: ");
                Console.ResetColor();

                Console.SetCursorPosition(70, 14);
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(25, 16); Console.Write("Saliendo del sistema... ¡Hasta luego!");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(25, 16); Console.Write("Opción no válida. Presione una tecla...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }

            } while (seguir);
        }

        private static void RegistrarPedido(PedidoService service)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 2); Console.Write("===== REGISTRAR NUEVO PEDIDO =====");
            Console.ResetColor();

            Console.SetCursorPosition(20, 5); Console.Write("Ingrese el nombre del Estudiante: ");
            Console.SetCursorPosition(55, 5); string estudiante = Console.ReadLine();

            Console.SetCursorPosition(20, 7); Console.Write("Ingrese el nombre del Libro: ");
            Console.SetCursorPosition(55, 7); string libro = Console.ReadLine();

            string resultado = service.SavePedido(estudiante, libro);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(20, 10); Console.Write(resultado);
            Console.ResetColor();

            Console.SetCursorPosition(20, 12); Console.Write("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void ConsultarPedidos(PedidoService service)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 2); Console.Write("========= LISTADO DE PEDIDOS =========");
            Console.ResetColor();

            List<Pedido> pedidos = service.GetPedidos();

            if (pedidos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(20, 5); Console.Write("(No hay pedidos aún)");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(20, 5); Console.Write("ID | Estudiante | Libro | Fecha");
                Console.SetCursorPosition(20, 6); Console.Write("------------------------------------------");
                Console.ResetColor();

                int y = 8;
                foreach (var pedido in pedidos)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(20, y);
                    Console.Write($"{pedido.IdPedido} | {pedido.Estudiante} | {pedido.Libro} | {pedido.Fecha}");
                    y++;
                }
                Console.ResetColor();
            }

            Console.SetCursorPosition(20, 20); Console.Write("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
