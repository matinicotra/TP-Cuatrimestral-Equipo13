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
    public partial class altaModificacionVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoVehiculoNegocio aux = new TipoVehiculoNegocio();
            List<TipoVehiculo> ListTipoVehi = new List<TipoVehiculo>();

            ListTipoVehi = aux.ObtenerDatos();

            foreach (TipoVehiculo X in ListTipoVehi)
            {
              
                    ddlTipoVehiculo.Items.Add(X.NombreTipo);
                
            }
        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminVehiculo.aspx", false);
        }

    }
}