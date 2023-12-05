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
            //si el IDCliente = -1 significa que  no tiene cliente
        public int IDCliente { get; set; }
        public Cliente ClienteViaje { get; set; }
        public string TipoViaje { get; set; }
        public decimal Importe { get; set; }
        public Domicilio Origen { get; set; }
        public List<Domicilio> Destinos { get; set; }
        
            // ESTADOS A MANEJAR= 'Cancelado' (baja logica) , 'Asignado' (con chofer) , 'Libre' (sin chofer) , 'Finalizado' 
        public string Estado { get; set; } 
        public DateTime FechaHoraViaje { get; set; }
            //MEDIOS DE PAGO A MANEJAR= 'No Especifica', 'Efectivo', 'Tarjeta de Credito', 'Tarjeta de Debito', 'Mercado Pago', 'Cuenta Corriente'
        public string MedioDePago { get; set; }
        public bool Pagado { get; set; }

        public override string ToString()
        {
            return NumViaje + " - " + TipoViaje + " (" + Estado + ")";
        }
    }
}
