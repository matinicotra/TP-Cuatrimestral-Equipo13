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

            if (!IsPostBack)
            {
                cargarChoferes();
                listaChoferes.SelectedIndex = 0;
            }

            // --- prueba con data grid view --- //

            ChoferNegocio negocio = new ChoferNegocio();

            listarChoferes = negocio.ObtenerDatos();
            dgvChoferes.DataSource = listarChoferes;
            dgvChoferes.DataBind();
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
                    item.Text = $"{chofer.Nombres} - {chofer.Apellidos}- {chofer.AutoAsignado.Patente} - {chofer.ZonaAsignada.NombreZona}";
                    item.Attributes["class"] = "list-group-item";
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
            //SI ES ALTA, SOLO REDIRECT
            Response.Redirect("altaModificacionChofer.aspx", false);
        }

        protected void btnDetalleChofer_Click(object sender, EventArgs e)
        {
            string idSeleccionado = listaChoferes.SelectedValue;
            Response.Redirect("detalleChofer.aspx?id=" + idSeleccionado, false);
        }

        protected void btnModificarChofer_Click(object sender, EventArgs e)
        {
            string idSeleccionado = listaChoferes.SelectedValue;
            Response.Redirect("altaModificacionChofer.aspx?id=" + idSeleccionado, false);
        }

        protected void listaChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionado = listaChoferes.SelectedValue;
        }

        protected void btnBajaChofer_Click(object sender, EventArgs e)
        {
            int id = int.Parse(listaChoferes.SelectedValue);
            ChoferNegocio negocio = new ChoferNegocio();

            negocio.BajaChofer(id);

            cargarChoferes();
        }

        
        // -- prueba data grid view -- //

        protected void dgvChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aux = dgvChoferes.SelectedRow.Cells[0].Text;         // no me acuerdo si esta linea la que devuelve el id seleccionado o la siguiente..
            Seleccionado = dgvChoferes.SelectedDataKey.Value.ToString();   // datakey del gridview seleccionado
        }
    }
}