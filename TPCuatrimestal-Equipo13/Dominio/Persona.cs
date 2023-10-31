using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public Persona() 
        {
            Direccion = new Domicilio();
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Domicilio Direccion { get; set; }
        public string Nacionalidad { get; set; }
    }
}
