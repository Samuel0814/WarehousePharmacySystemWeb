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
    public partial class rClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            TextBoxClienteID.Text = String.Empty;
            TextBoxNombre.Text = String.Empty;
            TextBoxApellido.Text = String.Empty;
            TextBoxTelefono.Text = String.Empty;
            TextBoxDireccion.Text = String.Empty;
            TextBoxEmail.Text = String.Empty;
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RepositorioBase<Clientes> rb = new RepositorioBase<Clientes>();

                int id = 0;

                if (ComprobarID(id) == 0)
                {
                    if (rb.Guardar(LlenaClase()))
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Cliente Guardado');", addScriptTags: true);
                    ClearAll();
                }
                else
                {
                    if (rb.Modificar(LlenaClase()))
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Cliente Modificado');", addScriptTags: true);
                    ClearAll();
                }
            }
        }

        private Clientes LlenaClase()
        {
            int id = 0;

            return new Clientes(
                ComprobarID(id),
                TextBoxNombre.Text,
                TextBoxApellido.Text,
                TextBoxTelefono.Text,
                TextBoxDireccion.Text,
                TextBoxEmail.Text
                );
        }

        private int ComprobarID(int id)
        {
            if (TextBoxClienteID.Text == String.Empty)
                id = 0;
            else
                id = int.Parse(TextBoxClienteID.Text);
            return id;
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> clienteRepository = new RepositorioBase<Clientes>();
            Clientes cliente = clienteRepository.Buscar(int.Parse(TextBoxClienteID.Text));

            int.TryParse(TextBoxClienteID.Text, out int id);

            if (cliente != null)
            {
                clienteRepository.Eliminar(int.Parse(TextBoxClienteID.Text));
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Cliente Eliminado');", addScriptTags: true);
                ClearAll();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('No se puede eliminar un cliente que no existe');", addScriptTags: true);
            }
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> clienteRepository = new RepositorioBase<Clientes>();
            Clientes cliente = clienteRepository.Buscar(int.Parse(TextBoxClienteID.Text));

            if (cliente != null)
            {
                LlenarCampos(cliente);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Cliente Encontrado');", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Cliente no Encontrado');", addScriptTags: true);
            }
        }

        private void LlenarCampos(Clientes cliente)
        {
            TextBoxNombre.Text = cliente.Nombre;
            TextBoxApellido.Text = cliente.Apellido;
            TextBoxTelefono.Text = cliente.Telefono;
            TextBoxDireccion.Text = cliente.Direccion;
            TextBoxEmail.Text = cliente.Email;
        }
    }
}