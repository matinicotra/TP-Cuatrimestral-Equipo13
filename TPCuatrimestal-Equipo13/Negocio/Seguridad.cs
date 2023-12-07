using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva (object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
