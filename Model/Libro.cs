using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Libro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }
        public Boolean Disponible { get; set; } = true;
    }
}
