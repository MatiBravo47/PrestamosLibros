using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IRepository<T>
    {
        void Guardar(T entidad);
        List<T> ObtenerTodos();
        void Actualizar(List<T> entidades);
    }
}
