<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="altaModificacionViaje.aspx.cs" Inherits="TPCuatrimestal.altaModificacionViaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="display: flex; align-items: center; justify-content: center; flex-direction: column; grid-row-gap: 10px; margin: 50px 50px;">

        <div class="contenedor">

            <h4 class="text-lg-center">VIAJE</h4>

            <h5 class="text-lg-center">DATOS CLIENTE</h5>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblSinCliente" runat="server" Font-Bold="false">OMITIR CLIENTE</asp:Label>
                <asp:CheckBox ID="cbxSinCliente" runat="server" />
                <!-- SI ESTÁ TRUE DESHABILITAR TODA LA SECCION CLIENTE O DEJAR SOLO NOMBRE -->
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblEmpresa" runat="server" Font-Bold="false">¿ES EMPRESA?</asp:Label>
                <asp:CheckBox CssClass="form-check-input" ID="cbxEmpresa" runat="server" />
                <!-- SI ESTÁ TRUE DESHABILITAR NOMBRE DE EMPRESA -->
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblNombreEmpresa" runat="server" Font-Bold="false">NOMBRE EMPRESA</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtNombreEmpresa" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblNombreApellido" runat="server" Font-Bold="false">NOMBRE Y APELLIDO PASAJERO/A</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtNombreApellido" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblTelefonoCliente" runat="server" Font-Bold="false">TELEFONO CLIENTE</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtTelefonoCliente" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblFormaDePago" runat="server" Font-Bold="false">FORMA DE PAGO</asp:Label>
                <asp:RadioButtonList CssClass="table" ID="RadioButtonList1" runat="server">
                    <asp:ListItem Text="No Especifica" Value="1" />
                    <asp:ListItem Text="Efectivo" Value="2" Selected="True" />
                    <asp:ListItem Text="Debito" Value="3" />
                    <asp:ListItem Text="Credito" Value="4" />
                    <asp:ListItem Text="Mercado Pago" Value="5" />
                    <asp:ListItem Text="Cuenta Corriente" Value="6" />
                </asp:RadioButtonList>
            </div>

            <h5 class="text-lg-cent">DOMICILIO ORIGEN</h5>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblCalleOrigen" runat="server" Font-Bold="false">CALLE</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtCalleOrigen" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblAlturaOrigen" runat="server" Font-Bold="false">ALTURA</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtAlturaOrigen" runat="server"></asp:TextBox>
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

            <div class="input-group mb-3">
                <asp:Button ID="btnAgregarDestino" runat="server" Text="Agregar Destino" CssClass="btn btn-primary" />
                <asp:Button ID="btnQuitarDestino" runat="server" Text="Quitar Destino" CssClass="btn btn-secondary" />
            </div>

            <h5 class="text-lg-center">CHOFER</h5>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="Label1" runat="server" Font-Bold="false">ASIGNAR DESPUES</asp:Label>
                <asp:CheckBox ID="cbxAsignarDespues" runat="server" Checked="true" />
                <!-- SI ESTÁ TRUE DESHABILITAR TODA LA SECCION CHOFER -->
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblNombreChofer" runat="server" Font-Bold="false">NOMBRE</asp:Label>
                <asp:TextBox CssClass="form-control" ID="txtNombreChofer" runat="server"></asp:TextBox>
            </div>

            <div class="text-center">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" />
                <asp:Button ID="btnCanelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCanelar_Click" />
            </div>

        </div>

    </div>

</asp:Content>
