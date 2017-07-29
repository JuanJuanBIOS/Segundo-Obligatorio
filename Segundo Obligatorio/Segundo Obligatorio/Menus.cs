
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    class Menus
    {
        // Método que muestra el menú principal
        public static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("*********************************************");
            Console.WriteLine("            Alquiler de vehículos");
            Console.WriteLine("\n********************************************* \n");
            Console.WriteLine("   1 - Mantenimiento de Clientes    ");
            Console.WriteLine("   2 - Mantenimiento de Autos");
            Console.WriteLine("   3 - Mantenimiento de Utilitarios");
            Console.WriteLine("   4 - Realizar alquiler");
            Console.WriteLine("   5 - Listado de vehículos alquilados");
            Console.WriteLine("   6 - Total recaudado por vehículo");
            Console.WriteLine("   7 - Salir\n");
            Console.WriteLine("*********************************************");
            Console.Write("Ingrese la opción deseada: ");
        }

    }
}
