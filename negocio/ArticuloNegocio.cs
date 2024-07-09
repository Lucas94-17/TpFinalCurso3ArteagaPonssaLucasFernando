using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;
using negocio;

namespace negocios
{
    public class ArticuloNegocio
    {
        // Declaro la Lista
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = (ConfigurationManager.AppSettings["cadenaConexion"]);
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Codigo , Nombre , A.Precio , A.Descripcion, ImagenUrl , M.Descripcion as Marca ,C.Descripcion as Categoria , A.IdCategoria, A.IdMarca,A.Id from ARTICULOS A, CATEGORIAS C , MARCAS M  WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria";
                if (id != "")
                {
                    comando.CommandText += " and A.Id=" + id;
                }
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Precio = (decimal)lector["Precio"];
                    if (!(lector["ImagenUrl"] is DBNull))
                        aux.urlImage = (string)lector["ImagenUrl"];

                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = (string)lector["Marca"];

                    //aux.Activo = (bool)lector["Activo"];
                    //aux.Activo = bool.Parse(lector["Activo"].ToString());

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Articulo> listarSp()
        {
            //Creo la instancia del objeto articulo , en tipo de lista
            List<Articulo> lista = new List<Articulo>();
            //Creo la instancia de base de datos
            AccesodeDatos datos = new AccesodeDatos();

            try
            {
                datos.setearProcedimiento("storedListar");
                //datos.setearConsulta("Select Id , Codigo from Articulos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.lector["Id"];
                    aux.Codigo = (string)datos.lector["Codigo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    aux.Precio = (decimal)datos.lector["Precio"];
                    if (!(datos.lector["ImagenUrl"] is DBNull))
                        aux.urlImage = (string)datos.lector["ImagenUrl"];

                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.lector["Id"];
                    aux.Categoria.Descripcion = (string)datos.lector["Categoria"];

                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.lector["Id"];
                    aux.Marca.Descripcion = (string)datos.lector["Marca"];

                    lista.Add(aux);
                }
                datos.conexion.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregar(Articulo articulo_Nuevo)
        {
            AccesodeDatos datos = new AccesodeDatos();

            try
            {
                datos.setearProcedimiento("storedAgregar");
                datos.setearParametro("@Codigo", articulo_Nuevo.Codigo);
                datos.setearParametro("@Nombre", articulo_Nuevo.Nombre);
                datos.setearParametro("@Descripcion", articulo_Nuevo.Descripcion);
                datos.setearParametro("@Precio", articulo_Nuevo.Precio);
                datos.setearParametro("@ImagenUrl", articulo_Nuevo.urlImage);
                datos.setearParametro("@IdCategoria", articulo_Nuevo.Categoria.Id);
                datos.setearParametro("@IdMarca", articulo_Nuevo.Marca.Id);
                datos.setearParametro("@id", articulo_Nuevo.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo articulo_modificar)
        {
            AccesodeDatos datos = new AccesodeDatos();
            try
            {
                datos.setearProcedimiento("storedmodificarArticulo");
                datos.setearParametro("@Codigo", articulo_modificar.Codigo);
                datos.setearParametro("@Nombre", articulo_modificar.Nombre);
                datos.setearParametro("@Descripcion", articulo_modificar.Descripcion);
                datos.setearParametro("@ImagenUrl", articulo_modificar.urlImage);
                datos.setearParametro("@IdCategoria", articulo_modificar.Categoria.Id);
                datos.setearParametro("@IdMarca", articulo_modificar.Marca.Id);
                datos.setearParametro("@Precio", articulo_modificar.Precio);
                datos.setearParametro("@Id", articulo_modificar.Id);
                //Console.WriteLine(articulo_modificar.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int Id)
        {
            AccesodeDatos datos = new AccesodeDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where Id = @Id");
                datos.setearParametro("@Id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesodeDatos datos = new AccesodeDatos();
            
            try
            {
                string consulta = "Select Codigo , Nombre, A.Descripcion ,ImagenUrl, Precio , M.Descripcion  Marca, C.Descripcion Categoria, A.IdCategoria,A.IdMarca , A.Id  from ARTICULOS A , MARCAS M , CATEGORIAS C  where M.Id = A.IdMarca AND C.Id = A.IdCategoria AND ";
                Console.WriteLine(consulta);
                Console.WriteLine(filtro);
                if (campo == "Codigo")
                {
                    consulta += "Codigo = '" + filtro + "'";

                }
                else if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like'%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Descripcion")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while(datos.lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.urlImage = (string)datos.Lector["ImagenUrl"];

                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    articulos.Add(aux);
                }
                return articulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

}
