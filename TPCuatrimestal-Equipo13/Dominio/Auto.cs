using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Auto
    {
        public Auto() 
        {
            Tipo = new TipoVehiculo();
            Asignado = new Chofer();
        }
        public int IDVehiculo { get; set; }
        public TipoVehiculo Tipo { get; set; }
        public Chofer Asignado { get; set; }
    }
}
