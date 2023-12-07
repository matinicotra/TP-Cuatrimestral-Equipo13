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
        public Usuario usuario  { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            hlHome.Visible = false;

            if (!(Page is login))
            {
                if (!Seguridad.sesionActiva(Session["Usuario"]))
                {
                    Response.Redirect("login.aspx", false);
                }
            }

            if (Seguridad.sesionActiva(Session["Usuario"]))
            {
                usuario = new Usuario();

                usuario = (Usuario)Session["Usuario"];
                hlNombreUsuario.Text = usuario.Email;
                hlNombreUsuario.Visible = true;
                hlHome.Visible = true;

                if (usuario.esAdmin)
                {
                    hlHome.NavigateUrl = "homeAdmin.aspx";
                }
                else
                {
                    hlHome.NavigateUrl = "homeChofer.aspx?id=" + usuario.idChofer;
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