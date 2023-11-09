<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TPCuatrimestal.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display:flex; align-items:center; justify-content:center; flex-direction:column; min-width:400px;">
        <div style="margin:30px 30px;">
            <h3>INGRESO AL SISTEMA</h3>
        </div>
        <form>
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email address</label>
                <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Password</label>
                <input type="password" class="form-control" id="exampleInputPassword1">
            </div>
            <div class="mb-3">
                <button type="submit" class="btn btn-primary">Submit</button>
            </div>
            <div class="mb-3">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar Sesión</button>
            </div>
        </form>
    </div>
</asp:Content>
