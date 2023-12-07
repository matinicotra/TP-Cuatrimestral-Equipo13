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
        private List<Cliente> listaClientes;
        private Chofer choferAux;
        private Domicilio dirOrigen;
        private Domicilio dirDestino1;
        private Domicilio dirDestino2;
        private Domicilio dirDestino3;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["Usuario"]))
            {
                Response.Redirect("login.aspx", false);
            }

            if (!IsPostBack)
            {
                txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtHora.Text = "07:00";
                rblFormaDePago.SelectedValue = "No Especifica";
                ddlEstadoViaje.SelectedIndex = 0;
                ddlChoferes.SelectedIndex = 0;
                ddlClientes.SelectedIndex = 0;

                CargarDesplegables();
            }

            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                ViajeNegocio viajeNegocio = new ViajeNegocio();
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                ChoferNegocio choferNegocio = new ChoferNegocio();
                DomicilioNegocio domicilioNegocio = new DomicilioNegocio();

                long idViaje = long.Parse(Request.QueryString["id"]);

                viajeAux = viajeNegocio.ObtenerDatos(idViaje)[0];

                if (viajeAux.IDCliente > 0)
                {
                    clienteAux = clienteNegocio.ObtenerDatos(viajeAux.IDCliente)[0];
                    Session["ClienteID"] = clienteAux.IDCliente;
                }
                else
                {
                    clienteAux = new Cliente();

                    Session["ClienteID"] = 0;
                    cbxSinCliente.Checked = true;
                    cbxSinCliente_CheckedChanged(this, e);
                }

                if (viajeAux.IDChofer != -1)
                {
                    choferAux = choferNegocio.ObtenerDatos(viajeAux.IDChofer)[0];
                    Session["ChoferID"] = choferAux.IDChofer;
                }
                else
                {
                    Session["ChoferID"] = 0;
                }

                dirOrigen = domicilioNegocio.ObtenerDomicilio(viajeAux.Origen.IDDomicilio);
                dirDestino1 = domicilioNegocio.ObtenerDomicilio(viajeAux.Destinos[0].IDDomicilio);

                Session["clienteAux"] = viajeAux.ClienteViaje;


                if (viajeAux.Destinos.Count() > 1)
                {
                    dirDestino2 = domicilioNegocio.ObtenerDomicilio(viajeAux.Destinos[1].IDDomicilio);
                    ddlCantidadDestino.SelectedIndex = 2;
                    txtCalleDestino2.Text = dirDestino2.Direccion;
                    txtLocalidadDestino2.Text = dirDestino2.Localidad;
                    txtProvinciaDestino2.Text = dirDestino2.Provincia;
                    txtDescripcionDestino2.Text = dirDestino2.Descripcion;

                    if (viajeAux.Destinos.Count() > 2)
                    {
                        dirDestino3 = domicilioNegocio.ObtenerDomicilio(viajeAux.Destinos[2].IDDomicilio);
                        ddlCantidadDestino.SelectedIndex = 3;
                        txtCalleDestino3.Text = dirDestino3.Direccion;
                        txtLocalidadDestino3.Text = dirDestino3.Localidad;
                        txtProvinciaDestino3.Text = dirDestino3.Provincia;
                        txtDescripcionDestino3.Text = dirDestino3.Descripcion;
                    }
                }

                txtNombre.Text = clienteAux.Nombres;
                txtApellido.Text = clienteAux.Apellidos;
                txtTelefonoCliente.Text = clienteAux.Telefono;

                txtCalleOrigen.Text = dirOrigen.Direccion;
                txtLocalidadOrigen.Text = dirOrigen.Localidad;
                txtProvinciaOrigen.Text = dirOrigen.Provincia;
                txtDescripcionOrigen.Text = dirOrigen.Descripcion;

                txtCalleDestino1.Text = dirDestino1.Direccion;
                txtLocalidadDestino1.Text = dirDestino1.Localidad;
                txtProvinciaDestino1.Text = dirDestino1.Provincia;
                txtDescripcionDestino1.Text = dirDestino1.Descripcion;

                cbxPagado.Checked = viajeAux.Pagado;
                ddlEstadoViaje.Text = viajeAux.Estado;

                txtFecha.Text = viajeAux.FechaHoraViaje.ToString("yyyy-MM-dd");
                txtHora.Text = viajeAux.FechaHoraViaje.ToString("HH:mm");
                txtTipoDeViaje.Text = viajeAux.TipoViaje;
                txtImporte.Text = viajeAux.Importe.ToString("f0");

                rblFormaDePago.SelectedValue = viajeAux.MedioDePago;

                if (Session["CantidadDestino"] != null)
                {
                    ddlCantidadDestino.SelectedValue = Session["CantidadDestino"].ToString();
                }
                else
                {
                    ddlCantidadDestino.SelectedValue = viajeAux.Destinos.Count().ToString();
                }

                if ((int.Parse(Session["ClienteID"].ToString()) != 0))
                {
                    ddlClientes.SelectedValue = Session["ClienteID"].ToString();
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtTelefonoCliente.Enabled = false;
                }
                else
                {
                    ddlClientes.SelectedIndex = 0;
                }
                if (Session["ChoferID"] != null)
                {
                    ddlChoferes.SelectedValue = Session["ChoferID"].ToString();
                }
            }
        }

        private void CargarDesplegables()
        {
            ChoferNegocio cnAux = new ChoferNegocio();
            List<Chofer> listaChoferes = new List<Chofer>();

            listaChoferes = cnAux.ObtenerDatos();

            //no asignado es index = 0
            ddlChoferes.DataValueField = "IDChofer";

            //Se configura con el Items.Add y el new  ListItem (Valor del campo a mostrar, DataValueField)
            ddlChoferes.Items.Add(new ListItem("No Asignado", "0"));
            int contador = 0;
            ddlChoferes.SelectedIndex = 0;

            foreach (Chofer X in listaChoferes)
            {
                if (X.Estado)
                {
                    ddlChoferes.Items.Add(new ListItem(X.IDChofer.ToString() + "- " + X.Nombres + " " + X.Apellidos + " | " + X.AutoAsignado.ToString(), X.IDChofer.ToString()));

                    contador++;

                    if (viajeAux != null)
                    {
                        if (X.IDChofer == viajeAux.IDChofer)
                        {
                            ddlChoferes.SelectedIndex = contador;
                        }
                    }
                }
            }

            ClienteNegocio clienteNegocioAux = new ClienteNegocio();
            listaClientes = clienteNegocioAux.ObtenerDatos();

            //No asignado es index = 0
            ddlClientes.DataValueField = "IDCliente";

            ddlClientes.Items.Add(new ListItem("Cliente Nuevo", "0"));
            ddlClientes.SelectedIndex = 0;
            contador = 0;

            foreach (Cliente Y in listaClientes)
            {
                ddlClientes.Items.Add(new ListItem(Y.ToString(), Y.IDCliente.ToString()));

                contador++;

                if (viajeAux != null)
                {
                    if (Y.IDCliente == viajeAux.IDCliente)
                    {
                        ddlClientes.SelectedIndex = contador;
                    }
                }
            }

            Session["listaClientes"] = listaClientes;
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
            viajeAux = new Viaje();

            viajeAux.Pagado = cbxPagado.Checked;
            viajeAux.Estado = ddlEstadoViaje.SelectedValue;

            //Carga CLIENTE: SI SE OMITE CLIENTE DEVUELVE IDCLIENTE -1, SI ES CLIENTE NUEVO ES IDCLIENTE 0
            if (cbxSinCliente.Checked)
            {
                viajeAux.ClienteViaje = null;
                viajeAux.IDCliente = -1;
            }
            else
            {
                if (ddlClientes.SelectedIndex == 0)
                {
                    viajeAux.ClienteViaje.Nombres = ValidarNullVacio(txtNombre) == false ? "" : txtNombre.Text;
                    viajeAux.ClienteViaje.Apellidos = ValidarNullVacio(txtApellido) == false ? "" : txtApellido.Text;
                    viajeAux.ClienteViaje.Telefono = ValidarNullVacio(txtTelefonoCliente) == false ? "" : txtTelefonoCliente.Text;
                }
                else
                {       //SI ES CLIENTE YA INGRESADO SE LO RECUPERA
                    viajeAux.ClienteViaje = (Cliente)Session["clienteAux"];
                    Cliente cliente = (Cliente)Session["clienteAux"];
                    viajeAux.IDCliente = cliente.IDCliente;
                }
            }

            viajeAux.MedioDePago = rblFormaDePago.Text;

            string fechaHoraAux = txtFecha.Text + " " + txtHora.Text;
            viajeAux.FechaHoraViaje = DateTime.Parse(fechaHoraAux);

            dirOrigen = new Domicilio();
            dirOrigen.Direccion = ValidarNullVacio(txtCalleOrigen) == false ? "" : txtCalleOrigen.Text;
            dirOrigen.Localidad = ValidarNullVacio(txtLocalidadOrigen) == false ? "" : txtLocalidadOrigen.Text;
            dirOrigen.Provincia = ValidarNullVacio(txtProvinciaOrigen) == false ? "" : txtProvinciaOrigen.Text;
            dirOrigen.Descripcion = ValidarNullVacio(txtDescripcionOrigen) == false ? "" : txtDescripcionOrigen.Text;
            viajeAux.Origen = ValidarNullVacio(txtCalleOrigen) == false ? new Domicilio() : dirOrigen;

            dirDestino1 = new Domicilio();
            dirDestino1.Direccion = ValidarNullVacio(txtCalleDestino1) == false ? "" : txtCalleDestino1.Text;
            dirDestino1.Localidad = ValidarNullVacio(txtLocalidadDestino1) == false ? "" : txtLocalidadDestino1.Text;
            dirDestino1.Provincia = ValidarNullVacio(txtProvinciaDestino1) == false ? "" : txtProvinciaDestino1.Text;
            dirDestino1.Descripcion = ValidarNullVacio(txtDescripcionDestino1) == false ? "" : txtDescripcionDestino1.Text;

            viajeAux.Destinos.Add(dirDestino1);

            if (ddlCantidadDestino.SelectedIndex > 0)
            {
                dirDestino2 = new Domicilio();
                dirDestino2.Direccion = ValidarNullVacio(txtCalleDestino2) == false ? "" : txtCalleDestino2.Text;
                dirDestino2.Direccion = ValidarNullVacio(txtLocalidadDestino2) == false ? "" : txtLocalidadDestino2.Text;
                dirDestino2.Direccion = ValidarNullVacio(txtProvinciaDestino2) == false ? "" : txtProvinciaDestino2.Text;
                dirDestino2.Direccion = ValidarNullVacio(txtDescripcionDestino2) == false ? "" : txtDescripcionDestino2.Text;

                viajeAux.Destinos.Add(dirDestino2);

                if (ddlCantidadDestino.SelectedIndex > 1)
                {
                    dirDestino3 = new Domicilio();

                    dirDestino3.Direccion = ValidarNullVacio(txtCalleDestino3) == false ? "" : txtCalleDestino3.Text;
                    dirDestino3.Direccion = ValidarNullVacio(txtLocalidadDestino3) == false ? "" : txtLocalidadDestino3.Text;
                    dirDestino3.Direccion = ValidarNullVacio(txtProvinciaDestino3) == false ? "" : txtProvinciaDestino3.Text;
                    dirDestino3.Direccion = ValidarNullVacio(txtDescripcionDestino3) == false ? "" : txtDescripcionDestino3.Text;

                    viajeAux.Destinos.Add(dirDestino3);
                }
            }

            if (ddlChoferes.SelectedIndex != 0)
            {
                ChoferNegocio choferNegocio = new ChoferNegocio();

                string aux = ddlChoferes.SelectedValue;
                int idChofer = int.Parse(ddlChoferes.SelectedValue);

                choferAux = choferNegocio.ObtenerDatos(int.Parse(ddlChoferes.SelectedValue))[0];

                viajeAux.IDChofer = choferAux.IDChofer;
            }
            else
            {
                viajeAux.IDChofer = 0;
            }

            viajeAux.ChoferViaje = choferAux;

            viajeAux.TipoViaje = ValidarNullVacio(txtTipoDeViaje) == false ? "" : txtTipoDeViaje.Text;

            viajeAux.Importe = ValidarNullVacio(txtImporte) == false ? 0 : decimal.Parse(txtImporte.Text);

            ViajeNegocio viajeNegocio = new ViajeNegocio();

            if (txtCalleOrigen.BorderColor != System.Drawing.Color.Red &&
                txtApellido.BorderColor != System.Drawing.Color.Red &&
                txtCalleDestino1.BorderColor != System.Drawing.Color.Red &&
                txtCalleDestino2.BorderColor != System.Drawing.Color.Red &&
                txtCalleDestino3.BorderColor != System.Drawing.Color.Red &&
                txtHora.BorderColor != System.Drawing.Color.Red &&
                txtImporte.BorderColor != System.Drawing.Color.Red &&
                txtLocalidadDestino1.BorderColor != System.Drawing.Color.Red &&
                txtLocalidadDestino2.BorderColor != System.Drawing.Color.Red &&
                txtLocalidadDestino3.BorderColor != System.Drawing.Color.Red &&
                txtLocalidadOrigen.BorderColor != System.Drawing.Color.Red &&
                txtNombre.BorderColor != System.Drawing.Color.Red &&
                txtProvinciaDestino1.BorderColor != System.Drawing.Color.Red &&
                txtProvinciaDestino2.BorderColor != System.Drawing.Color.Red &&
                txtProvinciaDestino3.BorderColor != System.Drawing.Color.Red &&
                txtProvinciaOrigen.BorderColor != System.Drawing.Color.Red &&
                txtTelefonoCliente.BorderColor != System.Drawing.Color.Red &&
                txtTipoDeViaje.BorderColor != System.Drawing.Color.Red)
            {

                if ((Request.QueryString["id"] == null))
                {
                    viajeNegocio.AltaModificacionViaje(viajeAux, true);
                }
                else
                {
                    viajeAux.NumViaje = long.Parse(Request.QueryString["id"]);

                    viajeNegocio.AltaModificacionViaje(viajeAux, false);
                }

                Response.Redirect("homeAdmin.aspx", false);
            }
        }
        //los siguientes dos eventos comparten código, ver la manera de hacerlo mas eficiente
        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaClientes = (List<Cliente>)Session["listaClientes"];
            if (ddlClientes.SelectedIndex != 0)
            {
                Session["clienteAux"] = listaClientes[ddlClientes.SelectedIndex - 1];
                clienteAux = (Cliente)Session["clienteAux"];
                txtNombre.Text = clienteAux.Nombres;
                txtApellido.Text = clienteAux.Apellidos;
                txtTelefonoCliente.Text = clienteAux.Telefono;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtTelefonoCliente.Enabled = false;

                txtCalleOrigen.Text = clienteAux.Direccion.Direccion;
                txtLocalidadOrigen.Text = clienteAux.Direccion.Localidad;
                txtProvinciaOrigen.Text = clienteAux.Direccion.Provincia;
                txtDescripcionOrigen.Text = clienteAux.Direccion.Descripcion;
            }
            else
            {
                Session["clienteAux"] = null;
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtTelefonoCliente.Text = string.Empty;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtTelefonoCliente.Enabled = true;
            }
        }

        protected void cbxSinCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSinCliente.Checked == true)
            {
                ddlClientes.Enabled = false;
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtTelefonoCliente.Text = string.Empty;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtTelefonoCliente.Enabled = false;
            }
            else
            {
                ddlClientes.Enabled = true;
                listaClientes = (List<Cliente>)Session["listaClientes"];
                if (ddlClientes.SelectedIndex != 0)
                {
                    Session["clienteAux"] = listaClientes[ddlClientes.SelectedIndex - 1];
                    clienteAux = (Cliente)Session["clienteAux"];
                    txtNombre.Text = clienteAux.Nombres;
                    txtApellido.Text = clienteAux.Apellidos;
                    txtTelefonoCliente.Text = clienteAux.Telefono;
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtTelefonoCliente.Enabled = false;
                }
                else
                {
                    Session["clienteAux"] = null;
                    txtNombre.Text = string.Empty;
                    txtApellido.Text = string.Empty;
                    txtTelefonoCliente.Text = string.Empty;
                    txtNombre.Enabled = true;
                    txtApellido.Enabled = true;
                    txtTelefonoCliente.Enabled = true;
                }
            }
        }

        protected void rblFormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {

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