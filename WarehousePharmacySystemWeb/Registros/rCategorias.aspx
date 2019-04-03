<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCategorias.aspx.cs" Inherits="WarehousePharmacySystemWeb.Registros.rCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="page-header text-center">
            <h2 style="color: #358CCE">Registro de Categorias</h2>
        </div>

        <hr style="color: #358CCE"/>

        <label for="TextBoxCategoriasID">ID</label>
        <div class="form-row">
            <div class="form-group col-lg-1">
                <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxCategoriasID" runat="server" placeholder="ID"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="id" SetFocusOnError="true" ForeColor="Red" ID="RequiredFieldValidator1" ControlToValidate="TextBoxCategoriasID" runat="server" Display="Dynamic" ErrorMessage="Introduzca un ID"></asp:RequiredFieldValidator>
            </div>
            <div class="btn-group-col-md-1">
                <asp:Button class="btn btn-primary" ValidationGroup="id" ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-7 col-md-offset-3">
                <label for="TextBoxDescripcion">Categorias</label>
                <asp:TextBox class="form-control" ID="TextBoxDescripcion" runat="server" placeholder="Categorias" autocomplete="off" ControlToValidate="TextBoxNombre"> </asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" SetFocusOnError="true" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="TextBoxDescripcion" runat="server" Display="Dynamic" ErrorMessage="Introduzca un Categoria"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="btn-block text-center">
            <asp:Button class="btn btn-primary" ID="ButtonNuevo" runat="server" Text="Nuevo" OnClick="ButtonNuevo_Click" />
            <asp:Button class="btn btn-success" ValidationGroup="save" ID="ButtonGuardar" runat="server" Text="Guardar" OnClick="ButtonGuardar_Click" />
            <asp:Button class="btn btn-danger" ValidationGroup="id" ID="ButtonEliminar" runat="server" Text="Eliminar" OnClick="ButtonEliminar_Click" />
        </div>
    </div>

</asp:Content>