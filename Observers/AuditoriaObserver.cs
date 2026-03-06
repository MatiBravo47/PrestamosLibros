using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsFinal.Observers
{
    public class AuditoriaObserver
    {
        public void Subscribirse(PrestamoService service) 
        {
            service.OnPrestamoConfirmado += RegistrarAuditoria;
        }

        public void RegistrarAuditoria(Prestamo prestamo) 
        {
            File.AppendAllText("auditoria.txt",
                $"Fecha: {DateTime.Now} - Socio: {prestamo.DNISocio} - Total: {prestamo.CostoTotal}\n");
        }
    }
}
