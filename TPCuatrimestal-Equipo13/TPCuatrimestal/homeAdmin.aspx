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
            <h5>Viajes con grid view</h5>
            <asp:GridView ID="dgvViajes" DataKeyNames="NumViaje" OnSelectedIndexChanged="dgvViajes_SelectedIndexChanged" AutoGenerateColumns="false" CssClass="table table-primary" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Viaje N°" DataField="NumViaje" />

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

                    <asp:BoundField HeaderText="Importe" DataField="Importe" DataFormatString="{0:F2}" />
                    <asp:BoundField HeaderText="Pagado" DataField="Pagado" />
                    <asp:TemplateField HeaderText="Accion">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnModificar" runat="server" ImageUrl="https://img2.freepng.es/20201210/hcb/transparent-edit-icon-interface-icon-5fd2c0863c4dc9.114206481607647366247.jpg" class="btn btn-close btn-lg border ms-1" CommandName="Modificar" CommandArgument='<%# Eval("NumViaje") %>' ToolTip="Modificar" OnClick="btnModificar_Click" />
                            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="https://e7.pngegg.com/pngimages/729/952/png-clipart-computer-icons-recycling-bin-waste-others-text-recycling.png" class="btn btn-close btn-lg border ms-1" CommandName="Eliminar" CommandArgument='<%# Eval("NumViaje") %>' ToolTip="Eliminar" OnClick="btnEliminar_Click" />

                            <!-- EVALUA EL ESTADO DEL VIAJE Y ASIGNA EL BOTON CORRESPONDIENTE -->
                            <asp:ImageButton ID="btnNoPagado" ImageUrl="https://us.123rf.com/450wm/igoun/igoun1805/igoun180500088/101280971-icono-de-cruz-en-c%C3%ADrculo-se-puede-utilizar-como-bot%C3%B3n-de-eliminar-bloquear-cerrar-etc-eliminar.jpg" OnClick="btnNoPagado_Click" CommandArgument='<%#Eval("NumViaje")%>' CommandName="NumViaje" runat="server" Text="No Pagado" CssClass="btn btn-close btn-lg border ms-1" ToolTip="No Pagado" Visible='<%# Convert.ToBoolean(Eval("Pagado")) %>' />

                            <asp:ImageButton ID="btnPagado" ImageUrl="https://c0.klipartz.com/pngpicture/605/284/gratis-png-cheque-verde-ogo-iconos-de-la-marca-de-verificacion-marca-verde-thumbnail.png" OnClick="btnPagado_Click" CommandArgument='<%#Eval("NumViaje")%>' CommandName="NumViaje" runat="server" Text="Pagado" CssClass="btn btn-close btn-lg border ms-1" ToolTip="Pagado" Visible='<%# !Convert.ToBoolean(Eval("Pagado")) %>' />
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
            <h5>BUSQUEDA POR DIA</h5>
            <asp:Calendar ID="calOtrosDias" runat="server" class="table table-secondary table-striped"></asp:Calendar>
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
