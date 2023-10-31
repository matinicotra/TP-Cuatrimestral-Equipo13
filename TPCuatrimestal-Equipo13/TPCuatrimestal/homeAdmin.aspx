<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="homeAdmin.aspx.cs" Inherits="TPCuatrimestal.homeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg" style="display:flex; align-items:center; justify-content:center; flex-direction:column;">
        <div>
            <h5>Listado de viajes del dia</h5>
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        </div>

        <div>
            <h5>ABM Viajes</h5>
            <asp:Button ID="btnAltaViaje" runat="server" Text="Alta" /> <!-- DARLE MUCHAS MAS IMPORTANCIA A ESTE BOTON-->
            <asp:Button ID="btnBajaViaje" runat="server" Text="Baja" />
            <asp:Button ID="btnModificarViaje" runat="server" Text="Modificar" />
        </div>

        <div>
            <h5>Detalles del viaje</h5>
            <asp:Button ID="Button1" runat="server" Text="Detalle viaje" />
        </div>

        <div>
            <h5>Filtrado por distintos criterios</h5>
            <asp:TextBox ID="txtFiltrar" runat="server"></asp:TextBox>
            <asp:Button ID="btnFiltrar" runat="server" Text="Button" />
        </div>

        <div>
            <h5>Opciones de ver otros dias</h5>
            <asp:Calendar ID="calOtrosDias" runat="server"></asp:Calendar>
        </div>

        <div>
            <h5>asignar viaje a chofer y compartir datos de viaje</h5>
        </div>

        <div>
            <asp:Button ID="btnEmpresa" runat="server" Text="Empresa" />
            <asp:Button ID="btnClientes" runat="server" Text="Clientes" />
            <asp:Button ID="btnChoferes" runat="server" Text="Choferes" />
        </div>
    </div>

</asp:Content>
