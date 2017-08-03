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
        private DateTime fecha_nac;

        //Definición de propiedades
        public string Documento
        {
            get { return documento; }
            set 
            {
                //Se verifica que el número de documento ingresado cuente con al menos 6 caracteres
                if (value.Length > 5)
                    documento = value;
                else
                    throw new Exception("\nERROR - El número de documento ingresado no es válido. \nEl mismo debe constar de al menos 6 caracteres.");
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
                if (value.Length == 16 && Convert.ToInt64(value) <= 9999999999999999 && Convert.ToInt64(value) > 0)
                    tarjeta = value;
                else
                    throw new Exception("\nERROR - La tarjeta de crédito debe constar de 16 números.");
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set 
            {
                //Se verifica que el número de telefono ingresado cuente con al menos 6 caracteres y que sea un número mayor a cero
                if (value.Length > 7 && Convert.ToInt64(value) > 0)
                    telefono = value;
                else
                    throw new Exception("\nERROR - El número de teléfono debe constar de al menos 8 caracteres numéricos.");
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public DateTime Fecha_nac
        {
            get { return fecha_nac; }
            set 
            {
                //Se define una variable auxiliar para calcular la diferencia entre el año actual y el año de nacimiento
                int difanio = DateTime.Now.Year - value.Year;
                //Se comprueba que el cliente sea mayor de 18 años, teniendo en cuenta que si la diferencia entre el año actual y 
                //el año de nacimiento es 18 puede ocurrir que el cliente aún no haya cumplido los 18 años
                if (difanio<18||(difanio==18&&value.Month>DateTime.Now.Month)||
                    (difanio==18&&value.Month==DateTime.Now.Month&&value.Day>DateTime.Now.Day))
                {
                    throw new Exception("\nERROR - El cliente debe ser mayor de edad.");
                }
                else
                {
                    fecha_nac=value;
                }
            }
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
            // Creación de un loop para que se siga ejecutando el menú mantenimiento de clientes
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
                if (presionarS(documentoingresado))
                    break;
                else
                {
                    //Si no se presionó "S" se busca al cliente para comprobar si ya fue ingresado
                    if (BuscoCliente(documentoingresado, ListaClientes) == null)
                    {
                        //Si no se encuentra en el listado de clientes, se pregunta si se quiere añadir
                        Console.Write("\nEl cliente no se encuentra en la base de datos. ¿Desea agregarlo? <S/N>: ");
                        if (presionarS(Console.ReadLine()))
                        {
                            //Si se quiere añadir al cliente, se ejecuta el método para añadirlo
                            AgregoCliente(documentoingresado, ListaClientes);
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
                //Se intenta crear un cliente nuevo con el número de documento 
                try
                {
                    //Se crea el cliente con el documento ingresado
                    Cliente C = new Cliente(documentoingresado);
                    
                    //Se ejecuta el método para agregar el nombre del cliente
                    C.AgregoNombre(C, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar la tarjeta de crédito del cliente
                    C.AgregoTarjeta(C, ListaClientes, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar el teléfono del cliente
                    C.AgregoTelefono(C, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar la dirección del cliente
                    C.AgregoDireccion(C, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar la fecha de nacimiento del cliente
                    C.AgregoFechaNac(C, out ejecutando);
                    if (ejecutando)
                        break;

                    Console.Clear();
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("            Mantenimiento de clientes");
                    Console.WriteLine("\n********************************************* \n");

                    Console.WriteLine("Los datos ingresados para el cliente son los siguientes: ");
                    Console.WriteLine("\nDocumento: \t\t{0}", C.documento);
                    Console.WriteLine("Nombre: \t\t{0}", C.nombre);
                    Console.WriteLine("Nº de tarjeta: \t\t{0}", C.tarjeta);
                    Console.WriteLine("Teléfono: \t\t{0}", C.telefono);
                    Console.WriteLine("Dirección: \t\t{0}", C.direccion);
                    Console.WriteLine("Fecha de nacimiento: \t{0}", C.fecha_nac.ToShortDateString());

                    Console.Write("\n¿Confirma el ingreso de este cliente a la base de datos? <S/N> : ");
                    string opcion = Console.ReadLine();
                    if (opcion == "S" || opcion == "s")
                    {
                        ListaClientes.Add(C);
                        Console.Write("\nCliente ingresado con éxito.");
                        Console.ReadLine();
                        //ejecutando = false;
                    }
                    else
                    {
                        Console.Write("\nNo se agregó el cliente a la base de datos.");
                        Console.ReadLine();
                        //ejecutando = false;
                    }
                }
                catch (Exception error)
                {
                    Console.Write(error.Message);
                    Console.ReadLine();
                    ejecutando = false;
                }
            }
        }

        //Método para agregar nombre del cliente
        public void AgregoNombre(Cliente C, out bool ejecutando)
        {
            //Se pide el nombre del cliente
            Console.Write("\nIngrese el nombre del cliente o presione 'S' para salir: ");
            string nombreingresado = Console.ReadLine();
            if (presionarS(nombreingresado))
                ejecutando = true;
            else
            {
                C.Nombre = nombreingresado;
                ejecutando = false;
            }
        }

        //Método para agregar la tarjeta del cliente
        public void AgregoTarjeta(Cliente C, ArrayList ListaClientes, out bool ejecutando)
        {
            ejecutando = true;
            //Creación de un loop para volver a pedir el número de tarjeta de crédito en caso de ingresar un número no válido
            bool ejecutando2 = true;
            while (ejecutando2)
            {
                //Se pide la tarjeta de crédito del cliente
                Console.Write("\nIngrese la tarjeta de crédito o presione 'S' para salir: ");
                string tarjetaingresada = Console.ReadLine();

                if (presionarS(tarjetaingresada))
                {
                    ejecutando2 = false;
                    ejecutando = true;
                }
                else
                {
                    //Se busca si la tarjeta ya está ingresada a nombre de otro cliente
                    if (BuscoTarjeta(tarjetaingresada, ListaClientes) == null)
                    {
                        //Si no se encontró la tarjeta ingresada a nombre de otro cliente se guarda el valor en el cliente que se está creando
                        try
                        {
                            C.Tarjeta = tarjetaingresada;
                            ejecutando2 = false;
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
                        Console.Write("La tarjeta asociada ingresada está asociada a otro cliente.");
                        Console.ReadLine();
                    }
                }
            }
        }

        //Método para buscar tarjetas de crédito
        public Cliente BuscoTarjeta(string tarjetaingresada, ArrayList ListaClientes)
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
        public void AgregoTelefono(Cliente C, out bool ejecutando)
        {
            //Creación de un loop para volver a pedir el número de teléfono en caso de ingresar un número no válido
            ejecutando = true;
            bool ejecutando2 = true;
            while (ejecutando2)
            {
                //Se pide el número de teléfono del cliente
                Console.Write("\nIngrese el número de teléfono o presione 'S' para salir: ");
                string telingresado = Console.ReadLine();
                if (presionarS(telingresado))
                {
                    ejecutando2 = false;
                    ejecutando = true;
                }
                else
                    try
                    {
                        C.Telefono = telingresado;
                        ejecutando2 = false;
                        ejecutando = false;
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }
            }
        }

        //Método para agregar la dirección del cliente
        public void AgregoDireccion(Cliente C, out bool ejecutando)
        {
            //Se pide la dirección del cliente
            Console.Write("\nIngrese la dirección del cliente o presione 'S' para salir: ");
            string direccioningresada = Console.ReadLine();
            if (presionarS(direccioningresada))
                ejecutando = true;
            else
            {
                C.Direccion = direccioningresada;
                ejecutando = false;
            }
            
        }

        //Método para agregar la fecha de nacimiento del cliente
        public void AgregoFechaNac(Cliente C, out bool ejecutando)
        {
            ejecutando = true;
            bool ejecutando2 = true;
            while (ejecutando2)
            {
                Console.Write("\nIngrese la fecha de nacimiento del cliente (DD/MM/AAA) o presione 'S' para salir: ");
                string fechaingresada = Console.ReadLine();
                if (presionarS(fechaingresada))
                {
                    ejecutando2 = false;
                    ejecutando = true;
                }
                else
                {
                    DateTime fechanac;
                    bool esfecha = DateTime.TryParse(fechaingresada, out fechanac);
                    if (esfecha)
                    {
                        try
                        {
                            C.Fecha_nac = fechanac;
                            ejecutando2 = false;
                            ejecutando = false;
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                    }
                    else
                    {
                        Console.Write("\nERROR - La fecha ingresada no es válida.");
                    }
                }
            }
        }

        //Método auxiliar para comprobar si se quiere salir con la letra S
        public static bool presionarS(string respuesta)
        {
            if (respuesta == "S" || respuesta == "s")
                return true;
            else
                return false;
        }


    }
}
