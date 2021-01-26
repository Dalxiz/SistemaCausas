using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCargo
    {
        DCargo objcargo = new DCargo();
        
        public DataTable Listar()
        {
            return new DCargo().ListarCargo();
        }

        public string Insertar(string nombre)
        {
            objcargo.NCargo = nombre;
            return objcargo.InsertarCargo(objcargo);
        }

        public string Editar(int id, string nombre)
        {
            objcargo.ID_cargo = id;
            objcargo.NCargo = nombre;
            return objcargo.EditarCargo(objcargo);
        }

        public string Eliminar(int id)
        {
            objcargo.ID_cargo = id;
            return objcargo.EliminarCargo(objcargo);
        }
    }
}
