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
            ZonaAsignada = new Zona();
        }
        public int IDChofer { get; set; }
        public Zona ZonaAsignada { get; set; }
        public Vehiculo AutoAsignado { get; set; }
        public bool Estado { get; set; }
    }
}
