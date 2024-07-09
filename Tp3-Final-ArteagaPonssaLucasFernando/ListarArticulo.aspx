<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="ListarArticulo.aspx.cs" Inherits="Tp3_Final_ArteagaPonssaLucasFernando.ListarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function validar() {

        }
    </script>
    <h1>Lista de Articulos</h1>
    <%--Filtro por busqueda--%>
    <div class="col-3">
        <div class="mb-3">
            <label id="lblFiltrar" class="">Filtrar</label>
            <asp:TextBox runat="server" ID="txtFiltrar" AutoPostBack="true" OnTextChanged="txtFiltrar_TextChanged" CssClass="form-control " data-bs-theme="dark"></asp:TextBox>
        </div>
    </div>
    <div class="col-3">
        <div class="mb-3">
            <asp:Button runat="server" ID="btnLimpiarFiltro" OnClick="btnLimpiarFiltro_Click" Text="Limpiar Filtro" CssClass="btn btn-light" />
        </div>
    </div>
    <%--Filtro Avanzado--%>
    <div class="col-6">
        <div class="mb-3">
            <asp:CheckBox runat="server" Text="Filtro Avanzado" ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
        </div>
    </div>
    <%if (chkAvanzado.Checked)
        { %>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="lblcampo" runat="server" Text="Campo"></asp:Label>
                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlcampo" OnSelectedIndexChanged="ddlcampo_SelectedIndexChanged">

                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Descripcion" />
                    <asp:ListItem Text="Codigo" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" ID="lbl" Text="Criterio" />
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCriterio"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" ID="LblFiltroAvanzado" Text="Filtro" />
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" OnClientClick="return validar()" />
        </div>
    </div>
    <%} %>
    <div class="mb-3">
        <asp:GridView ID="dgvArticulos" runat="server" CssClass="table"
            AutoGenerateColumns="false" DataKeyNames="Id"
            OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
            OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" data-bs-theme="dark">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✏️" />
            </Columns>
        </asp:GridView>
        <div class="mb-3">
            <%--<asp:Button runat="server" Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click"/>--%>
            <a href="formularioArticulos.aspx" class="btn btn-primary">Agregar </a>
            <asp:Button runat="server" Text="Volver" ID="btnVolver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
        </div>
    </div>
</asp:Content>
