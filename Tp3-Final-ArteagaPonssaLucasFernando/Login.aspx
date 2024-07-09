<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tp3_Final_ArteagaPonssaLucasFernando.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-control" data-bs-theme="dark">
        <h2>Ingreso</h2>
        <hr />
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Correo Electrónico</label>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Ingrese un Email !"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <label for="exampleInputPassword1" class="form-label">Contraseña</label>
            <asp:TextBox runat="server" ID="txtPass" TextMode="Password" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtPass"
                ErrorMessage="La contraseña es necesaria! "
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <asp:Button runat="server" Text="Ingresar" ID="btnLoguearse" OnClick="btnLoguearse_Click" CssClass="btn btn-success" />
        <hr />
        <p>Si aún no posees una cuenta , ingresa aquí : </p>
        <a href="Registro.aspx" class="btn btn-primary">Registrarse</a>
    </div>

</asp:Content>
