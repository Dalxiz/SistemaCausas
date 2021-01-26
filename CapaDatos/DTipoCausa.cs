using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTipoCausa
    {
        private int _IdTipo;
        private string _Ntipo;

        public int IdTipo { get => _IdTipo; set => _IdTipo = value; }
        public string Ntipo { get => _Ntipo; set => _Ntipo = value; }

        public DTipoCausa()
        {

        }
        public DTipoCausa(int id, string nombre)
        {
            this.IdTipo = id;
            this.Ntipo = nombre;
        }

        private Conexion Conexion = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader LeerFilas;

        public DataTable ListarTipo()
        {
            DataTable Tabla = new DataTable();
            cmd.Connection = Conexion.AbrirConexion();
            cmd.CommandText = "spMostrarTipoCausa";
            cmd.CommandType = CommandType.StoredProcedure;
            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            cmd.Connection = Conexion.CerrarConexion();
            return Tabla;
        }

        public string InsertarTipo(DTipoCausa Tipo)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spInsertarTipoCausa";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@ncausa";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParTipo.Size = 50;
                ParTipo.Value = Tipo.Ntipo;
                cmd.Parameters.Add(ParTipo);

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

        public string EditarTipo(DTipoCausa Tipo)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEditarTipoCausa";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Tipo.IdTipo;
                cmd.Parameters.Add(ParId);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@ncausa";
                ParTipo.SqlDbType = SqlDbType.VarChar;
                ParTipo.Size = 50;
                ParTipo.Value = Tipo.Ntipo;
                cmd.Parameters.Add(ParTipo);

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

        public string EliminarTipo(DTipoCausa Tipo)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEliminarTipoCausa";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Tipo.IdTipo;
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
