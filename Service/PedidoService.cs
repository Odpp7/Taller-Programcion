using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PedidoService
    {
        // Creo una instancia de repository
        PedidoRepositoryTxt PedidoRepositoryTxt;
        public PedidoService()
        {
            PedidoRepositoryTxt = new PedidoRepositoryTxt();
        }
        // 
        public String SavePedido(String Estudiante, String Libro)
        {
            if (String.IsNullOrWhiteSpace(Estudiante))
            {
                return "Warn: El nombre del estudiante no puede estar vacio";
            }
            if (String.IsNullOrWhiteSpace(Libro))
            {
                return "Warn: El nombre del libro no puede estar vacio";
            }
            // Creo una lista para saber que id es el siguiente
            var pedidos = PedidoRepositoryTxt.GetAll();
            long IdNuevo;
            // Utilizo el .Any() para validar si hay un elemento en la lista.
            if (pedidos.Any())
            {
                IdNuevo = pedidos.Last().IdPedido + 1;
            }
            else
            {
                IdNuevo = 1;
            }
            String Fecha = DateTime.Now.ToString("dd/MM/yyyy");

            bool flag = PedidoRepositoryTxt.Save(new Pedido(IdNuevo, Estudiante, Libro, Fecha));

            if (flag) {
                return $"Success: El pedido de {Estudiante} se ha guardado con exito";
            }
            else
            {
                return $"Warn: El pedido de {Estudiante} no se ha guardado con exito";
            }

        }

    }
}
