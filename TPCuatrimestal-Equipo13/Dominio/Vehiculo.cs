using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vehiculo
    {
        public Vehiculo() 
        {
            Tipo = new TipoVehiculo();
        }
        public int IDVehiculo { get; set; }
        public TipoVehiculo Tipo { get; set; }
        public int Modelo { get; set; }
        public string Patente {  get; set; }
        public bool Estado {  get; set; }

        public override string ToString()
        {
            return Tipo.ToString();
        }
    }
}
