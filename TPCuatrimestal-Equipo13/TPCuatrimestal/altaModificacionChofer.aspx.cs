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
            ddlAutoAsignado.Items.Add("Sin Auto");

            foreach (Vehiculo X in ListVehi)
            {
                if (X.Estado)
                {
                    ddlAutoAsignado.Items.Add(X.IDVehiculo.ToString() + " - " + "(" + X.Patente + ")");
                }
            }

            ChoferNegocio cnAux = new ChoferNegocio();
            List<Zona> ListZona = new List<Zona>();

            ListZona = ZonaNegocio.ObtenerZonas();

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
            if (!Seguridad.esAdmin(Session["Usuario"]))
            {
                Response.Redirect("login.aspx", false);
            }

            CargarDesplegables();

            ChoferNegocio cnAux;

            txtFechaNacimiento.Text = DateTime.Today.ToString("yyyy-MM-dd");

            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                cnAux = new ChoferNegocio();
                choferAux = new Chofer();

                string idChofer = Request.QueryString["id"];

                choferAux = cnAux.ObtenerDatos(int.Parse(idChofer))[0];

                txtNombre.Text = choferAux.Nombres;
                txtApellido.Text = choferAux.Apellidos;
                txtDNI.Text = choferAux.DNI.ToString();
                ddlNacionalidad.SelectedValue = choferAux.Nacionalidad;
                txtFechaNacimiento.Text = choferAux.FechaNacimiento.ToString("yyyy-MM-dd");
                txtCalleyAltura.Text = choferAux.Direccion.Direccion;
                txtLocalidad.Text = choferAux.Direccion.Localidad;
                txtProvincia.Text = choferAux.Direccion.Provincia;
                txtDescripcion.Text = choferAux.Direccion.Descripcion;
                txtEmail.Text = choferAux.Email;
                txtTelefono.Text = choferAux.Telefono;

                string autoString = choferAux.AutoAsignado.IDVehiculo.ToString() + " - " + "(" + choferAux.AutoAsignado.Patente + ")";
                ListItem autoPreseleccionado = ddlAutoAsignado.Items.FindByValue(autoString);

                if (autoPreseleccionado != null)
                {
                    ddlAutoAsignado.SelectedIndex = ddlAutoAsignado.Items.IndexOf(autoPreseleccionado);
                }

                string zonaString = choferAux.ZonaAsignada.IDZona.ToString() + " - " + choferAux.ZonaAsignada.NombreZona;
                ListItem zonaPreseleccionada = ddlZona.Items.FindByValue(zonaString);

                if (zonaPreseleccionada != null)
                {
                    ddlZona.SelectedIndex = ddlZona.Items.IndexOf(zonaPreseleccionada);
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
            Vehiculo vehiculoAux = null;
            VehiculoNegocio vnAux = new VehiculoNegocio();
            UsuarioNegocio unAux = new UsuarioNegocio();
            PersonaNegocio pnAux = new PersonaNegocio();

            bool banderaAlta = false;

            if (Request.QueryString["id"] == null)
            {
                choferAux = new Chofer();
                banderaAlta = true;
            }

            //seteo de chofer
            choferAux.Nombres = ValidarNullVacio(txtNombre) == false ? "" : txtNombre.Text;
            choferAux.Apellidos = ValidarNullVacio(txtApellido) == false ? "" : txtApellido.Text;
            choferAux.DNI = ValidarNullVacio(txtDNI) == false ? "" : txtDNI.Text;
            choferAux.Nacionalidad = ddlNacionalidad.SelectedValue;
            choferAux.FechaNacimiento = ValidarNullVacio(txtNombre) == false ? new DateTime(1900,01,01) : DateTime.Parse(txtFechaNacimiento.Text);
            choferAux.Email = ValidarNullVacio(txtEmail) == false ? "" : txtEmail.Text;
            choferAux.Telefono = ValidarNullVacio(txtTelefono) == false ? "" : txtTelefono.Text;

            //seteo domicilio
            choferAux.Direccion.Direccion = ValidarNullVacio(txtCalleyAltura) == false ? "" : txtCalleyAltura.Text;
            choferAux.Direccion.Localidad = ValidarNullVacio(txtLocalidad) == false ? "" : txtLocalidad.Text;
            choferAux.Direccion.Provincia = ValidarNullVacio(txtProvincia) == false ? "" : txtProvincia.Text;
            choferAux.Direccion.Descripcion = ValidarNullVacio(txtDescripcion) == false ? "" : txtDescripcion.Text;

            //seteo zona
            int idZona = -1;
            idZona = ddlZona.SelectedIndex >= 0 && ddlZona.SelectedIndex < ZonaNegocio.ObtenerZonas().Count() ? ddlZona.SelectedIndex : 1;
            zonaAux = ZonaNegocio.ObtenerZonas()[idZona];
            choferAux.ZonaAsignada = zonaAux;

            //seteo vehiculo
            int idVehiculo = -1;
            idVehiculo = ddlAutoAsignado.SelectedIndex >= 0 && ddlAutoAsignado.SelectedIndex < vnAux.ObtenerDatos().Count() + 1 ? ddlAutoAsignado.SelectedIndex : 0;

            if (idVehiculo > 0)
            {
                vehiculoAux = vnAux.ObtenerDatos()[idVehiculo - 1];
            }

            choferAux.AutoAsignado = vehiculoAux;

            if (txtApellido.BorderColor != System.Drawing.Color.Red &&
                txtCalleyAltura.BorderColor != System.Drawing.Color.Red &&
                txtDNI.BorderColor != System.Drawing.Color.Red &&
                txtEmail.BorderColor != System.Drawing.Color.Red &&
                txtFechaNacimiento.BorderColor != System.Drawing.Color.Red &&
                txtLocalidad.BorderColor != System.Drawing.Color.Red &&
                txtNombre.BorderColor != System.Drawing.Color.Red &&
                txtProvincia.BorderColor != System.Drawing.Color.Red &&
                txtTelefono.BorderColor != System.Drawing.Color.Red)
            {
                if (banderaAlta)
                {
                    cnAux.AltaModificacionChofer(choferAux, true);
                    choferAux.IDChofer = cnAux.ultimoIdChofer();
                    unAux.nuevoUsuario(choferAux);
                }
                else
                {
                    cnAux.AltaModificacionChofer(choferAux, false);
                }

                Response.Redirect("adminChoferes.aspx", false);
            }
        }
        private bool ValidarNullVacio(TextBox txtAux)
        {
            if (txtAux.Text == null || txtAux.Text == "")
            {
                txtAux.BorderColor = System.Drawing.Color.Red;

                return false;
            }
            else
            {
                txtAux.BorderColor = System.Drawing.Color.Black;
            }

            return true;
        }
    }
}