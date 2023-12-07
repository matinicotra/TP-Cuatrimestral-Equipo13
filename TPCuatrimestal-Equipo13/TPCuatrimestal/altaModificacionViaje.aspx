<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="altaModificacionViaje.aspx.cs" Inherits="TPCuatrimestal.altaModificacionViaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="background-color: darkseagreen; display: flex; align-items: center; justify-content: center; flex-direction: column; grid-row-gap: 10px; margin: 50px 50px;">

        <div class="contenedor" style="margin-bottom: 100px;">

            <h4 class="text-center">VIAJE</h4>

            <div class="input-group mb-3">
                <asp:Label ID="lblPagado" runat="server" Text="PAGADO" CssClass="input-group-text"></asp:Label>
                <asp:CheckBox ID="cbxPagado" runat="server" Checked="false" CssClass="input-group-text" />
            </div>

            <div class="input-group mb-3">
                <asp:Label ID="lblEstadoViaje" runat="server" Text="ESTADO" CssClass="input-group-text"></asp:Label>
                <asp:DropDownList ID="ddlEstadoViaje" runat="server">
                    <asp:ListItem Text="Asignado" Value="Asignado" />
                    <asp:ListItem Text="Libre" Value="Libre" />
                    <asp:ListItem Text="Finalizado" Value="Finalizado" />
                    <asp:ListItem Text="Cancelado" Value="Cancelado" />
                </asp:DropDownList>
            </div>

            <h5 class="text-center">DATOS DEL CLIENTE</h5>
            <div class="input-group mb-2">
                <asp:Label CssClass="input-group-text" ID="lblSinCliente" runat="server" Font-Bold="false">OMITIR CLIENTE</asp:Label>
                <asp:CheckBox ID="cbxSinCliente" runat="server" CssClass="input-group-text" AutoPostBack="true" OnCheckedChanged="cbxSinCliente_CheckedChanged" />
                <!-- SI ESTÁ TRUE DESHABILITAR TODA LA SECCION CLIENTE O DEJAR SOLO NOMBRE -->
            </div>

            <div class="input-group mb-1">
                <asp:DropDownList ID="ddlClientes" runat="server" CssClass="btn btn-primary dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlClientes_SelectedIndexChanged"></asp:DropDownList>
            </div>

            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblNombre" runat="server" Font-Bold="false">NOMBRE</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="50" ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblApellido" runat="server" Font-Bold="false">APELLIDO</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="50" ID="txtApellido" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblTelefonoCliente" runat="server" Font-Bold="false">TELEFONO CLIENTE</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="15" ID="txtTelefonoCliente" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3 d-block">
                <div cssclass="input-group-prepend">
                    <asp:Label CssClass="input-group-text" ID="lblFormaDePago" runat="server" Font-Bold="false">FORMA DE PAGO</asp:Label>
                </div>
                <div cssclass="form-check form-check-inline mx-1 d-flex">
                    <asp:RadioButtonList CssClass="" ID="rblFormaDePago" runat="server" OnSelectedIndexChanged="rblFormaDePago_SelectedIndexChanged">
                        <asp:ListItem CssClass="form-check-input" Text="No Especifica" Value="No Especifica" />
                        <asp:ListItem CssClass="form-check-input" Text="Efectivo" Value="Efectivo" />
                        <asp:ListItem CssClass="form-check-input" Text="Tarjeta de Debito" Value="Tarjeta de Debito" />
                        <asp:ListItem CssClass="form-check-input" Text="Tarjeta de Credito" Value="Tarjeta de Credito" />
                        <asp:ListItem CssClass="form-check-input" Text="Mercado Pago" Value="Mercado Pago" />
                        <asp:ListItem CssClass="form-check-input" Text="Cuenta Corriente" Value="Cuenta Corriente" />
                    </asp:RadioButtonList>
                </div>
            </div>
            <h5 class="text-center">HORA Y FECHA</h5>
            <div cssclass="form-check form-check-inline">
                <asp:TextBox ID="txtHora" CssClass="col-form-label" runat="server" TextMode="Time"></asp:TextBox>
                <asp:TextBox ID="txtFecha" CssClass="col-form-label ms-2 mb-3" runat="server" TextMode="Date"></asp:TextBox>
            </div>

            <h5 class="text-center">DOMICILIO ORIGEN</h5>

            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblCalleOrigen" runat="server" Font-Bold="false">DIRECCION</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="100" ID="txtCalleOrigen" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblLocalidadOrigen" runat="server" Font-Bold="false">LOCALIDAD</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="80" ID="txtLocalidadOrigen" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblProvinciaOrigen" runat="server" Font-Bold="false">PROVINCIA</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="25" ID="txtProvinciaOrigen" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblDescripcionOrigen" runat="server" Font-Bold="false">DESCRIPCION</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="200" ID="txtDescripcionOrigen" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
            </div>

            <h5 class="text-center">DOMICILIO DESTINO</h5>

            <div class="input-group mb-3">
                <asp:Label ID="lblCantidadDestino" runat="server" Text="CANTIDAD DESTINOS" CssClass="input-group-text"></asp:Label>
                <asp:DropDownList ID="ddlCantidadDestino" runat="server" CssClass="btn btn-primary dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlCantidadDestino_SelectedIndexChanged">
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                </asp:DropDownList>

            </div>
            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblCalleDestino1" runat="server" Font-Bold="false">DOMICILIO</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="100" ID="txtCalleDestino1" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblLocalidadDestino1" runat="server" Font-Bold="false">LOCALIDAD</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="80" ID="txtLocalidadDestino1" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblProvinciaDestino1" runat="server" Font-Bold="false">PROVINCIA</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="25" ID="txtProvinciaDestino1" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblDescripcionDestino1" runat="server" Font-Bold="false">DESCRIPCION</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="200" ID="txtDescripcionDestino1" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
            </div>
            <% if (int.Parse(ddlCantidadDestino.SelectedValue) > 1)
                {
            %>
            <h6>SEGUNDO DOMICILIO</h6>
            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblCalleDestino2" runat="server" Font-Bold="false">2DO DOMICILIO</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="80" ID="txtCalleDestino2" runat="server"></asp:TextBox>
            </div>


            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblLocalidadDestino2" runat="server" Font-Bold="false">2DA LOCALIDAD</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="80" ID="txtLocalidadDestino2" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblProvinciaDestino2" runat="server" Font-Bold="false">2DA PROVINCIA</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="25" ID="txtProvinciaDestino2" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblDescripcionDestino2" runat="server" Font-Bold="false">DESCRIPCION</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="200" ID="txtDescripcionDestino2" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
            </div>
            <% if (int.Parse(ddlCantidadDestino.SelectedValue) > 2)
                {
            %>
            <h6>TERCER DOMICILIO</h6>
            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblCalleDestino3" runat="server" Font-Bold="false">3ER DOMICILIO</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="100" ID="txtCalleDestino3" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblLocalidadDestino3" runat="server" Font-Bold="false">3RA LOCALIDAD</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="80" ID="txtLocalidadDestino3" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-1">
                <asp:Label CssClass="input-group-text" ID="lblProvinciaDestino3" runat="server" Font-Bold="false">3RA PROVINCIA</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="25" ID="txtProvinciaDestino3" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblDescripcionDestino3" runat="server" Font-Bold="false">DESCRIPCION</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="200" ID="txtDescripcionDestino3" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
            </div>
            <%}
                } %>

            <h5 class="text-center">CHOFER</h5>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblNombreChofer" runat="server" Font-Bold="false">CHOFER</asp:Label>
                <%--<asp:TextBox CssClass="form-control" ID="txtNombreChofer" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="ddlChoferes" runat="server" CssClass="custom-select"></asp:DropDownList>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblTipoDeViaje" runat="server" Font-Bold="false">TIPO DE VIAJE</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="15" ID="txtTipoDeViaje" runat="server"></asp:TextBox>
            </div>

            <div class="input-group mb-3">
                <asp:Label CssClass="input-group-text" ID="lblImporte" runat="server" Font-Bold="false">IMPORTE $</asp:Label>
                <asp:TextBox CssClass="form-control" MaxLength="15" ID="txtImporte" runat="server" TextMode="Number"></asp:TextBox>
            </div>

            <div class="text-center">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnCanelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCanelar_Click" />
            </div>

            <br />

        </div>

    </div>

</asp:Content>
