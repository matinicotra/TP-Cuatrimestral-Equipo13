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
    public partial class altaModificacionVehiculo : System.Web.UI.Page
    {
        public List<TipoVehiculo> ListTipoVehi { get; set; }

        public int IDVehiculo { get; set; }

        public List<Vehiculo> listaVehiculos { get; set; }

        public Vehiculo vehiculoAux = new Vehiculo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["Usuario"]))
                Response.Redirect("login.aspx", false);

            TipoVehiculoNegocio aux = new TipoVehiculoNegocio();
            ListTipoVehi = new List<TipoVehiculo>();

            ListTipoVehi = aux.ObtenerDatos();

            if (!IsPostBack)
            {
                foreach (TipoVehiculo X in ListTipoVehi)
                {
                    ddlTipoVehiculo.Items.Add(X.NombreTipo);
                }

                if (Request.QueryString["id"] != null)
                {
                    IDVehiculo = int.Parse(Request.QueryString["id"]); //Capturamos el id de la URL

                    VehiculoNegocio vehiculoNegocio = new VehiculoNegocio();

                    listaVehiculos = vehiculoNegocio.ObtenerDatos();

                    vehiculoAux = listaVehiculos.Find(x => x.IDVehiculo == IDVehiculo); //Capturamos el vehiculo a modificar en vehiculoAux

                    //cargamos los campos con vehiculoAux
                    txtPatente.Text = vehiculoAux.Patente.ToString();
                    txtModelo.Text = vehiculoAux.Modelo.ToString();
                    ddlTipoVehiculo.SelectedValue = vehiculoAux.Tipo.NombreTipo.ToString();
                }
            }
        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminVehiculo.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoVehiculo tvAux = new TipoVehiculo();
                VehiculoNegocio vehiculoNegocioAux = new VehiculoNegocio();

                //capturamos en vehiculoAux los datos de los campos
                vehiculoAux.Patente = ValidarNullVacio(txtPatente) == false ? "" : txtPatente.Text;
                vehiculoAux.Modelo = ValidarNullVacio(txtModelo) == false ? 0 : int.Parse(txtModelo.Text);

                string tipoSeleccionado = ddlTipoVehiculo.SelectedValue;

                tvAux = ListTipoVehi.Find(x => x.NombreTipo == tipoSeleccionado);

                vehiculoAux.Tipo = tvAux;


                if (txtModelo.BorderColor != System.Drawing.Color.Red &&
                    txtPatente.BorderColor != System.Drawing.Color.Red)
                {
                    if (Request.QueryString["id"] != null) //si es modificar...
                    {
                        vehiculoAux.IDVehiculo = int.Parse(Request.QueryString["id"]);

                        vehiculoNegocioAux.AltaModificacionVehiculo(vehiculoAux, true);
                    }
                    else //si es agregar uno nuevo...
                    {
                        vehiculoNegocioAux.AltaModificacionVehiculo(vehiculoAux, false);
                    }

                    Response.Redirect("adminVehiculo.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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