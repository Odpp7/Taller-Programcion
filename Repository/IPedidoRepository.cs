using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPedidoRepository<T>
    {
        bool Save(T entity);
        List<T> GetAll();
    }
}
