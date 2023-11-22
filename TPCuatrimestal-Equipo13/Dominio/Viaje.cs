using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Viaje
    {
        public Viaje() 
        {
            Origen = new Domicilio();
            Destinos = new List<Domicilio>();
        }
        public long NumViaje { get; set; }
        public int IDChofer { get; set; }
        public int IDCliente { get; set; }
        public string TipoViaje { get; set; }
        public decimal Importe { get; set; }
        public Domicilio Origen { get; set; }
        public List<Domicilio> Destinos { get; set; }
        public string Estado { get; set; }
        public DateTime FechaHoraViaje { get; set; }
        public string MedioDePago { get; set; }
        public bool Pagado { get; set; }

        public override string ToString()
        {
            return NumViaje + " - " + TipoViaje + " (" + Estado + ")";
        }
    }
}
