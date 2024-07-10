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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLoguearse_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio Negocio = new TraineeNegocio();
            try
            {
                //Validacion de texto vacio por backend
                if (Validacion.validaTextoVacio(txtEmail.Text) || Validacion.validaTextoVacio(txtPass.Text))
                {
                    Session.Add("error", "Debe completar ambos campos");
                    //Response.Redirect("Error.aspx", false);
                }
                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPass.Text;

                if (Negocio.Login(trainee))
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o password incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            //    catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                //Response.Redirect("Error.aspx", false);
            }
            //}

            //private void Page_Error(object sender, EventArgs e)
            //{
            //    Exception exc = Server.GetLastError();


            //    Session.Add("error", exc.ToString());
            //    //Response.Redirect("Error.aspx");
            //    Server.Transfer("Error.aspx");
        }
    }
}
