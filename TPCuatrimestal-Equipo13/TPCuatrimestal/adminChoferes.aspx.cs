﻿using Dominio;
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
    public partial class choferes : System.Web.UI.Page
    {
        private List<Chofer> listarChoferes = new List<Chofer>();
        private string Seleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ChoferNegocio choferNegocio = new ChoferNegocio();
                listarChoferes = choferNegocio.ObtenerDatos();

                foreach (Chofer chofer in listarChoferes)
                {
                    ListItem item = new ListItem();
                    // Asigna el valor y el texto del ListItem con las propiedades de Chofer
                    item.Value = chofer.IDChofer.ToString(); // Asigna el valor deseado
                    item.Text = $"{chofer.Nombres} - {chofer.Apellidos}- {chofer.AutoAsignado.Patente} - {chofer.ZonaAsignada.NombreZona}";
                    item.Attributes["class"] = "list-group-item";
                    listaChoferes.Items.Add(item);
                }
            }
        }

        protected void btnAltaChofer_Click(object sender, EventArgs e)
        {
            //SI ES ALTA, SOLO REDIRECT
            Response.Redirect("altaModificacionChofer.aspx", false);
        }

        protected void btnDetalleChofer_Click(object sender, EventArgs e)
        {
            string idSeleccionado = listaChoferes.SelectedValue;
            Response.Redirect("detalleChofer.aspx?id=" + idSeleccionado, false);
        }

        protected void btnModificarChofer_Click(object sender, EventArgs e)
        {
            string idSeleccionado = listaChoferes.SelectedValue;
            Response.Redirect("altaModificacionChofer.aspx?id=" + idSeleccionado, false);
        }

        protected void listaChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccionado = listaChoferes.SelectedValue;
        }

        protected void btnBajaChofer_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(listaChoferes.SelectedValue);
            ChoferNegocio negocio = new ChoferNegocio();

            negocio.BajaChofer(id);
        }
    }
}