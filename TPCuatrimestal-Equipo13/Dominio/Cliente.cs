using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Persona
    {
        public int IDCliente { get; set; }
        public Zona zonaCliente { get; set; }
        public bool Estado { get; set; }

        public Cliente()
        {
            zonaCliente = new Zona();
            zonaCliente.IDZona = 5;
            zonaCliente.NombreZona = "Sin Zona";
        }
        public override string ToString()
        {
            if (this.IDPersona != 0)
                return this.IDCliente + " - " + this.Nombres + " " + this.Apellidos;
            return "Sin Cliente";
        }
    }
}
