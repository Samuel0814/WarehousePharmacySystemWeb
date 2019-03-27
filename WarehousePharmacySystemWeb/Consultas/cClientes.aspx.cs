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
        BLL.RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();

        Expression<Func<Clientes, bool>> filtro = x => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientesReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ClientesReportViewer.Reset();
                ClientesReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoClientes.rdlc");

                ClientesReportViewer.LocalReport.DataSources.Clear();
            }
        }


        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Filtrar();
            ClienteGridView.DataSource = repositorio.GetList(filtro);
            ClienteGridView.DataBind();
        }

        private void Filtrar()
        {
            int id = 0;
            switch (DropDownListFiltro.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;

                case 1://Cliente ID
                    id = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.IdCliente == id);
                    break;

                case 2://Nombre cliente
                    filtro = (x => x.Nombre.Contains(TextBoxBuscar.Text));
                    break;

                case 3://ApellidoCliente
                    filtro = (x => x.Apellido.Contains(TextBoxBuscar.Text));
                    break;

                case 4://Email
                    filtro = (x => x.Email.Contains(TextBoxBuscar.Text));
                    break;
            }
        }


        protected void ClienteGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClienteGridView.DataSource = repositorio.GetList(filtro);
            ClienteGridView.PageIndex = e.NewPageIndex;
            ClienteGridView.DataBind();
        }



        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Filtrar();
            ClientesReportViewer.LocalReport.DataSources.Clear();
            //ClientesReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Clientes", repositorio.GetList(filter)));
            ClientesReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Clientes", repositorio.GetList(filtro)));
            ClientesReportViewer.LocalReport.Refresh();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ReporteModal", "$('#ReporteModal').modal();", true);
        }

        
    }
}