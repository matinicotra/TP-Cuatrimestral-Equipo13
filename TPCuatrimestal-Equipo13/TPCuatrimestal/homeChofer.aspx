<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="homeChofer.aspx.cs" Inherits="TPCuatrimestal.homeChofer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg" style="display:flex; align-items:center; justify-content:center; flex-direction:column;">
        <div>
            <h5>Listado de viajes del dia</h5>
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        </div>

        <div>
            <h5>Detalles del viaje</h5>
            <asp:Button ID="Button1" runat="server" Text="Detalle viaje" />
        </div>

        <div>
            <h5>Filtrado por distintos criterios</h5>
            <asp:TextBox ID="txtFiltrar" runat="server"></asp:TextBox>
            <asp:Button ID="btnFiltrar" runat="server" Text="Button" />
        </div>

        <div>
            <h5>Copiar datos del viaje</h5>
        </div>

        <div>
            <asp:Button ID="btnChoferes" runat="server" Text="Copiar" />
        </div>

        <div>
            <h5>Ver viajes por día</h5>
            <asp:Calendar ID="calOtrosDias" runat="server"></asp:Calendar>
        </div>

    </div>
</asp:Content>
