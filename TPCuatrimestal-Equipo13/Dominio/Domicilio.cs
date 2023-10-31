using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Domicilio
    {
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int CodPostal { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
    }
}
