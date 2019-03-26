<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cUsuarios.aspx.cs" Inherits="WarehousePharmacySystemWeb.Consultas.cUsuarios" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="page-header text-center">
            <h2 style="color: #358CCE">Consulta de Usuarios</h2>
        </div>

        <hr style="color: #358CCE" />

        <div class="form-group row justify-content-center">
            <div class="col-lg-4">
                <asp:Label ID="Label1" runat="server" Text="Fecha-inicio">Desde:</asp:Label>
                <asp:TextBox ID="TextBoxFechaInicial" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-2"></div>
            <div class="col-lg-4">
                <asp:Label ID="Label2" runat="server" Text="Fecha-inicial">Hasta:</asp:Label>
                <asp:TextBox ID="TextBoxFechaFinal" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
            </div>
        </div>

        <div>
            <div class="form-group">
                <div class="row justify-content-center">
                    <div class="col-md-2">
                        <label for="DropDownListFiltro">Filtro:</label>
                        <asp:DropDownList ID="DropDownListFiltro" CssClass="form-control" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>UsuarioId</asp:ListItem>
                            <asp:ListItem>UserName</asp:ListItem>
                            <asp:ListItem>Password</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4">
                        <label for="TextBoxBuscar">Buscar:</label>
                        <asp:TextBox ID="TextBoxBuscar" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div style="margin-top: 7px;" class="col-lg-1 p-0">
                        <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-primary mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                        <span class="fas fa-search"></span>
                        Buscar
                        </asp:LinkButton>
                    </div>
                </div>

                <div class="row justify-content-center mt-3">
                    <div class="col-lg-11">
                        <asp:GridView ID="UsuarioGridView" runat="server" AllowPaging="true" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" OnPageIndexChanging="DatosGridView_PageIndexChanging" AutoGenerateColumns="False">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="IdUsuario" HeaderText="UsuarioId" />
                                <asp:BoundField DataField="Username" HeaderText="UserName" />
                                <asp:BoundField DataField="Password" HeaderText="Password" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <div class="btn-block text-center">
                    <asp:Button CssClass="btn btn-primary" ID="ButtonImprimir" runat="server" Text="Imprimir" OnClick="ButtonImprimir_Click"/>
                </div>

                <div class="modal fade bd-example-modal-lg" id="ReporteModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Imprimir</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div id="div1">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                    <rsweb:ReportViewer ID="UsuariosReportViewer" width="100%" runat="server">
                                        <ServerReport ReportPath=""  ReportServerUrl=""/>
                                    </rsweb:ReportViewer>
                                </div>
                            </div>
                            <div class="modal-footer">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>