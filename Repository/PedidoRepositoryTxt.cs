using Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository
{
    public class PedidoRepositoryTxt : IPedidoRepository<Pedido>
    {
        // Nombre del archivo que guardara los pedidos
        private String path = "pedidos.txt";
        public List<Pedido> GetAll()
        {
            // Necesito validar que el archivo existe. Si no existe retorno una lista sin elementos
            if (!File.Exists(path))
            {
                return new List<Pedido>();
            }
            // Creo una lista vacia que devolvera los pedidos existentes
            var list = new List<Pedido>();
            using (StreamReader rd = new StreamReader(path))
            {
                String line;
                // Salto de linea en linea hasta llegar al final 
                while ((line = rd.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue; // ignora líneas vacías
                    var pedido = MapPedido(line);
                    if (pedido != null) list.Add(pedido);
                }
            }
            return list;
        }
        public bool Save(Pedido entity)
        {
            bool flag = false; // Indicara si se guardo o no el pedido
                               // Por medio del using el sistema cierra automaticamente el wr - Me ahorro 1 linea de codigo
            using (StreamWriter wr = new StreamWriter(path, true))
            {
                wr.WriteLine(FormatPedido(entity)); // Guardamos el pedido bien formateado
                flag = true;
            }

            return flag;
        }

        public Pedido MapPedido(string line)
        {
            // 1. Creo un pedido vacio
            var pedido = new Pedido();
            // 2. Completo los campos con la linea que recibo del rd
            pedido.IdPedido = long.Parse(line.Split('|')[0]);
            pedido.Estudiante = line.Split('|')[1];
            pedido.Libro = line.Split('|')[2];
            pedido.Fecha = line.Split('|')[3];
            return pedido;
        }

        public String FormatPedido(Pedido pedido)
        {
            return $"{pedido.IdPedido}|{pedido.Estudiante}|{pedido.Libro}|{pedido.Fecha}";


        }
    }
}
