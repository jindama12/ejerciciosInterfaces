using ra4_actividades.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ra4_actividades.Vista
{
    public partial class mostrarUsuarios : Form
    {
        public mostrarUsuarios()
        {
            InitializeComponent();
            cargarDatos();
        }

        public void cargarDatos()
        {
            foreach (Usuario u in Controlador.ControladorUsuario.listaUsuarios)
            {
                dataGridView1.Rows.Add(u.Nombre, u.PrimerApellido, u.SegundoApellido, u.FechaNacimiento.ToString(), u.NIF);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(Form form in Application.OpenForms)
            {
                if (form is FormPrincipal)
                {
                    FormPrincipal formPrincipal = (FormPrincipal)form;

                    int indice = dataGridView1.SelectedCells[0].RowIndex;

                    formPrincipal.index = indice;

                    formPrincipal.nombre = Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).Nombre;
                    formPrincipal.apellido1 = Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).PrimerApellido;
                    formPrincipal.apellido2 = Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).SegundoApellido;
                    formPrincipal.fechaNac = Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).FechaNacimiento;
                    formPrincipal.getNIF = Controlador.ControladorUsuario.listaUsuarios.ElementAt(indice).NIF;
                }
            }

            this.Close();
        }
    }
}
