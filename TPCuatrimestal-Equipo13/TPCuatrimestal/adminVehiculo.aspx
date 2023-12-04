<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="adminVehiculo.aspx.cs" Inherits="TPCuatrimestal.adminVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="background-color:aliceblue; display:flex; align-items:center; justify-content:center; flex-direction:column; margin-bottom: 100px;">

        <div>
            <h4>ADMINISTRAR VEHICULOS</h4>
            <div class="input-group mb-3" style="display: flex; align-items: center; flex-direction: row;">
                <asp:TextBox ID="txtFiltrar" runat="server" CssClass="form-control" PlaceHolder="Busqueda..."></asp:TextBox>
                <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" CssClass="btn btn-primary" />
                <asp:CheckBox CssClass="ms-4" ID="chbMostrarInactivos" runat="server" AutoPostBack="true" OnCheckedChanged="chbMostrarInactivos_CheckedChanged" />
                <asp:Label CssClass="ms-1" ID="lblMostrarInactivos" runat="server" Text="Mostrar Inactivos"></asp:Label>
            </div>
        </div>

        <div id="div1">
            <table class="table position-relative shadow" border="1" style="overflow: scroll; background-color: lightgray;">
                <thead>
                    <tr>
                        <th scope="col" class="col-1 text-md-center">NUMERO</th>
                        <th scope="col" class="col-1 text-md-center">MODELO</th>
                        <th scope="col" class="col-1 text-md-center">PATENTE</th>
                        <th scope="col" class="col-1 text-md-center">TIPO</th>
                        <th scope="col" class="col-1 text-md-center">PLAZAS</th>
                        <th scope="col" class="col-6 text-md-center">ACCIONES</th>
                    </tr>
                </thead>

                <asp:Repeater ID="repVehiculos" runat="server">
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td class="text-md-center"><%#Eval("IDVehiculo")%></td>
                                <td class="text-md-center"><%#Eval("Modelo")%></td>
                                <td class="text-md-center"><%#Eval("Patente")%></td>
                                <td class="text-md-center"><%#Eval("Tipo.NombreTipo")%></td>
                                <td class="text-md-center"><%#Eval("Tipo.CantAsientos")%></td>
                                <!--<td><%#Eval("Estado")%></td>-->
                                <td>
                                    <asp:ImageButton ID="btnEliminar" ImageUrl="https://e7.pngegg.com/pngimages/729/952/png-clipart-computer-icons-recycling-bin-waste-others-text-recycling.png" runat="server" class="btn btn-close btn-lg border ms-1" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("IDVehiculo")%>' CommandName="IDVehiculo" ToolTip="Eliminar" />
                                    <asp:ImageButton ID="ImageButton1" ImageUrl="https://img2.freepng.es/20201210/hcb/transparent-edit-icon-interface-icon-5fd2c0863c4dc9.114206481607647366247.jpg" OnClick="ImageButton1_Click" CommandArgument='<%#Eval("IDVehiculo")%>' CommandName="IDVehiculo" runat="server" class="btn btn-close btn-lg border ms-1" ToolTip="Modificar" />

                                    <!-- EVALUA EL ESTADO DEL VEHICULO Y ASIGNA EL BOTON CORRESPONDIENTE -->
                                    <asp:ImageButton ID="btnBajaLogica" ImageUrl="https://us.123rf.com/450wm/igoun/igoun1805/igoun180500088/101280971-icono-de-cruz-en-c%C3%ADrculo-se-puede-utilizar-como-bot%C3%B3n-de-eliminar-bloquear-cerrar-etc-eliminar.jpg" OnClick="btnBajaLogica_Click" CommandArgument='<%#Eval("IDVehiculo")%>' CommandName="IDVehiculo" runat="server" Text="Desactivar" CssClass="btn btn-close btn-lg border ms-1" ToolTip="Desactivar" Visible='<%# Convert.ToBoolean(Eval("Estado")) %>' />

                                    <asp:ImageButton ID="btnAltaLogica" ImageUrl="https://c0.klipartz.com/pngpicture/605/284/gratis-png-cheque-verde-ogo-iconos-de-la-marca-de-verificacion-marca-verde-thumbnail.png" OnClick="btnAltaLogica_Click" CommandArgument='<%#Eval("IDVehiculo")%>' CommandName="IDVehiculo" runat="server" Text="Activar" CssClass="btn btn-close btn-lg border ms-1" ToolTip="Activar" Visible='<%# !Convert.ToBoolean(Eval("Estado")) %>' />

                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="text-center">
            <asp:Button ID="btnAgregarVehiculo" runat="server" Text="Agregar vehiculo" CssClass="btn btn-primary" OnClick="btnAgregarVehiculo_Click" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
        </div>
    </div>

    <hr />
</asp:Content>
