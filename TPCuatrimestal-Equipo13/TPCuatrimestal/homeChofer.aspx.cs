using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestal
{
    public partial class homeChofer : System.Web.UI.Page
    {

        private List<Viaje> viajes = new List<Viaje>();

        private List<Viaje> viajesAsignados = new List<Viaje>();

        private Domicilio domicilioOrigen = new Domicilio();

        private int idChofer;

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            if (Seguridad.esAdmin(usuario))
            {
                Response.Redirect("homeAdmin.aspx", false);
                return;
            }

            ViajeNegocio viajeNegocio = new ViajeNegocio();
            //idChofer = int.Parse(Request.QueryString["id"]);
            idChofer = (int)usuario.idPersona;
            viajes = viajeNegocio.ViajesClientesChoferes(idChofer, true);

            if (viajes.Count() < 1)
            {
                dgvViajes.Visible = false;
            }
            else
            {
                viajesAsignados.Clear();

                foreach (Viaje viaje in viajes)
                {
                    if (viaje.Estado.ToString() != "Finalizado")
                    {
                        viajesAsignados.Add(viaje);
                    }
                }

            }


            if (!IsPostBack)
            {
                dgvViajes.DataSource = viajesAsignados;
                dgvViajes.DataBind();
            }

            if (viajesAsignados.Count != 0)
                CargarMapa(viajesAsignados[0]);
        }

        private void CargarViajesAsignados()
        {
            ViajeNegocio viajeNegocio = new ViajeNegocio();
            viajes = viajeNegocio.ViajesClientesChoferes(idChofer, true);

            viajesAsignados.Clear();

            foreach (Viaje viaje in viajes)
            {
                if (viaje.Estado.ToString() != "Finalizado")
                {
                    viajesAsignados.Add(viaje);
                }
            }

            dgvViajes.DataSource = viajesAsignados;
            dgvViajes.DataBind();

            if (viajesAsignados.Count != 0)
                CargarMapa(viajesAsignados[0]);
        }

        protected void CargarMapa(Viaje viaje)
        {
            string direccion = viaje.Origen.Direccion.ToString().Replace(" ", "+");
            string localidad = viaje.Origen.Localidad.ToString().Replace(" ", "+");
            string provincia = viaje.Origen.Provincia.ToString().Replace(" ", "+");

            string domicilio = direccion + "," + localidad + "," + provincia;
            urlIframe.Attributes.Add("src", "https://www.google.com/maps/embed/v1/place?key=AIzaSyDoBiKY57PiZmKkaMIjWRjSMPZO2i-XJJM&q=" + domicilio);
        }

        protected void btnDetalleViaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalleViaje.aspx", false);
        }

        protected void dgvViajes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnPagado_Click(object sender, ImageClickEventArgs e)
        {
            ViajeNegocio viajeNegocio = new ViajeNegocio();

            int valorID = int.Parse(((ImageButton)sender).CommandArgument);

            viajeNegocio.PagarDespagarViaje(valorID, true);

            CargarViajesAsignados();
        }

        // MAPA ORIGEN
        protected void btnMapa_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnImg = (ImageButton)sender;
            long numViaje = long.Parse(btnImg.CommandArgument);
            Viaje viaje = viajesAsignados.Find(X => X.NumViaje == numViaje);

            string direccion = viaje.Origen.Direccion.ToString().Replace(" ", "+");
            string localidad = viaje.Origen.Localidad.ToString().Replace(" ", "+");
            string provincia = viaje.Origen.Provincia.ToString().Replace(" ", "+");

            string domicilio = direccion + "," + localidad + "," + provincia;

            urlIframe.Attributes.Add("src", "https://www.google.com/maps/embed/v1/place?key=AIzaSyDoBiKY57PiZmKkaMIjWRjSMPZO2i-XJJM&q=" + domicilio);
        }

        // MAPA DESTINO
        protected void btnMapaDestino_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnImg = (ImageButton)sender;
            long numViaje = long.Parse(btnImg.CommandArgument);
            Viaje viaje = viajesAsignados.Find(X => X.NumViaje == numViaje);

            string direccion = viaje.Destinos[0].Direccion.ToString().Replace(" ", "+");        // !!! ver lista destinos 
            string localidad = viaje.Destinos[0].Localidad.ToString().Replace(" ", "+");
            string provincia = viaje.Destinos[0].Provincia.ToString().Replace(" ", "+");

            string domicilio = direccion + "," + localidad + "," + provincia;

            urlIframe.Attributes.Add("src", "https://www.google.com/maps/embed/v1/place?key=AIzaSyDoBiKY57PiZmKkaMIjWRjSMPZO2i-XJJM&q=" + domicilio);
        }

        // MENSAJE WHATSAPP
        protected void btnWhatsApp_Click1(object sender, ImageClickEventArgs e)
        {
            ImageButton btnImg = (ImageButton)sender;
            long numViaje = long.Parse(btnImg.CommandArgument);
            Viaje viaje = viajesAsignados.Find(X => X.NumViaje == numViaje);

            string telefono = viaje.ClienteViaje.Telefono.ToString();
            Response.Redirect("https://wa.me/" + telefono + "?text=Tu%20transporte%20ha%20llegado!");
        }

        protected void btnFinalizado_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btnImg = (ImageButton)sender;
            long idViaje = long.Parse(btnImg.CommandArgument);
            ViajeNegocio viajeNegocio = new ViajeNegocio();
            viajeNegocio.FinalizarViaje(idViaje);

            CargarViajesAsignados();
        }

        protected void btnDetalle_Click(object sender, ImageClickEventArgs e)
        {
            int valorID = int.Parse(((ImageButton)sender).CommandArgument);
            string esChofer = "true";
            Response.Redirect("detalleViaje.aspx?id=" + valorID + "&esChofer=" + esChofer, false);
        }

        protected void btnResumenSemanal_Click(object sender, EventArgs e)
        {
            string Ide = idChofer.ToString();
            string homeChofer = Request.QueryString["id"];

            //ACA SETEAR UN PARAMETRO IDCHOFER: USAR EL USUARIO PARA ESO (PUEDE SER CON SESSION[])

            DateTime IN = DateTime.Now.AddDays(-7);
            DateTime OUT = DateTime.Now.AddDays(1);

            Response.Redirect("listaViajes.aspx?Ide=" + Ide + "&ID=" + idChofer + "&Inicio=" + IN.ToString() + "&Fin=" + OUT.ToString() + "&Home=" + homeChofer, false);
        }

        protected void btnResumenMesChofer_Click(object sender, EventArgs e)
        {
            string Ide = idChofer.ToString();
            string homeChofer = Request.QueryString["id"];

            //ACA SETEAR UN PARAMETRO IDCHOFER: USAR EL USUARIO PARA ESO (PUEDE SER CON SESSION[])

            DateTime IN = DateTime.Now.AddDays(-15);
            DateTime OUT = DateTime.Now.AddDays(1);

            Response.Redirect("listaViajes.aspx?Ide=" + Ide + "&ID=" + idChofer + "&Inicio=" + IN.ToString() + "&Fin=" + OUT.ToString() + "&Home=" + homeChofer, false);
        }

        protected void btnResumenQuincenal_Click(object sender, EventArgs e)
        {
            string Ide = idChofer.ToString();
            string homeChofer = Request.QueryString["id"];
            //ACA SETEAR UN PARAMETRO IDCHOFER: USAR EL USUARIO PARA ESO (PUEDE SER CON SESSION[])

            DateTime IN = DateTime.Now.AddDays(-30);
            DateTime OUT = DateTime.Now.AddDays(1);

            Response.Redirect("listaViajes.aspx?Ide=" + Ide + "&ID=" + idChofer + "&Inicio=" + IN.ToString() + "&Fin=" + OUT.ToString() + "&Home=" + homeChofer, false);
        }
    }
}