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
            if (!IsPostBack)
            {
                cargarClientes();
                listaClientes.SelectedIndex = 0;
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
                    item.Value = cliente.IDCliente.ToString();
                    item.Text = cliente.Apellidos + " - " + cliente.Nombres;
                    item.Attributes["class"] = "list-group-item";
                    listaClientes.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAltaCliente_Click(object sender, EventArgs e)
        {
            //SI ES ALTA, SOLO REDIRECT
            //SI ES MODIFICACIÓN, CON PARAMETRO POR URL O DE ALGÚNA OTRA MANERA
            Response.Redirect("altaModificacionCliente.aspx", false);
        }

        protected void btnBajaCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {
            string idSeleccionado = listaClientes.SelectedValue;

            Session.Add("RediCliente", 2);

            Response.Redirect("altaModificacionCliente.aspx?id=" + idSeleccionado, false);
        }

        protected void btnDetalleCliente_Click(object sender, EventArgs e)
        {
            string idSeleccionado = listaClientes.SelectedValue;
            Response.Redirect("detalleCliente.aspx?id=" + idSeleccionado, false);
        }

        protected void listaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionado = listaClientes.SelectedValue;
        }
    }
}