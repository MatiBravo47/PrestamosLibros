using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model 
{     
    //Sealed para que nadie pueda heredar esta clase 
    public sealed class ConfiguracionSistema
    {
        private static ConfiguracionSistema _instancia;
        private static readonly object _lock = new object();

        //Se pueden leer desde afuera
        //No se pueden modificar desde afuera
        public string RutaArchivos { get; private set; }
        public string NombreBiblioteca { get; private set; }

        private ConfiguracionSistema() 
        {
            RutaArchivos = "Data";
            NombreBiblioteca = "Mi Biblioteca";
        }

        public static ConfiguracionSistema Instancia 
        {
            get 
            {
                lock (_lock) 
                {
                    if (_instancia == null)
                        _instancia = new ConfiguracionSistema();
                    return _instancia;
                }
            }
        }
    }
}
