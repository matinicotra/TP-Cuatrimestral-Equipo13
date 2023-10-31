<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="homeAdmin.aspx.cs" Inherits="TPCuatrimestal.homeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg" style="display:flex; align-items:center; justify-content:center; flex-direction:column;">
        <div>
            lista viajes del dia
        </div>
        <div>
            opciones ABM viajes
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Detalle viaje" />
        </div>
        <div>
            filtrado por distintos criterios
        </div>
        <div>
            opciones de ver otros dias
        </div>
        <div>
            asignar viaje a chofer y compartir datos de viaje
        </div>
        <div>
            <asp:Button ID="Button2" runat="server" Text="Empresa" />
            <asp:Button ID="Button3" runat="server" Text="Clientes" />
            <asp:Button ID="Button4" runat="server" Text="Choferes" />
        </div>
    </div>

</asp:Content>
