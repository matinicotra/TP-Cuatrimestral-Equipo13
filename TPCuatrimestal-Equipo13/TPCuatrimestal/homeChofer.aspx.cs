using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestal
{
    public partial class homeChofer : System.Web.UI.Page
    {
        public string telefono;         // deberia llegar el numero de telefono del cliente por session para el boton de whatsapp

        protected void Page_Load(object sender, EventArgs e)
        {
            // MAPA //
            string direccionPrueba = "cochabamba+1200,+capital+federal";        // desarrollar una funcion para concatenar la direccion
            urlIframe.Attributes.Add("src", "https://www.google.com/maps/embed/v1/place?key=AIzaSyDoBiKY57PiZmKkaMIjWRjSMPZO2i-XJJM&q=" + direccionPrueba);
        }

        protected void btnDetalleViaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalleViaje.aspx", false);
        }

        protected void btnWhatsapp_Click(object sender, EventArgs e)
        {
            telefono = "1535947980";        
            Response.Redirect("https://wa.me/" + telefono + "?text=Tu%20vehiculo%20ha%20llegado!");
        }
    }
}