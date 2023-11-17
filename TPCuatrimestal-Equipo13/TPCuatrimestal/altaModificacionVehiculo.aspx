<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="altaModificacionVehiculo.aspx.cs" Inherits="TPCuatrimestal.altaModificacionVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-lg" style="display: flex; align-items: center; justify-content: center; flex-direction: column; grid-row-gap: 10px; margin: 50px 50px;">

        <div class="contenedor" style="margin-bottom: 100px;">
            <h4 class="text-lg-center">DATOS VEHICULO</h4>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblTipoVehiculo" runat="server" Font-Bold="false">TIPO VEHICULO</asp:Label>
                <asp:DropDownList CssClass="form-control" ID="ddlTipoVehiculo" runat="server"></asp:DropDownList>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblPatente" runat="server" Font-Bold="false">PATENTE</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtPatente" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblModelo" runat="server" Font-Bold="false">MODELO</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtModelo" MaxLength="4" runat="server" onkeypress="return event.charCode >= 48 && event.charCode <= 57"></asp:TextBox>
            </div>

            <div class="text-center">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnCanelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCanelar_Click" />
            </div>

        </div>

    </div>

</asp:Content>
