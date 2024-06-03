using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crudWPF.BLL;


namespace crudWPF.DAL
{
    class productosDAL
    {
        conexionsql conexion;

        public productosDAL()
        {
            //Constructor asigna una conexion a cada objeto instanciado de ProductosDAL
            conexion = new conexionsql();
        }

        public DataSet MostrarProductos()
        {
            MySqlCommand SQLComando = new MySqlCommand("SELECT * FROM productos");
            return conexion.EjecutarSentencia(SQLComando);
        }

        public DataSet BuscarPorID(int id)
        {
            MySqlCommand SQLComando = new MySqlCommand($"SELECT * FROM productos WHERE ID={id}");
            return conexion.EjecutarSentencia(SQLComando);
        }

        public bool Agregar(productosBLL oProducto)
        {

            MySqlCommand SQLComando = new MySqlCommand($"INSERT INTO productos VALUES({oProducto.id}," +
                                                        $"'{oProducto.nombre}',{oProducto.cantidad}," +
                                                        $"'{oProducto.descripcion}',{oProducto.precio}," +
                                                        $"'{oProducto.fechaIngreso}')");

            return conexion.execSinRetornoDatos(SQLComando);
        }

        public int Eliminar(productosBLL oProductoBLL)
        {
            conexion.execSinRetornoDatos($"DELETE FROM productos WHERE id={oProductoBLL.id}");

            return 1;
        }

        public int Modificar(productosBLL oProductosBLL)
        {
            conexion.execSinRetornoDatos($"UPDATE productos SET nombre='{oProductosBLL.nombre}', " +
                                        $"cantidad={oProductosBLL.cantidad}, descripcion='{oProductosBLL.descripcion}'," +
                                        $"precio={oProductosBLL.precio}, fechaIngreso = '{oProductosBLL.fechaIngreso}'" +
                                        $"WHERE ID = {oProductosBLL.id}");

            return 1;
        }


    }
}
