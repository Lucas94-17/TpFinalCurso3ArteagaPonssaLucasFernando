using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categorias> listar()
        {
            List<Categorias> categoriasLista = new List<Categorias>();
            AccesodeDatos datos = new AccesodeDatos();
            try
            {
                datos.setearConsulta("Select Id ,Descripcion from categorias");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    categoriasLista.Add(aux);

                }
                return categoriasLista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
