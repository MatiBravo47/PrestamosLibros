using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsFinal.Model;
using WinFormsFinal.Strategies;

namespace Model
{
    public class PrestamoService
    {
        private readonly IRepository<Prestamo> _repoPrestamos;
        private readonly IRepository<Libro> _repoLibros;

        public event Action<Prestamo> OnPrestamoConfirmado;

        public PrestamoService(IRepository<Prestamo> repoPrestamos, IRepository<Libro> repoLibros) 
        {
            _repoPrestamos = repoPrestamos;
            _repoLibros = repoLibros;
        }

        public Prestamo CrearPrestamo(Socio socio,
                                      List<Libro> libros,
                                      IPrestamoStrategy strategy)
        {
            if (libros.Count == 0)
                throw new Exception("Debe agregar al menos un libro");
            if (libros.Count > strategy.ObtenerMaxLibros())
                throw new Exception("Supera el maximo permitido");
            if (libros.Any(l => !l.Disponible))
                throw new Exception("Uno o mas libros no estan disponibles");

            var prestamo = new Prestamo
            {
                DNISocio = socio.DNI,
                ISBNLibros = libros.Select(l => l.ISBN).ToList(),
                FechaPrestamo = DateTime.Now,
                FechaDevolucion = DateTime.Now.AddDays(strategy.ObtenerMaxDias()),
                CostoTotal = strategy.CalcularCosto(libros.Count),
            };

            foreach (var libro in libros)
                libro.Disponible = false;

            _repoPrestamos.Guardar(prestamo);
            _repoLibros.Actualizar(_repoLibros.ObtenerTodos());

            OnPrestamoConfirmado?.Invoke(prestamo);
            return prestamo;
        }

    }
}
