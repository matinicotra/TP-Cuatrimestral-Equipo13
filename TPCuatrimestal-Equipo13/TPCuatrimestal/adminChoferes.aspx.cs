using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestal
{
    public partial class choferes : System.Web.UI.Page
    {
        private List<Chofer> listarChoferes = new List<Chofer>();
        private string Seleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["Usuario"]) && Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                Response.Redirect("homeChofer.aspx?id=" + usuario.idPersona, false);
            }

            if (!IsPostBack)
            {
                cargarChoferes();
                listaChoferes.SelectedIndex = -1;
            }
        }

        private void cargarChoferes()
        {
            ChoferNegocio choferNegocio = new ChoferNegocio();

            listarChoferes = null;
            listaChoferes.Items.Clear();

            listarChoferes = choferNegocio.ObtenerDatos();

            try
            {
                foreach (Chofer chofer in listarChoferes)
                {
                    ListItem item = new ListItem();
                    // Asigna el valor y el texto del ListItem con las propiedades de Chofer
                    item.Value = chofer.IDChofer.ToString(); // Asigna el valor deseado
                    string autoAsignado;

                    if (chofer.AutoAsignado == null || chofer.AutoAsignado.Estado == false)
                    {
                        autoAsignado = "Sin Auto";
                    }
                    else
                    {
                        autoAsignado = chofer.AutoAsignado.Patente + " " + chofer.AutoAsignado.Tipo.ToString();
                    }

                    item.Text = $"{chofer.Nombres} {chofer.Apellidos} - {autoAsignado} - {chofer.ZonaAsignada.NombreZona}";
                    item.Attributes["class"] = "list-group-item my-1 mx-2";

                    listaChoferes.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAltaChofer_Click(object sender, EventArgs e)
        {
            Response.Redirect("altaModificacionChofer.aspx", false);
        }

        protected void btnDetalleChofer_Click(object sender, EventArgs e)
        {
            if (listaChoferes.SelectedIndex != -1)
            {
                string idSeleccionado = listaChoferes.SelectedValue;

                Response.Redirect("detalleChofer.aspx?id=" + idSeleccionado, false);
            }
            else
            {
                cargarChoferes();
            }
        }

        protected void btnModificarChofer_Click(object sender, EventArgs e)
        {
            if (listaChoferes.SelectedIndex != -1)
            {
                string idSeleccionado = listaChoferes.SelectedValue;

                Response.Redirect("altaModificacionChofer.aspx?id=" + idSeleccionado, false);
            }
            else
            {
                cargarChoferes();
            }
        }

        protected void listaChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionado = listaChoferes.SelectedValue;
        }

        protected void btnBajaChofer_Click(object sender, EventArgs e)
        {
            ChoferNegocio negocio = new ChoferNegocio();

            int id = listaChoferes.SelectedIndex == -1 ? -1 : int.Parse(listaChoferes.SelectedValue);

            if (id != -1)
            {
                negocio.BajaChofer(id);
            }

            cargarChoferes();
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<Chofer> listaFiltrada = new List<Chofer>();
            ChoferNegocio chofer = new ChoferNegocio();

            if (txtFiltrar.Text != null || txtFiltrar.Text != "")
            {
                listaFiltrada = chofer.Filtrar(ddlCampo.SelectedValue, txtFiltrar.Text);

                txtFiltrar.Text = null;

                listaChoferes.Items.Clear();

                foreach (Chofer X in listaFiltrada)
                {
                    ListItem item = new ListItem();
                    // Asigna el valor y el texto del ListItem con las propiedades de Chofer
                    item.Value = X.IDChofer.ToString(); // Asigna el valor deseado
                    string autoAsignado;

                    if (X.AutoAsignado == null || X.AutoAsignado.Estado == false)
                    {
                        autoAsignado = "Sin Auto";
                    }
                    else
                    {
                        autoAsignado = X.AutoAsignado.Patente + " " + X.AutoAsignado.Tipo.ToString();
                    }

                    item.Text = $"{X.Nombres} {X.Apellidos} - {autoAsignado} - {X.ZonaAsignada.NombreZona}";
                    item.Attributes["class"] = "list-group-item my-1 mx-2";

                    listaChoferes.Items.Add(item);
                }

                listaChoferes.DataBind();
                listaChoferes.SelectedIndex = -1;
            }
        }
    }
}