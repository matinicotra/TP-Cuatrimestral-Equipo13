using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestal
{
    public partial class altaModificacionViaje : System.Web.UI.Page
    {
        private Viaje viajeAux;
        private Cliente clienteAux;
        private Chofer choferAux;
        private Domicilio dirOrigen;
        private Domicilio dirDestino1;
        private Domicilio dirDestino2;
        private Domicilio dirDestino3;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                ViajeNegocio viajeNegocio = new ViajeNegocio();
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                ChoferNegocio choferNegocio = new ChoferNegocio();
                DomicilioNegocio domicilioNegocio = new DomicilioNegocio();

                int idViaje = int.Parse(Request.QueryString["id"]);

                viajeAux = viajeNegocio.ObtenerDatos(idViaje)[0];
                clienteAux = clienteNegocio.ObtenerDatos(viajeAux.IDCliente)[0];
                choferAux = choferNegocio.ObtenerDatos(viajeAux.IDChofer)[0];
                dirOrigen = domicilioNegocio.ObtenerDomicilio(viajeAux.Origen.IDDomicilio);
                dirDestino1 = domicilioNegocio.ObtenerDomicilio(viajeAux.Destinos[0].IDDomicilio);
                dirDestino2 = domicilioNegocio.ObtenerDomicilio(viajeAux.Destinos[1].IDDomicilio);
                dirDestino3 = domicilioNegocio.ObtenerDomicilio(viajeAux.Destinos[2].IDDomicilio);

                txtNombreApellido.Text = clienteAux.Nombres + " " + clienteAux.Apellidos;
                txtTelefonoCliente.Text = clienteAux.Telefono;
                txtNombreChofer.Text = choferAux.Nombres + " " + choferAux.Apellidos;
                txtCalleOrigen.Text = dirOrigen.Direccion;
                //txtAlturaOrigen.Text = dirOrigen.Direccion; // ver altura
                txtLocalidadOrigen.Text = dirOrigen.Localidad;
                txtProvinciaOrigen.Text = dirOrigen.Provincia;
                txtCalleDestino1.Text = dirDestino1.Direccion;
                //txtAlturaDestino1.Text = dirDestino1.Direccion; // ver altura
                txtLocalidadDestino1.Text = dirDestino1.Localidad;
                txtProvinciaDestino1.Text = dirDestino1.Provincia;

            }
        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("homeAdmin.aspx", false);
        }
    }
}