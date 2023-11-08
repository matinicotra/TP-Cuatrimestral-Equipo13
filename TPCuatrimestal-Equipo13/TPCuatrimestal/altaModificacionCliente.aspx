<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="altaModificacionCliente.aspx.cs" Inherits="TPCuatrimestal.altaModificacionCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-lg" style="display: flex; align-items: center; justify-content: center; flex-direction: column; grid-row-gap: 10px; margin: 50px 50px;">

        <div>
            <h5 class="text-lg-center">DATOS PERSONALES</h5>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblNombre" runat="server" Font-Bold="false">NOMBRE</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblApellido" runat="server" Font-Bold="false">APELLIDO</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtApellido" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblDNI" runat="server" Font-Bold="false">DOCUMENTO</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtDNI" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblNacionalidad" runat="server" Font-Bold="false">NACIONALIDAD</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtNacionalidad" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblFechaNacimiento" runat="server" Font-Bold="false">FECHA DE NACIMIENTO</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtFechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
            </div>

            <h5 class="text-lg-center">DATOS DE DOMICILIO</h5>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblCalle" runat="server" Font-Bold="false">CALLE</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtCalle" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblAltura" runat="server" Font-Bold="false">ALTURA</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtAltura" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblCodPostal" runat="server" Font-Bold="false">CODIGO POSTAL</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtCodPostal" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblLocalidad" runat="server" Font-Bold="false">LOCALIDAD</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtLocalidad" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblProvincia" runat="server" Font-Bold="false">PROVINCIA</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtProvincia" runat="server"></asp:TextBox>
            </div>

            <h5 class="text-lg-center">DATOS DE CONTACTO</h5>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblZona" runat="server" Font-Bold="false">ZONA</asp:Label>
                <asp:DropDownList CssClass="form-control" ID="ddlZona" runat="server"></asp:DropDownList>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblTelefono" runat="server" Font-Bold="false">TELEFONO</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtTelefono" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblEmail" runat="server" Font-Bold="false">EMAIL</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"></asp:TextBox>
            </div>

            <div class="text-center">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" />
                <asp:Button ID="btnCanelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCanelar_Click" />
            </div>

        </div>


    </div>

</asp:Content>
