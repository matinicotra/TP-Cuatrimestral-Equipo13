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
            <asp:Button CssClass="btn btn-info" ID="btnDetalleViaje" runat="server" Text="Detalles viaje" OnClick="btnDetalleViaje_Click" />
        </div>

        <div>
            <h5 class="text-sm-center">Resumen del Chofer</h5>
            <asp:Button CssClass="btn btn-info" ID="btnResumenAnioChofer" runat="server" Text="Semanal" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenMesChofer" runat="server" Text="Quincenal" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenTotalChofer" runat="server" Text="Mensual" />
        </div>
    </div>
</asp:Content>
