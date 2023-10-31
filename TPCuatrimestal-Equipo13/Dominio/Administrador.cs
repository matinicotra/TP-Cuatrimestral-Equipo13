using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Persona
    {
        public Administrador() 
        {
            Login = new Usuario();
        }
        public int IDAdmin { get; set; }
        public Usuario Login { get; set; }
    }
}
