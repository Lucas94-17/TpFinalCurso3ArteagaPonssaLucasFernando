using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp3_Final_ArteagaPonssaLucasFernando
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {

            try
            {
                Trainee user = new Trainee();
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;
                //user.urlImagenPerfil = txtUrlImagen.Text;
                //if (txtImagen.PostedFile.FileName != "")
                //{
                //    string ruta = Server.MapPath("./Img/");
                //    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Nombre + ".jpg");
                //    user.urlImagenPerfil = "perfil-" + user.Nombre + ".jpg";
                //}
                //Image imgAvatar = (Image)Master.FindControl("imgAvatar");
                //imgAvatar.ImageUrl = "~/Img/" + user.urlImagenPerfil;
                user.urlImagenPerfil = "imagenes-de-usuario" + ".png";
                user.Id = traineeNegocio.insertarNuevo(user);
                Session.Add("trainee", user);
                Response.Redirect("MiPerfil.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }


    }
}
