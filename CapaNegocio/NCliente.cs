using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        DCliente Objcliente = new DCliente();

        public DataTable Mostrar()
        {
            return new DCliente().MostrarCliente();
        }

        public string Insertar(string rut,string nrazon,string direccion,string comuna,int telefono)
        {
            Objcliente.Rut = rut;
            Objcliente.Razon = nrazon;
            Objcliente.Direccion = direccion;
            Objcliente.Comuna = comuna;
            Objcliente.Telefono = telefono;
            return Objcliente.InsertarCliente(Objcliente);
        }

        public string Editar(string rut,string nrazon, string direccion, string comuna, int telefono)
        {
            Objcliente.Rut = rut;
            Objcliente.Razon = nrazon;
            Objcliente.Direccion = direccion;
            Objcliente.Comuna = comuna;
            Objcliente.Telefono = telefono;
            return Objcliente.EditarCliente(Objcliente);
        }

        public string Eliminar(string rut)
        {
            Objcliente.Rut = rut;
            return Objcliente.EliminarCliente(Objcliente);
        }
    }
}
