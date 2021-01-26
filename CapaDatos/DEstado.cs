using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEstado
    {
        private int _IdEstado;
        private string _Nestado;

        public int IdEstado { get => _IdEstado; set => _IdEstado = value; }
        public string Nestado { get => _Nestado; set => _Nestado = value; }

        public DEstado()
        {

        }
        public DEstado(int id,string nombre)
        {
            this.IdEstado = id;
            this.Nestado = nombre;

        }

        private Conexion Conexion = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader LeerFilas;

        public DataTable ListarEstado()
        {
            DataTable Tabla = new DataTable();
            cmd.Connection = Conexion.AbrirConexion();
            cmd.CommandText = "spMostrarEstado";
            cmd.CommandType = CommandType.StoredProcedure;
            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            cmd.Connection = Conexion.CerrarConexion();
            return Tabla;
        }

        public string InsertarEstado(DEstado Estado)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spInsertarEstado";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@nestado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 30;
                ParEstado.Value = Estado.Nestado;
                cmd.Parameters.Add(ParEstado);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "NO se ingreso el registro";
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                cmd.Connection = Conexion.CerrarConexion();
            }
            return rpta;
        }

        public string EditarEstado(DEstado Estado)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEditarEstado";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Estado.IdEstado;
                cmd.Parameters.Add(ParId);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nestado";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 10;
                ParNombre.Value = Estado.Nestado;
                cmd.Parameters.Add(ParNombre);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "NO se ingreso el registro";
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                cmd.Connection = Conexion.CerrarConexion();
            }
            return rpta;
        }

        public string EliminarEstado(DEstado Estado)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEliminarEstado";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Estado.IdEstado;
                cmd.Parameters.Add(ParId);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el registro";
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                cmd.Connection = Conexion.CerrarConexion();
            }
            return rpta;
        }

    }
}
