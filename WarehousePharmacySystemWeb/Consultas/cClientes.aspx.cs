using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarehousePharmacySystemWeb.Consultas
{
    public partial class cClientes : System.Web.UI.Page
    {
        Expression<Func<Clientes, bool>> filter = x => true;

        RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();

        protected void Page_Load(object sender, EventArgs e)
        {
          
            ClientesReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            ClientesReportViewer.Reset();
            ClientesReportViewer.LocalReport.DataSources.Clear();
            ClientesReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoClientes.rdlc");
        }

        protected void ClientesReportViewer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClienteGridView.DataSource = repositorio.GetList(filter);
            ClienteGridView.PageIndex = e.NewPageIndex;
            ClienteGridView.DataBind();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Filtrar();
            ClienteGridView.DataSource = repositorio.GetList(filter);
            ClienteGridView.DataBind();
        }

        private void Filtrar()
        {
            int id = 0;
            switch (DropDownListFiltro.SelectedIndex)
            {
                case 0://Todo
                    filter = x => true;
                    break;

                case 1://Cliente ID
                    id = int.Parse(TextBoxBuscar.Text);
                    filter = (x => x.IdCliente == id);
                    break;

                case 2://Nombre cliente
                    filter = (x => x.Nombre.Contains(TextBoxBuscar.Text));
                    break;

                case 3://ApellidoCliente
                    filter = (x => x.Apellido.Contains(TextBoxBuscar.Text));
                    break;

                case 4://Email
                    filter = (x => x.Email.Contains(TextBoxBuscar.Text));
                    break;
            }
        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Filtrar();
            ClientesReportViewer.LocalReport.DataSources.Clear();
            ClientesReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetListadoClientes", repositorio.GetList(filter)));
            ClientesReportViewer.LocalReport.Refresh();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ReporteModal", "$('#ReporteModal').modal();", true);
        }
    }
}