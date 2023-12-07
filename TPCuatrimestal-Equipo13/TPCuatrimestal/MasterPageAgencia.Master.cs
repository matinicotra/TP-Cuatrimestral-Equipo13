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
    public partial class MasterPageAgencia : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is login))
            {
                if (!Seguridad.sesionActiva(Session["Usuario"]))
                {
                    Response.Redirect("login.aspx", false);
                }
            }

            if (Seguridad.sesionActiva(Session["Usuario"]))
            {

                Usuario usuarioAux = (Usuario)Session["Usuario"];
                hlNombreUsuario.Text = usuarioAux.Email;
                hlNombreUsuario.Visible = true;
                if (usuarioAux.esAdmin)
                {
                    hlHome.NavigateUrl = "homeAdmin.aspx";
                }
                else
                {
                    hlHome.NavigateUrl = "homeChofer.aspx?id=" + usuarioAux.idChofer;
                }


            }
            else
            {
                hlNombreUsuario.Visible = false;
            }

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {

        }
    }
}