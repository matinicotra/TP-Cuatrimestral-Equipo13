<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="homeChofer.aspx.cs" Inherits="TPCuatrimestal.homeChofer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="display: flex; align-items: center; justify-content: center; flex-direction: column; gap: 20px; margin-top: 40px; margin-bottom: 100px;">
        <div style="display: flex; flex-direction: row; width: 400px;">
            <asp:TextBox CssClass="form-control" ID="txtFiltrar" runat="server">Filtrar</asp:TextBox>
            <asp:Button CssClass="btn btn-info" ID="btnFiltrar" runat="server" Text="Buscar" />
        </div>

        <div>
            <h4 class="h3 text-center">VIAJES</h4>
            <asp:GridView ID="dgvViajes" runat="server" CssClass="table table-primary" OnSelectedIndexChanged="dgvViajes_SelectedIndexChanged" DataKeyNames="NumViaje" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Viaje N°" DataField="NumViaje" />

                    <asp:TemplateField HeaderText="Cliente">
                        <ItemTemplate>
                            <%# Eval("ClienteViaje")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Origen" DataField="Origen" />

                    <%-- <asp:TemplateField HeaderText="Destino">
                        <ItemTemplate>
                            <%# Eval("Domicilio")%>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <%--<asp:BoundField HeaderText="Destino" DataField="" />--%>

                    <asp:BoundField HeaderText="Importe" DataField="Importe" DataFormatString="{0:F1}" />

                    <asp:BoundField HeaderText="Pagado" DataField="Pagado" />

                    <asp:BoundField HeaderText="Estado" DataField="Estado" />

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnMapa" runat="server" CssClass="btn btn-close btn-lg border ms-1" CommandArgument='<%# Eval("NumViaje") %>' ToolTip="Origen" OnClick="btnMapa_Click" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcrDhC3i0jmSXhxnMoI5TDMWulKu0GZ6Jn2g&usqp=CAU" />

                            <asp:ImageButton ID="btnMapaDestino" runat="server" CssClass="btn btn-close btn-lg border ms-1" CommandArgument='<%# Eval("NumViaje") %>' ToolTip="Destino" OnClick="btnMapaDestino_Click" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcrDhC3i0jmSXhxnMoI5TDMWulKu0GZ6Jn2g&usqp=CAU" />

                            <asp:ImageButton ID="btnWhatsApp" runat="server" CssClass="btn btn-close btn-lg border ms-1" CommandArgument='<%# Eval("NumViaje") %>' ToolTip="Enviar WhatsApp" OnClick="btnWhatsApp_Click1" src="https://i.pinimg.com/736x/b3/80/4c/b3804c40eb070822e5673157950faa96.jpg" />

                            <asp:ImageButton ID="btnPagado" CommandArgument='<%#Eval("NumViaje")%>' CommandName="NumViaje" runat="server" Text="Pagado" CssClass="btn btn-close btn-lg border ms-1" ToolTip="Pagado" Visible='<%# !Convert.ToBoolean(Eval("Pagado")) %>' OnClick="btnPagado_Click" src="https://img.freepik.com/vector-premium/signo-dolar-icono-plano-ilustracion-vectorial_686498-432.jpg" />

                            <asp:ImageButton ID="btnFinalizado" runat="server" CommandArgument='<%#Eval("NumViaje")%>' CommandName="NumViaje" Text="Finalizado" ToolTip="Finalizado" CssClass="btn btn-close btn-lg border ms-1" OnClick="btnFinalizado_Click" src="https://cdn.icon-icons.com/icons2/1506/PNG/512/emblemok_103757.png" />

                            <asp:ImageButton ID="btnDetalle" runat="server" ImageUrl="https://w7.pngwing.com/pngs/756/956/png-transparent-computer-icons-symbol-hamburger-button-details-miscellaneous-blue-angle-thumbnail.png" class="btn btn-close btn-lg border ms-1" CommandName="Detalle" CommandArgument='<%# Eval("NumViaje") %>' ToolTip="Detalle" OnClick="btnDetalle_Click" />

                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>

        <div>
            <asp:Label ID="lblOrigen" runat="server"></asp:Label>
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

        <%--        <div>
            <asp:Button CssClass="btn btn-info" ID="btnDetalleViaje" runat="server" Text="Detalle viaje" OnClick="btnDetalleViaje_Click" />
        </div>--%>


        <div>
            <h5>Resumenes del Chofer</h5>
            <asp:Button CssClass="btn btn-info" ID="btnResumenSemanal" runat="server" Text="Semanal" OnClick="btnResumenSemanal_Click" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenQuincenal" runat="server" Text="Quincenal" OnClick="btnResumenQuincenal_Click" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenMesChofer" runat="server" Text="Mensual" OnClick="btnResumenMesChofer_Click"/>
        </div>

    </div>

</asp:Content>
