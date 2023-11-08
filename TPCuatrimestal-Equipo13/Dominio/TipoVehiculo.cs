using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoVehiculo
    {
        public int IDTipo {  get; set; }
        public string NombreTipo { get; set; }
        public int CantAsientos { get; set; }

        public override string ToString()
        {
            return NombreTipo;
        }
    }

}
