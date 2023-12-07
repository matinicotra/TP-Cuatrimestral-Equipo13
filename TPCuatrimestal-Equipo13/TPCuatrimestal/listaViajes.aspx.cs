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
    public partial class listaViajes : System.Web.UI.Page
    {
        private int Ide;
        private DateTime Inicio;
        private DateTime Fin;
        private Chofer chofer;
        private Cliente cliente;
        private List<Viaje> viajes = new List<Viaje>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ViajeNegocio viajeNego = new ViajeNegocio();

            Ide = int.Parse(Request.QueryString["Ide"]);
            int ID = int.Parse(Request.QueryString["ID"]);
            Inicio = DateTime.Parse(Request.QueryString["Inicio"]);
            Fin = DateTime.Parse(Request.QueryString["Fin"]);

            Fin.AddDays(1);

            if (Ide == 1)
            {
                ChoferNegocio negoAux = new ChoferNegocio();
                decimal Total = 0;

                chofer = negoAux.ObtenerDatos(ID)[0];

                viajes = viajeNego.ViajesClientesChoferes(chofer.IDChofer, true);

                lblClienteOChofer.Text = "CHOFER";
                lblNombre.Text = "NOMBRE: " + chofer.Nombres;
                lblZona.Text = "ZONA: " + chofer.ZonaAsignada.NombreZona;

                foreach (Viaje X in viajes)
                {
                    Total += X.Importe;
                }

                lblTotal.Text = "TOTAL (PAGANDO AL %30): $" + (Total * (decimal)0.30).ToString("f2");

                if (chofer.Estado)
                {
                    lblEstado.Text = "ESTADO: Activo";
                }
                else
                {
                    lblEstado.Text = "ESTADO: Inactivo";
                }
            }
            else
            {
                ClienteNegocio negoAux = new ClienteNegocio();
                decimal Total = 0;

                cliente = negoAux.ObtenerDatos(ID)[0];

                viajes = viajeNego.ViajesClientesChoferes(cliente.IDCliente, false);

                foreach (Viaje X in viajes)
                {
                    if (X.Importe > 0)
                    {
                        Total += X.Importe;
                    }
                }

                lblTotal.Text = "TOTAL: $" + Total.ToString("f2");

                lblClienteOChofer.Text = "CLIENTE";
                lblNombre.Text = "NOMBRE: " + cliente.Nombres;
                lblZona.Text = "ZONA: " + cliente.zonaCliente.NombreZona;

                if (cliente.Estado)
                {
                    lblEstado.Text = "ESTADO: Activo";
                }
                else
                {
                    lblEstado.Text = "ESTADO: Inactivo";
                }
            }

            repViajes.DataSource = viajes.FindAll(X => X.FechaHoraViaje >= Inicio && X.FechaHoraViaje <= Fin);
            repViajes.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            string ID;

            if (chofer != null)
            {
                ID = chofer.IDChofer.ToString();
                Usuario usuario = (Usuario)Session["Usuario"];

                if (!Seguridad.esAdmin(usuario))
                {
                    Response.Redirect("homeChofer.aspx?id=" + usuario.idChofer, false);
                }

                if (Request.QueryString["Home"] != null)
                {
                    Response.Redirect("homeChofer.aspx?id=" + ID, false);
                }
                else
                {
                    Response.Redirect("detalleChofer.aspx?id=" + ID, false);
                }
            }
            else
            {
                ID = cliente.IDCliente.ToString();

                Response.Redirect("detalleCliente.aspx?id=" + ID, false);
            }
        }
    }
}