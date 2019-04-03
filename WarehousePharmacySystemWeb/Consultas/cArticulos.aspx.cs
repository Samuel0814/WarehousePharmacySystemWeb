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
    public partial class cArticulos : System.Web.UI.Page
    {
        BLL.RepositorioBase<Articulos> repositorio = new BLL.RepositorioBase<Articulos>();

        Expression<Func<Articulos, bool>> filtro = x => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                TextBoxFechaInicial.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                TextBoxFechaFinal.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

                ArticulosReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ArticulosReportViewer.Reset();

                ArticulosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoArticulos.rdlc");
                ArticulosReportViewer.LocalReport.DataSources.Clear();
            }
            
        }

        protected void ArticuloGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RepositorioBase<Articulos> rep = new RepositorioBase<Articulos>();
            ArticuloGridView.DataSource = rep.GetList(filtro);
            ArticuloGridView.PageIndex = e.NewPageIndex;
            ArticuloGridView.DataBind();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Filtrar();
            ArticuloGridView.DataSource = repositorio.GetList(filtro);
            ArticuloGridView.DataBind();
        }

        private void Filtrar()
        {
            DateTime fInicial = DateTime.Parse(TextBoxFechaInicial.Text);
            DateTime fFinal = DateTime.Parse(TextBoxFechaFinal.Text);

            int id = 0;
            switch (DropDownListFiltro.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    
                    break;

                case 1://ArticulosID
                    id = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.IdArticulos == id && ((x.FechaDeVencimiento >= fInicial) && (x.FechaDeVencimiento <= fFinal)));
                    break;

                case 2://Nombre Articulo
                    filtro = (x => x.Nombre.Contains(TextBoxBuscar.Text) && ((x.FechaDeVencimiento >= fInicial) && (x.FechaDeVencimiento <= fFinal)));
                    break;

                case 3://Existencia
                    id = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.Existencia == id && x.FechaDeVencimiento >= fInicial && x.FechaDeVencimiento<= fFinal);
                    break;

                case 4://Costo
                    id = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.Costo == id && x.FechaDeVencimiento >= fInicial && x.FechaDeVencimiento <= fFinal);
                    break;

                case 5://Precio
                    id = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.Precio == id && x.FechaDeVencimiento >= fInicial && x.FechaDeVencimiento <= fFinal);
                    break;

            }
        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Filtrar();
            ArticulosReportViewer.LocalReport.DataSources.Clear();
            ArticulosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Articulos", repositorio.GetList(filtro)));
            ArticulosReportViewer.LocalReport.Refresh();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ReporteModal", "$('#ReporteModal').modal();", true);
        }
    }
}