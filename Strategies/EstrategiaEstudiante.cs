using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsFinal.Strategies
{
    internal class EstrategiaEstudiante : IPrestamoStrategy
    {
        public int ObtenerMaxDias() => 21;
        public int ObtenerMaxLibros() => 4;
        public decimal CalcularCosto(int cantidadLibros) => 200 * cantidadLibros;
    {
    }
}
