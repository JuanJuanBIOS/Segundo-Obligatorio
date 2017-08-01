using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Segundo_Obligatorio
{
    class Cliente
    {
        //Definición de atributos
        private string documento;
        private string nombre;
        private string tarjeta;
        private int telefono;
        private string direccion;
        private string fecha_nac;
        List<Alquiler> ListaAlquieres;

        //Definición de propiedades
        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Tarjeta
        {
            get { return tarjeta; }
            set
            {
                if (value.Length == 16 && Convert.ToInt64(value) < 9999999999999999 && Convert.ToInt64(value) > 0)
                    tarjeta = value;
                else
                    throw new Exception("La tarjeta de crédito debe constar de 16 números.");
            }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Fecha_nac
        {
            get { return fecha_nac; }
            set { fecha_nac = value; }
        }

        //Constructor por defecto
        public Cliente ()
        {
        }

        //Constructor
        public Cliente(string pdocumento)
        {
            Documento = pdocumento;
        }

        //Método Mantenimiento de Clientes
        public static void MantenimientoClientes(ArrayList ListaClientes)
        {
            // Creación de un loop para que se siga ejecutando el menú mantenimiento de clientes en caso de ingresar una opción no válida 
            bool ejecutando = true;
            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("*********************************************");
                Console.WriteLine("            Mantenimiento de clientes");
                Console.WriteLine("\n********************************************* \n");

                //Se pide el número de documento y se da la opción de volver al menú principal
                Console.Write("Ingrese el número documento (cédula o pasaporte) o presione 'S' para regresar: ");
                string documento = Console.ReadLine();

                //Si se presionó "S" se sale del menú de mantenimiento de clientes
                if (documento == "S" || documento == "s")
                {
                    ejecutando = false;
                }
                else
                {
                    //Se busca al cliente para comprobar si ya fue ingresado
                    if (BuscoCliente(documento, ListaClientes) == null)
                    {
                        //Si no se encuentra en el listado de clientes, se pregunta si se quiere añadir
                        Console.Write("\nEl cliente no se encuentra en la base de datos. ¿Desea agregarlo <S/N>?: ");
                        string opcion = Console.ReadLine();
                        if (opcion == "S" || opcion == "s")
                        {
                            //Si se quiere añadir al cliente, se ejecuta el método para hacerlo
                            AgregoCliente(documento, ListaClientes);
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
                        Console.Write("\nEl cliente ya se encuentra en la base de datos.");
                        Console.ReadLine();
                    }
                }
            }
        }

        //Método para buscar clientes
        public static Cliente BuscoCliente(string documento, ArrayList ListaClientes)
        {
            foreach (Cliente C in ListaClientes)
            {
                if (C.Documento == documento)
                {
                    return C;
                }
            }
            return null;
        }

        //Método para agregar cliente
        public static void AgregoCliente(string documento, ArrayList ListaClientes)
        {
            //Se crea un cliente nuevo con el número de documento 
            Cliente C = new Cliente(documento);
            C.AgregoNombre(C);
            C.AgregoTarjeta(C, ListaClientes);
            ListaClientes.Add(C);
        }

        //Método para agregar nombre del cliente
        public void AgregoNombre(Cliente C)
        {
            //Se pide el nombre del cliente
            Console.Write("\nIngrese el nombre del cliente: ");
            C.Nombre = Console.ReadLine();
        }

        //Método para agregar la tarjeta del cliente
        public void AgregoTarjeta(Cliente C, ArrayList ListaClientes)
        {
            //Creación de un loop para volver a pedir el número de tarjeta de crédito en caso de ingresar un número no válido
            bool ejecutando = true;
            while (ejecutando)
            {
                //Se pide la tarjeta de crédito del cliente
                Console.Write("\nIngrese la tarjeta de crédito: ");
                string valoringresado = Console.ReadLine();
                if (BuscoTarjeta(valoringresado, ListaClientes) == null)
                {
                    try
                    {
                        C.Tarjeta = valoringresado;
                        ejecutando = false;
                    }
                    catch (Exception error)
                    {
                        Console.Write(error.Message);
                    }
                }
                else
                {
                    Console.Write("\nLa tarjeta asociada ingresada está asociada a otro cliente.");
                    Console.ReadLine();
                }
            }
        }

        //Método para buscar tarjetas de crédito
        public static Cliente BuscoTarjeta(string tarjeta, ArrayList ListaClientes)
        {
            foreach (Cliente C in ListaClientes)
            {
                if (C.Tarjeta == tarjeta)
                {
                    return C;
                }
            }
            return null;
        }

    }
}
