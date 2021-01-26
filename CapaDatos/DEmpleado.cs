using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEmpleado
    {
        private int _Id_empleado;
        private string _Nombre;
        private string _Apellido;
        private string _Correo;
        private string _Contraseña;
        private int _Id_cargo;

        public int Id_empleado { get => _Id_empleado; set => _Id_empleado = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        public int Id_cargo { get => _Id_cargo; set => _Id_cargo = value; }

        private Conexion Conexion = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader LeerFilas;

        public DEmpleado()
        {

        }

        public DEmpleado(int id_empleado, string nombre, string apellido, string correo,string contraseña, int id_cargo)
        {
            this.Id_empleado = id_empleado;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Correo = correo;
            this.Contraseña = contraseña;
            this.Id_cargo = id_cargo;
        }

        public DEmpleado(string correo,string contraseña)
        {
            this.Correo = correo;
            this.Correo = contraseña;
        }

        public bool Login(DEmpleado Empleado)
        {
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spValidar";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@correo";
                ParCorreo.SqlDbType =SqlDbType.VarChar;
                ParCorreo.Size =60;
                ParCorreo.Value = Empleado.Correo;
                cmd.Parameters.Add(ParCorreo);

                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@contraseña";
                ParContraseña.SqlDbType = SqlDbType.VarChar;
                ParContraseña.Size = 60;
                ParContraseña.Value = Empleado.Contraseña;
                cmd.Parameters.Add(ParContraseña);

                LeerFilas = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                if (LeerFilas.HasRows)
                {
                    while (LeerFilas.Read())
                    {
                        DCabhe.Idempleado = LeerFilas.GetInt32(0);
                        DCabhe.Nombre = LeerFilas.GetString(1);
                        DCabhe.Apellido = LeerFilas.GetString(2);
                        DCabhe.Correo = LeerFilas.GetString(3);
                        DCabhe.Idcargo = LeerFilas.GetInt32(5);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                cmd.Connection = Conexion.CerrarConexion();
            }
        }

        public DataTable MostrarEmpleado()
        {
            DataTable Tabla = new DataTable();
            cmd.Connection = Conexion.AbrirConexion();
            cmd.CommandText = "spMostrarCargo";
            cmd.CommandType = CommandType.StoredProcedure;
            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            cmd.Connection = Conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable MostrarEmpleado2()
        {
            DataTable Tabla = new DataTable();
            cmd.Connection = Conexion.AbrirConexion();
            cmd.CommandText = "spMostrarEmpleado";
            cmd.CommandType = CommandType.StoredProcedure;
            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            cmd.Connection = Conexion.CerrarConexion();
            return Tabla;
        }

        public string InsertarEmpleado(DEmpleado Empleado)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spInsertarEmpleado";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Empleado.Nombre;
                cmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 50;
                ParApellido.Value = Empleado.Apellido;
                cmd.Parameters.Add(ParApellido);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 60;
                ParCorreo.Value = Empleado.Correo;
                cmd.Parameters.Add(ParCorreo);

                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@contraseña";
                ParContraseña.SqlDbType = SqlDbType.VarChar;
                ParContraseña.Size = 10;
                ParContraseña.Value = Empleado.Contraseña;
                cmd.Parameters.Add(ParContraseña);

                SqlParameter ParIdcargo = new SqlParameter();
                ParIdcargo.ParameterName = "@id_cargo";
                ParIdcargo.SqlDbType = SqlDbType.Int;
                ParIdcargo.Value = Empleado.Id_cargo;
                cmd.Parameters.Add(ParIdcargo);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "NO se ingreso el registro";
                cmd.Parameters.Clear();
            }
            catch(Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                cmd.Connection = Conexion.CerrarConexion();
            }
            return rpta;
        }

        public string EditarEmpleado(DEmpleado Empleado)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEditarEmpleado";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@id_empleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empleado.Id_empleado;
                cmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Empleado.Nombre;
                cmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 50;
                ParApellido.Value = Empleado.Apellido;
                cmd.Parameters.Add(ParApellido);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 60;
                ParCorreo.Value = Empleado.Correo;
                cmd.Parameters.Add(ParCorreo);

                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@contraseña";
                ParContraseña.SqlDbType = SqlDbType.VarChar;
                ParContraseña.Size = 10;
                ParContraseña.Value = Empleado.Contraseña;
                cmd.Parameters.Add(ParContraseña);

                SqlParameter ParIdcargo = new SqlParameter();
                ParIdcargo.ParameterName = "@id_cargo";
                ParIdcargo.SqlDbType = SqlDbType.Int;
                ParIdcargo.Value = Empleado.Id_cargo;
                cmd.Parameters.Add(ParIdcargo);

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

        public string EliminarEmpleado(DEmpleado Empleado)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEliminarEmpleado";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idempleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empleado.Id_empleado;
                cmd.Parameters.Add(ParIdEmpleado);

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
