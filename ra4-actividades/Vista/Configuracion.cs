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
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
            cargarValores();
        }

        private void cargarValores()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormPrincipal)
                {
                    FormPrincipal formPrincipal = (FormPrincipal)form;

                    fontColorLabel.Text = formPrincipal.colorForm.Name;
                    backColorLabel.Text = formPrincipal.fontColor.Name;
                    fontLabel.Text = formPrincipal.formFont.Name;
                    widthLabel.Text = formPrincipal.formWidth.ToString();
                    heightLabel.Text = formPrincipal.formHeight.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormPrincipal)
                {
                    FormPrincipal formPrincipal = (FormPrincipal)form;

                    if (colorDialog1.ShowDialog() == DialogResult.OK)
                    {
                        formPrincipal.fontColor = colorDialog1.Color;
                        cargarValores();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormPrincipal)
                {
                    FormPrincipal formPrincipal = (FormPrincipal)form;

                    if (colorDialog1.ShowDialog() == DialogResult.OK)
                    {
                        formPrincipal.colorForm = colorDialog1.Color;
                        cargarValores();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormPrincipal)
                {
                    FormPrincipal formPrincipal = (FormPrincipal)form;

                    if (fontDialog1.ShowDialog() == DialogResult.OK)
                    {
                        formPrincipal.formFont = fontDialog1.Font;
                        cargarValores();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormPrincipal)
                {
                    FormPrincipal formPrincipal = (FormPrincipal)form;

                    formPrincipal.Width = (int)numericUpDown1.Value;
                    cargarValores();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormPrincipal)
                {
                    FormPrincipal formPrincipal = (FormPrincipal)form;

                    formPrincipal.Height = (int)numericUpDown2.Value;
                    cargarValores();
                }
            }
        }
    }
}
