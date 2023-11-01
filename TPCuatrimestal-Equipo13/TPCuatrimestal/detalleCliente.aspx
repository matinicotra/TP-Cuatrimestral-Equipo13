<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="detalleCliente.aspx.cs" Inherits="TPCuatrimestal.detalleEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg" style="display: flex; align-items: center; justify-content: center; flex-direction: column;">
        <div>
            <h1>NOMBRE DEL CLIENTE</h1>
        </div>

        <div>
            <h5>Ordenar y filtrar por distintos criterios</h5>
            <asp:TextBox ID="txtFiltrar" runat="server"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <!-- AGREGAR LOS CRITERIOS DE ORDEN-->
            <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" />
        </div>

        <div>
            <h5>Listado de viajes del Cliente</h5>
            <asp:ListBox ID="listaViajesPorCliente" runat="server"></asp:ListBox>
        </div>

        <div>
            <h5>Detalles del viaje</h5>
            <asp:Button ID="btnDetalleViaje" runat="server" Text="Detalles viaje" OnClick="btnDetalleViaje_Click" />
        </div>

        <div>
            <h5>ABM Empresa</h5>
            <asp:Button ID="btnBajaCliente" runat="server" Text="Eliminar Cliente" />
            <asp:Button ID="btnModificarViaje" runat="server" Text="Modificar" OnClick="btnModificarViaje_Click" />
        </div>

        <div>
            <h5>Opciones de ver otros dias</h5>
            <asp:Calendar ID="verDiaCliente" runat="server"></asp:Calendar>
        </div>

        <div>
            <h5>Resumenes del Cliente</h5>
            <asp:Button ID="btnResumenAnioCliente" runat="server" Text="Por Anio" />
            <asp:Button ID="btnResumenMesCliente" runat="server" Text="Por Mes" />
            <asp:Button ID="btnResumenTotalCliente" runat="server" Text="Total" />
        </div>
    </div>
</asp:Content>
