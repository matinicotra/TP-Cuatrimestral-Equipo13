using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestal
{
    public partial class adminCliente : System.Web.UI.Page
    {
        private List<Cliente> listarClientes = new List<Cliente>();

        private string Seleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["Usuario"]) && Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                Response.Redirect("homeChofer.aspx?id=" + usuario.idChofer, false);
            }

            if (!IsPostBack)
            {
                cargarClientes();
                listaClientes.SelectedIndex = -1;
            }
        }
        private void cargarClientes()
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();

            listarClientes = null;

            listaClientes.Items.Clear();

            listarClientes = clienteNegocio.ObtenerDatos();

            try
            {
                foreach (Cliente cliente in listarClientes)
                {
                    ListItem item = new ListItem();

                    if (cliente.Estado)
                    {
                        item.Value = cliente.IDCliente.ToString();
                        item.Text = $"{cliente.Nombres} {cliente.Apellidos} - {cliente.Direccion.Localidad} - {cliente.zonaCliente.NombreZona}";
                        item.Attributes["class"] = "list-group-item my-1 mx-2";

                        listaClientes.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnAltaCliente_Click(object sender, EventArgs e)
        {
            Session.Add("RediCliente", 2);

            Response.Redirect("altaModificacionCliente.aspx", false);
        }
        protected void btnBajaCliente_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();

            int id = listaClientes.SelectedIndex == -1 ? -1 : int.Parse(listaClientes.SelectedValue);

            if (id != -1)
            {
                negocio.BajaLogicaCliente(id);
            }

            cargarClientes();
        }
        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (listaClientes.SelectedIndex != -1)
            {
                string idSeleccionado = listaClientes.SelectedValue;

                Response.Redirect("altaModificacionCliente.aspx?id=" + idSeleccionado, false);
            }
            else
            {
                cargarClientes();
            }
        }
        protected void btnDetalleCliente_Click(object sender, EventArgs e)
        {
            if (listaClientes.SelectedIndex != -1)
            {
                string idSeleccionado = listaClientes.SelectedValue;

                Response.Redirect("detalleCliente.aspx?id=" + idSeleccionado, false);
            }
            else
            {
                cargarClientes();
            }
        }
        protected void listaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionado = listaClientes.SelectedValue;
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<Cliente> listaFiltrada = new List<Cliente>();
            ClienteNegocio cliente = new ClienteNegocio();

            if (txtFiltrar.Text != null || txtFiltrar.Text != "")
            {
                listaFiltrada = cliente.Filtrar(ddlCampo.SelectedValue, txtFiltrar.Text);

                txtFiltrar.Text = null;

                listaClientes.Items.Clear();

                foreach (Cliente X in listaFiltrada)
                {
                    ListItem item = new ListItem();

                    if (X.Estado)
                    {
                        item.Value = X.IDCliente.ToString();
                        item.Text = $"{X.Nombres} {X.Apellidos} - {X.Direccion.Localidad} - {X.zonaCliente.NombreZona}";
                        item.Attributes["class"] = "list-group-item my-1 mx-2";

                        listaClientes.Items.Add(item);
                    }
                }

                listaClientes.DataBind();
                listaClientes.SelectedIndex = -1;
            }
        }
    }
}