<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="homeChofer.aspx.cs" Inherits="TPCuatrimestal.homeChofer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="display: flex; align-items: center; justify-content: center; flex-direction: column; gap: 20px; margin-top: 40px; margin-bottom: 100px;">

        <div>
            <h4>Listado de viajes</h4>
            <asp:GridView ID="dgvViajes" runat="server" CssClass="table table-primary" OnSelectedIndexChanged="dgvViajes_SelectedIndexChanged" DataKeyNames="NumViaje" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Viaje N°" DataField="NumViaje" />

                    <asp:TemplateField HeaderText="Cliente">
                        <ItemTemplate>
                            <%# Eval("ClienteViaje")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Importe" DataField="Importe" DataFormatString="{0:F1}" />

                    <asp:BoundField HeaderText="Pagado" DataField="Pagado" />

                    <asp:TemplateField HeaderText="Accion">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnMapa" runat="server" CssClass="btn btn-close btn-lg border ms-1" CommandArgument='<%# Eval("NumViaje") %>' OnClick="btnMapa_Click" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcrDhC3i0jmSXhxnMoI5TDMWulKu0GZ6Jn2g&usqp=CAU"/>

                            <asp:ImageButton ID="btnNoPagado" ImageUrl="https://us.123rf.com/450wm/igoun/igoun1805/igoun180500088/101280971-icono-de-cruz-en-c%C3%ADrculo-se-puede-utilizar-como-bot%C3%B3n-de-eliminar-bloquear-cerrar-etc-eliminar.jpg" CommandArgument='<%#Eval("NumViaje")%>' CommandName="NumViaje" runat="server" Text="No Pagado" CssClass="btn btn-close btn-lg border ms-1" ToolTip="No Pagado" Visible='<%# Convert.ToBoolean(Eval("Pagado")) %>' OnClick="btnNoPagado_Click" />

                            <asp:ImageButton ID="btnPagado" ImageUrl="https://c0.klipartz.com/pngpicture/605/284/gratis-png-cheque-verde-ogo-iconos-de-la-marca-de-verificacion-marca-verde-thumbnail.png" CommandArgument='<%#Eval("NumViaje")%>' CommandName="NumViaje" runat="server" Text="Pagado" CssClass="btn btn-close btn-lg border ms-1" ToolTip="Pagado" Visible='<%# !Convert.ToBoolean(Eval("Pagado")) %>' OnClick="btnPagado_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>

        <div>
            <iframe id="urlIframe"
                runat="server"
                width="600"
                height="450"
                style="border: 0"
                loading="lazy"
                allowfullscreen
                referrerpolicy="no-referrer-when-downgrade"></iframe>
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
