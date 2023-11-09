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
    public partial class adminVehiculo : System.Web.UI.Page
    {
        public List<Vehiculo> ListarVehiculos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            VehiculoNegocio vehiculoNegocio = new VehiculoNegocio();
            ListarVehiculos = vehiculoNegocio.ObtenerDatos();

            if (!IsPostBack)
            {
                repVehiculos.DataSource = ListarVehiculos;
                repVehiculos.DataBind();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("homeAdmin.aspx", false);
        }

        protected void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            Response.Redirect("altaModificacionVehiculo.aspx", false);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string valorID = ((ImageButton)sender).CommandArgument;
            Response.Redirect("altaModificacionVehiculo.aspx?id=" + valorID, false);
        }
    }
}