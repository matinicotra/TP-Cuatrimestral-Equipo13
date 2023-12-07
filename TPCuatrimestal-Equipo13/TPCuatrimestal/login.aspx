<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TPCuatrimestal.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; align-items: center; justify-content: center; flex-direction: column; min-width: 400px;">
        <div style="margin: 30px 30px;">
            <h3 class="h3 text-primary-emphasis">LOGIN</h3>
        </div>

            <div class="mb-3">
                <asp:Label ID="lblUsuario" runat="server" CssClass="form-label" Text="USUARIO:"></asp:Label>
                <asp:TextBox ID="tbxUsuario" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblConstrasenia" runat="server" CssClass="form-label" Text="CONTRASEÑA:"></asp:Label>
                <asp:TextBox ID="tbxConstrasenia" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" Text="Ingresar" OnClick="btnLogin_Click"/>
                <asp:Button ID="btnCerrarSesion" class="btn btn-secondary" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" />
            </div>
          
    </div>
</asp:Content>
