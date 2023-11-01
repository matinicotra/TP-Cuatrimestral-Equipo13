using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestal
{
    public partial class homeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAltaViaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("altaModificacionViaje.aspx", false);
        }

        protected void btnBajaViaje_Click(object sender, EventArgs e)
        {

        }

        protected void btnDetalleViaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalleViaje.aspx", false);
        }

        protected void btnModificarViaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("altaModificacionViaje.aspx", false);
        }

        protected void btnEmpresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminCliente.aspx", false);
        }

        protected void btnChoferes_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminChoferes.aspx", false);
        }
    }
}