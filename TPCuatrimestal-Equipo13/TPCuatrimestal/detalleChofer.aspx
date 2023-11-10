<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="detalleChofer.aspx.cs" Inherits="TPCuatrimestal.detalleChofer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="display: flex; align-items: center; justify-content: center; flex-direction: column; gap: 20px; margin: 40px 40px;">

        <div>
            <asp:Label ID="lblTituloChofer" runat="server" Text=""></asp:Label>
        </div>

        <div>
            <h5>Ordenar y filtrar por distintos criterios</h5>
            <asp:TextBox ID="txtFiltrar" runat="server"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <!-- AGREGAR LOS CRITERIOS DE ORDEN-->
            <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" />
        </div>

        <div>
            <h5 class="text-sm-center">Listado de viajes del Chofer</h5>
            <asp:ListBox ID="listaViajesPorChofer" runat="server"></asp:ListBox>
        </div>

        <!--<div>
            <h5>Asignar viaje al Chofer</h5>
        </div>
        <div>
            <asp:Button ID="btnAsignarViaje" runat="server" Text="AsignarViaje" />
        </div>-->

        <div>
            <h5 class="text-sm-center">Gestionar Viaje Seleccionado</h5>
            <asp:Button CssClass="btn btn-success" ID="btnAltaViaje" runat="server" Text="Alta" />
            <asp:Button CssClass="btn btn-danger" ID="btnBajaViaje" runat="server" Text="Baja" />
            <asp:Button CssClass="btn btn-warning" ID="btnModificarViaje" runat="server" Text="Modificar" />
            <asp:Button CssClass="btn btn-info" ID="btnDetalleViaje" runat="server" Text="Detalles viaje" OnClick="btnDetalleViaje_Click" />
        </div>

        <div>
            <h5>Opciones de ver otros dias</h5>
            <asp:Calendar ID="verDiaChofer" runat="server"></asp:Calendar>
        </div>

        <div>
            <h5 class="text-sm-center">Resumenes del Chofer</h5>
            <asp:Button CssClass="btn btn-info" ID="btnResumenAnioChofer" runat="server" Text="Por Anio" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenMesChofer" runat="server" Text="Por Mes" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenTotalChofer" runat="server" Text="Total" />
        </div>
    </div>
</asp:Content>
