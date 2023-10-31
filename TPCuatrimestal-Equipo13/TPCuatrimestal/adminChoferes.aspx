<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="adminChoferes.aspx.cs" Inherits="TPCuatrimestal.choferes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg" style="display:flex; align-items:center; justify-content:center; flex-direction:column;">
        <div>
             <h1>ADMINISTRACION CHOFERES</h1>
        </div>
        <div>
            <h5>Filtrado por distintos criterios</h5>
            <asp:TextBox ID="txtFiltrar" runat="server"></asp:TextBox>
            <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" />
        </div>
      
        <div>
            <h5>Listado de Choferes</h5> 
            <asp:ListBox ID="listaChoferes" runat="server"></asp:ListBox> <!-- DEBERIA SER UN DATA GRID VIEW ? -->
        </div>

        <div>
            <h5>ABM Choferes</h5>
            <asp:Button ID="btnAltaChofer" runat="server" Text="Alta" />
            <asp:Button ID="btnBajaChofer" runat="server" Text="Baja" />
            <asp:Button ID="btnModificarChofer" runat="server" Text="Modificar" />
        </div>

        <div>
            <h5>Detalles del Chofer Seleccionado</h5>
            <asp:Button ID="btnDetalleChofer" runat="server" Text="Detalle Chofer" />
        </div>

    </div>
</asp:Content>
