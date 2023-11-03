using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Chofer : Persona
    {
        public Chofer() 
        {
            AutoAsignado = new Vehiculo();
        }
        public int IDChofer { get; set; }
        public int Zona { get; set; }
        public Vehiculo AutoAsignado { get; set; }
    }
}
