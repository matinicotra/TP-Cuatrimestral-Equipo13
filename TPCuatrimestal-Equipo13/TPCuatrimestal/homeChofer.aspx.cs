using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestal
{
    public partial class homeChofer : System.Web.UI.Page
    {

        private List<Viaje> viajes = new List<Viaje>();

        private Domicilio origen = new Domicilio();

        protected void Page_Load(object sender, EventArgs e)
        {
            long idChofer = 2;      //el login determina el idChofer

            ViajeNegocio viajeNegocio = new ViajeNegocio();
            viajes = viajeNegocio.ObtenerViajesChofer(idChofer);

            dgvViajes.DataSource = viajes;
            dgvViajes.DataBind();


            // MAPA //
            //string direccionPrueba = "cochabamba+1200,+capital+federal";        // desarrollar una funcion para concatenar la direccion
            //urlIframe.Attributes.Add("src", "https://www.google.com/maps/embed/v1/place?key=AIzaSyDoBiKY57PiZmKkaMIjWRjSMPZO2i-XJJM&q=" + direccionPrueba);
            string direccion = viajes[0].Origen.Direccion.ToString().Replace(" ", "+");
            string localidad = viajes[0].Origen.Localidad.ToString().Replace(" ", "+");
            string provincia = viajes[0].Origen.Provincia.ToString().Replace(" ", "+");
            //cambiar el indice por el viaje seleccionado o activo o actual

            string direccionPrueba = "cochabamba+1200,+capital+federal";
            string domicilio = direccion + "," + localidad + "," + provincia;

            urlIframe.Attributes.Add("src", "https://www.google.com/maps/embed/v1/place?key=AIzaSyDoBiKY57PiZmKkaMIjWRjSMPZO2i-XJJM&q=" + domicilio);

        }

        protected void btnDetalleViaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalleViaje.aspx", false);
        }

        protected void btnWhatsapp_Click(object sender, EventArgs e)
        {
            string telefono = "1535947980";      //  prueba
            Response.Redirect("https://wa.me/" + telefono + "?text=Tu%20vehiculo%20ha%20llegado!");
        }

        protected void dgvViajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var numViajeSeleccionado = dgvViajes.SelectedDataKey.Value.ToString();
        }

        protected void btnDireccion_Click(object sender, ImageClickEventArgs e)
        {

        }


        protected void btnNoPagado_Click(object sender, ImageClickEventArgs e)
        {
            ViajeNegocio viajeNegocio = new ViajeNegocio();

            int valorID = int.Parse(((ImageButton)sender).CommandArgument);

            viajeNegocio.PagarDespagarViaje(valorID, false);
        }

        protected void btnPagado_Click(object sender, ImageClickEventArgs e)
        {
            ViajeNegocio viajeNegocio = new ViajeNegocio();

            int valorID = int.Parse(((ImageButton)sender).CommandArgument);

            viajeNegocio.PagarDespagarViaje(valorID, true);
        }
    }
}