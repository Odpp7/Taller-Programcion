using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pedido
    {
        public long IdPedido { get; set; }
        public String Estudiante { get; set; }
        public String Libro { get; set; }
        public String Fecha { get; set; }

        public Pedido()
        {

        }

        public Pedido(long id, String estudiante, String libro, String fecha)
        {
            IdPedido = id;
            Estudiante = estudiante;
            Libro = libro;
            Fecha = fecha;
        }

    }
}
