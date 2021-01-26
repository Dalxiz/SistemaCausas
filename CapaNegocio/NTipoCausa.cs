using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NTipoCausa
    {
        DTipoCausa objtipo = new DTipoCausa();
        public DataTable Listar()
        {
            return new DTipoCausa().ListarTipo();
        }

        public string Insertar(string nombre)
        {
            objtipo.Ntipo = nombre;
            return objtipo.InsertarTipo(objtipo);
        }

        public string Editar(int id, string nombre)
        {
            objtipo.IdTipo = id;
            objtipo.Ntipo = nombre;
            return objtipo.EditarTipo(objtipo);
        }

        public string Eliminar(int id)
        {
            objtipo.IdTipo = id;
            return objtipo.EliminarTipo(objtipo);
        }

    }
}
