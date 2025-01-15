using Microsoft.Reporting.WinForms;
using ra5_actividades.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ra5_actividades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ControladorEmpleados.cargarEmpleadosPorDefecto();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "InformeFiltrado1.rdlc";

            ReportDataSource source = new ReportDataSource("DataSet1", ControladorEmpleados.empleados);

            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
        }

        private void filtrado1()
        {
            var empleadosFiltrados1 = ControladorEmpleados.empleados.Where(e => e.Salario > (int)numericUpDown1.Value);

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", empleadosFiltrados1));
            reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filtrado1();
        }

        private void tablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormValoresCalculados formValoresCalculados = new FormValoresCalculados();
            formValoresCalculados.ShowDialog();
        }

        private void gráficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGraficos formGraficos = new FormGraficos();
            formGraficos.ShowDialog();
        }
    }
}
