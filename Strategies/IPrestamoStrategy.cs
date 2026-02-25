using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsFinal.Strategies
{
    public interface IPrestamoStrategy
    {
        int ObtenerMaxDias();
        int ObtenerMaxLibros();
        decimal CalcularCosto();
    }
}
