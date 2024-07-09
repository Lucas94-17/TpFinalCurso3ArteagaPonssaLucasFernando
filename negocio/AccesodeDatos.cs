using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace negocio
{
    public class AccesodeDatos
    {
        //parametros para ingresar en la base de datos
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesodeDatos()
        {
            conexion = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //Setea el procedimiento creado en la base de datos
        public void setearProcedimiento(string storedprocedure)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = storedprocedure;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int ejecutarAccionScalar()
        {
            if (comando == null)
            {
                throw new NullReferenceException("El comando no ha sido inicializado.");
            }

            if (conexion == null)
            {
                throw new NullReferenceException("La conexión no ha sido inicializada.");
            }

            comando.Connection = conexion;
            try
            {
                conexion.Open();
                object result = comando.ExecuteScalar();
                return int.Parse(result.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
