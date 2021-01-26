using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle
    {
        private int _Iddetalle;
        private DateTime _FechaRegistro;
        private string _Observacion;
        private string _Rol;
        private int _Idempleado;
        private string _Tribunal;
        private DateTime _FechaDesde;
        private DateTime _FechaHasta;

        public int Iddetalle { get => _Iddetalle; set => _Iddetalle = value; }
        public DateTime FechaRegistro { get => _FechaRegistro; set => _FechaRegistro = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }
        public string Rol { get => _Rol; set => _Rol = value; }
        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public string Tribunal { get => _Tribunal; set => _Tribunal = value; }
        public DateTime FechaDesde { get => _FechaDesde; set => _FechaDesde = value; }
        public DateTime FechaHasta { get => _FechaHasta; set => _FechaHasta = value; }

        public DDetalle()
        {

        }

        public DDetalle(int iddetalle,DateTime fecha,string obser,string rol, int idempleado,string tribunal)
        {
            this.Iddetalle = iddetalle;
            this.FechaRegistro = fecha;
            this.Observacion = obser;
            this.Rol = rol;
            this.Idempleado = idempleado;
            this.Tribunal = tribunal;
        }
        public DDetalle(DateTime desde, DateTime hasta)
        {
            this.FechaDesde = desde;
            this.FechaHasta = hasta;
        }

        private Conexion Conexion = new Conexion();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader LeerFilas;

        public DataTable BuscarFecha(DDetalle Detalle)
        {
            DataTable Tabla = new DataTable();
            cmd.Connection = Conexion.AbrirConexion();
            cmd.CommandText = "spBuscarPorFecha";
            cmd.CommandType = CommandType.StoredProcedure;



            SqlParameter Pardesde = new SqlParameter();
            Pardesde.ParameterName = "@fechadesde";
            Pardesde.SqlDbType = SqlDbType.VarChar;
            Pardesde.Size = 30;
            Pardesde.Value = Detalle.FechaDesde;
            cmd.Parameters.Add(Pardesde);

            SqlParameter Parhasta = new SqlParameter();
            Parhasta.ParameterName = "@fechahasta";
            Parhasta.SqlDbType = SqlDbType.VarChar;
            Parhasta.Size = 30;
            Parhasta.Value = Detalle.FechaHasta;
            cmd.Parameters.Add(Parhasta);

            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            cmd.Connection = Conexion.CerrarConexion();
            return Tabla;
        }

        public DataTable ListarDetalle()
        {
            DataTable Tabla = new DataTable();
            cmd.Connection = Conexion.AbrirConexion();
            cmd.CommandText = "spMostrarDetalle";
            cmd.CommandType = CommandType.StoredProcedure;

            LeerFilas = cmd.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            cmd.Connection = Conexion.CerrarConexion();
            return Tabla;
        }

        public string InsertarDetalle(DDetalle Detalle)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spInsertarDetalle";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Parfecha = new SqlParameter();
                Parfecha.ParameterName = "@fecha";
                Parfecha.SqlDbType = SqlDbType.VarChar;
                Parfecha.Size = 30;
                Parfecha.Value = Detalle.FechaRegistro;
                cmd.Parameters.Add(Parfecha);

                SqlParameter Parobs = new SqlParameter();
                Parobs.ParameterName = "@observacion";
                Parobs.SqlDbType = SqlDbType.VarChar;
                Parobs.Size = 500;
                Parobs.Value = Detalle.Observacion;
                cmd.Parameters.Add(Parobs);

                SqlParameter ParRol = new SqlParameter();
                ParRol.ParameterName = "@rol";
                ParRol.SqlDbType = SqlDbType.VarChar;
                ParRol.Size = 20;
                ParRol.Value = Detalle.Rol;
                cmd.Parameters.Add(ParRol);

                SqlParameter ParIdempleado = new SqlParameter();
                ParIdempleado.ParameterName = "@idempleado";
                ParIdempleado.SqlDbType = SqlDbType.Int;
                ParIdempleado.Value = Detalle.Idempleado;
                cmd.Parameters.Add(ParIdempleado);

                SqlParameter ParTribunal = new SqlParameter();
                ParTribunal.ParameterName = "@tribunal";
                ParTribunal.SqlDbType = SqlDbType.VarChar;
                ParTribunal.Size = 150;
                ParTribunal.Value = Detalle.Tribunal;
                cmd.Parameters.Add(ParTribunal);

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
        public string EditarDetalle(DDetalle Detalle)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEditarDetalle";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle = new SqlParameter();
                ParIddetalle.ParameterName = "@idregistro";
                ParIddetalle.SqlDbType = SqlDbType.Int;
                ParIddetalle.Value = Detalle.Iddetalle;
                cmd.Parameters.Add(ParIddetalle);

                SqlParameter Parfecha = new SqlParameter();
                Parfecha.ParameterName = "@fecha";
                Parfecha.SqlDbType = SqlDbType.VarChar;
                Parfecha.Size = 30;
                Parfecha.Value = Detalle.FechaRegistro;
                cmd.Parameters.Add(Parfecha);

                SqlParameter Parobs = new SqlParameter();
                Parobs.ParameterName = "@observacion";
                Parobs.SqlDbType = SqlDbType.VarChar;
                Parobs.Size = 500;
                Parobs.Value = Detalle.Observacion;
                cmd.Parameters.Add(Parobs);

                SqlParameter ParRol = new SqlParameter();
                ParRol.ParameterName = "@rol";
                ParRol.SqlDbType = SqlDbType.VarChar;
                ParRol.Size = 20;
                ParRol.Value = Detalle.Rol;
                cmd.Parameters.Add(ParRol);

                SqlParameter ParIdempleado = new SqlParameter();
                ParIdempleado.ParameterName = "@idempleado";
                ParIdempleado.SqlDbType = SqlDbType.Int;
                ParIdempleado.Value = Detalle.Idempleado;
                cmd.Parameters.Add(ParIdempleado);

                SqlParameter ParTribunal = new SqlParameter();
                ParTribunal.ParameterName = "@tribunal";
                ParTribunal.SqlDbType = SqlDbType.VarChar;
                ParTribunal.Size = 150;
                ParTribunal.Value = Detalle.Tribunal;
                cmd.Parameters.Add(ParTribunal);

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

        public string EliminarDetalle(DDetalle Detalle)
        {
            string rpta = "";
            try
            {
                cmd.Connection = Conexion.AbrirConexion();
                cmd.CommandText = "spEliminarDetalle";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle = new SqlParameter();
                ParIddetalle.ParameterName = "@idregistro";
                ParIddetalle.SqlDbType = SqlDbType.Int;
                ParIddetalle.Value = Detalle.Iddetalle;
                cmd.Parameters.Add(ParIddetalle);
                
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
