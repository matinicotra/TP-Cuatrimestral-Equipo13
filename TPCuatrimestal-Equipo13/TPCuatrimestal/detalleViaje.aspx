<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="detalleViaje.aspx.cs" Inherits="TPCuatrimestal.detalleViaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-md" style="display: flex; align-items: center; justify-content: center; flex-direction: column; grid-row-gap: 30px; margin-top: 50px;">
        <div class="text-center">
            <asp:Label ID="lblTitulo" CssClass="h1 text-primary" runat="server" Text=""></asp:Label>
        </div>
        <div class="list-group">

            <%-- LISTA DE LOS DETALLES DEL VIAJE --%>
            <div class="list-group list-group-horizontal">
                <asp:Label ID="lblCliente" CssClass="list-group-item list-group-item-primary mb-2" runat="server" Text="Cliente:"></asp:Label>
                <asp:Label ID="lblClienteData" CssClass="list-group-item mb-2" runat="server" Text=""></asp:Label>
            </div>

            <div class="list-group list-group-horizontal">
                <asp:Label ID="lblOrigen" CssClass="list-group-item list-group-item-primary mb-2" runat="server" Text="Direccion Origen:"></asp:Label>
                <asp:Label ID="lblOrigenData" CssClass="list-group-item mb-2" runat="server" Text=""></asp:Label>
            </div>

            <div class="list-group list-group-horizontal">
                <asp:Label ID="lblFechaHora" CssClass="list-group-item list-group-item-primary mb-2" runat="server" Text="Hora y Fecha:"></asp:Label>
                <asp:Label ID="lblFechaHoraData" CssClass="list-group-item mb-2" runat="server" Text=""></asp:Label>
            </div>

            <div class="list-group list-group-horizontal">
                <asp:Label ID="lblChofer" CssClass="list-group-item list-group-item-primary mb-2" runat="server" Text="Chofer:"></asp:Label>
                <asp:Label ID="lblChoferData" CssClass="list-group-item mb-2" runat="server" Text=""></asp:Label>
            </div>

            <div class="list-group list-group-horizontal">
                <asp:Label ID="lblDestino1" CssClass="list-group-item list-group-item-primary mb-2" runat="server" Text="Direccion Destino:"></asp:Label>
                <asp:Label ID="lblDestino1Data" CssClass="list-group-item mb-2" runat="server" Text=""></asp:Label>
            </div>
            <%-- SI TIENE MAS DESTINOS MUESTRA MAS LABELS DE DESTINOS --%>
            <%if (viaje.Destinos.Count() > 1)
                { %>
            <div class="list-group list-group-horizontal">
                <asp:Label ID="lblDestino2" CssClass="list-group-item list-group-item-primary mb-2" runat="server" Text="Direccion Segundo Destino:"></asp:Label>
                <asp:Label ID="lblDestino2Data" CssClass="list-group-item mb-2" runat="server" Text=""></asp:Label>
            </div>
            <%if (viaje.Destinos.Count() > 2)
                { %>
            <div class="list-group list-group-horizontal">
                <asp:Label ID="lblDestino3" CssClass="list-group-item list-group-item-primary mb-2" runat="server" Text="Direccion Tercer Destino:"></asp:Label>
                <asp:Label ID="lblDestino3Data" CssClass="list-group-item mb-2" runat="server" Text=""></asp:Label>
            </div>
            <%}
                } %>

            <div class="list-group list-group-horizontal">
                <asp:Label ID="lblImporte" CssClass="list-group-item list-group-item-primary mb-2" runat="server" Text="Importe:"></asp:Label>
                <asp:Label ID="lblImporteData" CssClass="list-group-item mb-2" runat="server" Text=""></asp:Label>
            </div>

            <div class="list-group list-group-horizontal">
                <asp:Label ID="lblMedioPago" CssClass="list-group-item list-group-item-primary mb-2" runat="server" Text="Forma de Pago:"></asp:Label>
                <asp:Label ID="lblMedioPagoData" CssClass="list-group-item mb-2" runat="server" Text=""></asp:Label>
            </div>

            <div class="list-group list-group-horizontal">
                <asp:Label ID="lblPagado" CssClass="list-group-item list-group-item-primary mb-2" runat="server" Text="Está Pago:"></asp:Label>
                <%if (viaje.Pagado)
                    {%>
                <asp:Image ID="imgPagado" runat="server" ImageUrl="https://c0.klipartz.com/pngpicture/605/284/gratis-png-cheque-verde-ogo-iconos-de-la-marca-de-verificacion-marca-verde-thumbnail.png" Text="Pagado" CssClass="btn btn-close btn-lg border m-1" ToolTip="Pagado" />
                <%}
                    else
                    { %>
                <asp:Image ID="imgNoPagado" runat="server" ImageUrl="https://us.123rf.com/450wm/igoun/igoun1805/igoun180500088/101280971-icono-de-cruz-en-c%C3%ADrculo-se-puede-utilizar-como-bot%C3%B3n-de-eliminar-bloquear-cerrar-etc-eliminar.jpg" Text="No Pagado" CssClass="btn btn-close btn-lg border m-1" ToolTip="No Pagado" />
                <%} %>
            </div>

            <div class="list-group list-group-horizontal">
                <asp:Label ID="lblTipoViaje" CssClass="list-group-item list-group-item-primary mb-2" runat="server" Text="Tipo Viaje:"></asp:Label>
                <asp:Label ID="lblTipoViajeData" CssClass="list-group-item mb-2" runat="server" Text=""></asp:Label>
            </div>

            <div class="list-group list-group-horizontal">
                <asp:Button ID="btnAtras" runat="server" Text="Atras" CssClass="btn btn-primary m-2" OnClick="btnAtras_Click" />
                <asp:Button ID="btnCopiarDatos" runat="server" Text="Copiar Datos" CssClass="btn btn-warning m-2" />
                <asp:Button ID="btnEnviarDatosViaje" runat="server" CssClass="btn btn-success m-2" Text="Enviar Por WhatsApp" />
            </div>

        </div>
    </div>
</asp:Content>
