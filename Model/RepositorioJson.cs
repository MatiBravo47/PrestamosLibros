using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Resources.ResXFileRef;

namespace Model
{
    public class RepositorioJson<T> : IRepository<T>
    {
        private readonly string _rutaArchivo;

        public RepositorioJson(string nombreArchivo)
        {
            var config = ConfiguracionSistema.Instancia;
            if (!Directory.Exists(config.RutaArchivos))
                Directory.CreateDirectory(config.RutaArchivos);

            _rutaArchivo = Path.Combine(config.RutaArchivos, nombreArchivo);

            if (!File.Exists(_rutaArchivo))
                File.WriteAllText(_rutaArchivo, "[]");           
        }
        public List<T> ObtenerTodos()
        {
            try
            {
                var json = File.ReadAllText(_rutaArchivo);
                //Convertir JSON a objetos(deserializar)
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch 
            {
                return new List<T>();
            }
        }

        public void Guardar(T entidad) 
        {
            var lista = ObtenerTodos();
            lista.Add(entidad);
            Actualizar(lista);
        }

        public void Actualizar(List<T> entidades) 
        {
            //Convertir objetos a JSON (serializar)
            var json = JsonSerializer.Serialize(entidades, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_rutaArchivo, json);
        }
    }
}
