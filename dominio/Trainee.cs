using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Trainee
    {
        public int Id { get; set; }
        //Ejemplo de encapsulamiento ;)
        private string email;
        //Metodos
        public string Email
        {
            get { return email; }
            set
            {
                if (value != "")
                {
                    email = value;
                }
                else
                {
                    throw new Exception("El email esta vacio");
                }
            }
        }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string urlImagenPerfil { get; set; }
        public bool Admin { get; set; }
    }
}
