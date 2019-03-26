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
    public partial class cUsuarios : System.Web.UI.Page
    {
        BLL.RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();

        Expression<Func<Usuarios, bool>> filtro = x => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBoxFechaInicial.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                TextBoxFechaFinal.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

                UsuariosReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                UsuariosReportViewer.Reset();
                
                UsuariosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoUsuarios.rdlc");
                UsuariosReportViewer.LocalReport.DataSources.Clear();

                //UsuariosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Usuarios", repositorio.GetList(x => true)));
            }
        }

        protected void DatosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RepositorioBase<Usuarios> rep = new RepositorioBase<Usuarios>();
            UsuarioGridView.DataSource = rep.GetList(filtro);
            UsuarioGridView.PageIndex = e.NewPageIndex;
            UsuarioGridView.DataBind();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            Filtrar();
            RepositorioBase<Usuarios> rep = new RepositorioBase<Usuarios>();
            UsuarioGridView.DataSource = rep.GetList(filtro);
            UsuarioGridView.DataBind();
        }

        RepositorioBase<Usuarios> usuario = new RepositorioBase<Usuarios>();


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

                case 1://UsuarioId
                    id = int.Parse(TextBoxBuscar.Text);
                    filtro = (x => x.IdUsuario == id);
                    break;

                case 2://Nombre Usuario
                    filtro = (x => x.Username.Contains(TextBoxBuscar.Text) && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;

                case 3://Password
                    filtro = (x => x.Password.Contains(TextBoxBuscar.Text) && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;
            }
        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Filtrar();
            UsuariosReportViewer.LocalReport.DataSources.Clear();
            UsuariosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Usuarios", usuario.GetList(filtro)));
            UsuariosReportViewer.LocalReport.Refresh();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ReporteModal", "$('#ReporteModal').modal();", true);
        }
    }
}