using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPCuatrimestal
{
    public partial class homeAdmin : System.Web.UI.Page
    {
        public List<Vehiculo> ListarVehiculos { get; set; }

        public List<Viaje> ListarViajes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            VehiculoNegocio vehiculoNegocio = new VehiculoNegocio();
            ListarVehiculos = vehiculoNegocio.ObtenerDatos();

            ViajeNegocio viajeNegocio = new ViajeNegocio();
            ListarViajes = viajeNegocio.ObtenerDatos();

            if (!IsPostBack)
            {
                repVehiculos.DataSource = ListarVehiculos;
                repVehiculos.DataBind();

                dgvViajes.DataSource = ListarViajes;
                dgvViajes.DataBind();
            }




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

        protected void btnVehiculo_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminVehiculo.aspx", false);
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            Response.Redirect("altaModificacionViaje.aspx", false);
        }

        protected void dgvViajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var numViajeSeleccionado = dgvViajes.SelectedDataKey.Value.ToString();


        }
    }
}