<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAgencia.Master" AutoEventWireup="true" CodeBehind="detalleViaje.aspx.cs" Inherits="TPCuatrimestal.detalleViaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <!-- DETALLE VIAJE DEBERIA SE ACCEDIDA DESDE HOME-ADMIN O HOME-CHOFER
                        HAY QUE ACOMODAR BIEN EL TEMA DE BOTONES ASP-->
    <div>
        <div>
             <ul class="list-group list-group-horizontal">
              <li class="list-group-item">Direccion Origen</li>
              <li class="list-group-item">Avenida Rivadavia 888  Piso 4 - Timbre 3</li>
            </ul>

            <ul class="list-group list-group-horizontal-sm">
              <li class="list-group-item">Localidad Origen</li>
              <li class="list-group-item">CABA</li>
            </ul>

            <ul class="list-group list-group-horizontal-md">
              <li class="list-group-item">Direccion Destino</li>
              <li class="list-group-item">Calle Uriburu 1550</li>            
            </ul>

            <ul class="list-group list-group-horizontal-lg">
              <li class="list-group-item">Localidad Destino</li>
              <li class="list-group-item">Vicente López</li>
            </ul>

            <ul class="list-group list-group-horizontal-lg">
              <li class="list-group-item">Pasajero/a</li>
              <li class="list-group-item">Mirta Gonzalez</li>
            </ul>

            <ul class="list-group list-group-horizontal-lg">
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
            <asp:Button ID="btnHome" runat="server" Text="Home" />
        </div>

    </div>
</asp:Content>
