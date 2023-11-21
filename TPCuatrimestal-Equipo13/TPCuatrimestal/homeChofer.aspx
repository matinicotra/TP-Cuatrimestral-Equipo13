<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="homeChofer.aspx.cs" Inherits="TPCuatrimestal.homeChofer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="display: flex; align-items: center; justify-content: center; flex-direction: column; gap: 20px; margin-top: 40px; margin-bottom: 100px;">

        <div>
            <h4>Listado de viajes del dia</h4>
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        </div>

        <div>
            <iframe id="urlIframe"
                runat="server"
                width="600"
                height="450"
                style="border: 0"
                loading="lazy"
                allowfullscreen
                referrerpolicy="no-referrer-when-downgrade"
                src="">
            </iframe>
        </div>

        <div>
            <asp:Button ID="btnWhatsapp" runat="server" OnClick="btnWhatsapp_Click" CssClass="btn btn-info" Text="Enviar mensaje de WhatsApp" />
        </div>

        <div>
            <asp:Button CssClass="btn btn-info" ID="btnDetalleViaje" runat="server" Text="Detalle viaje" OnClick="btnDetalleViaje_Click" />
            <asp:Button CssClass="btn btn-info" ID="btnCopiarDatosViajeSeleccionado" runat="server" Text="Copiar datos del viaje" />
        </div>

        <div style="display: flex; flex-direction: row; width: 400px;">
            <asp:TextBox CssClass="form-control" ID="txtFiltrar" runat="server">Filtrar</asp:TextBox>
            <asp:Button CssClass="btn btn-info" ID="btnFiltrar" runat="server" Text="Buscar" />
        </div>

        <div>
            <h5>Ver viajes por día</h5>
            <asp:Calendar ID="calOtrosDias" runat="server"></asp:Calendar>
        </div>

        <div>
            <h5>Resumenes del Chofer</h5>
            <asp:Button CssClass="btn btn-info" ID="btnResumenAnioChofer" runat="server" Text="Por Anio" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenMesChofer" runat="server" Text="Por Mes" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenTotalChofer" runat="server" Text="Total" />
        </div>

    </div>

</asp:Content>
