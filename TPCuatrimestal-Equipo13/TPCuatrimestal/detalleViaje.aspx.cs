using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPCuatrimestal
{
    public partial class detalleViaje : System.Web.UI.Page
    {
        public Viaje viaje = new Viaje();

        ViajeNegocio vnAux = new ViajeNegocio();

        long idViaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            idViaje = long.Parse(Request.QueryString["id"]);
            viaje = vnAux.ObtenerDatos(idViaje)[0];

            lblEstadoData.Text = viaje.Estado;
            lblClienteData.Text = viaje.ClienteViaje.ToString();
            lblTitulo.Text = "VIAJE NUMERO: " + viaje.NumViaje;
            lblOrigenData.Text = viaje.Origen.ToString();
            lblChoferData.Text = viaje.ChoferViaje.ToString() + " | " + viaje.ChoferViaje.AutoAsignado.ToString() + " " + viaje.ChoferViaje.AutoAsignado.Patente;
            string horaViaje = viaje.FechaHoraViaje.ToString("HH:mm");
            lblFechaHoraData.Text = horaViaje + " | " + viaje.FechaHoraViaje.ToShortDateString();
            lblDestino1Data.Text = viaje.Destinos[0].ToString();
            if (viaje.Destinos.Count > 1)
            {
                lblDestino2Data.Text = viaje.Destinos[1].ToString();
                lblObservacionDestino2Data.Text = viaje.Destinos[1].Descripcion;
                if (viaje.Destinos.Count > 2)
                {
                    lblDestino3Data.Text = viaje.Destinos[2].ToString();
                    lblObservacionDestino3Data.Text = viaje.Destinos[2].Descripcion;
                }
            }
            lblImporteData.Text = "$ " + viaje.Importe.ToString("f1");
            lblMedioPagoData.Text = viaje.MedioDePago;
            lblTipoViajeData.Text = viaje.TipoViaje;
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["esChofer"] == "true")
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                int idPersona = usuario.idPersona;
                Response.Redirect("homeChofer.aspx?id=" + idPersona, false);

            }
            else Response.Redirect("homeAdmin.aspx");
        }
    }
}