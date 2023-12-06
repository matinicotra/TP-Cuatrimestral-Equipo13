<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="listaViajes.aspx.cs" Inherits="TPCuatrimestal.listaViajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-lg" style="display: flex; align-items: center; justify-content: center; flex-direction: column; gap: 20px;"">
        <div>
            <asp:Label ID="lblClienteOChofer" runat="server" Font-Size="Large" Font-Bold="true"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblNombre" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblZona" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblEstado" runat="server"></asp:Label>        
        </div>
    </div>

    <div id="div1">
        <table class="table position-relative shadow" border="1" style="overflow: scroll; background-color: lightgray;">
            <thead>
                <tr>
                    <th scope="col" class="col-1 text-md-center">TIPO DE VIAJE</th>
                    <th scope="col" class="col-1 text-md-center">IMPORTE</th>
                    <th scope="col" class="col-1 text-md-center">FECHA Y HORA</th>
                </tr>
            </thead>

            <asp:Repeater ID="repViajes" runat="server">
                <ItemTemplate>
                    <tbody>
                        <tr>
                            <td class="text-md-center"><%#Eval("TipoViaje")%></td>
                            <td class="text-md-center"><%#((Decimal)Eval("Importe")).ToString("f2")%></td>
                            <td class="text-md-center"><%#Eval("FechaHoraViaje")%></td>
                        </tr>
                    </tbody>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div>
        <asp:Label ID="lblTotal" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
    </div>

    <div>
        <asp:Button CssClass="btn btn-primary" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
    </div>

</asp:Content>
