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
        private PedidoRepositoryTxt repositoryTxt;

        public PedidoService()
        {
            repositoryTxt = new PedidoRepositoryTxt();
        }

        // HU-01: Registrar pedido
        public string RegistrarPedido(string estudiante, string libro)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(estudiante))
            {
                return "Error: El campo Estudiante no puede estar vacio.";
            }
            if (string.IsNullOrWhiteSpace(libro))
            {
                return "Error: El campo Libro no puede estar vacio.";
            }

            // Consultar pedidos existentes para calcular nuevo Id
            var pedidos = repositoryTxt.GetAll();
            long nuevoId = pedidos.Count == 0 ? 1 : pedidos[pedidos.Count - 1].IdPedido + 1;


            var pedido = new Pedido
            {
                IdPedido = nuevoId,
                Estudiante = estudiante,
                Libro = libro,
                Fecha = DateTime.Now
            };

            // Guardar
            bool ok = repositoryTxt.Save(pedido);

            return ok ? "Pedido registrado correctamente." : "Error al registrar pedido.";
        }

        // HU-02: Listar pedidos
        public List<Pedido> ConsultarPedidos()
        {
            return repositoryTxt.GetAll();
        }
    }
}
