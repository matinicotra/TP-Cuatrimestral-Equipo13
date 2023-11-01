<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="altaModificacionViaje.aspx.cs" Inherits="TPCuatrimestal.altaModificacionViaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
             <h1 class="text-lg-center" style="color: darkred">VIAJE</h1>
        <div>
            <h5 class="text-lg-center" style="color: orangered">DATOS CLIENTE</h5>
            <table class="table">
                <tbody>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblSinCliente" runat="server" Font-Bold="false">OMITIR CLIENTE</asp:Label>
                            <asp:CheckBox ID="cbxSinCliente" runat="server" /> <!-- SI ESTÁ TRUE DESHABILITAR TODA LA SECCION CLIENTE O DEJAR SOLO NOMBRE -->
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblEmpresa" runat="server" Font-Bold="false">¿ES EMPRESA?</asp:Label>
                            <asp:CheckBox ID="cbxEmpresa" runat="server" /> <!-- SI ESTÁ TRUE DESHABILITAR NOMBRE DE EMPRESA -->
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblNombreEmpresa" runat="server" Font-Bold="false">NOMBRE EMPRESA</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtNombreEmpresa" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblNombreApellido" runat="server" Font-Bold="false">NOMBRE Y APELLIDO PASAJERO/A</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtNombreApellido" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblTelefonoCliente" runat="server" Font-Bold="false">TELEFONO CLIENTE</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtTelefonoCliente" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblFormaDePago" runat="server" Font-Bold="false">FORMA DE PAGO</asp:Label>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                  <asp:ListItem Text="Efectivo" Value="1" />
                                  <asp:ListItem Text="Debito" Value="2" />
                                  <asp:ListItem Text="Credito" Value="3" />
                                  <asp:ListItem Text="Mercado Pago" Value="4" />
                                  <asp:ListItem Text="No Especifica" Value="5" />
                            </asp:RadioButtonList>
                        </th>
                    </tr>
                </tbody>
            </table>
        </div>

        <div>
            <h5 class="text-lg-center" style="color: orangered">DOMICILIO ORIGEN</h5>
            <table class="table">
                <tbody>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblCalleOrigen" runat="server" Font-Bold="false">CALLE</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtCalleOrigen" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblAlturaOrigen" runat="server" Font-Bold="false">ALTURA</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtAlturaOrigen" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblLocalidadOrigen" runat="server" Font-Bold="false">LOCALIDAD</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtLocalidadOrigen" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblProvinciaOrigen" runat="server" Font-Bold="false">PROVINCIA</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtProvinciaOrigen" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                </tbody>
            </table>

        </div>

        <div>
            <h5 class="text-lg-center" style="color: orangered">DOMICILIO DESTINO</h5>
            <table class="table">
                <tbody>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblCalleDestino1" runat="server" Font-Bold="false">CALLE</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtCalleDestino1" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblAlturaDestino1" runat="server" Font-Bold="false">ALTURA</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtAlturaDestino1" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblLocalidadDestino1" runat="server" Font-Bold="false">LOCALIDAD</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtLocalidadDestino1" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblProvinciaDestino1" runat="server" Font-Bold="false">PROVINCIA</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtProvinciaDestino1" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr class="text-xl-center">
                        <th>
                            <asp:Button ID="btnAgregarDestino" runat="server" Text="Agregar Destino" CssClass="btn btn-primary" />
                            <asp:Button ID="btnQuitarDestino" runat="server" Text="Quitar Destino" CssClass="btn btn-secondary" />
                        </th>
                    </tr>
                </tbody>
            </table>

        </div>

        <div>
            <h5 class="text-lg-center" style="color: orangered">CHOFER</h5>
            <table class="table">
                <tbody>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="Label1" runat="server" Font-Bold="false">ASIGNAR DESPUES</asp:Label>
                            <asp:CheckBox ID="cbxAsignarDespues" runat="server" Checked="true" /> <!-- SI ESTÁ TRUE DESHABILITAR TODA LA SECCION CHOFER -->
                        </th>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblNombreChofer" runat="server" Font-Bold="false">NOMBRE</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtNombreChofer" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblModeloAuto" runat="server" Font-Bold="false">MODELO DEL AUTO</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtModeloAuto" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblTipoAuto" runat="server" Font-Bold="false">TIPO DE AUTO</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtTipoAuto" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-xl-center">
                            <asp:Label CssClass="col-2" ID="lblTelefonoChofer" runat="server" Font-Bold="false">TELEFONO</asp:Label>
                            <asp:TextBox CssClass="col-2" ID="txtTelefonoChofer" runat="server"></asp:TextBox>
                        </th>
                    </tr>
                </tbody>
            </table>

        </div>


        <div class="text-center">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" />
            <asp:Button ID="btnCanelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" onClick="btnCanelar_Click"/>
        </div>
        <hr />

</div>


</asp:Content>
