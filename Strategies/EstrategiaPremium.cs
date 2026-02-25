using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsFinal.Strategies
{
    internal class EstrategiaPremium: IPrestamoStrategy
    {
        public int ObtenerMaxDias() => 30;
        public int ObtenerMaxLibros() => 5;
        public decimal CalcularCosto(int cantidadLibros) => 0;
    }
}
