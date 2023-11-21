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
        private void CargarVehiculos()
        {
            VehiculoNegocio vehiculoNegocio = new VehiculoNegocio();
            ListarVehiculos = vehiculoNegocio.ObtenerDatos(chbMostrarInactivos.Checked);

            repVehiculos.DataSource = ListarVehiculos;
            repVehiculos.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarVehiculos();
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

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            //SE TIENE QUE CHEQUEAR QUE EL AUTO NO ESTE ASIGNADO A NINGUN CHOFER
            //O, AL MOMENTO DE DAR DE BAJA, QUITARLE LA ASIGNACION AL CHOFER TAMBIEN
            VehiculoNegocio vehiAux = new VehiculoNegocio();
            int valorID = int.Parse(((ImageButton)sender).CommandArgument);

            vehiAux.BajaFisicaVehiculo(valorID);

            CargarVehiculos();
        }

        protected void btnBajaLogica_Click(object sender, EventArgs e)
        {
            VehiculoNegocio vehiculoNegocio = new VehiculoNegocio();

            int valorID = int.Parse(((ImageButton)sender).CommandArgument);

            vehiculoNegocio.BajaoAltaLogicaVehiculo(valorID, false);

            CargarVehiculos();
        }

        protected void btnAltaLogica_Click(object sender, EventArgs e)
        {
            VehiculoNegocio vehiculoNegocio = new VehiculoNegocio();

            int valorID = int.Parse(((ImageButton)sender).CommandArgument);

            vehiculoNegocio.BajaoAltaLogicaVehiculo(valorID, true);

            CargarVehiculos();
        }

        protected void chbMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarVehiculos();
        }
    }
}