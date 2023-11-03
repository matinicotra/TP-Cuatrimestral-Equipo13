<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="adminVehiculo.aspx.cs" Inherits="TPCuatrimestal.adminVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; align-items: center; justify-content:center; flex-direction:column;">
        <style>
                #div1 {
                    overflow: scroll;
                    
                }

                #div1 table {
                    width: 500px;
                    background-color: lightgray;
                }
        </style>
        <div style="margin: 10px 15px;">
            <h4>VEHICULOS</h4>
            <div>
                <asp:TextBox ID="txtFiltrar" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-secondary" />
            </div>
        </div>
        <div id="div1">
            <table class="table position-relative" border="1">
                <thead>
                    <tr>
                        <th scope="col" class="col-1">ID</th>
                        <th scope="col" class="col-1">MODELO</th>
                        <th scope="col" class="col-1">PATENTE</th>
                        <th scope="col" class="col-1">TIPO</th>
                        <th scope="col" class="col-1">PLAZAS</th>
                        <th scope="col" class="col-1">ESTADO</th>
                    </tr>
                </thead>
                <asp:Repeater ID="repVehiculos" runat="server" >
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td><%#Eval("IDVehiculo")%></td>
                                <td><%#Eval("Modelo")%></td>
                                <td><%#Eval("Patente")%></td>
                                <td><%#Eval("Tipo.NombreTipo")%></td>
                                <td><%#Eval("Tipo.CantAsientos")%></td>
                                <td><%#Eval("Estado")%></td>
                                <td>                     
                                    <asp:ImageButton ID="btnEliminar" ImageUrl="https://e7.pngegg.com/pngimages/623/319/png-clipart-computer-icons-graphics-icon-design-illustration-delete-icon-logo-area.png" runat="server" class="btn-close border display-6 shadow-sm"/>   
                                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>

    <div class="text-center">
        <asp:Button ID="btnAgregarVehiculo" runat="server" Text="Agregar vehiculo" CssClass="btn btn-secondary" OnClick="btnAgregarVehiculo_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
    </div>
    <hr />
</asp:Content>
