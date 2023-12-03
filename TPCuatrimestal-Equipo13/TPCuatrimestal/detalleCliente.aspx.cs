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
    public partial class detalleEmpresa : System.Web.UI.Page
    {
        Cliente clienteAux;
        protected void Page_Load(object sender, EventArgs e)
        {
            string idCliente = Request.QueryString["id"];
            ClienteNegocio cnAux = new ClienteNegocio();

            clienteAux = cnAux.ObtenerDatos(int.Parse(idCliente))[0];

            lblNombreTitulo.Text = clienteAux.Nombres;
            lblTelefonoTitulo.Text = clienteAux.Telefono;
            lblEmail.Text = clienteAux.Email;
            lblNombre.Text = clienteAux.Nombres;
            lblApellido.Text = clienteAux.Apellidos;
            lblCalle.Text = clienteAux.Direccion.Direccion;
            lblLocalidad.Text = clienteAux.Direccion.Localidad;
            lblProvincia.Text = clienteAux.Direccion.Provincia;
            lblDescripcion.Text = clienteAux.Direccion.Descripcion;
            lblZona.Text = clienteAux.zonaCliente.NombreZona;

        }

        protected void btnModificarViaje_Click(object sender, EventArgs e)
        {
            string idSeleccionado = clienteAux.IDCliente.ToString();

            Session.Add("RediCliente", 1);

            Response.Redirect("altaModificacionCliente.aspx?id=" + idSeleccionado, false);
        }

        protected void btnDetalleViaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalleViaje.aspx", false);
        }

        protected void btnResumenSemanalCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnResumenQuincenalCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnResumenMensualCliente_Click(object sender, EventArgs e)
        {

        }
    }
}