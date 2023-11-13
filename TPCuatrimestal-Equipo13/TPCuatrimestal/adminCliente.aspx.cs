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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarClientes();
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
                    item.Value = cliente.Apellidos.ToString();
                    item.Value = cliente.Nombres.ToString();
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
            //FALTA LA LOGICA, SOLO NAVEGAVILIDAD
            Response.Redirect("altaModificacionCliente.aspx", false);
        }

        protected void btnDetalleCliente_Click(object sender, EventArgs e)
        {
            //FALTA LA LOGICA, SOLO NAVEGAVILIDAD
            Response.Redirect("detalleCliente.aspx", false);
        }
    }
}