using ra4_actividades.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ra4_actividades.Vista
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool correct = true;

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (String.IsNullOrWhiteSpace(c.Text))
                    {
                        correct = false;
                    }
                }
            }

            if (correct)
            {
                Usuario u = new Usuario(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value, textBox4.Text);
                Controlador.ControladorUsuario.addUser(u);
            }

            this.Close();
        }
    }
}
