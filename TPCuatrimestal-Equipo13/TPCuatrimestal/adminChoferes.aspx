<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="adminChoferes.aspx.cs" Inherits="TPCuatrimestal.choferes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-md" style="background-color:aliceblue; display:flex; align-items:center; justify-content:center; flex-direction:column;">
        <div style="display:flex; align-items:center; margin: 20px; flex-direction: column; gap: 20px;">

            <div>
                 <h4>ADMINISTRACION CHOFERES</h4>
            </div>

            <div class="input-group mb-3" style="display:flex; align-items:center; flex-direction: row;">
                <asp:TextBox CssClass="form-control" ID="txtFiltrar" runat="server" PlaceHolder="Busqueda..."></asp:TextBox>
                <asp:Button cssclass="btn btn-primary" ID="btnFiltrar" runat="server" Text="Buscar" />
            </div>
      
            <div>
                <h5>Listado de Choferes</h5> 
                <asp:ListBox CssClass="list-group list-group-flush" ID="listaChoferes" runat="server" OnSelectedIndexChanged="listaChoferes_SelectedIndexChanged" ></asp:ListBox>
            </div>

            <br />

            <div>
                <asp:GridView ID="dgvChoferes" DataKeyNames="id" OnSelectedIndexChanged="dgvChoferes_SelectedIndexChanged" runat="server" AutoGenerateColumns="false" CssClass="table table-primary"></asp:GridView>
            </div>

            <div>
                <asp:Button ID="btnAltaChofer" runat="server" CssClass="btn btn-success" Text="Alta" OnClick="btnAltaChofer_Click" />
                <asp:Button ID="btnBajaChofer" runat="server" cssClass="btn btn-danger" Text="Baja" OnClick="btnBajaChofer_Click"/>
                <asp:Button ID="btnModificarChofer" runat="server" CssClass="btn btn-warning" Text="Modificar" onClick="btnModificarChofer_Click" />
                <asp:Button ID="btnDetalleChofer" CssClass="btn btn-info" runat="server" Text="Detalle Chofer" OnClick="btnDetalleChofer_Click" />
            </div>
        </div>

    </div>
</asp:Content>
