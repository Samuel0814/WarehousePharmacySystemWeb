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
    public partial class rCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        public void ClearAll()
        {
            TextBoxCategoriasID.Text = String.Empty;
            TextBoxDescripcion.Text = String.Empty;
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RepositorioBase<Categorias> categorias = new RepositorioBase<Categorias>();

                int id = 0;

                if (ComprobarID(id) == 0)
                {
                    if (categorias.Guardar(LlenaClase()))
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Categoria Guardada');", addScriptTags: true);
                    ClearAll();
                }
                else
                {
                    if (categorias.Modificar(LlenaClase()))
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Categoria Modificada');", addScriptTags: true);
                    ClearAll();
                }
            }
        }

        private int ComprobarID(int id)
        {
            if (TextBoxCategoriasID.Text == String.Empty)
                id = 0;
            else
                id = int.Parse(TextBoxCategoriasID.Text);
            return id;
        }

        private Categorias LlenaClase()
        {
            int id = 0;
            return new Categorias(
                ComprobarID(id),
                TextBoxDescripcion.Text
                );
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> d = new RepositorioBase<Categorias>();
            Categorias d1 = d.Buscar(int.Parse(TextBoxCategoriasID.Text));

            if (d1 != null)
            {
                d.Eliminar(int.Parse(TextBoxCategoriasID.Text));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Categoria Eliminada');", addScriptTags: true);
                ClearAll();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se puede eliminar una categoria que no existe');", addScriptTags: true);
            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> rd = new RepositorioBase<Categorias>();
            Categorias d = rd.Buscar(int.Parse(TextBoxCategoriasID.Text));

            if (d != null)
            {
                TextBoxDescripcion.Text = d.NombreCategoria;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Categoria Encontrada');", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Categoria no Encontrada');", addScriptTags: true);
            }
        }
    }
}