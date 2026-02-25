using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsFinal.Model
{
    public enum TipoSocio 
    {
        Estandar,
        Premium,
        Estudiante
    }
    public class Socio
    {
        public string DNI { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public TipoSocio Tipo { get; set; }
    }
}
