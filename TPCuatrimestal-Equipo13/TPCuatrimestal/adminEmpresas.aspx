<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="adminEmpresas.aspx.cs" Inherits="TPCuatrimestal.adminEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg" style="display:flex; align-items:center; justify-content:center; flex-direction:column;">
        <div>
            <h5>Filtrado por distintos criterios</h5>
            <asp:TextBox ID="txtFiltrar" runat="server"></asp:TextBox>
            <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" />
        </div>
      
        <div>
            <h5>Listado de Empresas</h5> 
            <asp:ListBox ID="listaEmpresas" runat="server"></asp:ListBox> <!-- DEBERIA SER UN DATA GRID VIEW ? -->
        </div>

        <div>
            <h5>ABM Empresas</h5>
            <asp:Button ID="btnAltaEmpresa" runat="server" Text="Alta" />
            <asp:Button ID="btnBajaEmpresa" runat="server" Text="Baja" />
            <asp:Button ID="btnModificarEmpresa" runat="server" Text="Modificar" />
        </div>

        <div>
            <h5>Detalles de la Empresa</h5>
            <asp:Button ID="btnDetalleEmpresa" runat="server" Text="Detalle Empresa" />
        </div>

    </div>
</asp:Content>
