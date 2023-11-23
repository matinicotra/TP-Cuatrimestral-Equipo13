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

        //SE CARGA EL ID DEL ELEMENTO SELECCIONADO, EN EL ULTIMO EVENTO
        public string IDSeleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            VehiculoNegocio vehiculoNegocio = new VehiculoNegocio();
            ViajeNegocio viajeNegocio = new ViajeNegocio();
            
            ListarVehiculos = vehiculoNegocio.ObtenerDatos();
            ListarViajes = viajeNegocio.ObtenerDatos();

            if (!IsPostBack)
            {
                repVehiculos.DataSource = ListarVehiculos;
                repVehiculos.DataBind();

                // LISTAR VIAJES
                lbListaViajes.DataValueField = "NumViaje";
                lbListaViajes.DataTextField = "NumViaje";
                lbListaViajes.SelectedIndex = 0;
                lbListaViajes.DataSource = ListarViajes;
                lbListaViajes.DataBind();

                // OPCION listar viajes CON GRID VIEW //
                dgvViajes.DataSource = ListarViajes;
                dgvViajes.DataBind();
            }
        }

        protected void btnAltaViaje_Click(object sender, EventArgs e)
        {
            //SOLO IMPACTAR INSERT EN DB
            Response.Redirect("altaModificacionViaje.aspx", false);
        }

        protected void btnBajaViaje_Click(object sender, EventArgs e)
        {
            //REALIZAR BAJA LOGICA (CAMBIAR ESTADO DE VIAJE A "CANCELADO" POR EJEMPLO)
        }

        protected void btnDetalleViaje_Click(object sender, EventArgs e)
        {
            //MANEJAR ID EN PÁGINA DETALLEVIAJE
            Response.Redirect("detalleViaje.aspx?id=" + IDSeleccionado, false);
        }

        protected void btnModificarViaje_Click(object sender, EventArgs e)
        {
            //MANEJAR ID EN PÁGINA ALTAMODIFICACIONVIAJE
            IDSeleccionado = lbListaViajes.SelectedValue;
            Response.Redirect("altaModificacionViaje.aspx?id=" + IDSeleccionado, false);
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


        // OPCION CON GRID VIEW....
        protected void dgvViajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var numViajeSeleccionado = dgvViajes.SelectedDataKey.Value.ToString();
        }

        protected void lbViajesDelDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SE GUARDA EL ID DEL VIAJE SELECCIONADO
            IDSeleccionado = lbListaViajes.SelectedValue.ToCharArray()[0].ToString();
            Response.Redirect("altaModificacionViaje.aspx?id=" + IDSeleccionado, false);
        }

        protected void btnModificar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnImg = (ImageButton)sender;
            long numViaje = long.Parse(btnImg.CommandArgument);
            Response.Redirect("altaModificacionViaje.aspx?id=" + numViaje, false);
        }
    }
}