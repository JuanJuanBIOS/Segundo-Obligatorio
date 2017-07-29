using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creación de un loop para que se siga ejecutando el menú principal en caso de ingresar una opción no válida
            bool ejecutando = true;
            while (ejecutando)
            {
                // Llamada al método que muestra el menú principal
                int opcion = 0;
                Menus.MenuPrincipal();

                //Se pide el número de opción del menú principal
                bool esnumero = Int32.TryParse(Console.ReadLine(), out opcion);

                //Verificación de que la opción ingresada es válida
                if (!esnumero || opcion <= 0 || opcion > 7)
                {
                    Console.Write("La opción ingresada no es válida.");
                    Console.ReadLine();
                }

                // Ejecución de métodos dependiendo de la opción ingresada
                switch (opcion)
                {
                    case 1:
                        //Mantenimiento de Clientes;
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
                        Menus.MenuPrincipal();
                        break;
                }
            }
        }
    }
}
