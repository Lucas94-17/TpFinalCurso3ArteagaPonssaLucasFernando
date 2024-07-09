using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI.WebControls;

namespace Tp3_Final_ArteagaPonssaLucasFernando
{
    public class Validacion
    {
        public static bool validaTextoVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty((texto.Text)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsValidImageUrl(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriResult);
                    request.Method = "HEAD";
                    request.AllowAutoRedirect = false;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        string contentType = response.ContentType.ToLower();
                        return (response.StatusCode == HttpStatusCode.OK &&
                                (contentType.StartsWith("image/jpeg") ||
                                 contentType.StartsWith("image/png") ||
                                 contentType.StartsWith("image/gif") ||
                                 contentType.StartsWith("image/bmp")));
                    }
                }
                catch (WebException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
