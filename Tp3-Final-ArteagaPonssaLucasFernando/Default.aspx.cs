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
    public partial class Default : System.Web.UI.Page
    {

        // creo una lista de articulos
        public List<Articulo> ListaArticulos { get; set; }
        public void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio Articulo = new ArticuloNegocio();
            ListaArticulos = Articulo.listar();
            Articulo art = new Articulo();

            if (!IsPostBack)
            {
                Repetidor.DataSource = ListaArticulos;

                Repetidor.DataBind();
            }

        }
        protected void btnDetalle_click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            string valor = ((Button)sender).CommandArgument;
            Response.Redirect("paginaDetalle.aspx?&id=" + valor);

        }
    }
}