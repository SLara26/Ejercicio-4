using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DatosBiblioteca.Entidades;


//Cristhian Eduardo Cáceres Velásquez – 20201600006

namespace DatosBiblioteca.Accesos
{
    public class UsuarioAccesos
    {


        //Se crea la cadena de conexión a la base de datos en MySql
        readonly string cadena = "Server=127.0.0.1; Port=3306; Database=ejercicio#4_cristhiancaceres; Uid=root; Pwd=123456;";

        //variables para la conexión
        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuario Login(string correo, string clave)
        {
            Usuario user = null;

            try
            {
                //cadena de conexión a la tabla usuarios de mi base de datos
                string sql = "SELECT * FROM usuarios WHERE Correo=@Correo AND Clave=@Clave;";

                conn = new MySqlConnection(cadena);
                conn.Open();//abre la conexión

                cmd = new MySqlCommand(sql, conn);
                //parámetros de la tabla necesarios para ingresar
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                //llamada de los datos de la tabla
                while (reader.Read())
                {
                    user = new Usuario();
                    user.Correo = reader[0].ToString();
                    user.Clave = reader[1].ToString();

                }
                reader.Close();
                conn.Close();//cierra conexión


            }
            catch (Exception ex)
            {
            }

            return user;
        }
    }
}
