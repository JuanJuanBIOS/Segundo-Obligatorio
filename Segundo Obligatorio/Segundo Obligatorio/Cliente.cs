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
        private string documento; //Se define el documento como string porque puede ser un pasaporte que contiene letras o cédulas extranjeras que contienen letras
        private string nombre;
        private string tarjeta;  //Se define la tarjeta como string porque puede empezar con ceros y además no se necesita operar con el número de tarjeta
        private string telefono; //Se define el teléfono como string porque puede empezar con ceros y además no se necesita operar con el número de teléfono
        private string direccion;
        private string fecha_nac;

        //Definición de propiedades
        public string Documento
        {
            get { return documento; }
            set 
            {
                //Se verifica que el número de documento ingresado cuente con al menos 6 caracteres
                if (value.Length > 5)
                    tarjeta = value;
                else
                    throw new Exception("\nEl número de documento ingresado no es válido. \nEl número de documento debe constar de al menos 6 caracteres.");
            }
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
                //Se verifica que el número de tarjeta ingresado cuente con 16 caracteres, que sea un número y que sea mayora a cero
                if (value.Length == 16 && Convert.ToInt64(value) < 9999999999999999 && Convert.ToInt64(value) > 0)
                    tarjeta = value;
                else
                    throw new Exception("\nLa tarjeta de crédito debe constar de 16 números.");
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set 
            {
                //Se verifica que el número de telefono ingresado cuente con al menos 6 caracteres y que sea un número mayor a cero
                if (value.Length > 7 && Convert.ToInt64(value) > 0)
                    tarjeta = value;
                else
                    throw new Exception("\nEl número de teléfono debe constar de al menos 8 caracteres numéricos.");
            }
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

        //Constructor común
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
                string documentoingresado = Console.ReadLine();

                //Si se presionó "S" se sale del menú de mantenimiento de clientes
                if (documentoingresado == "S" || documentoingresado == "s")
                {
                    ejecutando = false;
                }
                else
                {
                    //Se busca al cliente para comprobar si ya fue ingresado
                    if (BuscoCliente(documentoingresado, ListaClientes) == null)
                    {
                        //Si no se encuentra en el listado de clientes, se pregunta si se quiere añadir
                        Console.Write("\nEl cliente no se encuentra en la base de datos. ¿Desea agregarlo <S/N>?: ");
                        string opcion = Console.ReadLine();
                        if (opcion == "S" || opcion == "s")
                        {
                            //Si se quiere añadir al cliente, se ejecuta el método para hacerlo
                            AgregoCliente(documentoingresado, ListaClientes);
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
        public static Cliente BuscoCliente(string documentoingresado, ArrayList ListaClientes)
        {
            foreach (Cliente C in ListaClientes)
            {
                if (C.Documento == documentoingresado)
                {
                    return C;
                }
            }
            return null;
        }

        //Método para agregar cliente
        public static void AgregoCliente(string documentoingresado, ArrayList ListaClientes)
        {
            bool ejecutando = true;
            while (ejecutando)
            {
                //Se crea un cliente nuevo con el número de documento 
                try
                {
                    Cliente C = new Cliente(documentoingresado);
                    C.AgregoNombre(C);
                    C.AgregoTarjeta(C, ListaClientes);
                    C.AgregoTelefono(C);
                    //C.AgregoDireccion(C);
                    //C.AgregoFechaNac(C);
                    ListaClientes.Add(C);
                    ejecutando = false;
                }
                catch (Exception error)
                {
                    Console.Write(error.Message);
                    Console.ReadLine();
                    break;
                }
            }
        }

        //Método para agregar nombre del cliente
        public void AgregoNombre(Cliente C)
        {
            //Se pide el nombre del cliente
            Console.Write("\nIngrese el nombre del cliente: ");
            string nombreingresado = Console.ReadLine();
            C.Nombre = nombreingresado;
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
                string tarjetaingresada = Console.ReadLine();
                //Se busca si la tarjeta ya está ingresada a nombre de otro cliente
                if (BuscoTarjeta(tarjetaingresada, ListaClientes) == null)
                {
                    //Si no se encontró la tarjeta ingresada a nombre de otro cliente se guarda el valor en el cliente que se está creando
                    try
                    {
                        C.Tarjeta = tarjetaingresada;
                        ejecutando = false;
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }
                }
                else
                {
                    //Si se encontró la tarjeta ingresada a nombre de otro cliente se informa de la situación
                    Console.Write("\nLa tarjeta asociada ingresada está asociada a otro cliente.");
                    Console.ReadLine();
                }
            }
        }

        //Método para buscar tarjetas de crédito
        public static Cliente BuscoTarjeta(string tarjetaingresada, ArrayList ListaClientes)
        {
            foreach (Cliente C in ListaClientes)
            {
                if (C.Tarjeta == tarjetaingresada)
                {
                    return C;
                }
            }
            return null;
        }

        //Método para agregar teléfono del cliente
        public void AgregoTelefono(Cliente C)
        {
            //Creación de un loop para volver a pedir el número de teléfono en caso de ingresar un número no válido
            bool ejecutando = true;
            while (ejecutando)
            {
                //Se pide la tarjeta de crédito del cliente
                Console.Write("\nIngrese el número de teléfono: ");
                string telingresado = Console.ReadLine();
                try
                {
                    C.Telefono = telingresado;
                    ejecutando = false;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }



    }
}
