using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crudWPF.BLL;
using MySql.Data.MySqlClient;

namespace crudWPF.DAL
{
    class proveedoresDAL
    {
        conexionsql conexion;

        public proveedoresDAL()
        {
            //Constructor asigna una conexion a cada objeto instanciado de proveedoresDAL
            conexion = new conexionsql();
        }


        public DataSet MostrarProveedores()
        {
            MySqlCommand SQLComando = new MySqlCommand("SELECT * FROM proveedores");

            return conexion.EjecutarSentencia(SQLComando);
        }

        public int Eliminar(proveedoresBLL oProveedorBLL)
        {
            conexion.execSinRetornoDatos("DELETE FROM  proveedores WHERE id = " + oProveedorBLL.id);

            return 1;
        }


        public int Modificar(proveedoresBLL oProveedorBLL)
        {
            conexion.execSinRetornoDatos("UPDATE proveedores SET nombre = '" + oProveedorBLL.nombre + "',telefono = '" + oProveedorBLL.telefono+ "' WHERE id = " + oProveedorBLL.id);

            return 1;
        }

        //
        public bool Agregar(proveedoresBLL oProveedor)
        {

            MySqlCommand SQLComando = new MySqlCommand("INSERT INTO proveedores VALUES(@id,@nombre,@telefono)");

            SQLComando.Parameters.Add("@id", MySqlDbType.Int32).Value = oProveedor.id; 
            SQLComando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = oProveedor.nombre;
            SQLComando.Parameters.Add("@telefono", MySqlDbType.VarChar).Value = oProveedor.telefono;


            return conexion.execSinRetornoDatos(SQLComando);
        }



    }
}
