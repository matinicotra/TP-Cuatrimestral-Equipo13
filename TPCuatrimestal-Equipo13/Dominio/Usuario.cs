using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        //Email varchar(50)
        public string Email { get; set; }
        //contrasenia varchar(15)
        public string Contrasenia { get; set; }
        public bool esAdmin { get; set; }
        public int idChofer { get; set; }
    }
}
