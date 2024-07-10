using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Tp3_Final_ArteagaPonssaLucasFernando
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition(
           "jquery",
           new ScriptResourceDefinition
           {
               Path = "~/Scripts/jquery-3.6.0.min.js",  // Actualiza el camino según sea necesario
               DebugPath = "~/Scripts/jquery-3.6.0.js",
               CdnPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js",
               CdnDebugPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.js"
           });
        }
        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
            {
                // Pass the error on to the error page.
                Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
            }
        }
    }
}