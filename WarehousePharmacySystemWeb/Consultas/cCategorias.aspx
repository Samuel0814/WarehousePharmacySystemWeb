<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cCategorias.aspx.cs" Inherits="WarehousePharmacySystemWeb.Consultas.cCategorias" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="page-header text-center">
            <h2 style="color: #358CCE">Consulta de Categorias</h2>
        </div>

        <hr style="color: #358CCE" />

        <div>
            <div class="form-group">
                <div class="row justify-content-center">
                    <div class="col-md-2">
                        <label for="DropDownListFiltro">Filtro:</label>
                        <asp:DropDownList ID="DropDownListFiltro" CssClass="form-control" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>CategoriaId</asp:ListItem>
                            <asp:ListItem>Nombre de la categoria</asp:ListItem>
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
                        <asp:GridView ID="CategoriaGridView" runat="server" AllowPaging="true" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="CategoriaId" HeaderText="Categoria ID" />
                                <asp:BoundField DataField="NombreCategoria" HeaderText="Nombre de la Categoria" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <!-- Large modal -->
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg">Reporte</button>

                <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Reporte de Categorias</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div id="div1">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                    <rsweb:reportviewer id="CategoriasReportViewer" width="100%" runat="server"></rsweb:reportviewer>
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