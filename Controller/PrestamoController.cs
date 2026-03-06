using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using WinFormsFinal.Model;
using WinFormsFinal.Strategies;

namespace WinFormsFinal.Controller
{
    public class PrestamoController
    {
        private readonly IRepository<Socio> _repoSocios;
        private readonly IRepository<Libro> _repoLibros;
        private readonly PrestamoService _prestamoService;

        private Socio _socioActual;
        private List<Libro> _librosSeleccionados = new();

        public PrestamoController(IRepository<Socio> repoSocios,
                                    IRepository<Libro> repoLibros,
                                    PrestamoService prestamoService)
        {
            _repoSocios = repoSocios;
            _repoLibros = repoLibros;
            _prestamoService = prestamoService;
        }

        //Buscar Socio
        public Socio BuscarSocio(string dni) 
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new Exception("Debe Ingresar un DNI");

            var socio = _repoSocios.ObtenerTodos().FirstOrDefault(s => s.DNI == dni);

            if (socio == null)
                throw new Exception("Socio no encontrado");

            _socioActual = socio;
            return socio;
        }

        //Agregar libro 

        public void AgregarLibro(string isbn)
        {
            var libro = _repoLibros.ObtenerTodos().FirstOrDefault(l => l.ISBN == isbn);

            if (libro == null)
                throw new Exception("Libro no encontrado");

            if (!libro.Disponible)
                throw new Exception("Libro no disponible");
            _librosSeleccionados.Add(libro);
        }

        //Confirmar prestamo
        public Prestamo ConfirmarPrestamo()
        {
            if (_socioActual == null)
                throw new Exception("Debe buscar un socio primero");

            var strategy = ObtenerStrategy(_socioActual.Tipo);
            var prestamo = _prestamoService.CrearPrestamo(
                _socioActual,
                _librosSeleccionados,
                strategy);
            _librosSeleccionados.Clear();
            return prestamo;
        }

        private IPrestamoStrategy ObtenerStrategy(TipoSocio tipo)
        {
            return tipo switch
            {
                TipoSocio.Estandar => new EstrategiaEstandar(),
                TipoSocio.Premium => new EstrategiaPremium(),
                TipoSocio.Estudiante => new EstrategiaEstudiante(),
                _ => throw new Exception("Tipo de socio no soportado")
            };
        }
    }
}
