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

            if (Request.QueryString["id"] != null)
            {
                string idChofer = Request.QueryString["id"];
                ChoferNegocio cnAux = new ChoferNegocio();
                Chofer choferAux = cnAux.ObtenerDatos(int.Parse(idChofer))[0];

                txtNombre.Text = choferAux.Nombres;
                txtApellido.Text = choferAux.Apellidos;
                txtDNI.Text = choferAux.DNI.ToString();
                txtNacionalidad.Text = choferAux.Nacionalidad;
                txtFechaNacimiento.Text = choferAux.FechaNacimiento.ToString("dd/MM/yyyy");
                txtCalleyAltura.Text = choferAux.Direccion.Direccion;
                txtLocalidad.Text = choferAux.Direccion.Localidad;
                txtProvincia.Text = choferAux.Direccion.Provincia;
            }

        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalleChofer.aspx", false);
        }
    }
}