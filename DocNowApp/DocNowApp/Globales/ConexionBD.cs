using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocNowApp.Globales
{
    internal class ConexionBD
    {
        //ES MUY POSIBLE QUE SE ELIMINE ESTA CLASE
        private string sentencia; //Recibirá la instrucción SQL

        private SqlConnection conexion = new SqlConnection(); //Abre y cierrra la conexión
        private SqlCommand comando; //Es el comando SQL

        public ConexionBD(string sentencia)
        {
            this.sentencia = sentencia;
        }
        public ConexionBD()
        {

        }

        public string Ejecutar()
        {
            //Estamos preparando una calse global para todas las tareas de una base de datos
            conexion.ConnectionString = Globales.CadenaConexion.miConexion;
            //clases es la carpeta, globales la clase, y miconexion tiene la
            //cadena de conexión de la base de datos
            //miconexion incluye usuario, nombre del servidor, contraseña,  nombre de la base de datos

            //Se valida que la conexión con la base de datos este abierta, si está cerrada, la abre.
            //Si intentamos abrir una conexión que ya esta abierta, marcara error
            if (conexion.State != System.Data.ConnectionState.Open)
            {
                conexion.Close();
                conexion.Open();
            }
            comando = new SqlCommand(); //Estamos creando en memoria el objeto cmd con un constructor vacío
            //Aquí trabajamos con las propiedades del objeto de tipo SqlCommand
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            comando.ExecuteNonQuery(); //Sirve para guardar, modificar y eliminar
            conexion.Close();
            return "Operación exitosa";
        }

        //TEMPORAL
        /*
        public DataSet Validar()
        {
            DataSet datos = new DataSet(); //Es una especie de arreglo, o tabla si tiene más de una dimensión, para almacenar los datos.
            conexion = new SqlConnection(Globales.CadenaConexion.miConexion); //Existe un control gráfico que hace más pesado el formulario

            using (comando = new SqlCommand(sentencia, conexion))
            {
                comando.Parameters.AddWithValue("@correo", correo)
            }

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                try
                {
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();

                    if (lector.Read())
                    {
                        // Usuario encontrado
                        usuarioEncontrado = true;
                        btnEliminar.Enabled = true;
                        txtNombreUsuario.Text = lector["Nombre"].ToString();
                        txtApellidoUsuario.Text = lector["Apellido"].ToString();
                        txtCorreoUsuario.Text = lector["Correo"].ToString();
                        mskTelefonoUsuario.Text = lector["Telefono"].ToString();
                        txtDireccionUsuario.Text = lector["Direccion"].ToString();
                        dtpFechaUsuario.Value = Convert.ToDateTime(lector["FechaRegistro"]);
                        cmbUsuario.Text = lector["TipoUsuario"].ToString();
                    }
                    else
                    {
                        // Usuario no encontrado
                        usuarioEncontrado = false;
                        btnEliminar.Enabled = false;
                        MessageBox.Show("Usuario no encontrado. Puede crear uno nuevo.");
                        LimpiarControles();
                    }

                    lector.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar usuario: " + ex.Message);
                }
            }

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Close();
                conexion.Open();
            }
            SqlDataAdapter adaptador = new SqlDataAdapter(sentencia, conexion); //Existe un control gráfico que hace más pesado el formulario
            adaptador.Fill(datos, "Tabla"); //Rellena con toda la información
            conexion.Close();
            return datos;
        }
        public DataSet Consultar()
        {
            DataSet datos = new DataSet(); //Es una especie de arreglo, o tabla si tiene más de una dimensión, para almacenar los datos.
            //Es un puente para almacenar ahí la información momentaneamente
            conexion = new SqlConnection(Globales.CadenaConexion.miConexion); //Existe un control gráfico que hace más pesado el formulario

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Close();
                conexion.Open();
            }
            //Permite hacer las 4 tareas: Tendra una command sql para consultar, otro para insertar, otro para borrar y otro para modificar.
            //Toma el sql command para la consulta
            SqlDataAdapter adaptador = new SqlDataAdapter(sentencia, conexion); //Existe un control gráfico que hace más pesado el formulario
            //Este objeto recibirá dos parámetros, los datos almcenados y un nombre (Tabla)
            //Todas estas instrucciones son para SqlServer, cada manejador tiene las suyas propias
            adaptador.Fill(datos, "Tabla"); //Rellena con toda la información
            //El constructor filtará si leera un solo campo o varios
            conexion.Close();
            return datos;
        }*/
    }
}
