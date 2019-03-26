using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarehousePharmacySystemWeb.SignUp
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void ButtonComeBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> usuarioRepository = new RepositorioBase<Usuarios>();
            Usuarios usuario = usuarioRepository.Buscar(int.Parse(TextBoxUsuarioID.Text));

            if (usuario != null)
            {
                LlenarCampos(usuario);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Usuario Encontrado');", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Usuario no Encontrado');", addScriptTags: true);
            }
        }

        private void LlenarCampos(Usuarios usuario)
        {
            TextBoxUsername.Text = usuario.Username;
            TextBoxPassword.Text = usuario.Password;
            TextBoxFecha.Text = usuario.Fecha.ToString("yyyy-MM-dd");
            TextBoxNombre.Text = usuario.Nombre;
            TextBoxEmail.Text = usuario.Comentario;
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            TextBoxUsuarioID.Text = String.Empty;
            TextBoxNombre.Text = String.Empty;
            TextBoxUsername.Text = String.Empty;
            TextBoxPassword.Text = String.Empty;
            TextBoxConfirmacionPassword.Text = String.Empty;
            TextBoxEmail.Text = String.Empty;
            TextBoxFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RepositorioBase<Usuarios> usuario = new RepositorioBase<Usuarios>();

                int id = 0;

                if (TextBoxPassword.Text == TextBoxConfirmacionPassword.Text)
                {
                    if (ComprobarID(id) == 0)
                    {
                        if (usuario.Guardar(LlenaClase()))
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Usuario Guardado');", addScriptTags: true);
                        ClearAll();
                    }
                    else
                    {
                        if (usuario.Modificar(LlenaClase()))
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Usuario Modificado');", addScriptTags: true);
                        ClearAll();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['info']('Recuerde que la contraseña debe ser igual a la confirmacion de esta');", addScriptTags: true);
                }
            }
        }

        private Usuarios LlenaClase()
        {
            int id = 0;
            return new Usuarios(
                ComprobarID(id),
                TextBoxUsername.Text,
                TextBoxPassword.Text,
                Convert.ToDateTime(TextBoxFecha.Text),
                TextBoxNombre.Text,
                TextBoxEmail.Text
                );
        }

        private int ComprobarID(int id)
        {
            if (TextBoxUsuarioID.Text == String.Empty)
                id = 0;
            else
                id = int.Parse(TextBoxUsuarioID.Text);
            return id;
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> usuarioRepository = new RepositorioBase<Usuarios>();
            Usuarios usuario = usuarioRepository.Buscar(int.Parse(TextBoxUsuarioID.Text));

            int.TryParse(TextBoxUsuarioID.Text, out int id);

            if (usuario != null)
            {
                usuarioRepository.Eliminar(int.Parse(TextBoxUsuarioID.Text));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Usuario Eliminado');", addScriptTags: true);
                ClearAll();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se puede eliminar un usuario que no existe');", addScriptTags: true);
            }
        }
    }
}