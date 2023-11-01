<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="altaModificacionChofer.aspx.cs" Inherits="TPCuatrimestal.altaModificacionChofer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h5 class="text-lg-center" style="color: orangered">DATOS PERSONALES</h5>
        <table class="table">
            <tbody>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblNombre" runat="server" Font-Bold="false">NOMBRE</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtNombre" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblApellido" runat="server" Font-Bold="false">APELLIDO</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtApellido" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblDNI" runat="server" Font-Bold="false">DOCUMENTO</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtDNI" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblNacionalidad" runat="server" Font-Bold="false">NACIONALIDAD</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtNacionalidad" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblFechaNacimiento" runat="server" Font-Bold="false">FECHA DE NACIMIENTO</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtFechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
                    </th>
                </tr>

            </tbody>
        </table>
    </div>
    <div>
        <h5 class="text-lg-center" style="color: orangered">DATOS DE DOMICILIO</h5>
        <table class="table">
            <tbody>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblCalle" runat="server" Font-Bold="false">NOMBRE DE CALLE</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtCalle" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblAltura" runat="server" Font-Bold="false">ALTURA DE CALLE</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtAltura" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblCodPostal" runat="server" Font-Bold="false">CODIGO POSTAL</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtCodPostal" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblLocalidad" runat="server" Font-Bold="false">LOCALIDAD</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtLocalidad" runat="server"></asp:TextBox>
                    </th>
                </tr>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblProvincia" runat="server" Font-Bold="false">PROVINCIA</asp:Label>
                        <asp:TextBox CssClass="col-2" ID="txtProvincia" runat="server"></asp:TextBox>
                    </th>
                </tr>

            </tbody>
        </table>

    </div>

    <div>
        <h5 class="text-lg-center" style="color: orangered">DATOS ASIGNADOS</h5>
        <table class="table">
            <tbody>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblZona" runat="server" Font-Bold="false">ZONA</asp:Label>
                        <asp:DropDownList CssClass="col-2" ID="ddlZona" runat="server"></asp:DropDownList>
                    </th>
                </tr>
                <tr>
                    <th class="text-xl-center">
                        <asp:Label CssClass="col-2" ID="lblAutoAsignado" runat="server" Font-Bold="false">AUTO</asp:Label>
                        <asp:DropDownList CssClass="col-2" ID="ddlAutoAsignado" runat="server"></asp:DropDownList>
                    </th>
                </tr>
            </tbody>
        </table>

    </div>


    <div class="text-center">
        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" />
        <asp:Button ID="btnCanelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />
    </div>
    <hr />

</asp:Content>
