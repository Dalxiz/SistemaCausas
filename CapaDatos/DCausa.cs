using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCausa
    {
        private string _ROl;
        private int _IdTipocausa;
        private string _Caratulado;
        private string _Rut;
        private DateTime _Fecha;
        private int _Idestado;
        private string _Descripcion;

        public string ROl { get => _ROl; set => _ROl = value; }
        public int IdTipocausa { get => _IdTipocausa; set => _IdTipocausa = value; }
        public string Caratulado { get => _Caratulado; set => _Caratulado = value; }
        public string Rut { get => _Rut; set => _Rut = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public int Idestado { get => _Idestado; set => _Idestado = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }

        private Conexion Conexion = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader LeerFilas;

        public DCausa()
        {

        }
        public DCausa(string rol,int idtipo,string caratulado,string rut,DateTime fecha,int idestado, string descripcion)
        {
            this.ROl = rol;
            this.IdTipocausa = idtipo;
            this.Caratulado = caratulado;
            this.Rut = rut;
            this.Fecha = fecha;
            this.Idestado = idestado;
            this.Descripcion = descripcion;
        }

        public DataTable MostrarCausa()
        {
            DataTable Tabla = new DataTable();
            cmd.Connection = Conexion.AbrirConexion();
            cmd.CommandText = "spMostrarCausa";
            cmd.CommandType = CommandType.StoredProcedure;
            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            cmd.Connection = Conexion.CerrarConexion();
            return Tabla;
        }

        public string InsertarCausa(DCausa Causa)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spInsertarCausa";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCausa = new SqlParameter();
                ParCausa.ParameterName = "@rol";
                ParCausa.SqlDbType = SqlDbType.VarChar;
                ParCausa.Size = 20;
                ParCausa.Value = Causa.ROl;
                cmd.Parameters.Add(ParCausa);

                SqlParameter ParIdtipo = new SqlParameter();
                ParIdtipo.ParameterName = "@idtipo";
                ParIdtipo.SqlDbType = SqlDbType.Int;
                ParIdtipo.Value = Causa.IdTipocausa;
                cmd.Parameters.Add(ParIdtipo);

                SqlParameter ParCara = new SqlParameter();
                ParCara.ParameterName = "@caratulado";
                ParCara.SqlDbType = SqlDbType.VarChar;
                ParCara.Size = 100;
                ParCara.Value = Causa.Caratulado;
                cmd.Parameters.Add(ParCara);

                SqlParameter ParRut = new SqlParameter();
                ParRut.ParameterName = "@rut";
                ParRut.SqlDbType = SqlDbType.VarChar;
                ParRut.Size = 10;
                ParRut.Value = Causa.Rut;
                cmd.Parameters.Add(ParRut);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.VarChar;
                ParFecha.Value = Causa.Fecha;
                cmd.Parameters.Add(ParFecha);

                SqlParameter ParIdestado = new SqlParameter();
                ParIdestado.ParameterName = "@idestado";
                ParIdestado.SqlDbType = SqlDbType.Int;
                ParIdestado.Value = Causa.Idestado;
                cmd.Parameters.Add(ParIdestado);

                SqlParameter ParDescrpcion = new SqlParameter();
                ParDescrpcion.ParameterName = "@descripcion";
                ParDescrpcion.SqlDbType = SqlDbType.VarChar;
                ParDescrpcion.Size = 500;
                ParDescrpcion.Value = Causa.Descripcion;
                cmd.Parameters.Add(ParDescrpcion);

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


        public string EditarCausa(DCausa Causa)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEditarCausa";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCausa = new SqlParameter();
                ParCausa.ParameterName = "@rol";
                ParCausa.SqlDbType = SqlDbType.VarChar;
                ParCausa.Size = 20;
                ParCausa.Value = Causa.ROl;
                cmd.Parameters.Add(ParCausa);

                SqlParameter ParIdtipo = new SqlParameter();
                ParIdtipo.ParameterName = "@idtipo";
                ParIdtipo.SqlDbType = SqlDbType.Int;
                ParIdtipo.Value = Causa.IdTipocausa;
                cmd.Parameters.Add(ParIdtipo);

                SqlParameter ParCara = new SqlParameter();
                ParCara.ParameterName = "@caratulado";
                ParCara.SqlDbType = SqlDbType.VarChar;
                ParCara.Size = 100;
                ParCara.Value = Causa.Caratulado;
                cmd.Parameters.Add(ParCara);

                SqlParameter ParRut = new SqlParameter();
                ParRut.ParameterName = "@rut";
                ParRut.SqlDbType = SqlDbType.VarChar;
                ParRut.Size = 10;
                ParRut.Value = Causa.Rut;
                cmd.Parameters.Add(ParRut);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.VarChar;
                ParFecha.Value = Causa.Fecha;
                cmd.Parameters.Add(ParFecha);

                SqlParameter ParIdestado = new SqlParameter();
                ParIdestado.ParameterName = "@idestado";
                ParIdestado.SqlDbType = SqlDbType.Int;
                ParIdestado.Value = Causa.Idestado;
                cmd.Parameters.Add(ParIdestado);

                SqlParameter ParDescrpcion = new SqlParameter();
                ParDescrpcion.ParameterName = "@descripcion";
                ParDescrpcion.SqlDbType = SqlDbType.VarChar;
                ParDescrpcion.Size = 500;
                ParDescrpcion.Value = Causa.Descripcion;
                cmd.Parameters.Add(ParDescrpcion);

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

        public string EliminarCausa(DCausa Causa)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEliminarCausa";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCausa = new SqlParameter();
                ParCausa.ParameterName = "@rol";
                ParCausa.SqlDbType = SqlDbType.VarChar;
                ParCausa.Size = 20;
                ParCausa.Value = Causa.ROl;
                cmd.Parameters.Add(ParCausa);

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
    }
}
