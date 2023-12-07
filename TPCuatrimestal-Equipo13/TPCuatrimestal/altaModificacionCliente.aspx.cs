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
    public partial class altaModificacionCliente : System.Web.UI.Page
    {
        private Cliente clienteAux;

        private void CargarZonasEnDDL()
        {
            ClienteNegocio cnAux = new ClienteNegocio();
            List<Zona> ListZona = new List<Zona>();

            //ListZona = cnAux.ObtenerZonas();
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
                Response.Redirect("login.aspx", false);

            ClienteNegocio cnAux = new ClienteNegocio();

            CargarZonasEnDDL();

            if (Request.QueryString["id"] != null && !IsPostBack) //si es modificar entra aca
            {
                string idSeleccionado = Request.QueryString["id"];
                clienteAux = cnAux.ObtenerDatos(int.Parse(idSeleccionado))[0]; //trae el objeto Cliente seleccionado

                //setea los campos del formulario
                txtNombre.Text = clienteAux.Nombres;
                txtApellido.Text = clienteAux.Apellidos;
                txtDNI.Text = clienteAux.DNI;
                ddlNacionalidad.Text = clienteAux.Nacionalidad;
                txtFechaNacimiento.Text = clienteAux.FechaNacimiento.ToString("yyyy-MM-dd");
                txtCalleyAltura.Text = clienteAux.Direccion.Direccion;
                txtLocalidad.Text = clienteAux.Direccion.Localidad;
                txtProvincia.Text = clienteAux.Direccion.Provincia;
                txtDescripcion.Text = clienteAux.Direccion.Descripcion;
                txtTelefono.Text = clienteAux.Telefono;
                txtEmail.Text = clienteAux.Email;

                string zonaString = clienteAux.zonaCliente.IDZona.ToString() + " - " + clienteAux.zonaCliente.NombreZona;
                ListItem zonaPreseleccionada = ddlZona.Items.FindByValue(zonaString);

                if (zonaPreseleccionada != null)
                {
                    ddlZona.SelectedIndex = ddlZona.Items.IndexOf(zonaPreseleccionada);
                }
            }
            else if (Request.QueryString["id"] != null)
            {
                cnAux = new ClienteNegocio();

                string idCliente = Request.QueryString["id"];

                clienteAux = new Cliente();

                clienteAux = cnAux.ObtenerDatos(int.Parse(idCliente))[0];
            }
        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminCliente.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ClienteNegocio cnAux = new ClienteNegocio();
            Zona zonaAux = new Zona(); ;
            bool banderaAlta = false;

            if (Request.QueryString["id"] == null)
            {
                clienteAux = new Cliente();
                banderaAlta = true;
            }

            //seteo de cliente
            clienteAux.Nombres = ValidarNullVacio(txtNombre) == false ? "" : txtNombre.Text;
            clienteAux.Apellidos = ValidarNullVacio(txtApellido) == false ? "" : txtApellido.Text;
            clienteAux.DNI = ValidarNullVacio(txtDNI) == false ? "" : txtDNI.Text;
            clienteAux.Nacionalidad = ddlNacionalidad.SelectedValue;
            clienteAux.FechaNacimiento = ValidarNullVacio(txtDNI) == false ? new DateTime(1900,01,01) : Convert.ToDateTime(txtFechaNacimiento.Text);
            clienteAux.Telefono = ValidarNullVacio(txtTelefono) == false ? "" : txtTelefono.Text;
            clienteAux.Email = ValidarNullVacio(txtEmail) == false ? "" : txtEmail.Text;

            //seteo domicilio
            clienteAux.Direccion.Direccion = ValidarNullVacio(txtCalleyAltura) == false ? "" : txtCalleyAltura.Text;
            clienteAux.Direccion.Localidad = ValidarNullVacio(txtLocalidad) == false ? "" : txtLocalidad.Text;
            clienteAux.Direccion.Provincia = ValidarNullVacio(txtProvincia) == false ? "" : txtProvincia.Text;
            clienteAux.Direccion.Descripcion = ValidarNullVacio(txtDescripcion) == false ? "" : txtDescripcion.Text;

            //seteo zona
            int indexZona = -1;
            indexZona = ddlZona.SelectedIndex >= 0 && ddlZona.SelectedIndex < ZonaNegocio.ObtenerZonas().Count() ? ddlZona.SelectedIndex : 1;
            zonaAux = ZonaNegocio.ObtenerZonas()[indexZona];
            clienteAux.zonaCliente = zonaAux;

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
                    cnAux.AltaModificacionCliente(clienteAux, true);
                }
                else
                {
                    cnAux.AltaModificacionCliente(clienteAux, false);
                }

                Response.Redirect("adminCliente.aspx", false);
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