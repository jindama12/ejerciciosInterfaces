using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ra5_actividades
{
    public class Empleado
    {
        private int id;
        private string nombre;
        private string apellido;
        private DateTime fechaNacimiento;
        private double salario;
        private bool esAdmin;
        private int nivel;
        public Empleado(int id, string nombre, string apellido, DateTime
        fechaNacimiento, double salario, bool esAdmin, int nivel)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNacimiento = fechaNacimiento;
            this.Salario = salario;
            this.EsAdmin = esAdmin;
            this.Nivel = nivel;
        }
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNacimiento
        {
            get => fechaNacimiento; set =>
        fechaNacimiento = value;
        }
        public double Salario { get => salario; set => salario = value; }
        public bool EsAdmin { get => esAdmin; set => esAdmin = value; }
        public int Nivel { get => nivel; set => nivel = value; }
    }
}
