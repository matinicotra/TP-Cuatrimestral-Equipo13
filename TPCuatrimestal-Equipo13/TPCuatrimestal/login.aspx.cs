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
                    Response.Redirect("homeChofer.aspx?id=" + usuarioAux.idPersona, false);
                }
            }
        }
    }
}