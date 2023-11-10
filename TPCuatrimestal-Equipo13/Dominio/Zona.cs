using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Zona
    {
        public int IDZona { get; set; }
        public string NombreZona { get; set; }

        public override string ToString()
        {
            return NombreZona;
        }
    }
}
