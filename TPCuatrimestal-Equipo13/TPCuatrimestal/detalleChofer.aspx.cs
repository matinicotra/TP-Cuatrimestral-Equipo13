using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestal
{
    public partial class detalleChofer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                ChoferNegocio cnAux = new ChoferNegocio();

                string idChofer = Request.QueryString["id"];
                Chofer choferAux = cnAux.ObtenerDatos(int.Parse(idChofer))[0];

                lblTituloChofer.Text = choferAux.Nombres + " " + choferAux.Apellidos;
                lblAutoAsignado.Text = choferAux.AutoAsignado.Patente;
                lblZona.Text = choferAux.ZonaAsignada.NombreZona;
            }
        }

        protected void btnDetalleViaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalleViaje.aspx", false);
        }

        protected void btnModificarViaje_Click(object sender, EventArgs e)
        {
            string idSeleccionado = Request.QueryString["id"];

            Session.Add("RediChofer", 1);

            Response.Redirect("altaModificacionChofer.aspx?id=" + idSeleccionado, false);
        }

        protected void btnResumenSemanalChofer_Click(object sender, EventArgs e)
        {
            string Ide = "1";
            string ID = Request.QueryString["id"];
            DateTime IN = DateTime.Now.AddDays(-7);
            DateTime OUT = DateTime.Now.AddDays(1);

            Response.Redirect("listaViajes.aspx?Ide=" + Ide + "&ID=" + ID + "&Inicio=" + IN.ToString() + "&Fin=" + OUT.ToString(), false);
        }

        protected void btnResumenQuincenalChofer_Click(object sender, EventArgs e)
        {
            string Ide = "1";
            string ID = Request.QueryString["id"];
            DateTime IN = DateTime.Now.AddDays(-15);
            DateTime OUT = DateTime.Now.AddDays(1);

            Response.Redirect("listaViajes.aspx?Ide=" + Ide + "&ID=" + ID + "&Inicio=" + IN.ToString() + "&Fin=" + OUT.ToString(), false);

        }

        protected void btnResumenMensualChofer_Click(object sender, EventArgs e)
        {
            string Ide = "1";
            string ID = Request.QueryString["id"];
            DateTime IN = DateTime.Now.AddDays(-30);
            DateTime OUT = DateTime.Now.AddDays(1);

            Response.Redirect("listaViajes.aspx?Ide=" + Ide + "&ID=" + ID + "&Inicio=" + IN.ToString() + "&Fin=" + OUT.ToString(), false);

        }
    }
}