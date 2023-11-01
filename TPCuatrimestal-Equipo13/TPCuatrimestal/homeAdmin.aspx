<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="homeAdmin.aspx.cs" Inherits="TPCuatrimestal.homeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-lg" style="display:flex; align-items:center; justify-content:center; flex-direction:column; grid-row-gap:30px; margin-top:50px;">
        <div style="display:flex; flex-direction:row;">
            <h5>Viajes del dia</h5>
            <asp:ListBox ID="lbViajesDelDia" runat="server"></asp:ListBox>
        </div>


        <div class="btn-group" role="group">
            <asp:Button ID="btnAltaViaje" runat="server" Text="Alta viaje" CssClass="btn btn-success"/> <!-- DARLE MUCHAS MAS IMPORTANCIA A ESTE BOTON-->
            <asp:Button ID="btnBajaViaje" runat="server" Text="Baja viaje" CssClass="btn btn-danger"/>
            <asp:Button ID="btnModificarViaje" runat="server" Text="Modificar viaje" CssClass="btn btn-warning"/>
            <asp:Button ID="btnDetalleViaje" runat="server" Text="Detalle viaje" CssClass="btn btn-info"/>
        </div>


        <div>
            <asp:TextBox ID="txtFiltrar" runat="server"></asp:TextBox>
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-secondary"/>
        </div>

        <div>
            <h5>Opciones de ver otros dias</h5>
            <asp:Calendar ID="calOtrosDias" runat="server"></asp:Calendar>
        </div>

        <div>
            <asp:Button ID="btnAsignarViaje" runat="server" Text="Asignar viaje" CssClass="btn btn-success"/>
        </div>

        <div class="btn-group" role="group">
            <asp:Button ID="btnEmpresa" runat="server" Text="Empresa" CssClass="btn btn-primary"/>
            <asp:Button ID="btnClientes" runat="server" Text="Clientes" CssClass="btn btn-primary"/>
            <asp:Button ID="btnChoferes" runat="server" Text="Choferes" CssClass="btn btn-primary"/>
        </div>
    </div>

</asp:Content>
