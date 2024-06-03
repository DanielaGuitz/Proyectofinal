using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudWPF.DAL
{
    class conexionsql
    {
        private string cadenaconexion = "server= localhost; port= 3306; userid = root; password= justinbieber; database = proyectofinal";
        MySqlConnection conexion;

        //public string SendingData(string sv,string puerto, string user, string passwd, string db)
        //{
        //    this.cadenaconexion = $"server={sv}; port={puerto}; userid={user}; password={passwd}; database={db}";
        //    return cadenaconexion;
        //}


        public MySqlConnection EstablecerConexion()
        {
            this.conexion = new MySqlConnection(this.cadenaconexion);
            return this.conexion;
        }



        /*INSERT , DELETE, UPDATE de informacion*/
        public bool execSinRetornoDatos(string strComando)
        {
            try
            {
                MySqlCommand Comando = new MySqlCommand();


                Comando.CommandText = strComando;
                Comando.Connection = this.EstablecerConexion();
                conexion.Open();
                Comando.ExecuteNonQuery();
                conexion.Close();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        //Sobrecarga +1 (Acepta un comando instanciado de MySqlCommand)
        public bool execSinRetornoDatos(MySqlCommand SQLComando)
        {
            try
            {
                MySqlCommand Comando = SQLComando;
                Comando.Connection = this.EstablecerConexion();
                conexion.Open();
                Comando.ExecuteNonQuery();
                conexion.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }


        /* SELECT Devuelve info, util para el datagrid*/
        public DataSet EjecutarSentencia(MySqlCommand SQLComando)
        {
            DataSet DS = new DataSet();
            MySqlDataAdapter Adaptador = new MySqlDataAdapter();

            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando = SQLComando;
                comando.Connection = this.EstablecerConexion();
                Adaptador.SelectCommand = comando;
                conexion.Open();
                Adaptador.Fill(DS);
                conexion.Close();

                return DS;
            }
            catch 
            {
                return DS;
            }
        }



        public void abrirConexion()
        {
            conexion = new MySqlConnection(this.cadenaconexion);
            conexion.Open();
        }


        /// <summary>
        /// metodo que ejecuta una consulta, esta clase maneja la apertura y clausura a la base de datos
        /// </summary>
        /// <param name="strComando"></param>
        /// <returns></returns>
        public DataTable consultaTablaDirecta(string strComando)
        {
            abrirConexion();
            MySqlDataReader dr;
            MySqlCommand comando = new MySqlCommand(strComando, conexion);

            dr = comando.ExecuteReader();

            var dataTable = new DataTable();

            dataTable.Load(dr);

            conexion.Close();
            return dataTable;

        }



        public bool testBD()
        {
            try
            {
                abrirConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
