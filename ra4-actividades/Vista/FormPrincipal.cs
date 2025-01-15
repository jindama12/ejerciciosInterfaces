using ra4_actividades.Modelo;
using ra4_actividades.Vista;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ra4_actividades
{
    public partial class FormPrincipal : Form
    {
        private bool seleccionado = false;

        public FormPrincipal()
        {
            InitializeComponent();
            Controlador.ControladorUsuario.cargarUsuarios();
            //Controlador.ControladorUsuario.leerBin();
            //Controlador.ControladorUsuario.guardarXML();
            //Controlador.ControladorUsuario.guardarJSON();
            //Controlador.ControladorUsuario.guardarBin();
            cargarTabla();
        }

        int indice = -1;

        //Getters and setters
        public Color colorForm { get => this.BackColor; set => this.BackColor = value; }
        public Color fontColor { get => this.ForeColor; set => this.ForeColor = value; }
        public Font formFont { get =>  this.Font; set => this.Font = value; }
        public int formWidth { get => this.Width; set => this.Width = value; }
        public int formHeight { get => this.Height; set => this.Height = value; }


        public string nombre { get => textBox1.Text; set => textBox1.Text = value; }
        public string apellido1 { get => textBox2.Text; set => textBox2.Text = value; }
        public string apellido2 { get => textBox3.Text; set => textBox3.Text = value; }
        public DateTime fechaNac { get => dateTimePicker1.Value; set => dateTimePicker1.Value = value; }
        public string getNIF { get => textBox4.Text; set => textBox4.Text = value; }
        public int index { get => indice; set => indice = value; }

        public void cargarTabla()
        {
            foreach (Usuario u in Controlador.ControladorUsuario.listaUsuarios)
            {
                dataGridView1.Rows.Add(u.Nombre, u.PrimerApellido, u.SegundoApellido, u.FechaNacimiento.ToString(), u.NIF);
            }
        }

        public void vaciarTabla()
        {
            dataGridView1.Rows.Clear();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vista.Configuracion configuracion = new Vista.Configuracion();
            configuracion.ShowDialog();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vista.Registro registro = new Vista.Registro();
            registro.ShowDialog();
            vaciarTabla();
            cargarTabla();
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.SourceControl.Text = String.Empty;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostrarUsuarios mostrar = new mostrarUsuarios();
            mostrar.ShowDialog();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool empty = false;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (String.IsNullOrWhiteSpace(c.Text))
                    {
                        empty = true;
                    }
                }
            }

            if (indice > -1 && !empty)
            {
                if (!textBox1.Text.Equals(Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).Nombre))
                {
                    Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).Nombre = textBox1.Text;
                }
                if (!textBox2.Text.Equals(Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).PrimerApellido))
                {
                    Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).PrimerApellido = textBox2.Text;
                }
                if (!textBox3.Text.Equals(Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).SegundoApellido))
                {
                    Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).SegundoApellido = textBox3.Text;
                }
                if (!dateTimePicker1.Value.ToString().Equals(Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).FechaNacimiento.ToString()))
                {
                    Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).FechaNacimiento = dateTimePicker1.Value;
                }
                if (!textBox4.Text.Equals(Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).NIF))
                {
                    Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).NIF = textBox4.Text;
                }
            }

            vaciarTabla();
            cargarTabla();

            limpiarCampos();
        }

        private void limpiarCampos()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = String.Empty;
                }
            }
            dateTimePicker1.Value = DateTime.Now;
        }

        private void copiarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                Clipboard.SetText(contextMenuStrip1.SourceControl.Text);
            } else if (contextMenuStrip1.SourceControl.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
            {
                Clipboard.SetText(contextMenuStrip1.SourceControl.Text);
            }
        }

        private void cortarToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                Clipboard.SetText(contextMenuStrip1.SourceControl.Text);
            }
            else if (contextMenuStrip1.SourceControl.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
            {
                Clipboard.SetText(contextMenuStrip1.SourceControl.Text);
            }
            contextMenuStrip1.SourceControl.Text = String.Empty;
        }

        private void pegarToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (!Clipboard.GetText().Equals(String.Empty))
            {
                if (contextMenuStrip1.SourceControl.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    contextMenuStrip1.SourceControl.Text = Clipboard.GetText();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            indice = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = Controlador.ControladorUsuario.listaUsuarios[indice].Nombre;
            textBox2.Text = Controlador.ControladorUsuario.listaUsuarios[indice].PrimerApellido;
            textBox3.Text = Controlador.ControladorUsuario.listaUsuarios[indice].SegundoApellido;
            dateTimePicker1.Value = Controlador.ControladorUsuario.listaUsuarios[indice].FechaNacimiento;
            textBox4.Text = Controlador.ControladorUsuario.listaUsuarios[indice].NIF;
        }
    }
}
