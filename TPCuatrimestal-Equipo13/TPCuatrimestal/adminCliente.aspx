<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="adminCliente.aspx.cs" Inherits="TPCuatrimestal.adminEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg" style="display:flex; align-items:center; justify-content:center; flex-direction:column;">
        <div>
            <h1>ADMINISTRACION CLIENTES</h1>
        </div>
        <div>
            <h5>Filtrado por distintos criterios</h5>
            <asp:TextBox ID="txtFiltrar" runat="server"></asp:TextBox>
            <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" />
        </div>
      
        <div>
            <h5>Listado de Clientes</h5> 
            <asp:ListBox ID="listaClientes" runat="server"></asp:ListBox> <!-- DEBERIA SER UN DATA GRID VIEW ? -->
        </div>

        <div>
            <h5>ABM Clientes</h5>
            <asp:Button ID="btnAltaCliente" runat="server" Text="Alta" />
            <asp:Button ID="btnBajaCliente" runat="server" Text="Baja" />
            <asp:Button ID="btnModificarCliente" runat="server" Text="Modificar" />
        </div>

        <div>
            <h5>Detalles del Cliente Seleccionado</h5>
            <asp:Button ID="btnDetalleCliente" runat="server" Text="Detalle Cliente" />
        </div>

    </div>
</asp:Content>
