<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="adminCliente.aspx.cs" Inherits="TPCuatrimestal.adminCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-md" style="background-color: aliceblue; display: flex; align-items: center; justify-content: center; flex-direction: column">
        <div style="display: flex; align-items: center; margin: 20px; flex-direction: column; gap: 20px;">

            <div>
                <h4>ADMINISTRACION CLIENTES</h4>
            </div>

            <div class="input-group mb-3" style="display: flex; align-items: center; flex-direction: row;">
                <div>
                    <asp:DropDownList Style="border-radius: 5px;" CssClass="form-control-color dropdown-toggle-split border-secondary-subtle ratio" ID="ddlCampo" runat="server" ToolTip="Campo">
                        <asp:ListItem>NOMBRE</asp:ListItem>
                        <asp:ListItem>APELLIDO</asp:ListItem>
                        <asp:ListItem>ZONA</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:TextBox CssClass="form-control" ID="txtFiltrar" runat="server" PlaceHolder="Busqueda..."></asp:TextBox>
                <asp:Button CssClass="btn btn-primary" ID="btnFiltrar" runat="server" Text="Buscar" OnClick="btnFiltrar_Click"/>
            </div>

            <div>
                <h5>Listado de Clientes</h5>
                <asp:ListBox CssClass="list-group list-group-flush" ID="listaClientes" runat="server" OnSelectedIndexChanged="listaClientes_SelectedIndexChanged"></asp:ListBox>
            </div>

            <div>
                <asp:Button ID="btnAltaCliente" runat="server" CssClass="btn btn-success" Text="Alta" OnClick="btnAltaCliente_Click" />
                <asp:Button ID="btnBajaCliente" runat="server" CssClass="btn btn-danger" Text="Baja" OnClick="btnBajaCliente_Click" />
                <asp:Button ID="btnModificarCliente" runat="server" CssClass="btn btn-warning" Text="Modificar" OnClick="btnModificarCliente_Click" />
                <asp:Button ID="btnDetalleCliente" runat="server" CssClass="btn btn-info" Text="Detalle Cliente" OnClick="btnDetalleCliente_Click" />
            </div>

        </div>

    </div>

</asp:Content>
