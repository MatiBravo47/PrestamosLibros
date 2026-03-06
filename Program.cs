using Model;
using WinFormsFinal.Controller;
using WinFormsFinal.Model;
using WinFormsFinal.Observers;



namespace WinFormsFinal
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            ApplicationConfiguration.Initialize();

            //Singleton
            var config = ConfiguracionSistema.Instancia;

            var repoSocios = new RepositorioJson<Socio>("socios.json");
            var repoLibros = new RepositorioJson<Libro>("libros.json");
            var repoPrestamos = new RepositorioJson<Prestamo>("prestamos.json");

            //Services
            var prestamoService = new PrestamoService(repoPrestamos, repoLibros);

            //Observers 

            var emailObserver = new EmailObserver();
            emailObserver.Subscribirse(prestamoService);

            var auditoriaObserver = new AuditoriaObserver();
            auditoriaObserver.Subscribirse(prestamoService);

            //Controller
            var controller = new PrestamoController(repoSocios, repoLibros, prestamoService);

            //Form
            Application.Run(new Form1(controller));
        }
    }
}