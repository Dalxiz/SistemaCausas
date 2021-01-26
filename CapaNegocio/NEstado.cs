using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NEstado
    {
        DEstado objcargo = new DEstado();
        public DataTable Listar()
        {
            return new DEstado().ListarEstado();
        }

        public string Insertar(string nombre)
        {
            objcargo.Nestado = nombre;
            return objcargo.InsertarEstado(objcargo);
        }

        public string Editar(int id, string nombre)
        {
            objcargo.IdEstado = id;
            objcargo.Nestado = nombre;
            return objcargo.EditarEstado(objcargo);
        }

        public string Eliminar(int id)
        {
            objcargo.IdEstado = id;
            return objcargo.EliminarEstado(objcargo);
        }
    }
}
