<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="homeAdmin.aspx.cs" Inherits="TPCuatrimestal.homeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-color: aliceblue; display: flex; align-items: center; justify-content: center; flex-direction: column; grid-row-gap: 30px; margin-top: 50px; margin-bottom: 150px;">

        <div cssclass="input-group" style="display: flex;">
            <asp:TextBox ID="txtFiltrar" runat="server" CssClass="form-control" PlaceHolder="Busqueda..."></asp:TextBox>
            <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" CssClass="btn btn-primary ms-2" />
        </div>


        <div style="display: flex; flex-direction: column;">

            <asp:Label ID="lblViajesDelDia" runat="server" Text="VIAJES DEL DIA" CssClass="h3 text-center"></asp:Label>
            <asp:GridView ID="dgvViajes" DataKeyNames="NumViaje" OnSelectedIndexChanged="dgvViajes_SelectedIndexChanged" AutoGenerateColumns="false" CssClass="table table-primary" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Viaje N°" DataField="NumViaje" />

                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate>
                            <%# ((DateTime)Eval("FechaHoraViaje")).ToString("yyyy-MM-dd") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Hora">
                        <ItemTemplate>
                            <%# ((DateTime)Eval("FechaHoraViaje")).ToString("HH:mm") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Chofer">
                        <ItemTemplate>
                            <%# Eval("ChoferViaje") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cliente">
                        <ItemTemplate>
                            <%# Eval("ClienteViaje")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tipo Viaje">
                        <ItemTemplate>
                            <%# Eval("TipoViaje")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Importe" DataField="Importe" DataFormatString="{0:F0}" />

                    <asp:BoundField HeaderText="Pagado" DataField="Pagado" />

                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <%# Eval("Estado")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Accion">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnModificar" runat="server" ImageUrl="https://img2.freepng.es/20201210/hcb/transparent-edit-icon-interface-icon-5fd2c0863c4dc9.114206481607647366247.jpg" class="btn btn-close btn-lg border ms-1" CommandName="Modificar" CommandArgument='<%# Eval("NumViaje") %>' ToolTip="Modificar" OnClick="btnModificar_Click" />

                            <asp:ImageButton ID="btnDetalle" runat="server" ImageUrl="https://w7.pngwing.com/pngs/756/956/png-transparent-computer-icons-symbol-hamburger-button-details-miscellaneous-blue-angle-thumbnail.png" class="btn btn-close btn-lg border ms-1" CommandName="Detalle" CommandArgument='<%# Eval("NumViaje") %>' ToolTip="Detalle" OnClick="btnDetalle_Click" />
                            <%-- <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="https://e7.pngegg.com/pngimages/729/952/png-clipart-computer-icons-recycling-bin-waste-others-text-recycling.png" class="btn btn-close btn-lg border ms-1" CommandName="Eliminar" CommandArgument='<%# Eval("NumViaje") %>' ToolTip="Eliminar" OnClick="btnEliminar_Click" />--%>

                            <!-- EVALUA EL ESTADO DEL VIAJE Y ASIGNA EL BOTON CORRESPONDIENTE -->
                            <asp:ImageButton ID="btnNoPagado" ImageUrl="https://us.123rf.com/450wm/igoun/igoun1805/igoun180500088/101280971-icono-de-cruz-en-c%C3%ADrculo-se-puede-utilizar-como-bot%C3%B3n-de-eliminar-bloquear-cerrar-etc-eliminar.jpg" OnClick="btnNoPagado_Click" CommandArgument='<%#Eval("NumViaje")%>' CommandName="NumViaje" runat="server" Text="No Pagado" CssClass="btn btn-close btn-lg border ms-1" ToolTip="No Pagado" Visible='<%# Convert.ToBoolean(Eval("Pagado")) %>' />

                            <asp:ImageButton ID="btnPagado" ImageUrl="https://c0.klipartz.com/pngpicture/605/284/gratis-png-cheque-verde-ogo-iconos-de-la-marca-de-verificacion-marca-verde-thumbnail.png" OnClick="btnPagado_Click" CommandArgument='<%#Eval("NumViaje")%>' CommandName="NumViaje" runat="server" Text="Pagado" CssClass="btn btn-close btn-lg border ms-1" ToolTip="Pagado" Visible='<%# !Convert.ToBoolean(Eval("Pagado"))%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>


        <%-- <div>
            <h5>Viajes del dia</h5>
            <asp:ListBox ID="lbListaViajes" CssClass="list-group list-group-flush" OnSelectedIndexChanged="lbViajesDelDia_SelectedIndexChanged" runat="server"></asp:ListBox>
        </div>--%>



        <div role="group">
            <asp:Button ID="btnAltaViaje" runat="server" Text="Alta viaje" CssClass="btn btn-success" OnClick="btnAltaViaje_Click" />
            <%--<asp:Button ID="btnModificarViaje" run<%--at="server" Text="Modificar viaje" CssClass="btn btn-warning" OnClick="btnModificarViaje_Click" />--%>
            <%--<asp:Button ID="btnBajaViaje" runat="server" Text="Baja viaje" CssClass="btn btn-danger" OnClick="btnBajaViaje_Click" />--%>
            <%--<asp:Button ID="btnDetalleViaje" runat="server" Text="Detalle viaje" CssClass="btn btn-info" OnClick="btnDetalleViaje_Click" />--%>
        </div>

        <div>
            <div>
                <asp:Label ID="lblCalendario" runat="server" Text="BUSQUEDA POR DIA" CssClass="h4 text-center"></asp:Label>
                <asp:Button ID="btnVolverHoy" runat="server" Text="Listar Hoy" OnClick="btnVolverHoy_Click" CssClass="btn btn-primary m-2"/>
            </div>
            <div>
                <asp:Calendar ID="calOtrosDias" runat="server" class="table table-secondary table-striped" OnSelectionChanged="calOtrosDias_SelectionChanged"></asp:Calendar>
            </div>
        </div>

        <div style="font-family: cursive;" role="group">
            <asp:Button ID="btnClientes" runat="server" Text="Clientes" CssClass="btn btn-primary" OnClick="btnEmpresa_Click" />
            <asp:Button ID="btnChoferes" runat="server" Text="Choferes" CssClass="btn btn-info" OnClick="btnChoferes_Click" />
            <asp:Button ID="btnVehiculo" runat="server" Text="Vehiculos" CssClass="btn btn-primary" OnClick="btnVehiculo_Click" />
        </div>

        <!--<div>
            <asp:Label ID="lblAsignarChofer" runat="server" Text="COFER: "></asp:Label>
            <asp:TextBox ID="txtAsignarViaje" runat="server"></asp:TextBox>
            <asp:Button ID="btnAsignarViaje" runat="server" Text="Aceptar" CssClass="btn btn-success"/>
        </div>

        <div>
            <h4>VEHICULOS</h4>
            <table class="table position-relative">
                <thead>
                    <tr>
                        <th scope="col" class="col-1">ID</th>
                        <th scope="col" class="col-1">MODELO</th>
                        <th scope="col" class="col-1">PATENTE</th>
                        <th scope="col" class="col-1">TIPO</th>
                        <th scope="col" class="col-1">PLAZAS</th>
                        <th scope="col" class="col-1">ESTADO</th>
                    </tr>
                </thead>

                <asp:Repeater ID="repVehiculos" runat="server">
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("IDVehiculo")%></td>
                                <td><%#Eval("Modelo")%></td>
                                <td><%#Eval("Patente")%></td>
                                <td><%#Eval("Tipo.NombreTipo")%></td>
                                <td><%#Eval("Tipo.CantAsientos")%></td>
                                <td><%#Eval("Estado")%></td>
                                <td>
                                    <asp:Button ID="btnAsignar" runat="server" Text="Asignar viaje" OnClick="btnAsignar_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>-->
    </div>

</asp:Content>
