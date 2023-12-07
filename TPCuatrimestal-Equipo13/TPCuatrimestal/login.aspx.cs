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
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                if (Seguridad.sesionActiva(usuario))
                {
                    tbxUsuario.Text = usuario.Email;
                    tbxUsuario.Enabled = false;
                    lblConstrasenia.Visible = false;
                    tbxConstrasenia.Visible = false;
                    btnLogin.Visible = false;
                    btnCerrarSesion.Visible = true;
                }

            }
            else
            {
                tbxUsuario.Enabled = true;
                lblConstrasenia.Visible = true;
                tbxConstrasenia.Visible = true;
                btnLogin.Visible = true;
                btnCerrarSesion.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuarioAux = new Usuario();
            string emailString;
            string constraseniaString;

            emailString = tbxUsuario.Text;
            constraseniaString = tbxConstrasenia.Text;
            //envia y corrobora si existen en la BBDD la coincidencia de ambos parametros
            if (usuarioNegocio.login(emailString, constraseniaString))
            {
                usuarioAux = usuarioNegocio.obtenerDatosUsuario(emailString);

                Session.Add("Usuario", usuarioAux);

                if (usuarioAux.esAdmin)
                {
                    Response.Redirect("homeAdmin.aspx", false);
                }
                else
                {
                    Response.Redirect("homeChofer.aspx?id=" + usuarioAux.idChofer, false);
                }
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("login.aspx", false);
        }
    }
}