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
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool EsEmpresa { get; set; }
        public bool Estado { get; set; }
    }
}
