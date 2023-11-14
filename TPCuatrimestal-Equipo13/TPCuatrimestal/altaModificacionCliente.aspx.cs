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
                //txtFechaNacimiento.Text = clienteAux.FechaNacimiento.ToString();
                txtCalle.Text = clienteAux.Direccion.Direccion;
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
        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminCliente.aspx", false);
        }
    }
}