using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum  EstadoPrestamo
    {
        Activo,
        Devuelto,
        Vencido
    }
    public class Prestamo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string DNISocio { get; set; }
        public List<string> ISBNLibros { get; set; } = new();
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public decimal CostoTotal { get; set; }
        public EstadoPrestamo Estado { get; set; } = EstadoPrestamo.Activo;
    }
}
