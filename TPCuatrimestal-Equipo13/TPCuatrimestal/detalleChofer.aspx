<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="detalleChofer.aspx.cs" Inherits="TPCuatrimestal.detalleChofer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="display: flex; align-items: center; justify-content: center; flex-direction: column; gap: 20px; margin: 40px 40px; margin-bottom: 100px">

        <div>
            <asp:Label ID="lblTituloChofer" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblZona" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblAutoAsignado" runat="server" Text=""></asp:Label>
        </div>

        <div class="input-group mb-3" style="display:flex; align-items:center; flex-direction: row;">
            <asp:TextBox ID="txtFiltrar" runat="server" CssClass="form-control" PlaceHolder="Busqueda..."></asp:TextBox>
            <asp:DropDownList ID="ddlFiltrar" runat="server" CssClass="form-control"></asp:DropDownList>
            <!-- AGREGAR LOS CRITERIOS DE ORDEN-->
            <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary" Text="Buscar" />
        </div>

        <div>
            <h5 class="text-sm-center">VIAJES</h5>
            <asp:ListBox ID="listaViajesPorChofer" runat="server"></asp:ListBox>
        </div>

        <!--<div>
            <h5>Asignar viaje al Chofer</h5>
        </div>
        <div>
            <asp:Button ID="btnAsignarViaje" runat="server" Text="AsignarViaje" />
        </div>-->

        <div>
            <asp:Button CssClass="btn btn-success" ID="btnAltaViaje" runat="server" Text="Alta" />
            <asp:Button CssClass="btn btn-danger" ID="btnBajaViaje" runat="server" Text="Baja" />
            <asp:Button CssClass="btn btn-warning" ID="btnModificarViaje" runat="server" Text="Modificar" />
            <asp:Button CssClass="btn btn-info" ID="btnDetalleViaje" runat="server" Text="Detalles viaje" OnClick="btnDetalleViaje_Click" />
        </div>

        <div>
            <h5>BUSQUEDA POR DIA</h5>
            <asp:Calendar ID="verDiaChofer" runat="server" class="table table-secondary table-striped"></asp:Calendar>
        </div>

        <div>
            <h5 class="text-sm-center">Resumenes del Chofer</h5>
            <asp:Button CssClass="btn btn-info" ID="btnResumenAnioChofer" runat="server" Text="Por Anio" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenMesChofer" runat="server" Text="Por Mes" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenTotalChofer" runat="server" Text="Total" />
        </div>
    </div>
</asp:Content>
