<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="detalleViaje.aspx.cs" Inherits="TPCuatrimestal.detalleViaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- DETALLE VIAJE DEBERIA SE ACCEDIDA DESDE homeAdmin, homeChofer, detalleChofer, etc..
                        HAY QUE ACOMODAR BIEN EL TEMA DE BOTONES ASP-->
    <div class="container-md" style="display: flex; align-items: center; justify-content: center; flex-direction: column; grid-row-gap: 30px; margin-top: 50px;">
        <div>
            <h1>VIAJE DE (NOMBRE DEL CLIENTE/EMPRESA)</h1>
        </div>
        <!-- SI ES ACCEDIDA DESDE CHOFER SOLO DEJAR CAMBIAR DIRECCIONES Y QUIZÁS ALGUNA COSITA MAS
                    SI ES DESDE ADMIN SE PUEDE MODIFICAR TODO-->
        <div class="list-group">
            <ul class="list-group list-group-horizontal">
                <li class="list-group-item">Direccion Origen</li>
                <li class="list-group-item">Avenida Rivadavia 888  Piso 4 - Timbre 3</li>
            </ul>

            <ul class="list-group list-group-horizontal-md">
                <li class="list-group-item">Localidad Origen</li>
                <li class="list-group-item">CABA</li>
            </ul>

            <ul class="list-group list-group-horizontal-md">
                <li class="list-group-item">Direccion Destino</li>
                <li class="list-group-item">Calle Uriburu 1550</li>
            </ul>

            <ul class="list-group list-group-horizontal-md">
                <li class="list-group-item">Localidad Destino</li>
                <li class="list-group-item">Vicente López</li>
            </ul>

            <ul class="list-group list-group-horizontal-md">
                <li class="list-group-item">Pasajero/a</li>
                <li class="list-group-item">Mirta Gonzalez</li>
            </ul>

            <ul class="list-group list-group-horizontal-md">
                <li class="list-group-item">etc...</li>
                <li class="list-group-item">...</li>
            </ul>
        </div>

        <div>
            <h5>Copiar datos del viaje</h5>
        </div>

        <div>
            <asp:Button ID="btnCopiarDatosViaje" runat="server" Text="Copiar" />
        </div>

        <div>
            <asp:Button ID="btnAtras" runat="server" Text="Atras" OnClick="btnAtras_Click" />
        </div>

    </div>
</asp:Content>
