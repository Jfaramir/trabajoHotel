using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
//este es el que contiene la declaración del DataTable
using System.Data;

namespace EjemploForms
{
    class Conexion
    {
        public MySqlConnection conexion;

        public Conexion()
        {
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = hotel; Uid = root; Pwd =root; Port = 3306");
        }

        public DataTable getHabitacion() {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM habitacion", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable hotel = new DataTable();
                hotel.Load(resultado);
                conexion.Close();
                return hotel;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        public DataTable getPokemonPorNombre(String numero)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = 
                    new MySqlCommand("SELECT * FROM habitacion where Numero ='" + numero + "'", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable hotel = new DataTable();
                hotel.Load(resultado);
                conexion.Close();
                return hotel;
            }
            catch (MySqlException e)
            {
                throw e;
            }

        }

        public void ActualizaHabitacion(String numeroCamas, String individual, String matrimonio, String supletoria)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = 
                    new MySqlCommand("UPDATE habitacion SET Numero Camas='"+ numeroCamas + "', Individual='"+ individual + "', Matrimonio='" + matrimonio + "', Supletoria='" + supletoria + "' WHERE Numero='101'" , conexion);
                consulta.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        public void ActualizaFecha(String numero, String fechaInicio, String fechaFinal)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("UPDATE reserva INSERT Fecha Inicio='" + fechaInicio + "', Fecha Final='" + fechaFinal + "' WHERE Numero='" + numero + "'", conexion);
                consulta.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
    }
}
