using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ra4_actividades.Modelo
{
    [Serializable]
    public class Usuario
    {
        private string nombre;
        private string primerApellido;
        private string segundoApellido;
        private DateTime fechaNacimiento;
        private string nif;

        public Usuario() { }

        public Usuario(string nombre, string primerApellido, string segundoApellido, DateTime fechaNacimiento, string nif)
        {
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.fechaNacimiento = fechaNacimiento;
            this.nif = nif;
        }

        public string Nombre {get => nombre; set => nombre = value;}
        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value;}
        public DateTime FechaNacimiento {  get => fechaNacimiento; set =>  fechaNacimiento = value;}
        public string NIF { get => nif; set => nif = value;}
    }
}
