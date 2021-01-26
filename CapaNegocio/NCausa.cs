using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCausa
    {
        DCausa objcausa = new DCausa();
        public DataTable Listar()
        {
            return new DCausa().MostrarCausa();
        }

        public string Insertar(string rol,int idtipo,string caratulado,string rut,DateTime fecha,int idestado,string descripcion)
        {
            objcausa.ROl = rol;
            objcausa.IdTipocausa = idtipo;
            objcausa.Caratulado = caratulado;
            objcausa.Rut = rut;
            objcausa.Fecha = fecha;
            objcausa.Idestado = idestado;
            objcausa.Descripcion = descripcion;
            return objcausa.InsertarCausa(objcausa);
        }

        public string Editar(string rol, int idtipo, string caratulado, string rut, DateTime fecha, int idestado, string descripcion)
        {
            objcausa.ROl = rol;
            objcausa.IdTipocausa = idtipo;
            objcausa.Caratulado = caratulado;
            objcausa.Rut = rut;
            objcausa.Fecha = fecha;
            objcausa.Idestado = idestado;
            objcausa.Descripcion = descripcion;
            return objcausa.EditarCausa(objcausa);
        }

        public string Eliminar(string rol)
        {
            objcausa.ROl = rol;
            return objcausa.EliminarCausa(objcausa);
        }
    }
}
