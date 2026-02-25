using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsFinal.Strategies
{
    public class EstrategiaEstandar: IPrestamoStrategy
    {
        public int ObtenerMaxDias() => 14;
        public int ObtenerMaxLibros() => 3;
        public decimal CalcularCosto(int cantidadLibros) => 500 * cantidadLibros;

    }
}
