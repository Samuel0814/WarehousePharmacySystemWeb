﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="WarehousePharmacySystemWeb.SignUp.rUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />
    <script src="../../js/jquery-3.3.1.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <link href="../../css/toastr.css" rel="stylesheet" />
    <script src="../../js/toastr.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="width:900px;height:200px;">
            <div class="jumbotron">
                <div class="page-header text-center">
                    <h2 style="color: #358CCE">Registro de Usuarios</h2>
                </div>

                <hr style="color: #358CCE" />

                <div class="btn-block text-center">
                    <asp:Button class="btn btn-info btn-lg" ID="ButtonComeBack" runat="server" Text="Volver al LogIn" OnClick="ButtonComeBack_Click"/>
                </div>

                <label for="TextBoxUsuarioID">ID</label>
                <div class="form-row">
                    <div class="form-group col-lg-1">
                        <asp:TextBox TextMode="Number" class="form-control" ID="TextBoxUsuarioID" runat="server" placeholder="ID"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="id" SetFocusOnError="true" ForeColor="Red" ID="RequiredFieldValidator7" ControlToValidate="TextBoxUsuarioID" runat="server" Display="Dynamic" ErrorMessage="Introduzca un id"></asp:RequiredFieldValidator>
                    </div>
                    <div class="btn-group-col-md-1">
                        <asp:Button class="btn btn-primary" ValidationGroup="id" ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-md-7 col-md-offset-3">
                        <label for="TextBoxUsername">Username</label>
                        <asp:TextBox class="form-control" ID="TextBoxUsername" runat="server" placeholder="Username" autocomplete="off"> </asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator1" ControlToValidate="TextBoxUsername" runat="server" Display="Dynamic" ErrorMessage="Introduzca su Username"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-md-7 col-md-offset-3">
                        <label for="TextBoxPassword">Password</label>
                        <asp:TextBox class="form-control" TextMode="Password" ID="TextBoxPassword" runat="server" placeholder="Password" autocomplete="off"> </asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="TextBoxPassword" runat="server" Display="Dynamic" ErrorMessage="Introduzca su Password"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-md-7 col-md-offset-3">
                        <label for="TextBoxConfirmacionPassword">Confirm Password</label>
                        <asp:TextBox class="form-control" TextMode="Password" ID="TextBoxConfirmacionPassword" runat="server" placeholder="Password" autocomplete="off"> </asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator6" ControlToValidate="TextBoxConfirmacionPassword" runat="server" Display="Dynamic" ErrorMessage="Introduzca la confirmacion de Password"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-md-7 col-md-offset-3">
                        <label for="TextBoxFecha">Fecha</label>
                        <asp:TextBox TextMode="Date" class="form-control" ID="TextBoxFecha" runat="server" placeholder="Fecha de Registro del Usuario"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator3" ControlToValidate="TextBoxFecha" runat="server" Display="Dynamic" ErrorMessage="Introduzca la Fecha de registro del usuario"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-md-7 col-md-offset-3">
                        <label for="TextBoxNombre">Nombre</label>
                        <asp:TextBox class="form-control" ID="TextBoxNombre" runat="server" placeholder="Nombre del Usuario" autocomplete="off"> </asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator4" ControlToValidate="TextBoxNombre" runat="server" Display="Dynamic" ErrorMessage="Introduzca el Nombre del usuario"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group col-md-7 col-md-offset-3">
                        <label for="TextBoxEmail">Email</label>
                        <asp:TextBox TextMode="MultiLine" class="form-control" ID="TextBoxEmail" runat="server" placeholder="Email del Cliente" autocomplete="off"> </asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="save" ForeColor="Red" ID="RequiredFieldValidator5" ControlToValidate="TextBoxEmail" runat="server" Display="Dynamic" ErrorMessage="Introduzca un email"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="btn-block text-center">
                    <asp:Button class="btn btn-primary" ID="ButtonNuevo" runat="server" Text="Nuevo" OnClick="ButtonNuevo_Click" />
                    <asp:Button class="btn btn-success" ValidationGroup="save" ID="ButtonGuardar" runat="server" Text="Guardar" OnClick="ButtonGuardar_Click" />
                    <asp:Button class="btn btn-danger" ValidationGroup="id" ID="ButtonEliminar" runat="server" Text="Eliminar" OnClick="ButtonEliminar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>