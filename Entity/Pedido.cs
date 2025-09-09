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
        public DateTime Fecha { get; set; }

<<<<<<< HEAD
=======
        // Formatea la linea para el guardado en el txt
>>>>>>> 3ccf7a8 (Subir proyecto con carpetas y archivos)
        public override string ToString()
        {
            return $"{IdPedido}|{Estudiante}|{Libro}|{Fecha}";
        }
<<<<<<< HEAD

=======
>>>>>>> 3ccf7a8 (Subir proyecto con carpetas y archivos)
    }
}
