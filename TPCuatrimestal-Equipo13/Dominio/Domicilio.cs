using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Domicilio
    {
        public long IDDomicilio { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Descripcion {  get; set; }

        public override string ToString()
        {
            string aux = Direccion + " " + Localidad;
            return aux;
        }

    }

}
