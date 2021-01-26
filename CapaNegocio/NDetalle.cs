using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NDetalle
    {
        DDetalle objdetalle = new DDetalle();
        public DataTable Listar()
        {
            return new DDetalle().ListarDetalle();
        }

        public DataTable Buscar(DateTime desde, DateTime hasta)
        {
            DDetalle o = new DDetalle();
            o.FechaDesde = desde;
            o.FechaHasta = hasta;
            return o.BuscarFecha(o);
        }

        public string Insertar(DateTime fecha,string obser,string rol,int idempleado, string tribunal)
        {
            objdetalle.FechaRegistro = fecha;
            objdetalle.Observacion = obser;
            objdetalle.Rol = rol;
            objdetalle.Idempleado = idempleado;
            objdetalle.Tribunal = tribunal;
            return objdetalle.InsertarDetalle(objdetalle);
        }

        public string Editar(int iddetalle,DateTime fecha, string obser, string rol, int idempleado, string tribunal)
        {
            objdetalle.Iddetalle = iddetalle;
            objdetalle.FechaRegistro = fecha;
            objdetalle.Observacion = obser;
            objdetalle.Rol = rol;
            objdetalle.Idempleado = idempleado;
            objdetalle.Tribunal = tribunal;
            return objdetalle.EditarDetalle(objdetalle);
        }

        public string Eliminar(int id)
        {
            objdetalle.Iddetalle = id;
            return objdetalle.EliminarDetalle(objdetalle);
        }
    }
}
