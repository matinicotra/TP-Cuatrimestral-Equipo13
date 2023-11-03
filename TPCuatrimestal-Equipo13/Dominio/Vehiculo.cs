using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vehiculo
    {
        public int IDVehiculo { get; set; }
        public TipoVehiculo Tipo { get; set; }
        public int Modelo { get; set; }
        public string Patente {  get; set; }
        public bool Estado {  get; set; }
        public Vehiculo() 
        {
            Tipo = new TipoVehiculo();
        }
    }
}
