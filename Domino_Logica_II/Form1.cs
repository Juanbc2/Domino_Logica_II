using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domino_Logica_II
{
    public partial class Form1 : Form
    {
        public static Jugador j1, j2, j3, j4;
        public static string j2n, j3n, j4n;
        public Form1()
        {

            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            createPlayers();
            j2n = textBox1.Text;
            j3n = textBox2.Text;
            j4n = textBox3.Text;
            tablero tableroJuego = new tablero(j2n, j3n, j4n, j1, j2, j3, j4);
            this.Hide();
            tableroJuego.Show();
        }

        public void createPlayers()
        {

            j1 = new Jugador("Usted");
            j2 = new Jugador(textBox1.Text);
            j3 = new Jugador(textBox2.Text);
            j4 = new Jugador(textBox3.Text);

        }
    }
}