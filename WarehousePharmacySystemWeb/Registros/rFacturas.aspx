<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rFacturas.aspx.cs" Inherits="WarehousePharmacySystemWeb.Registros.rFacturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div class="jumbotron">
        <div class="page-header text-center">
            <h2 style="color: #358CCE">Registro de Facturas</h2>
        </div>

        <hr style="color: #358CCE" />

        <label for="TextBoxFacturaID">Factura ID</label>
        <div class="form-row">
            <div class="form-group col-lg-1">
                <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxFacturaID" runat="server" placeholder="ID"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="id_f" SetFocusOnError="true" ForeColor="Red" ID="RequiredFieldValidator7" ControlToValidate="TextBoxFacturaID" runat="server" Display="Dynamic" ErrorMessage="Introduzca un id"></asp:RequiredFieldValidator>
            </div>
            <div class="btn-group-col-md-1">
                <asp:Button class="btn btn-primary" ValidationGroup="id_f" ID="ButtonBuscarFactura" runat="server" Text="Buscar" OnClick="ButtonBuscarFactura_Click" />
            </div>

        </div>

        
        <div class="row">
            <div class="form-group col-md-5 col-md-offset-3">
                <label for="TextBoxFecha">Fecha</label>
                <asp:TextBox TextMode="Date" class="form-control" ID="TextBoxFecha" runat="server" placeholder="Fecha de Registro del Usuario"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator3" ControlToValidate="TextBoxFecha" runat="server" Display="Dynamic" ErrorMessage="Introduzca la Fecha de registro del usuario"></asp:RequiredFieldValidator>
            </div>
        </div>

        <fieldset>
            <legend>Datos del Cliente</legend>

            <label for="TextBoxClienteID">Cliente ID</label>
            <div class="form-row">
                <div class="form-row">
                    <div class="form-group col-lg-3">
                        <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxClienteID" runat="server" placeholder="ID"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="id_c" SetFocusOnError="true" ForeColor="Red" ID="RequiredFieldValidator1" ControlToValidate="TextBoxClienteID" runat="server" Display="Dynamic" ErrorMessage="Introduzca un id"></asp:RequiredFieldValidator>
                    </div>
                    <div class="btn-group-col-md-1">
                        <asp:Button class="btn btn-primary" ValidationGroup="id_c" ID="ButtonBuscarCliente" runat="server" Text="Buscar" OnClick="ButtonBuscarCliente_Click" />
                    </div>
                </div>
                <div class="form-group col-md-3 col-md-offset-3">
                    <label for="TextBoxNombreCliente">Nombre</label>
                    <asp:TextBox class="form-control" ID="TextBoxNombreCliente" runat="server" autocomplete="off" ReadOnly="true"> </asp:TextBox>
                </div>
                <div class="form-group col-md-3 col-md-offset-3">
                    <label for="TextBoxApellidoCliente">Apellido</label>
                    <asp:TextBox class="form-control" ID="TextBoxApellidoCliente" runat="server" autocomplete="off" ReadOnly="true"> </asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <div class="form-row">
                    <div class="form-group col-lg-3" style="margin-left: 272px;">
                    </div>
                    <div class="btn-group-col-md-1">
                    </div>
                </div>
                <div class="form-group col-md-3 col-md-offset-4">
                    <label for="TextBoxTelefonoCliente">Telefono</label>
                    <asp:TextBox class="form-control" ID="TextBoxTelefonoCliente" runat="server" autocomplete="off" ReadOnly="true"> </asp:TextBox>
                </div>
                <div class="form-group col-md-3 col-md-offset-4">
                    <label for="TextBoxDireccionCliente">Direccion</label>
                    <asp:TextBox class="form-control" ID="TextBoxDireccionCliente" runat="server" autocomplete="off" ReadOnly="true"> </asp:TextBox>
                </div>
            </div>

        </fieldset>
        <br />
        <br />
        <fieldset>
            <legend>Datos de los Articulos</legend>

            <label for="TextBoxArticuloID">Articulo ID</label>
            <div class="form-row">
                <div class="form-row">
                    <div class="form-group col-lg-3">

                        <asp:TextBox TextMode="Number" class="form-control" ID="TextboxArticuloID" runat="server" placeholder="ID"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="id_c" SetFocusOnError="true" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="TextboxArticuloID" runat="server" Display="Dynamic" ErrorMessage="Introduzca un id"></asp:RequiredFieldValidator>
                   
                    
                    </div>
                    <div class="btn-group-col-md-1">
                        <asp:Button class="btn btn-primary" ValidationGroup="id_p" ID="ButtonBuscarArticulo" runat="server" Text="Buscar" OnClick="ButtonBuscarArticulo_Click" />
                    </div>
                </div>
                <div class="form-group col-md-3 col-md-offset-3">
                    <label for="TextBoxNombreArticulo">Nombre</label>
                    <asp:TextBox class="form-control" ID="TextBoxNombreArticulo" runat="server" autocomplete="off" ReadOnly="true"> </asp:TextBox>
                </div>
                <div class="form-group col-md-3 col-md-offset-4">
                    <label for="TextBoxPrecioArticulo">Precio</label>
                    <asp:TextBox class="form-control" ID="TextBoxPrecioArticulo" ReadOnly="true" runat="server" autocomplete="off"> </asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <div class="form-row">
                    <div class="form-group col-lg-3" style="margin-left: 272px;">
                    </div>
                    <div class="btn-group-col-md-1">
                    </div>
                </div>

                <div class="form-group col-md-3 col-md-offset-4">
                    <label for="TextBoxCantidadArticulo">Cantidad</label>
                    <asp:TextBox class="form-control" TextMode="Number" ID="TextBoxCantidadArticulo" runat="server" autocomplete="off"> </asp:TextBox>
                </div>
                <div class="form-group col-md-3 col-md-offset-4">
                    <label for="TextBoxImporteArticulo">Importe</label>
                    <asp:TextBox class="form-control" ID="TextBoxImporteArticulo" runat="server" autocomplete="off" ReadOnly="true"> </asp:TextBox>
                </div>
            </div>

            <div class="btn-block text-center">
                <asp:Button class="btn btn-primary" ValidationGroup="add" ID="ButtonAgregar" runat="server" Text="ADD" OnClick="ButtonAgregar_Click" />
            </div>

            <div class="row justify-content-center mt-3">
                <div class="col-lg-11">
                    <asp:GridView ID="FacturaGridView" runat="server" AllowPaging="true" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False">
                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="NombreArticulo" HeaderText="Nombre del Articulo" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:BoundField DataField="Importe" HeaderText="Importe" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </fieldset>

        <div class="form-row">
            <div class="form-group col-md-5" style="float:left">
                <label for="TextBoxComentario">Comentario</label>
                <asp:TextBox TextMode="MultiLine" class="form-control" ID="TextBoxComentario" runat="server" placeholder="Escriba un comentario" autocomplete="off"> </asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator5" ControlToValidate="TextBoxComentario" runat="server" Display="Dynamic" ErrorMessage="Introduzca un comentario"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-md-3 " style="margin-left:350px;">
                <label for="TextBoxTotal">Total</label>
                <asp:TextBox class="form-control" ReadOnly="true" ID="TextBoxTotal" runat="server" autocomplete="off"> </asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator4" ControlToValidate="TextBoxTotal" runat="server" Display="Dynamic" ErrorMessage="Total"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="btn-block text-center" >
            <asp:Button class="btn btn-primary" ID="ButtonNuevo" runat="server" Text="Nuevo" OnClick="ButtonNuevo_Click" />
            <asp:Button class="btn btn-success" ValidationGroup="save" ID="ButtonGuardar" runat="server" Text="Guardar" OnClick="ButtonGuardar_Click" />
            <asp:Button class="btn btn-danger" ValidationGroup="id_f" ID="ButtonEliminar" runat="server" Text="Eliminar" OnClick="ButtonEliminar_Click" />
        </div>
    </div>

</asp:Content>