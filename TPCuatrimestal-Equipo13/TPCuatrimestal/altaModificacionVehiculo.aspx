<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="altaModificacionVehiculo.aspx.cs" Inherits="TPCuatrimestal.altaModificacionVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <h5 class="text-lg-center" style="color: orangered">DATOS VEHICULO</h5>
        <table class="table">
            <tbody>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblTipoVehiculo" runat="server" Font-Bold="false">TIPO VEHICULO</asp:Label>
                        <asp:DropDownList CssClass="col-2" ID="ddlTipoVehiculo" runat="server"></asp:DropDownList>
                    </th>
                </tr>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblPatente" runat="server" Font-Bold="false">PATENTE</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtPatente" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblModelo" runat="server" Font-Bold="false">MODELO</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtModelo" MaxLength="4" runat="server" onkeypress="return event.charCode >= 48 && event.charCode <= 57"></asp:TextBox>
                    </th>
                </tr>
            </tbody>
        </table>
    </div>

    <div class="text-center">
        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
        <asp:Button ID="btnCanelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCanelar_Click"/>
    </div>
    <hr />
</asp:Content>
