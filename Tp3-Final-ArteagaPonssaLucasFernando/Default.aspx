<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp3_Final_ArteagaPonssaLucasFernando.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function handleImageError(imgElement, imgAux) {
            imgElement.onerror = null;
            imgElement.src = imgAux;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenidos a LucArt</h1>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="Repetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("urlImage") %>" class="card-img-top" alt="..." id="imgEstilo" onerror='handleImageError(this, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr64U1qrn_mnXFwQoOmiuJs1zp0aLvApc1WmtDk-_IywS0eg7pzlSCsqDNbUzJuPSRupo&usqp=CAU")'>
                        <div class="card-body">
                            <p class="card-title"><%#Eval("Nombre") %></p>
                            <h4 class="card-text">$<%#Eval("Precio") %></h4>
                            <asp:Button runat="server" CssClass="btn btn-primary" Text="Ver detalle" ID="btnVerDetalle" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnDetalle_click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
