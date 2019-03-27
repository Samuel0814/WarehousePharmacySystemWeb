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
    public partial class cFacturas : System.Web.UI.Page
    {
        RepositorioBase<Facturas> repositorio = new RepositorioBase<Facturas>();

        Expression<Func<Facturas, bool>> filter = x => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxFechaInicial.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            TextBoxFechaFinal.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

            FacturasReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            FacturasReportViewer.Reset();
            FacturasReportViewer.LocalReport.DataSources.Clear();
            FacturasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoFacturas.rdlc");
        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Filtrar();
            FacturasReportViewer.LocalReport.DataSources.Clear();
            FacturasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetListadoFacturas", repositorio.GetList(filter)));
            FacturasReportViewer.LocalReport.Refresh();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ReporteModal", "$('#ReporteModal').modal();", true);
        }

        protected void FacturaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            FacturaGridView.DataSource = repositorio.GetList(filter);
            FacturaGridView.PageIndex = e.NewPageIndex;
            FacturaGridView.DataBind();
        }

        private void Filtrar()
        {
            DateTime fInicial = DateTime.Parse(TextBoxFechaInicial.Text);
            DateTime fFinal = DateTime.Parse(TextBoxFechaFinal.Text);

            int id = 0;
            switch (DropDownListFiltro.SelectedIndex)
            {
                case 0://Todo
                    filter = x => true;
                    break;

                case 1://FacturaID
                    id = int.Parse(TextBoxBuscar.Text);
                    filter = (x => x.IdFactura.Equals(id) && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;

                case 2://ClienteID
                    id = int.Parse(TextBoxBuscar.Text);
                    filter = (x => x.IdCliente.Equals(id) && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;

             
            }
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Filtrar();
            RepositorioBase<Facturas> rep = new RepositorioBase<Facturas>();
            FacturaGridView.DataSource = rep.GetList(filter);
            FacturaGridView.DataBind();
        }
    }
}