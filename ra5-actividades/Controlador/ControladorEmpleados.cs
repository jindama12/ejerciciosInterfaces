using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ra5_actividades
{
    public class ControladorEmpleados
    {
        public static List<Empleado> empleados = new List<Empleado>();

        public static void cargarEmpleadosPorDefecto()
        {
            empleados.Add(new Empleado(1, "Hugo", "Durán", DateTime.MinValue, 1500, false, 5));
            empleados.Add(new Empleado(2, "Iván", "Manzaneque", DateTime.MinValue, 1400, false, 4));
            empleados.Add(new Empleado(3, "Roberto", "Burgos", DateTime.MinValue, 1300, false, 3));
            empleados.Add(new Empleado(4, "Marcos", "Agueda", DateTime.MinValue, 1200, false, 2));
            empleados.Add(new Empleado(5, "Félix", "Zamarra", DateTime.MinValue, 1100, false, 1));
        }
    }
}
