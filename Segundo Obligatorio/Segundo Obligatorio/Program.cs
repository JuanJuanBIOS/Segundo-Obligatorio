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
                        MantenimientoClientes(ListaClientes);
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

        //Método Mantenimiento de Clientes
        public static void MantenimientoClientes(ArrayList ListaClientes)
        {
            // Creación de un loop para que se siga ejecutando el menú mantenimiento de clientes en caso de ingresar una opción no válida 
            bool ejecutando = true;
            while (ejecutando)
            {
                //Se pide el número de cédula del cliente
                Console.Clear();
                Console.WriteLine("*********************************************");
                Console.WriteLine("            Mantenimiento de clientes");
                Console.WriteLine("\n********************************************* \n");

                //Se da la opción de no ingresar ninguna cédula y volver al menú principal
                Console.Write("Ingrese el número de cedula o presione 'S' para regresar: ");
                string opcion = Console.ReadLine();

                //Si se presionó "S" se sale del menú de mantenimiento de clientes
                if (opcion == "S" || opcion == "s")
                {
                    ejecutando = false;
                }
                else
                {
                    //Se verifica que el número ingresado es válido.
                    int cedula = 0;
                    bool esnumero = Int32.TryParse(opcion, out cedula);

                    if (!esnumero || cedula <= 0)
                    {
                        //Si no es válido se  muestra el mensaje indicando el problema
                        Console.Write("ERROR - La opción ingresada no es válida.");
                        Console.ReadLine();
                    }
                    else
                    {
                       //Si el valor ingresado es válido se ejecuta el método que lo busca en el listado de clientes
                        if (BuscoCliente(cedula, ListaClientes) == null)
                        {
                            //Si no se encuentra en el listado de clientes, se pregunta si se quiere añadir
                            Console.Write("\nEl cliente no se encuentra en la base de datos. ¿Desea agregarlo <S/N>?: ");
                            string opciondos = Console.ReadLine();
                            if (opciondos == "S" || opciondos == "s")
                            {
                                //Si se quiere añadir al cliente, se ejecuta el método para hacerlo
                                AgregoCliente(cedula, ref ListaClientes);
                                ejecutando = false;
                            }
                            else
                            {
                                //Si no se quiere añadir al cliente, se sale del menú Mantenimiento de clienttes
                                ejecutando = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("El cliente ya se encuentra en la base de datos.");
                        }
                    }
                }
            }
        }

        //Método para buscar clientes
        public static Cliente BuscoCliente(int cedula, ArrayList ListaClientes)
        {
            foreach (Cliente C in ListaClientes)
            {
                if (C.Cedula == cedula)
                {
                    return C;
                }
            }
            return null;
        }

        //Método para agregar clientes
        public static void AgregoCliente(int cedula, ref ArrayList ListaClientes)
        {
            bool ejecutando = true;
            while (ejecutando)
            {
                Cliente C;
                Console.Write("\nIngrese el número de tarjeta de crédito o presione 'S' para regresar: ");
                string tarjeta = Console.ReadLine();

                //Si se presionó "S" se retorna al menú anterior
                if (tarjeta == "S" || tarjeta == "s")
                {
                    ejecutando = false;
                }
                else
                {
                    try
                    {
                        C = new Cliente(cedula, tarjeta);
                        ListaClientes.Add(C);
                        ejecutando = false;
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("\nERROR - " + error.Message);
                    }
                }
            }
        }
    }
}
