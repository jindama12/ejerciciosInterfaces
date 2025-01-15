using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ra5_actividades.Vista
{
    public partial class FormValoresCalculados : Form
    {
        public FormValoresCalculados()
        {
            InitializeComponent();
        }

        private void FormValoresCalculados_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "ReportCalculados.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource("DataSet2", ControladorEmpleados.empleados);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
