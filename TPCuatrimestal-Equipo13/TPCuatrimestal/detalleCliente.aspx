<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="detalleCliente.aspx.cs" Inherits="TPCuatrimestal.detalleEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg" style="display: flex; align-items: center; justify-content: center; flex-direction: column; gap: 20px;">
        <div>
            <asp:Label ID="lblNombreTitulo" runat="server" Text="" CssClass="h3 text-primary-emphasis"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblTelefonoTitulo" runat="server" Text="" CssClass="h3 text-primary-emphasis"></asp:Label>
        </div>

        <div>
            <h5 class="text-center h5">VIAJES</h5>
            <asp:ListBox ID="lbxListaViajesPorCliente" runat="server" CssClass="list-group list-group-flush"></asp:ListBox>
        </div>

        <div>
            <asp:Button CssClass="btn btn-info" ID="btnDetalleViaje" runat="server" Text="Detalles viaje" OnClick="btnDetalleViaje_Click" />
        </div>

        <div>
            <h5 class="text-sm-center">Resumen del Cliente</h5>
            <asp:Button CssClass="btn btn-info" ID="btnResumenSemanalCliente" runat="server" Text="Semanal" OnClick="btnResumenSemanalCliente_Click" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenQuincenalCliente" runat="server" Text="Quincenal" OnClick="btnResumenQuincenalCliente_Click" />
            <asp:Button CssClass="btn btn-info" ID="btnResumenMensualCliente" runat="server" Text="Mensual" OnClick="btnResumenMensualCliente_Click" />
        </div>
        <div>
            <h5>DATOS CLIENTE</h5>
        </div>
        <div>
            <asp:Table runat="server" CssClass="table table-striped">
                <asp:TableRow>
                    <asp:TableHeaderCell>NOMBRE</asp:TableHeaderCell>
                    <asp:TableHeaderCell>APELLIDO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>TELEFONO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>EMAIL</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblApellido" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblTelefono" runat="server" Text="Sin Telefono"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblEmail" runat="server" Text="Sin Email"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableHeaderCell>CALLE</asp:TableHeaderCell>
                    <asp:TableHeaderCell>LOCALIDAD</asp:TableHeaderCell>
                    <asp:TableHeaderCell>PROVINCIA</asp:TableHeaderCell>
                    <asp:TableHeaderCell>DESCRIPCION</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblCalle" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblLocalidad" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblProvincia" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <div style="align-items: center; align-items: center; position: relative; left: 26%;">
                <h5>ZONA:
                    <asp:Label runat="server" ID="lblZona"></asp:Label></h5>
            </div>
        </div>
    </div>
    <div>
        <asp:Button CssClass="btn btn-primary" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click"/>
    </div>
</asp:Content>
