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
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public long DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Domicilio Direccion { get; set; }
        public string Nacionalidad { get; set; }
    }
}
