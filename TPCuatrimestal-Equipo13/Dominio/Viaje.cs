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
            ChoferViaje = new Chofer();
            ClienteViaje = new Cliente();
        }
        public long NumViaje { get; set; }
        public int IDChofer { get; set; }
        public Chofer ChoferViaje { get; set; }
        public int IDCliente { get; set; }
        public Cliente ClienteViaje { get; set; }
        public string TipoViaje { get; set; }
        public decimal Importe { get; set; }
        public Domicilio Origen { get; set; }
        public List<Domicilio> Destinos { get; set; }
        
            // ESTADOS A MANEJAR= 'Cancelado' (baja logica) , 'Asignado' (con chofer) , 'Libre' (sin chofer) , 'Finalizado' 
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
