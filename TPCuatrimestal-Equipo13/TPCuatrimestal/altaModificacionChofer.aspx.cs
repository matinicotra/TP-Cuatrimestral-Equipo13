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
    public partial class altaModificacionChofer : System.Web.UI.Page
    {
        private Chofer choferAux;
        private void CargarDesplegables()
        {
            VehiculoNegocio aux = new VehiculoNegocio();
            List<Vehiculo> ListVehi = new List<Vehiculo>();

            ListVehi = aux.ObtenerDatos();

            foreach (Vehiculo X in ListVehi)
            {
                if (X.Estado)
                {
                    ddlAutoAsignado.Items.Add(X.IDVehiculo.ToString() + " - " + "(" + X.Patente + ")");
                }
            }

            ChoferNegocio cnAux = new ChoferNegocio();
            List<Zona> ListZona = new List<Zona>();

            ListZona = cnAux.ObtenerZonas();

            foreach (Zona X in ListZona)
            {
                ddlZona.Items.Add(X.IDZona.ToString() + " - " + X.NombreZona);
            }

            ddlNacionalidad.Items.Add("Argentino");
            ddlNacionalidad.Items.Add("Brasilero");
            ddlNacionalidad.Items.Add("Paraguayo");
            ddlNacionalidad.Items.Add("Uruguayo");
            ddlNacionalidad.Items.Add("Boliviano");
            ddlNacionalidad.Items.Add("Peruano");
            ddlNacionalidad.Items.Add("Chileno");
            ddlNacionalidad.Items.Add("Colombiano");
            ddlNacionalidad.Items.Add("Venezolano");
            ddlNacionalidad.Items.Add("Ecuatoriano");
            ddlNacionalidad.Items.Add("Otra");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDesplegables();

            ChoferNegocio cnAux;

            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                cnAux = new ChoferNegocio();

                string idChofer = Request.QueryString["id"];

                choferAux = new Chofer();

                choferAux = cnAux.ObtenerDatos(int.Parse(idChofer))[0];

                txtNombre.Text = choferAux.Nombres;
                txtApellido.Text = choferAux.Apellidos;
                txtDNI.Text = choferAux.DNI.ToString();
                ddlNacionalidad.SelectedValue = choferAux.Nacionalidad;
                txtFechaNacimiento.Text = choferAux.FechaNacimiento.ToShortDateString();
                txtCalleyAltura.Text = choferAux.Direccion.Direccion;
                txtLocalidad.Text = choferAux.Direccion.Localidad;
                txtProvincia.Text = choferAux.Direccion.Provincia;
                txtDescripcion.Text = choferAux.Direccion.Descripcion;
                ddlAutoAsignado.SelectedIndex = choferAux.AutoAsignado.IDVehiculo;

                string valorAPreseleccionar = choferAux.ZonaAsignada.IDZona.ToString() + " - " + choferAux.ZonaAsignada.NombreZona;
                ListItem itemSeleccionado = ddlZona.Items.FindByValue(valorAPreseleccionar);
                if (itemSeleccionado != null)
                {
                    ddlZona.SelectedIndex = ddlZona.Items.IndexOf(itemSeleccionado);
                }
                
            }
            else if (Request.QueryString["id"] != null)
            {
                cnAux = new ChoferNegocio();

                string idChofer = Request.QueryString["id"];

                choferAux = new Chofer();

                choferAux = cnAux.ObtenerDatos(int.Parse(idChofer))[0];
            }
        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminChoferes.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ChoferNegocio cnAux = new ChoferNegocio();
            Zona zonaAux = new Zona();
            Vehiculo vehiculoAux = new Vehiculo();
            VehiculoNegocio vnAux = new VehiculoNegocio();
            bool banderaAlta = false;

            if (Request.QueryString["id"] == null)
            {
                choferAux = new Chofer();
                banderaAlta = true;
            }

            //seteo de chofer
            choferAux.Nombres = txtNombre.Text;
            choferAux.Apellidos = txtApellido.Text;
            choferAux.DNI = txtDNI.Text;
            choferAux.Nacionalidad = ddlNacionalidad.SelectedValue;
            choferAux.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);

            //seteo domicilio
            choferAux.Direccion.Direccion = txtCalleyAltura.Text;
            choferAux.Direccion.Localidad = txtLocalidad.Text;
            choferAux.Direccion.Provincia = txtProvincia.Text;
            choferAux.Direccion.Descripcion = txtDescripcion.Text;

            //seteo zona
            int idZona = -1;
            idZona = ddlZona.SelectedIndex >= 1 && ddlZona.SelectedIndex < cnAux.ObtenerZonas().Count() ? ddlZona.SelectedIndex : 1;
            zonaAux = cnAux.ObtenerZonas()[idZona - 1];
            choferAux.ZonaAsignada = zonaAux;

            //seteo vehiculo
            int idVehiculo = -1;
            idVehiculo = ddlAutoAsignado.SelectedIndex >= 1 && ddlAutoAsignado.SelectedIndex < vnAux.ObtenerDatos().Count() ? ddlAutoAsignado.SelectedIndex : 1;
            vehiculoAux = vnAux.ObtenerDatos()[idVehiculo - 1];
            choferAux.AutoAsignado = vehiculoAux;

            if (banderaAlta)
            {
                cnAux.AltaModificacionChofer(choferAux, true);
            }
            else
            {
                cnAux.AltaModificacionChofer(choferAux, false);
            }

            Response.Redirect("adminChoferes.aspx", false);
        }
    }
}