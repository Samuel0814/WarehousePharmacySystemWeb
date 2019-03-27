using BLL;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarehousePharmacySystemWeb.Registros
{
    public partial class rFacturas : System.Web.UI.Page
    {
        List<FacturasDetalle> detalle = new List<FacturasDetalle>();
        public bool active { get; set; }
        double total;
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState.Add("Detalle", detalle);
                ViewState.Add("Active", active);
            }
            else
            {
                detalle = (List<FacturasDetalle>)ViewState["Detalle"];
                active = (bool)ViewState["Active"];
            }


            TextBoxFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void ButtonBuscarFactura_Click(object sender, EventArgs e)
        {
            RepositorioFactura rep = new RepositorioFactura();

            Facturas facturas = rep.Buscar(int.Parse(TextBoxFacturaID.Text));
            

            if (facturas != null)
            {
                LlenarCamposFactura(facturas);
                active = true;
                ViewState["Active"] = active;
                //_Visible();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Factura encontrada');", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Factura no Encontrada');", addScriptTags: true);
            }
        }

        private void LlenarCamposFactura(Facturas facturas)
        {
            TextBoxFacturaID.Text = facturas.IdFactura.ToString();
            TextBoxClienteID.Text = facturas.IdCliente.ToString();
           // TextboxArticuloID.Text = facturas.IdArticulo.ToString();
            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();
            Clientes Clientes = client.Buscar(int.Parse(TextBoxClienteID.Text));
            LlenarCamposClientes(Clientes);

            TextBoxCantidadArticulo.Text = String.Empty;

            TextBoxFecha.Text = facturas.Fecha.ToString("yyyy-MM-dd");
            TextBoxComentario.Text = facturas.Observacion;
            TextBoxTotal.Text = facturas.Monto.ToString();
            FacturaGridView.DataSource = facturas.Lista;
            FacturaGridView.DataBind();
            ViewState["Detalle"] = facturas.Lista;
        }

        protected void ButtonBuscarCliente_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> client = new RepositorioBase<Clientes>();
            Clientes Client = null;
            if (!TextBoxClienteID.Text.Equals(string.Empty))
            {
                Client = client.Buscar(int.Parse(TextBoxClienteID.Text));
               
            }
            

            if (Client != null)
            {
                LlenarCamposClientes(Client);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Cliente Encontrado');", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Cliente no Encontrado');", addScriptTags: true);
            }
        }


        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulos> art = new RepositorioBase<Articulos>();
            FacturasDetalle facdetalle = new FacturasDetalle();
            Facturas facturas = new Facturas();

            var buscar = art.Buscar(int.Parse(TextboxArticuloID.Text));
            facdetalle.NombreArticulo = buscar.Nombre;
            facdetalle.Precio = buscar.Precio;
            facdetalle.Importe = facdetalle.Precio * int.Parse(TextBoxCantidadArticulo.Text);
            facdetalle.IDArt = int.Parse(TextboxArticuloID.Text); 
            facdetalle.Cantidad = int.Parse(TextBoxCantidadArticulo.Text);

            total += facdetalle.Importe;

            TextBoxTotal.Text = total.ToString();

            detalle.Add(facdetalle);
            FacturaGridView.DataSource = detalle;
            FacturaGridView.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            TextBoxClienteID.Text = String.Empty;
            TextboxArticuloID.Text = String.Empty;
            TextBoxFacturaID.Text = String.Empty;
            TextBoxFecha.Text = String.Empty;
            TextBoxComentario.Text = String.Empty;
            TextBoxTotal.Text = String.Empty;
            TextBoxNombreCliente.Text = String.Empty;
            TextBoxApellidoCliente.Text = String.Empty;
            TextBoxTelefonoCliente.Text = String.Empty;
            TextBoxDireccionCliente.Text = String.Empty;
            TextBoxNombreArticulo.Text = String.Empty;
            TextBoxPrecioArticulo.Text = String.Empty;
            TextBoxCantidadArticulo.Text = String.Empty;
            TextBoxImporteArticulo.Text = String.Empty;
            FacturaGridView.DataSource = null;
            FacturaGridView.DataBind();
            active = false;
            ViewState["Active"] = active;
            //Invisible();
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RepositorioFactura rb = new RepositorioFactura(); ;

                int id = 0;

                if (ComprobarID(id) == 0)
                {
                    if (rb.Guardar(LlenaClase()))
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Facturas Guardada');", addScriptTags: true);
                        ClearAll();
                        total = 0;
                    }

                }
                else
                {
                    if(rb.Modificar(LlenaClase()))
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Factura Modificada');", addScriptTags: true);
                    ClearAll();
                }
            }
        }

        private Facturas LlenaClase()
        {
            int id = 0;
            return new Facturas(
                ComprobarID(id),
                int.Parse(TextBoxClienteID.Text),
                Convert.ToDateTime(TextBoxFecha.Text),
                double.Parse(TextBoxTotal.Text),
                TextBoxComentario.Text,
                detalle,
                int.Parse(TextBoxCantidadArticulo.Text)
                );
        }

        private int ComprobarID(int id)
        {
            if (TextBoxFacturaID.Text == String.Empty)
                id = 0;
            else
                id = int.Parse(TextBoxFacturaID.Text);
            return id;
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioFactura rep = new RepositorioFactura();
            Facturas facturas = rep.Buscar(int.Parse(TextBoxFacturaID.Text));

            if (facturas != null)
            {
                if (rep.Eliminar(int.Parse(TextBoxFacturaID.Text)))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Factura eliminada')", true);
                    ClearAll();
                    //Invisible();
                }
                else
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('No se pudo eliminar la factura')", true);
            }
        }

        //private void _Visible()
        //{
        //    TextBoxTotal.Visible = true;
        //    ButtonNuevo.Visible = true;
        //    ButtonGuardar.Visible = true;
        //    ButtonEliminar.Visible = true;
        //}

        //private void Invisible()
        //{
        //    TextBoxTotal.Visible = false;
        //    ButtonNuevo.Visible = false;
        //    ButtonGuardar.Visible = false;
        //    ButtonEliminar.Visible = false;
        //}


        protected void TextBoxProductoID_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscarArticulo_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulos> TRA = new RepositorioBase<Articulos>();
            Articulos articulos = null;


            if (!TextboxArticuloID.Text.Equals(String.Empty)) { 
             articulos = TRA.Buscar(int.Parse(TextboxArticuloID.Text));
               }

            if (articulos != null   )
            {
                LlenarCamposArticulos(articulos);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Articulo Encontrado');", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Articulo no Encontrado');", addScriptTags: true);
            }
        }
        private void LlenarCamposArticulos(Articulos articulos)
        {
            TextboxArticuloID.Text = articulos.IdArticulos.ToString();
            TextBoxNombreArticulo.Text = articulos.Nombre.ToString();
            TextBoxPrecioArticulo.Text = articulos.Precio.ToString();
            TextBoxImporteArticulo.Text = articulos.Costo.ToString();
            
        }

        private void LlenarCamposClientes(Clientes clientes)
        {
            TextBoxClienteID.Text = clientes.IdCliente.ToString();
            TextBoxNombreCliente.Text = clientes.Nombre.ToString();
            TextBoxApellidoCliente.Text = clientes.Apellido.ToString();
            TextBoxTelefonoCliente.Text = clientes.Telefono.ToString();
            TextBoxDireccionCliente.Text = clientes.Direccion.ToString();

        }

        protected void TextBoxCantidadArticulo_TextChanged(object sender, EventArgs e)
        {
            //Contexto db = new Contexto();
            //var articulo = db.Articulos.Find(TextboxArticuloID.Text);

            //if (Convert.ToInt32(TextBoxCantidadArticulo.ToString()) > Convert.ToInt32(articulo.Existencia.ToString()))
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('La cantidad no debe exceder el inventario ');", addScriptTags: true);
            //    TextBoxCantidadArticulo.Text = "0";
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Articulo agregado correctamente ');", addScriptTags: true);
            //}
        }
    }
}