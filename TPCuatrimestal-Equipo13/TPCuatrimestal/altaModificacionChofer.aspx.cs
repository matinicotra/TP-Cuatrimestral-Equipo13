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
        private Chofer choferAux = new Chofer();
        protected void Page_Load(object sender, EventArgs e)
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

            if (Request.QueryString["id"] != null)
            {
                cnAux = new ChoferNegocio();

                string idChofer = Request.QueryString["id"];

                choferAux = cnAux.ObtenerDatos(int.Parse(idChofer))[0];

                txtNombre.Text = choferAux.Nombres;
                txtApellido.Text = choferAux.Apellidos;
                txtDNI.Text = choferAux.DNI.ToString();
                txtNacionalidad.Text = choferAux.Nacionalidad;
                txtFechaNacimiento.Text = choferAux.FechaNacimiento.ToShortDateString();
                txtCalleyAltura.Text = choferAux.Direccion.Direccion;
                txtLocalidad.Text = choferAux.Direccion.Localidad;
                txtProvincia.Text = choferAux.Direccion.Provincia;
            }
        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminChoferes.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ChoferNegocio cnAux = new ChoferNegocio();
            Domicilio domicilioAux = new Domicilio();
            Zona zonaAux = new Zona();
            Vehiculo vehiculoAux = new Vehiculo();
            VehiculoNegocio vnAux = new VehiculoNegocio();

            //seteo de chofer
            choferAux.Nombres = txtNombre.Text;
            choferAux.Apellidos = txtApellido.Text;
            choferAux.DNI = txtDNI.Text;
            choferAux.Nacionalidad = txtNacionalidad.Text;
            choferAux.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
            
            //seteo domicilioAux
            domicilioAux.Direccion = txtCalleyAltura.Text;
            domicilioAux.Localidad = txtLocalidad.Text;
            domicilioAux.Provincia = txtProvincia.Text;
            domicilioAux.Descripcion = txtDescripcion.Text;
            choferAux.Direccion = domicilioAux; //seteo domicilio en choferAux

            //seteo zonaAux
            int idZona = -1;
            idZona = ddlZona.SelectedIndex;
            zonaAux = cnAux.ObtenerZonas()[idZona];
            choferAux.ZonaAsignada = zonaAux;

            //seteo vehiculo
            int idVehiculo = -1;
            idVehiculo = ddlAutoAsignado.SelectedIndex;
            vehiculoAux = vnAux.ObtenerDatos()[idVehiculo];
            choferAux.AutoAsignado = vehiculoAux;

            if (choferAux.IDChofer == -1)
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