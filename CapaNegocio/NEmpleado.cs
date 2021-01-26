using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NEmpleado
    {
        DEmpleado ObjEmpleado = new DEmpleado();
        
        public DataTable Mostrar()
        {
            return new DEmpleado().MostrarEmpleado();
        }
        public DataTable Mostrar2()
        {
            return new DEmpleado().MostrarEmpleado2();
        }

        public bool Login(string correo,string contraseña)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.Correo = correo;
            Obj.Contraseña = contraseña;
            return Obj.Login(Obj);
        }

        public string Insertar(string nombre,string apellido,string correo,string contraseña, int idcargo)
        {
            ObjEmpleado.Nombre = nombre;
            ObjEmpleado.Apellido = apellido;
            ObjEmpleado.Correo = correo;
            ObjEmpleado.Contraseña = contraseña;
            ObjEmpleado.Id_cargo = idcargo;
            return ObjEmpleado.InsertarEmpleado(ObjEmpleado);
        }

        public string Editar(int idempleado,string nombre, string apellido, string correo, string contraseña, int idcargo)
        {
            ObjEmpleado.Id_empleado = idempleado;
            ObjEmpleado.Nombre = nombre;
            ObjEmpleado.Apellido = apellido;
            ObjEmpleado.Correo = correo;
            ObjEmpleado.Contraseña = contraseña;
            ObjEmpleado.Id_cargo = idcargo;
            return ObjEmpleado.EditarEmpleado(ObjEmpleado);
        }

        public string Eliminar(int idempleado)
        {
            ObjEmpleado.Id_empleado = idempleado;
            return ObjEmpleado.EliminarEmpleado(ObjEmpleado);
        }

       
    }
}
