using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestal
{
    public partial class adminEmpresas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAltaCliente_Click(object sender, EventArgs e)
        {
            //SI ES ALTA, SOLO REDIRECT
            //SI ES MODIFICACIÓN, CON PARAMETRO POR URL O DE ALGÚNA OTRA MANERA
            Response.Redirect("altaModificacionCliente.aspx", false);
        }

        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {
            //FALTA LA LOGICA, SOLO NAVEGAVILIDAD
            Response.Redirect("altaModificacionCliente.aspx", false);
        }

        protected void btnDetalleCliente_Click(object sender, EventArgs e)
        {
            //FALTA LA LOGICA, SOLO NAVEGAVILIDAD
            Response.Redirect("altaModificacionViaje.aspx", false);
        }
    }
}