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
    public partial class cCategorias : System.Web.UI.Page
    {
        BLL.RepositorioBase<Categorias> repositorio = new BLL.RepositorioBase<Categorias>();

        Expression<Func<Categorias, bool>> filtro = x => true;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriasReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                CategoriasReportViewer.Reset();
                CategoriasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoCategorias.rdlc");

                Filtrar();
                CategoriasReportViewer.LocalReport.DataSources.Clear();

                CategoriasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", repositorio.GetList(x => true)));
                CategoriasReportViewer.LocalReport.Refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ReporteModal", "$('#ReporteModal').modal();", true);
            }
            
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {

            Filtrar();
            CategoriaGridView.DataSource = repositorio.GetList(filtro);
            CategoriaGridView.DataBind();
        }

        private void Filtrar()
        {
            int id = 0;

            switch (DropDownListFiltro.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;

                case 1://CategoriaID
                    id = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.CategoriaId == id);
                    break;

                case 2://Nombre Categoria
                    filtro = (x => x.NombreCategoria.Contains(TextBoxBuscar.Text));
                    break;
            }
        }

        protected void CategoriaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RepositorioBase<Categorias> rb = new RepositorioBase<Categorias>();
            CategoriaGridView.DataSource = rb.GetList(filtro);
            CategoriaGridView.PageIndex = e.NewPageIndex;
            CategoriaGridView.DataBind();
        }

    }
}