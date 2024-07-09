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
    public partial class ListarArticulo : System.Web.UI.Page
    {
        public bool filtroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            filtroAvanzado = false;
            if (!Seguridad.esAdmin(Session["trainee"]))
            {
                Session.Add("error", "Se requiere permisos de admin para acceder a esta pantalla");
                Response.Redirect("Default.aspx", false);
            }

            if (!IsPostBack)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Session.Add("listaArticulos", articuloNegocio.listarSp());
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();

            }


        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("formularioArticulos.aspx?id=" + id);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("formularioArticulos.aspx", false);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltrar.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {

        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = chkAvanzado.Checked;
            txtFiltrar.Enabled = !filtroAvanzado;
        }

        protected void ddlcampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = ddlcampo.SelectedIndex.ToString();
            ddlCriterio.Items.Clear();
            if (opcion == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.filtrar(
                    ddlcampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}