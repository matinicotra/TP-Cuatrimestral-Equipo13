<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="adminVehiculo.aspx.cs" Inherits="TPCuatrimestal.adminVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; align-items: center; justify-content: center; flex-direction: column;">

        <div style="margin: 10px 15px;">
            <h4>ADMINISTRAR VEHICULOS</h4>
            <div class="input-group mb-3" style="display:flex; align-items:center; flex-direction: row;">
                <asp:TextBox ID="txtFiltrar" runat="server" CssClass="form-control" PlaceHolder="Busqueda..."></asp:TextBox>
                <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" CssClass="btn btn-primary" />
            </div>
        </div>

        <div id="div1">
            <table class="table position-relative shadow" border="1" style="overflow: scroll; background-color: lightgray; width: 400px;">
                <thead>
                    <tr>
                        <th scope="col" class="col-1">NUMERO</th>
                        <th scope="col" class="col-1">MODELO</th>
                        <th scope="col" class="col-1">PATENTE</th>
                        <th scope="col" class="col-1">TIPO</th>
                        <th scope="col" class="col-1">PLAZAS</th>
                        <th scope="col" class="col-1">ESTADO</th>
                        <th scope="col" class="col-4">ACCIONES</th>
                    </tr>
                </thead>

                <asp:Repeater ID="repVehiculos" runat="server">
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
                                    <asp:ImageButton ID="btnEliminar" ImageUrl="https://e7.pngegg.com/pngimages/623/319/png-clipart-computer-icons-graphics-icon-design-illustration-delete-icon-logo-area.png" runat="server" class="btn btn-close btn-lg border" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("IDVehiculo")%>' CommandName="IDVehiculo" ToolTip="Eliminar" />
                                    <asp:ImageButton ID="ImageButton1" ImageUrl="https://img2.freepng.es/20201210/hcb/transparent-edit-icon-interface-icon-5fd2c0863c4dc9.114206481607647366247.jpg" OnClick="ImageButton1_Click" CommandArgument='<%#Eval("IDVehiculo")%>' CommandName="IDVehiculo" runat="server" class="btn btn-close btn-lg border" ToolTip="Modificar" />
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>

    <div class="text-center">
        <asp:Button ID="btnAgregarVehiculo" runat="server" Text="Agregar vehiculo" CssClass="btn btn-primary" OnClick="btnAgregarVehiculo_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
    </div>
    <hr />
</asp:Content>
