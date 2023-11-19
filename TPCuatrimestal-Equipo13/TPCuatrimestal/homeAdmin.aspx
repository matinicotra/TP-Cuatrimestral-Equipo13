<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="homeAdmin.aspx.cs" Inherits="TPCuatrimestal.homeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="display: flex; align-items: center; justify-content: center; flex-direction: column; grid-row-gap: 30px; margin-top: 50px; margin-bottom: 150px;">

        <div CssClass="input-group" style="display:flex; ">
            <asp:TextBox ID="txtFiltrar" runat="server" CssClass="form-control" PlaceHolder="Busqueda..."></asp:TextBox>
            <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" CssClass="btn btn-primary ms-2" />
        </div>

        <div style="display: flex; flex-direction: row;">
            <h5>Viajes del dia</h5>
            <asp:ListBox ID="lbViajesDelDia" runat="server"></asp:ListBox>
        </div>

        <div role="group">
            <asp:Button ID="btnAltaViaje" runat="server" Text="Alta viaje" CssClass="btn btn-success" OnClick="btnAltaViaje_Click" />
            <asp:Button ID="btnModificarViaje" runat="server" Text="Modificar viaje" CssClass="btn btn-warning" OnClick="btnModificarViaje_Click" />
            <asp:Button ID="btnBajaViaje" runat="server" Text="Baja viaje" CssClass="btn btn-danger" OnClick="btnBajaViaje_Click" />
            <asp:Button ID="btnDetalleViaje" runat="server" Text="Detalle viaje" CssClass="btn btn-info" OnClick="btnDetalleViaje_Click" />
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
