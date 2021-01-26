using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCargo
    {
        private int _ID_cargo;
        private string _NCargo;

        public int ID_cargo { get => _ID_cargo; set => _ID_cargo = value; }
        public string NCargo { get => _NCargo; set => _NCargo = value; }

        public DCargo(int id_cargo, string ncargo)
        {
            this.ID_cargo = id_cargo;
            this.NCargo = ncargo;
        }
        public DCargo()
        {
        
        }


        private Conexion Conexion = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader LeerFilas;

        public DataTable ListarCargo()
        {
            DataTable Tabla = new DataTable();
            cmd.Connection = Conexion.AbrirConexion();
            cmd.CommandText = "spListarCargos";
            cmd.CommandType = CommandType.StoredProcedure;
            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            cmd.Connection = Conexion.CerrarConexion();
            return Tabla;
        }

        public string InsertarCargo(DCargo Cargo)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spInsertarCargo";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCargo = new SqlParameter();
                ParCargo.ParameterName = "@ncargo";
                ParCargo.SqlDbType = SqlDbType.VarChar;
                ParCargo.Size = 30;
                ParCargo.Value = Cargo.NCargo;
                cmd.Parameters.Add(ParCargo);            

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

        public string EditarCargo(DCargo Cargo)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEditarCargo";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCargo = new SqlParameter();
                ParIdCargo.ParameterName = "@idcargo";
                ParIdCargo.SqlDbType = SqlDbType.Int;
                ParIdCargo.Value = Cargo.ID_cargo;
                cmd.Parameters.Add(ParIdCargo);

                SqlParameter ParCargo = new SqlParameter();
                ParCargo.ParameterName = "@ncargo";
                ParCargo.SqlDbType = SqlDbType.VarChar;
                ParCargo.Size = 30;
                ParCargo.Value = Cargo.NCargo;
                cmd.Parameters.Add(ParCargo);

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

        public string EliminarCargo(DCargo Cargo)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEliminarCargo";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCargo = new SqlParameter();
                ParIdCargo.ParameterName = "@idcargo";
                ParIdCargo.SqlDbType = SqlDbType.Int;
                ParIdCargo.Value = Cargo.ID_cargo;
                cmd.Parameters.Add(ParIdCargo);

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
