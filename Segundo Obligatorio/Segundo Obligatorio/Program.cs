using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Segundo_Obligatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList ListaClientes = new ArrayList();
            ArrayList ListaVehiculos = new ArrayList();
            Cliente C1 = new Cliente("47879585", "JuanCa", "0123456789123456", "098492659", "Tres Cerros 1923", new DateTime(1987, 12, 16));
            Cliente C2 = new Cliente("44142650", "Vane", "0123456789123457", "091398982", "Tres Cerros 1923", new DateTime(1985, 04, 14));
            Cliente C3 = new Cliente("41348194", "JuanPe", "0123456789123458", "094586521", "Libertad y El Bosque", new DateTime(1988, 10, 14));
            ListaClientes.Add(C1);
            ListaClientes.Add(C2);
            ListaClientes.Add(C3);

            // Creación de un loop para que se siga ejecutando el menú principal en caso de ingresar una opción no válida
            bool ejecutando = true;
            while (ejecutando)
            {
                // Llamada al método que muestra el menú principal
                int opcion = 0;
                MenuPrincipal();

                //Se pide el número de opción del menú principal
                bool esnumero = Int32.TryParse(Console.ReadLine(), out opcion);

                //Verificación de que la opción ingresada es válida
                if (!esnumero || opcion <= 0 || opcion > 7)
                {
                    Console.Write("ERROR - La opción ingresada no es válida.");
                    Console.ReadLine();
                }

                // Ejecución de métodos dependiendo de la opción ingresada
                switch (opcion)
                {
                    case 1:
                        Cliente.MantenimientoClientes(ListaClientes);
                        break;
                    case 2:
                        //Manteminiento de Autos;
                        break;
                    case 3:
                        //Mantenimiento de Utilitarios;
                        break;
                    case 4:
                        //Realizar alquiler;
                        break;
                    case 5:
                        //Listado de vehiculos alquilados;
                        break;
                    case 6:
                        //Total recaudado por vehiculo;
                        break;
                    case 7:
                        ejecutando = false;
                        break;
                    default:
                        MenuPrincipal();
                        break;
                }
            }
        }

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
