using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marcas> listar()
        {
            List<Marcas> listaMarca= new List<Marcas>();
            AccesodeDatos datos = new AccesodeDatos();
            try
            {
                datos.setearConsulta("Select Id,Descripcion from Marcas");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    listaMarca.Add(aux);
                }
                return listaMarca;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
