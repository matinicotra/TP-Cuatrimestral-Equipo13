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
        List<Viaje> listaViajes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                ChoferNegocio cnAux = new ChoferNegocio();

                string idChofer = Request.QueryString["id"];
                Chofer choferAux = cnAux.ObtenerDatos(int.Parse(idChofer))[0];

                lblTituloChofer.Text = choferAux.Nombres + " " + choferAux.Apellidos;
                lblAutoAsignado.Text = choferAux.AutoAsignado.ToString();
                lblZona.Text = choferAux.ZonaAsignada.NombreZona;

                listarViajes();
            }
        }

        protected void btnDetalleViaje_Click(object sender, EventArgs e)
        {
            string idSeleccionado = lbxListaViajesChofer.SelectedValue;
            Response.Redirect("detalleViaje.aspx?id=" + idSeleccionado, false);
        }

        protected void btnModificarViaje_Click(object sender, EventArgs e)
        {
            string idSeleccionado = Request.QueryString["id"];

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

        protected void listarViajes()
        {
            ViajeNegocio viajesNegocio = new ViajeNegocio();
            try
            {
                listaViajes = viajesNegocio.ViajesClientesChoferes(int.Parse(Request.QueryString["id"]), true);

                if (listaViajes.Count <= 0)
                {
                    lbxListaViajesChofer.Visible = false;
                    btnDetalleViaje.Visible = false;
                }
                else
                {
                    foreach (Viaje X in listaViajes)
                    {
                        ListItem item = new ListItem();

                        item.Value = X.NumViaje.ToString();
                        item.Text = $"{X.NumViaje} - {X.FechaHoraViaje.ToShortDateString()} - {X.ClienteViaje} - {X.Estado} - Pago: {X.Pagado} - ${X.Importe.ToString("f0")}";
                        item.Attributes["class"] = "list-group-item my-1 mx-2";

                        lbxListaViajesChofer.Items.Add(item);
                    }
                    lbxListaViajesChofer.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}