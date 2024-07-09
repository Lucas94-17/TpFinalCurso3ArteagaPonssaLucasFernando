using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class TraineeNegocio
    {
        //Funcion para insertar un nuevo usuario
        public int insertarNuevo(Trainee nuevo)
        {
            AccesodeDatos datos = new AccesodeDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email",nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
                datos.setearParametro("@nombre",nuevo.Nombre);
                datos.setearParametro("@apellido",nuevo.Apellido);
                datos.setearParametro("@urlImagenPerfil",nuevo.urlImagenPerfil);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool Login(Trainee trainee)
        {
            AccesodeDatos datos = new AccesodeDatos();
            try
            {
                datos.setearConsulta("Select id , email , pass , nombre , apellido , urlImagenPerfil , admin from USERS where email = @email AND pass = @pass");
                datos.setearParametro("@email",trainee.Email);
                datos.setearParametro("@pass", trainee.Pass);             
                datos.ejecutarLectura();
                if (datos.lector.Read())
                {
                    trainee.Id = (int)datos.lector["Id"];
                    trainee.Admin = (bool)datos.lector["admin"];
                    if (!(datos.lector["urlImagenPerfil"] is DBNull))
                    {
                        trainee.urlImagenPerfil = (string)datos.lector["urlImagenPerfil"];
                    }if (!(datos.lector["Nombre"] is DBNull)) 
                    {
                        trainee.Nombre = (string)datos.lector["Nombre"];
                    }
                    if (!(datos.lector["apellido"] is DBNull))
                    {
                        trainee.Apellido = (string)datos.lector["apellido"];
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void actualizar(Trainee user) {
            AccesodeDatos datos = new AccesodeDatos();
            try
            {
                datos.setearConsulta("Update USERS set urlImagenPerfil = @urlImagenPerfil , nombre = @nombre , apellido = @apellido ,  pass = @pass where Id = @Id");
                datos.setearParametro("@Id" , user.Id);
                datos.setearParametro("@apellido",user.Apellido);
                datos.setearParametro("@nombre",user.Nombre);
                datos.setearParametro("@urlImagenPerfil", (object)user.urlImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@pass", user.Pass);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
