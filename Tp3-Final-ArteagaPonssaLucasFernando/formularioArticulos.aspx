<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="formularioArticulos.aspx.cs" Inherits="Tp3_Final_ArteagaPonssaLucasFernando.formularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <div class="form-control" data-bs-theme="dark">
        <div class="mb-3">
            <label for="lblId" class="form-label">Id</label>
            <asp:TextBox runat="server" ID="txtId" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="lblCodigo" class="form-label">Codigo </label>
            <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="txtCodigo"
                ErrorMessage="Ingrese un Codigo !! "
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <label for="lblNombre" class="form-label">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtNombre"
                ErrorMessage="Debes llenar con  un nombre"
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <label for="lblDescripcion" class="form-label">Descripcion</label>
            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ControlToValidate="txtDescripcion"
                ErrorMessage="La descripcion es necesaria! "
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <label for="lblMarca" class="form-label">Marca</label>
            <asp:DropDownList runat="server" ID="dropMarca" CssClass="form-select"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="lblCategoria" class="form-label">Categoria</label>
            <asp:DropDownList runat="server" ID="dropCategoria" CssClass="form-select"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="lblPrecio" class="forms">Precio</label>
            <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="mb-3">
                    <label for="lblImagenUrl" class="form-label">Url Imagen</label>
                    <asp:TextBox runat="server" ID="txtUrlImagen" OnTextChanged="txtUrlImagen_TextChanged" CssClass="form-control"
                        AutoPostBack="true"></asp:TextBox>
                </div>
                <asp:Image runat="server" ID="imgArticulo" Width="30%" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
            ControlToValidate="txtUrlImagen"
            ErrorMessage="Es necesario la url de una imagen"
            ForeColor="Red">
        </asp:RequiredFieldValidator>
        <asp:Button runat="server" Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" />
        <%--<asp:Button runat="server" Text="Volver" ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-secondary"/>--%>
        <a href="ListarArticulo.aspx" class="btn btn-secondary">Volver </a>
        <div class="row">
            <div class="col-6">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <% if (botonEliminar)
                            { %>
                        <div class="mb-3">
                            <asp:Button runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" Text="Eliminar" />
                        </div>
                        <%} %>
                        <%if (botonEliminarConf)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox runat="server" Text="Confimar" ID="CheckConfirmarEliminacion" />
                            <asp:Button runat="server" Text="Eliminar!" ID="btnConfirmarEliminacion" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click" />
                        </div>
                        <%} %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>

