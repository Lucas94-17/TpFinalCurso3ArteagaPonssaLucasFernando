using dominio;
using Microsoft.Win32;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp3_Final_ArteagaPonssaLucasFernando
{
    public partial class MasterPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "../Img/imagenes-de-usuario.png";

            if (!(Page is Login || Page is Registro))
            {
                if (!(Seguridad.sesionActiva(Session["trainee"])))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    Trainee user = (Trainee)Session["trainee"];
                    lblUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.urlImagenPerfil))
                    {
                        imgAvatar.ImageUrl = "~/Img/" + user.urlImagenPerfil;
                    }
                }
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void btnMiPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }
    }
}
}