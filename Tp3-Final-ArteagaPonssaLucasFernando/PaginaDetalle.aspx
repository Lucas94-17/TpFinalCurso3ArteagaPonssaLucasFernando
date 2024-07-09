<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="PaginaDetalle.aspx.cs" Inherits="Tp3_Final_ArteagaPonssaLucasFernando.PaginaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        #informacion {
            background-color: #2B3035;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card" style="width: 30rem;">
        <contenttemplate>
            <div class="card-body">
                <h1>
                    <asp:Label runat="server" ID="lblNombre"></asp:Label></h1>
                <div id="informacion">
                    <div>
                        <asp:Label CssClass="card-text" ID="lblDescripcion" runat="server"></asp:Label>
                    </div>

                    <div>
                        <label class="card-text">Marca : </label>
                        <asp:Label runat="server" ID="lblMarca" CssClass="card-text"></asp:Label>
                    </div>
                    <div>
                        <label class="card-text">Categoria : </label>
                        <asp:Label runat="server" ID="lblCategoria" CssClass="card-text"></asp:Label>
                    </div>
                </div>
                <hr />
                <div>
                    <%--<img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="..." id="imgEstilo" onerror='handleImageError(this, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr64U1qrn_mnXFwQoOmiuJs1zp0aLvApc1WmtDk-_IywS0eg7pzlSCsqDNbUzJuPSRupo&usqp=CAU")'>--%>

                    <asp:Image runat="server" ID="imgArticulo" Width="60%" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQr64U1qrn_mnXFwQoOmiuJs1zp0aLvApc1WmtDk-_IywS0eg7pzlSCsqDNbUzJuPSRupo&usqp=CAU" />
                </div>
                <div>
                    <h3>
                        <asp:Label runat="server" ID="lblPrecio" CssClass="card-text"></asp:Label></h3>
                </div>
            </div>
        </contenttemplate>
    </div>
</asp:Content>

