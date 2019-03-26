using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarehousePharmacySystemWeb.Registros
{
    public partial class rArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListCategorias();
            }
            TextBoxFechaVencimiento.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void ListCategorias()
        {
            RepositorioBase<Categorias> rep = new RepositorioBase<Categorias>();
            DropDownListCategorias.DataSource = rep.GetList(x => true);
            DropDownListCategorias.DataValueField = "CategoriaId";
            DropDownListCategorias.DataTextField = "NombreCategoria";
            DropDownListCategorias.DataBind();
            DropDownListCategorias.Items.Insert(0, new ListItem("", ""));
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulos> ArtRepository = new RepositorioBase<Articulos>();
            Articulos articulos = ArtRepository.Buscar(int.Parse(TextBoxArticuloID.Text));

            if (articulos != null)
            {
                LlenarCampos(articulos);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Articulo Encontrado');", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Articulo no Encontrado');", addScriptTags: true);
            }
        }

        private void LlenarCampos(Articulos articulos)
        {
            DropDownListCategorias.Text = articulos.IdCategorias.ToString();
            TextBoxNombreArticulo.Text = articulos.Nombre;
            TextBoxFechaVencimiento.Text = articulos.FechaDeVencimiento.ToString("yyyy-MM-dd");
            TextBoxCosto.Text = articulos.Costo.ToString();
            TextBoxExistencia.Text = articulos.Existencia.ToString();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            TextBoxArticuloID.Text = String.Empty;
            DropDownListCategorias.Text = String.Empty;
            TextBoxNombreArticulo.Text = String.Empty;
            TextBoxFechaVencimiento.Text = String.Empty;
            TextBoxCosto.Text = String.Empty;
            TextBoxExistencia.Text = String.Empty;
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RepositorioBase<Articulos> rb = new RepositorioBase<Articulos>();

                double.TryParse(TextBoxCosto.Text, out double costo);
                double.TryParse(TextBoxPrecio.Text, out double precio);

                int id = 0;

                if (costo < precio)
                {
                    if (ComprobarID(id) == 0)
                    {
                        if (rb.Guardar(LlenaClase()))
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Articulo Guardado');", addScriptTags: true);
                        ClearAll();
                    }
                    else
                    {
                        if (rb.Modificar(LlenaClase()))
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Articulo Modificado');", addScriptTags: true);
                        ClearAll();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Recuerde que el costo debe ser menor que el precio');", addScriptTags: true);
                }
            }
        }

        private int ComprobarID(int id)
        {
            if (TextBoxArticuloID.Text == String.Empty)
                id = 0;
            else
                id = int.Parse(TextBoxArticuloID.Text);
            return id;
        }

        private Articulos LlenaClase()
        {
            int id = 0;
            return new Articulos(
                    ComprobarID(id),
                    int.Parse(DropDownListCategorias.SelectedValue),
                    TextBoxNombreArticulo.Text,
                    double.Parse(TextBoxPrecio.Text),
                    int.Parse(TextBoxExistencia.Text),
                    Convert.ToDateTime(TextBoxFechaVencimiento.Text),
                    double.Parse(TextBoxCosto.Text)
                );
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulos> ArtRepositorio = new RepositorioBase<Articulos>();
            Articulos articulos = ArtRepositorio.Buscar(int.Parse(TextBoxArticuloID.Text));

            int.TryParse(TextBoxArticuloID.Text, out int id);

            if (articulos != null)
            {
                ArtRepositorio.Eliminar(int.Parse(TextBoxArticuloID.Text));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Articulo Eliminado');", addScriptTags: true);
                ClearAll();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se puede eliminar un articulo que no existe');", addScriptTags: true);
            }
        }
    }
}