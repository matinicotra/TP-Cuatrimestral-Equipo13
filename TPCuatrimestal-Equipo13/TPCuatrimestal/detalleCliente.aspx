<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="detalleCliente.aspx.cs" Inherits="TPCuatrimestal.detalleEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg" style="display: flex; align-items: center; justify-content: center; flex-direction: column; gap: 20px;">
        <div>
            <asp:Label ID="lblNombreTitulo" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblTelefonoTitulo" runat="server" Text=""></asp:Label>
        </div>

        <div>
            <h5>Listado de viajes</h5>
            <asp:ListBox ID="listaViajesPorCliente" runat="server"></asp:ListBox>
        </div>

        <div>
            <asp:Button CssClass="btn btn-info" ID="btnDetalleViaje" runat="server" Text="Detalles viaje" OnClick="btnDetalleViaje_Click" />
        </div>

        <div>
            <h5 class="text-sm-center">Resumen del Cliente</h5>
            <asp:Button CssClass="btn btn-info" ID="btnResumenSemanalCliente" runat="server" Text="Semanal" OnClick="btnResumenSemanalCliente_Click" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenQuincenalCliente" runat="server" Text="Quincenal" OnClick="btnResumenQuincenalCliente_Click" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenMensualCliente" runat="server" Text="Mensual" OnClick="btnResumenMensualCliente_Click"/>
        </div>
        <div>
            <h6>DATOS CLIENTE</h6>
        </div>
        <div>
            <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblApellido" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblTelefono" runat="server" Text="Sin Telefono"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblEmail" runat="server" Text="Sin Email"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblCalle" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblLocalidad" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblProvincia" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblZona" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
