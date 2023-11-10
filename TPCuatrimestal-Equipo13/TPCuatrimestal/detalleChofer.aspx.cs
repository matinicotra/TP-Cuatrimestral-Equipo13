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
            }
        }

        protected void btnDetalleViaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalleViaje.aspx", false);
        }
    }
}