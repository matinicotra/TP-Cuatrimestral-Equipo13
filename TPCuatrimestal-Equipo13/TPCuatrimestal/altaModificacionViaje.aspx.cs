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

                long idViaje = long.Parse(Request.QueryString["id"]);

                viajeAux = viajeNegocio.ObtenerDatos(idViaje)[0];
                clienteAux = clienteNegocio.ObtenerDatos(viajeAux.IDCliente)[0];
                choferAux = choferNegocio.ObtenerDatos(viajeAux.IDChofer)[0];
                dirOrigen = domicilioNegocio.ObtenerDomicilio(viajeAux.Origen.IDDomicilio);
                dirDestino1 = domicilioNegocio.ObtenerDomicilio(viajeAux.Destinos[0].IDDomicilio);
                CargarDesplegable();
                if (viajeAux.Destinos.Count() > 1)
                {
                    dirDestino2 = domicilioNegocio.ObtenerDomicilio(viajeAux.Destinos[1].IDDomicilio);
                    ddlCantidadDestino.SelectedIndex = 2;
                    txtCalleDestino2.Text = dirDestino2.Direccion;
                    txtLocalidadDestino2.Text = dirDestino2.Localidad;
                    txtProvinciaDestino2.Text = dirDestino2.Provincia;

                    if (viajeAux.Destinos.Count() > 2)
                    {
                        dirDestino3 = domicilioNegocio.ObtenerDomicilio(viajeAux.Destinos[2].IDDomicilio);
                        ddlCantidadDestino.SelectedIndex = 3;
                        txtCalleDestino3.Text = dirDestino3.Direccion;
                        txtLocalidadDestino3.Text = dirDestino3.Localidad;
                        txtProvinciaDestino3.Text = dirDestino3.Provincia;
                    }
                }

                txtNombre.Text = clienteAux.Nombres;
                txtApellido.Text = clienteAux.Apellidos;
                txtTelefonoCliente.Text = clienteAux.Telefono;
                txtCalleOrigen.Text = dirOrigen.Direccion;
                txtLocalidadOrigen.Text = dirOrigen.Localidad;
                txtProvinciaOrigen.Text = dirOrigen.Provincia;
                txtCalleDestino1.Text = dirDestino1.Direccion;
                txtLocalidadDestino1.Text = dirDestino1.Localidad;
                txtProvinciaDestino1.Text = dirDestino1.Provincia;



                if (Session["CantidadDestino"] != null)
                {
                    ddlCantidadDestino.SelectedValue = Session["CantidadDestino"].ToString();
                }
                else
                {
                    ddlCantidadDestino.SelectedValue = viajeAux.Destinos.Count().ToString();
                }
            }
        }

        private void CargarDesplegable()
        {
            ChoferNegocio cnAux = new ChoferNegocio();
            List<Chofer> listChoferes = new List<Chofer>();

            listChoferes = cnAux.ObtenerDatos();

                //no asignado es index = 0
            ddlChoferes.Items.Add("No Asignado");
            ddlChoferes.SelectedIndex = 0;
            int contador = 0;
            foreach (Chofer X in listChoferes)
            {
                if (X.Estado)
                {
                    ddlChoferes.Items.Add(X.IDChofer.ToString() + " - " + X.Nombres + " " + X.Apellidos);
                    contador++;
                    if (X.IDChofer == viajeAux.IDChofer)
                    {
                        ddlChoferes.SelectedIndex = contador;
                    }
                }
            }
        }
        protected void ddlCantidadDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CantidadDestino"] = ddlCantidadDestino.SelectedValue;
        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("homeAdmin.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //armmar metodo para dar de alta o modificar
        }
    }
}