<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="adminChoferes.aspx.cs" Inherits="TPCuatrimestal.choferes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-md" style="display:flex; align-items:center; justify-content:center; flex-direction:column; max-width: 900px">
        <div style="display:flex; align-items:center; margin: 20px; flex-direction: column; gap: 20px;">

            <div>
                 <h4>ADMINISTRACION CHOFERES</h4>
            </div>

            <div class="input-group mb-3" style="display:flex; align-items:center; flex-direction: row;">
                <asp:TextBox CssClass="form-control" ID="txtFiltrar" runat="server">Filtrar por criterio</asp:TextBox>
                <asp:Button cssclass="btn btn-primary" ID="btnFiltrar" runat="server" Text="Buscar" />
            </div>
      
            <div>
                <h5>Listado de Choferes</h5> 
                <asp:ListBox ID="listaChoferes" runat="server"></asp:ListBox> <!-- DEBERIA SER UN DATA GRID VIEW ? -->
            </div>

            <div>
                <h5>ABM Choferes</h5>
                <asp:Button ID="btnAltaChofer" runat="server" CssClass="btn btn-primary" Text="Alta" OnClick="btnAltaChofer_Click" />
                <asp:Button ID="btnBajaChofer" runat="server" cssClass="btn btn-danger" Text="Baja" />
                <asp:Button ID="btnModificarChofer" runat="server" CssClass="btn btn-warning" Text="Modificar" onClick="btnModificarChofer_Click" />
                <asp:Button ID="btnDetalleChofer" CssClass="btn btn-info" runat="server" Text="Detalle Chofer" OnClick="btnDetalleChofer_Click" />
            </div>
        </div>

    </div>
</asp:Content>
