using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestal
{
    public partial class choferes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAltaChofer_Click(object sender, EventArgs e)
        {
            //SI ES ALTA, SOLO REDIRECT
            //SI ES MODIFICACIÓN, CON PARAMETRO POR URL O DE ALGÚNA OTRA MANERA
            Response.Redirect("altaModificacionChofer.aspx", false);
        }
    }
}