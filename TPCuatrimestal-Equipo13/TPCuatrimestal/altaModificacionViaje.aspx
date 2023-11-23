<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="altaModificacionViaje.aspx.cs" Inherits="TPCuatrimestal.altaModificacionViaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="background-color: darkseagreen; display: flex; align-items: center; justify-content: center; flex-direction: column; grid-row-gap: 10px; margin: 50px 50px;">

        <div class="contenedor" style="margin-bottom: 100px;">

            <h4 class="text-lg-center">VIAJE</h4>

            <h5 class="text-lg-center">DATOS CLIENTE</h5>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblSinCliente" runat="server" Font-Bold="false">OMITIR CLIENTE</asp:Label>
                <asp:CheckBox ID="cbxSinCliente" runat="server" CssClass="m-2" />
                <!-- SI ESTÁ TRUE DESHABILITAR TODA LA SECCION CLIENTE O DEJAR SOLO NOMBRE -->
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblNombre" runat="server" Font-Bold="false">NOMBRE</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblApellido" runat="server" Font-Bold="false">APELLIDO</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtApellido" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblTelefonoCliente" runat="server" Font-Bold="false">TELEFONO CLIENTE</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtTelefonoCliente" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3 d-block">
                <div cssclass="input-group-prepend">
                    <asp:Label CssClass="input-group-text" ID="lblFormaDePago" runat="server" Font-Bold="false">FORMA DE PAGO</asp:Label>
                </div>
                <div cssclass="form-check form-check-inline mx-1 d-flex">
                    <asp:RadioButtonList CssClass="" ID="RadioButtonList1" runat="server">
                            <asp:ListItem CssClass="form-check-input" Text="No Especifica" Value="1" Selected="True" />
                            <asp:ListItem CssClass="form-check-input" Text="Efectivo" Value="2" />
                            <asp:ListItem CssClass="form-check-input" Text="Debito" Value="3" />
                            <asp:ListItem CssClass="form-check-input" Text="Credito" Value="4" />
                            <asp:ListItem CssClass="form-check-input" Text="Mercado Pago" Value="5" />
                            <asp:ListItem CssClass="form-check-input" Text="Cuenta Corriente" Value="6" />
                    </asp:RadioButtonList>
                </div>
            </div>

            <h5 class="text-lg-cent">DOMICILIO ORIGEN</h5>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblCalleOrigen" runat="server" Font-Bold="false">DIRECCION</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtCalleOrigen" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblLocalidadOrigen" runat="server" Font-Bold="false">LOCALIDAD</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtLocalidadOrigen" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblProvinciaOrigen" runat="server" Font-Bold="false">PROVINCIA</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtProvinciaOrigen" runat="server"></asp:TextBox>
            </div>

            <h5 class="text-lg-center">DOMICILIO DESTINO</h5>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblCalleDestino1" runat="server" Font-Bold="false">CALLE</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtCalleDestino1" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblAlturaDestino1" runat="server" Font-Bold="false">ALTURA</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtAlturaDestino1" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblLocalidadDestino1" runat="server" Font-Bold="false">LOCALIDAD</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtLocalidadDestino1" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblProvinciaDestino1" runat="server" Font-Bold="false">PROVINCIA</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtProvinciaDestino1" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Button ID="btnAgregarDestino" runat="server" Text="Agregar Destino" CssClass="btn btn-primary" />
                <asp:Button ID="btnQuitarDestino" runat="server" Text="Quitar Destino" CssClass="btn btn-danger" />
            </div>

            <h5 class="text-lg-center">CHOFER</h5>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblAsignarDespues" runat="server" Font-Bold="false">ASIGNAR DESPUES</asp:Label>
                <asp:CheckBox ID="cbxAsignarDespues" runat="server" Checked="true" CssClass="m-2"/>
                <!-- SI ESTÁ TRUE DESHABILITAR TODA LA SECCION CHOFER -->
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblNombreChofer" runat="server" Font-Bold="false">CHOFER</asp:Label>
                <%--<asp:TextBox CssClass="form-control" ID="txtNombreChofer" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="ddlChoferes" runat="server"></asp:DropDownList>
            </div>

            <div class="text-center">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" />
                <asp:Button ID="btnCanelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCanelar_Click" />
            </div>

            <br />

        </div>

    </div>

</asp:Content>
