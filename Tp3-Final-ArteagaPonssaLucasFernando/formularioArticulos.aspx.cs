using dominio;
using negocio;
using negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp3_Final_ArteagaPonssaLucasFernando
{
    public partial class formularioArticulos : System.Web.UI.Page
    {
        public bool botonEliminar { get; set; }
        public bool botonEliminarConf { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            botonEliminar = false;
            botonEliminarConf = false;
            txtId.Enabled = false;
            if (!Seguridad.esAdmin(Session["trainee"]))
            {
                Session.Add("error", "Se requiere permisos de admin para acceder a esta pantalla");
                Response.Redirect("Error.aspx", false);
            }

            if (!IsPostBack)
            {
                CategoriaNegocio negocioCategorias = new CategoriaNegocio();
                MarcaNegocio negocioMarcas = new MarcaNegocio();

                List<Categorias> listaCategorias = negocioCategorias.listar();
                List<Marcas> listaMarcas = negocioMarcas.listar();

                dropCategoria.DataSource = listaCategorias;
                dropCategoria.DataValueField = "id";
                dropCategoria.DataTextField = "Descripcion";
                dropCategoria.DataBind();

                dropMarca.DataSource = listaMarcas;
                dropMarca.DataValueField = "id";
                dropMarca.DataTextField = "Descripcion";
                dropMarca.DataBind();
            }
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                botonEliminar = true;
                Articulo articulo = new Articulo();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Articulo seleccionado = (articuloNegocio.listar(id)[0]);

                Session.Add("ArticuloSeleccionado", seleccionado);

                txtCodigo.Text = seleccionado.Codigo;
                txtId.Text = id;
                txtUrlImagen.Text = seleccionado.urlImage.ToString();

                txtDescripcion.Text = seleccionado.Descripcion;
                txtNombre.Text = seleccionado.Nombre;
                txtPrecio.Text = seleccionado.Precio.ToString();
                dropCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                dropMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                txtUrlImagen_TextChanged(sender, e);
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo articulo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.urlImage = txtUrlImagen.Text;

                articulo.Categoria = new Categorias();
                articulo.Categoria.Id = int.Parse(dropCategoria.SelectedValue);

                articulo.Marca = new Marcas();
                articulo.Marca.Id = int.Parse(dropMarca.SelectedValue);
                if (Request.QueryString["id"] != null)
                {
                    articulo.Id = int.Parse(txtId.Text);
                    negocio.modificar(articulo);
                    Response.Redirect("ListarArticulo.aspx", false);
                }
                else
                {
                    negocio.agregar(articulo);
                    Response.Redirect("ListarArticulo.aspx", false);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

            Response.Redirect("ListarArticulo.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            botonEliminarConf = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckConfirmarEliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListarArticulo.aspx", false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}