using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCliente
    {
        private string _Rut;
        private string _Razon;
        private string _Direccion;
        private string _Comuna;
        private int _Telefono;
        private string _Textobuscar;

        private Conexion Conexion = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader LeerFilas;

        public string Rut { get => _Rut; set => _Rut = value; }
        public string Razon { get => _Razon; set => _Razon = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Comuna { get => _Comuna; set => _Comuna = value; }
        public int Telefono { get => _Telefono; set => _Telefono = value; }
        public string Textobuscar { get => _Textobuscar; set => _Textobuscar = value; }

        public DCliente()
        {

        }

        public DCliente(string rut,string razon,string direccion,string comuna,int telefono,string textbuscar)
        {
            this.Rut = rut;
            this.Razon = razon;
            this.Direccion = direccion;
            this.Comuna = comuna;
            this.Telefono = telefono;
            this.Textobuscar = textbuscar;
        }

        public DataTable MostrarCliente()
        {
            DataTable Tabla = new DataTable();
            cmd.Connection = Conexion.AbrirConexion();
            cmd.CommandText = "spListarCliente";
            cmd.CommandType = CommandType.StoredProcedure;
            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            cmd.Connection = Conexion.CerrarConexion();
            return Tabla;
        }

        public string InsertarCliente(DCliente Cliente)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spInsertarCliente";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParRut = new SqlParameter();
                ParRut.ParameterName = "@rut";
                ParRut.SqlDbType = SqlDbType.VarChar;
                ParRut.Size = 100;
                ParRut.Value = Cliente.Rut;
                cmd.Parameters.Add(ParRut);

                SqlParameter ParRazon = new SqlParameter();
                ParRazon.ParameterName = "@nrazon";
                ParRazon.SqlDbType = SqlDbType.VarChar;
                ParRazon.Size = 100;
                ParRazon.Value = Cliente.Razon;
                cmd.Parameters.Add(ParRazon);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 250;
                ParDireccion.Value = Cliente.Direccion;
                cmd.Parameters.Add(ParDireccion);

                SqlParameter ParComuna = new SqlParameter();
                ParComuna.ParameterName = "@comuna";
                ParComuna.SqlDbType = SqlDbType.VarChar;
                ParComuna.Size = 100;
                ParComuna.Value = Cliente.Comuna;
                cmd.Parameters.Add(ParComuna);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.Int;
                ParTelefono.Value = Cliente.Telefono;
                cmd.Parameters.Add(ParTelefono);

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

        public string EditarCliente(DCliente Cliente)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEditarCliente";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParRut = new SqlParameter();
                ParRut.ParameterName = "@rut";
                ParRut.SqlDbType = SqlDbType.VarChar;
                ParRut.Size = 10;
                ParRut.Value = Cliente.Rut;
                cmd.Parameters.Add(ParRut);

                SqlParameter ParRazon = new SqlParameter();
                ParRazon.ParameterName = "@nrazon";
                ParRazon.SqlDbType = SqlDbType.VarChar;
                ParRazon.Size = 100;
                ParRazon.Value = Cliente.Razon;
                cmd.Parameters.Add(ParRazon);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 250;
                ParDireccion.Value = Cliente.Direccion;
                cmd.Parameters.Add(ParDireccion);

                SqlParameter ParComuna = new SqlParameter();
                ParComuna.ParameterName = "@comuna";
                ParComuna.SqlDbType = SqlDbType.VarChar;
                ParComuna.Size = 100;
                ParComuna.Value = Cliente.Comuna;
                cmd.Parameters.Add(ParComuna);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.Int;
                ParTelefono.Value = Cliente.Telefono;
                cmd.Parameters.Add(ParTelefono);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "NO se edito el registro";
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

        public string EliminarCliente(DCliente Cliente)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEliminarCliente";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParRut = new SqlParameter();
                ParRut.ParameterName = "@rut";
                ParRut.SqlDbType = SqlDbType.VarChar;
                ParRut.Size = 10;
                ParRut.Value = Cliente.Rut;
                cmd.Parameters.Add(ParRut);

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
