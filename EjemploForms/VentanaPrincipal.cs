using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploForms
{
    public partial class VentanaPrincipal : Form
    {
        Conexion miConexion = new Conexion();
        DataTable misPokemons = new DataTable();

        public VentanaPrincipal()
        {
            InitializeComponent();
            //misPokemons = miConexion.getHabitacion();
            dataGridView1.DataSource = misPokemons;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            misPokemons = miConexion.getConsultaHabitaciones(textBox1.Text , textBox2.Text);
            //textBox2.Text = misPokemons.Rows[0]["Numero Camas"].ToString();
            //textBox3.Text = misPokemons.Rows[0]["Individual"].ToString();
            //textBox4.Text = misPokemons.Rows[0]["Matrimonio"].ToString();
            //textBox5.Text = misPokemons.Rows[0]["Supletoria"].ToString();
            
        }


        //Método para cerrar la apliación entera cuando se cierra el form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            miConexion.ActualizaHabitacion(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            //refresca el dataGridView
            dataGridView1.DataSource = miConexion.getHabitacion();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
