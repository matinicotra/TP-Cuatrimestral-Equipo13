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

                lblClienteOChofer.Text = "Chofer:";
                lblNombre.Text = chofer.Nombres;
                lblZona.Text = chofer.ZonaAsignada.NombreZona;

                foreach (Viaje X in viajes)
                {
                    Total += X.Importe;
                }

                lblTotal.Text = "TOTAL (PAGANDO AL 0.30): $" + (Total * (decimal)0.30);

                if (chofer.Estado)
                {
                    lblEstado.Text = "Activo";
                }
                else
                {
                    lblEstado.Text = "Inactivo";
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
                    Total += X.Importe;
                }

                lblTotal.Text = "TOTAL: $" + Total;

                lblClienteOChofer.Text = "Cliente:";
                lblNombre.Text = cliente.Nombres;
                lblZona.Text = cliente.zonaCliente.NombreZona;

                if (cliente.Estado)
                {
                    lblEstado.Text = "Activo";
                }
                else
                {
                    lblEstado.Text = "Inactivo";
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

                Response.Redirect("detalleChofer.aspx?id=" + ID, false);
            }
            else
            {
                ID = cliente.IDCliente.ToString();

                Response.Redirect("detalleCliente.aspx?id=" + ID, false);
            }
        }
    }
}