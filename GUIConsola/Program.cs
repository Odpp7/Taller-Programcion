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
<<<<<<< HEAD
            
=======
            // Instanciamos el servicio
            
            PedidoService service = new PedidoService();

            // Menú principal
            bool seguir = true;

            while (seguir)
            {
                Console.Clear();
                Console.WriteLine("===== Sistema de Gestión de Pedidos de Libros =====");
                Console.WriteLine("1. Registrar un nuevo pedido");
                Console.WriteLine("2. Consultar todos los pedidos");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Registrar un nuevo pedido
                        RegistrarPedido(service);
                        break;

                    case "2":
                        // Consultar todos los pedidos
                        ConsultarPedidos(service);
                        break;

                    case "3":
                        // Salir
                        seguir = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Método para registrar un nuevo pedido
        private static void RegistrarPedido(PedidoService service)
        {
            Console.Clear();
            Console.WriteLine("===== Registrar Nuevo Pedido =====");

            Console.Write("Ingrese el nombre del Estudiante: ");
            string estudiante = Console.ReadLine();

            Console.Write("Ingrese el nombre del Libro: ");
            string libro = Console.ReadLine();

            // Llamamos al servicio para registrar el pedido
            string resultado = service.RegistrarPedido(estudiante, libro);

            Console.WriteLine(resultado);
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Método para consultar todos los pedidos
        private static void ConsultarPedidos(PedidoService service)
        {
            Console.Clear();
            Console.WriteLine("===== Listado de Pedidos =====");

            // Obtenemos todos los pedidos
            List<Pedido> pedidos = service.ConsultarPedidos();

            if (pedidos.Count == 0)
            {
                Console.WriteLine("(No hay pedidos aún)");
            }
            else
            {
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine($"{pedido.IdPedido} | {pedido.Estudiante} | {pedido.Libro} | {pedido.Fecha}");
                }
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
>>>>>>> 3ccf7a8 (Subir proyecto con carpetas y archivos)
        }
    }
}
