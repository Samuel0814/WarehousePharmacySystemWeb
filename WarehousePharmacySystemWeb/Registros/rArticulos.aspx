<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rArticulos.aspx.cs" Inherits="WarehousePharmacySystemWeb.Registros.rArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="page-header text-center">
            <h2 style="color: #358CCE">Registro de Articulos</h2>
        </div>

        <hr style="color: #358CCE"/>

        <label for="TextBoxArticuloID">ID</label>
        <div class="form-row">
            <div class="form-group col-lg-1">
                <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxArticuloID" runat="server" placeholder="ID"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="id" SetFocusOnError="true" ForeColor="Red" ID="RequiredFieldValidator7" ControlToValidate="TextBoxArticuloID" runat="server" Display="Dynamic" ErrorMessage="Introduzca un id"></asp:RequiredFieldValidator>
            </div>
            <div class="btn-group-col-md-1">
                <asp:Button class="btn btn-primary" ValidationGroup="id" ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-7 col-md-offset-3">
                <label for="DropDownListCategorias">Categoria</label>
                <asp:DropDownList ID="DropDownListCategorias" CssClass="form-control" runat="server" placeholder="Seleccione una categoria"></asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator6" ControlToValidate="DropDownListCategorias" runat="server" Display="Dynamic" ErrorMessage="Seleccione la categoria del articulo"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-7 col-md-offset-3">
                <label for="TextBoxNombreArticulo">Nombre</label>
                <asp:TextBox class="form-control" ID="TextBoxNombreArticulo" runat="server" placeholder="Nombre del Articulo" autocomplete="off"> </asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator1" ControlToValidate="TextBoxNombreArticulo" runat="server" Display="Dynamic" ErrorMessage="Introduzca un Nombre al Articulo"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-7 col-md-offset-3">
                <label for="TextBoxFechaVencimiento">Fecha </label>
                <asp:TextBox TextMode="Date" class="form-control" ID="TextBoxFechaVencimiento" runat="server" placeholder="Fecha de Vencimiento del articulo"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="TextBoxFechaVencimiento" runat="server" Display="Dynamic" ErrorMessage="Introduzca una Fecha de Vencimiento al articulo"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-7 col-md-offset-3">
                <label for="TextBoxExistencia">Existencia</label>
                <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxExistencia" runat="server" placeholder="Existencia del Articulo" autocomplete="off"> </asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator3" ControlToValidate="TextBoxExistencia" runat="server" Display="Dynamic" ErrorMessage="Introduzca una Existencia al articulo"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-7 col-md-offset-3">
                <label for="TextBoxCosto">Costo</label>
                <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxCosto" runat="server" placeholder="Costo del Articulo" autocomplete="off"> </asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator4" ControlToValidate="TextBoxExistencia" runat="server" Display="Dynamic" ErrorMessage="Introduzca un Costo al Articulo"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-7 col-md-offset-3">
                <label for="TextBoxPrecio">Precio</label>
                <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxPrecio" runat="server" placeholder="Precio del Articulo" autocomplete="off"> </asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator5" ControlToValidate="TextBoxPrecio" runat="server" Display="Dynamic" ErrorMessage="Introduzca un Precio al Articulo"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="btn-block text-center">
            <asp:Button class="btn btn-primary" ID="ButtonNuevo" runat="server" Text="Nuevo" OnClick="ButtonNuevo_Click" />
            <asp:Button class="btn btn-success" ValidationGroup="save" ID="ButtonGuardar" runat="server" Text="Guardar" OnClick="ButtonGuardar_Click" />
            <asp:Button class="btn btn-danger" ValidationGroup="id" ID="ButtonEliminar" runat="server" Text="Eliminar" OnClick="ButtonEliminar_Click" />
        </div>
    </div>
</asp:Content>