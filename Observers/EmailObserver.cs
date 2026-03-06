using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsFinal.Observers
{
    public class EmailObserver
    {
        public void Subscribirse(PrestamoService Service) 
        {
            Service.OnPrestamoConfirmado += EnviarEmail;
        }

        public void EnviarEmail(Prestamo prestamo) 
        {

        }
    }
}
