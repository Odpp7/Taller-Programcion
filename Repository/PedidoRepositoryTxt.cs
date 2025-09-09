using Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
    public class PedidoRepositoryTxt : IPedidoRepository<Pedido>
    {
        private readonly string path = @"C:\Users\ESTUDIANTES\Documents\Visual Studio 2022\repos\TALLER\Pedidos.txt";

        public List<Pedido> GetAll()
        {
            var listPedidos = new List<Pedido>();

            // Verificamos si el archivo existe antes de intentar leer
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        listPedidos.Add(MapPedido(line));
                    }
                }
            }
            else
            {
                Console.WriteLine("El archivo 'Pedidos.txt' no existe. Se creará uno nuevo al guardar.");
            }

            return listPedidos;
        }

        public bool Save(Pedido entity)
        {
            bool SaveFlag = false;

            // Si el archivo no existe, se crea automáticamente
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    // El archivo se crea vacío, luego se puede escribir
                }
            }

            // Ahora escribimos el pedido en el archivo
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(entity.ToString());
                SaveFlag = true;
            }

            return SaveFlag;
        }

        public Pedido MapPedido(string line)
        {
            var pedido = new Pedido();

            // Almaceno los datos del pedido
            var datos = line.Split('|');
            pedido.IdPedido = long.Parse(datos[0]);
            pedido.Estudiante = datos[1];
            pedido.Libro = datos[2];
            pedido.Fecha = DateTime.Parse(datos[3]);

            return pedido;
        }
    }
}
