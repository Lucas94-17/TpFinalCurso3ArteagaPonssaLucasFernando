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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["trainee"]))
                    {
                        Trainee trainee = (Trainee)Session["trainee"];

                        txtEmail.Text = trainee.Email;
                        txtNombre.Text = trainee.Nombre;
                        txtApellido.Text = trainee.Apellido;
                        txtPass.Text = trainee.Pass;
                        txtEmail.Text = trainee.Email;
                        txtEmail.ReadOnly = true;
                        if (!string.IsNullOrEmpty(trainee.urlImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Img/" + trainee.urlImagenPerfil;

                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                Trainee user = (Trainee)Session["trainee"];
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Img/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.urlImagenPerfil = "perfil-" + user.Id + ".jpg";

                }

                user.Nombre = txtNombre.Text;
                user.Email = txtEmail.Text;
                user.Apellido = txtApellido.Text;
                user.Pass = txtPass.Text;
                user.Email = txtEmail.Text;
                //user.urlImagenPerfil = txtImagen.Text;
                imgNuevoPerfil.ImageUrl = "~/Img/" + user.urlImagenPerfil;
                traineeNegocio.actualizar(user);
                Image imgAvatar = (Image)Master.FindControl("imgAvatar");
                imgAvatar.ImageUrl = "~/Img/" + user.urlImagenPerfil;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}
