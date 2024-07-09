using dominio;
using negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp3_Final_ArteagaPonssaLucasFernando
{
    public partial class PaginaDetalle : System.Web.UI.Page
    {
        Articulo articulo = new Articulo();
        ArticuloNegocio negocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                Validacion validacion = new Validacion();
                List<Articulo> lista = negocio.listar();
                Articulo seleccionado = (negocio.listar(id))[0];
                Session.Add("articuloSeleccionado", seleccionado);
                //cargar los elementos-
                lblDescripcion.Text = seleccionado.Descripcion;
                lblNombre.Text = seleccionado.Nombre.ToString();
                lblPrecio.Text = "$" + seleccionado.Precio.ToString();
                lblMarca.Text = seleccionado.Marca.Descripcion.ToString();
                lblCategoria.Text = seleccionado.Categoria.Descripcion.ToString();

                string imagenUrl = seleccionado.urlImage.ToString();

                if (!string.IsNullOrEmpty(imagenUrl))
                {
                    bool isValid = validacion.IsValidImageUrl(imagenUrl);
                    if (isValid)
                    {
                        imgArticulo.ImageUrl = seleccionado.urlImage;
                        imgArticulo.Visible = true;
                    }
                }
            }
        }


    }
}
