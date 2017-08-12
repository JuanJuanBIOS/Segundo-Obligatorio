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
        private string tarjeta;  //Se define la tarjeta como string porque puede empezar con ceros
        private string telefono; //Se define el teléfono como string porque puede empezar con ceros
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
                //Se verifica que el número de telefono ingresado cuente con al menos 8 caracteres y que sea un número mayor a cero
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
                //A la fecha actual se le sacan 25 años
                DateTime menos25anios = DateTime.Now.AddYears(-25);
                //Se compara el valor obtenido con la fecha actual para verificar si el cliente es mayor de 25 años
                if (value.Date <= menos25anios.Date)
                {
                    fecha_nac = value;
                }
                else
                {
                    throw new Exception("\nERROR - El cliente debe ser mayor de edad.");
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

        //Constructor completo
        public Cliente(string pdocumento, string pnombre, string ptarjeta, string ptelefono, string pdireccion, DateTime pfecha_nac)
        {
            Documento = pdocumento;
            Nombre = pnombre;
            Tarjeta = ptarjeta;
            Telefono = ptelefono;
            Direccion = pdireccion;
            Fecha_nac = pfecha_nac;
        }

        //Método Mantenimiento de Clientes
        public static void MantenimientoClientes(ArrayList ListaClientes, ArrayList ListaAlquileres)
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
                        //Si se encontró el cliente se muestran los datos y se pregunta qué se quiere hacer, si eliminarlo o modificarlo
                        Cliente encontrado = BuscoCliente(documentoingresado, ListaClientes);
                        
                        Console.WriteLine("\nEl cliente ya se encuentra en la base de datos.");
                        Console.WriteLine("Los datos del cliente ingresado son los siguientes: ");
                        encontrado.MostrarCliente(encontrado);
                        Console.WriteLine("\n1 - Modificar datos del cliente");
                        Console.WriteLine("2 - Eliminar cliente");
                        Console.WriteLine("3 - Salir");
                        
                        //Creación de un loop para que se siga preguntando qué se desea hacer si se ingresa una opción no válida
                        bool ejecutando2 = true;
                        while (ejecutando2)
                        {
                            int opcion = 0;
                            Console.Write("\nIngrese la opción deseada: ");
                            //Se pide el número de opción
                            bool esnumero = Int32.TryParse(Console.ReadLine(), out opcion);

                            //Verificación de que la opción ingresada es válida
                            if (!esnumero || opcion <= 0 || opcion > 3)
                            {
                                Console.Write("ERROR - La opción ingresada no es válida.");
                                Console.ReadLine();
                            }

                            // Ejecución de métodos dependiendo de la opción ingresada
                            switch (opcion)
                            {
                                //Si se seleccionó la opción para modificar los datos del cliente se llama al método para hacerlo
                                case 1:
                                    encontrado.ModificarCliente(encontrado, ListaClientes);
                                    ejecutando2 = false;
                                    break;
                                //Si se seleccionó la opción para eliminar el cliente se llama al método para hacerlo
                                case 2:
                                    encontrado.EliminarCliente(encontrado, ListaClientes, ListaAlquileres);
                                    ejecutando2 = false;
                                    break;
                                case 3:
                                    ejecutando2 = false;
                                    break;
                                default:
                                    break;
                            }
                        }
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
            //Creación de un loop para permitir que en cualquier parte del ingreso de los datos se pueda cancelar el mismo
            bool ejecutando = true;
            while (ejecutando)
            {
                //Se intenta crear un cliente nuevo con el número de documento 
                try
                {
                    //Se crea el cliente con el documento ingresado
                    Cliente C = new Cliente(documentoingresado);
                    
                    //Se ejecuta el método para agregar el nombre del cliente
                    C.AgregoNombre(C, ListaClientes, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar la tarjeta de crédito del cliente
                    C.AgregoTarjeta(C, ListaClientes, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar el teléfono del cliente
                    C.AgregoTelefono(C, ListaClientes, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar la dirección del cliente
                    C.AgregoDireccion(C,ListaClientes, out ejecutando);
                    if (ejecutando)
                        break;
                    
                    //Se ejecuta el método para agregar la fecha de nacimiento del cliente
                    C.AgregoFechaNac(C, ListaClientes, out ejecutando);
                    if (ejecutando)
                        break;

                    Console.Clear();
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("            Mantenimiento de clientes");
                    Console.WriteLine("\n********************************************* \n");

                    Console.WriteLine("Los datos ingresados para el cliente son los siguientes: ");
                    C.MostrarCliente(C);

                    Console.Write("\n¿Confirma el ingreso de este cliente a la base de datos? <S/N> : ");
                    string opcion = Console.ReadLine();
                    if (presionarS(opcion))
                    {
                        ListaClientes.Add(C);
                        Console.Write("\nCliente ingresado con éxito.");
                        Console.ReadLine();
                        ejecutando = false;
                    }
                    else
                    {
                        Console.Write("\nNo se agregó el cliente a la base de datos.");
                        Console.ReadLine();
                        ejecutando = false;
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
        public void AgregoNombre(Cliente C, ArrayList ListaClientes, out bool ejecutando)
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
                        Console.Write("\nLa tarjeta asociada ingresada está asociada a otro cliente.");
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
        public void AgregoTelefono(Cliente C, ArrayList ListaClientes, out bool ejecutando)
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
        public void AgregoDireccion(Cliente C, ArrayList ListaClientes, out bool ejecutando)
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
        public void AgregoFechaNac(Cliente C,ArrayList ListaClientes, out bool ejecutando)
        {
            //Creación de un loop para pedir de nuevo la fecha de nacimiento en caso de ingresar una fecha no válida
            ejecutando = true;
            bool ejecutando2 = true;
            while (ejecutando2)
            {
                //Se pide el ingreso de la fecha de nacimiento del cliente y se da la opción de presionar S para salir
                Console.Write("\nIngrese la fecha de nacimiento del cliente (DD/MM/AAA) o presione 'S' para salir: ");
                string fechaingresada = Console.ReadLine();
                //Si se presionó S se sale de esta opción
                if (presionarS(fechaingresada))
                {
                    ejecutando2 = false;
                    ejecutando = true;
                }
                else
                {
                    //Se intenta convertir la fecha ingresada por el usuario en un formato de fecha válido
                    DateTime fechanac;
                    bool esfecha = DateTime.TryParse(fechaingresada, out fechanac);
                    if (esfecha)
                    {
                        //Si se pudo convertir a una fecha válida se intenta guardar el dato
                        try
                        {
                            C.Fecha_nac = fechanac;
                            ejecutando2 = false;
                            ejecutando = false;
                        }
                        //En caso de existir algún error como que el cliente sea menor de 25 años se muestra el mensaje
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                    }
                    //Si no se ingresó una fecha válida se muestra el error
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

        //Método para modificar los datos de un cliente
        public void ModificarCliente(Cliente encontrado, ArrayList ListaClientes)
        {
            //Creación de un loop para volver a pedir la opción deseada en caso de ingresar una opción no válida
            bool ejecutando = true;
            while (ejecutando)
            {
                //Se muestran los datos del cliente y se pregunta qué dato se desea modificar
                Console.Clear();
                Console.WriteLine("*********************************************");
                Console.WriteLine("            Modificar cliente");
                Console.WriteLine("\n********************************************* \n");

                Console.WriteLine("Elija el dato que desea modificar: ");
                Console.WriteLine("\n1 - Documento: \t\t\t{0}", encontrado.documento);
                Console.WriteLine("2 - Nombre: \t\t\t{0}", encontrado.nombre);
                Console.WriteLine("3 - Nº de tarjeta: \t\t{0}", encontrado.tarjeta);
                Console.WriteLine("4 - Teléfono: \t\t\t{0}", encontrado.telefono);
                Console.WriteLine("5 - Dirección: \t\t\t{0}", encontrado.direccion);
                Console.WriteLine("6 - Fecha de nacimiento: \t{0}", encontrado.fecha_nac.ToShortDateString());
                Console.WriteLine("7 - Salir");
                Console.Write("\nDigite la opción deseada: ");

                int opcion = 0;
                bool esnumero = Int32.TryParse(Console.ReadLine(), out opcion);
                //En caso de ingresar una opción no válida se muestra el error
                if (!esnumero || opcion <= 0 || opcion > 7)
                {
                    Console.Write("ERROR - La opción ingresada no es válida.");
                    Console.ReadLine();
                }
                //En caso de ingresar una opción válida se ejecutan los métodos dependiendo de la opción deseada
                switch (opcion)
                {
                    case 1:
                        AgregoDocumento(encontrado, ListaClientes, out ejecutando);
                        if (!ejecutando)
                        {
                            Console.Write("\nEl documento se ha cambiado satisfactoriamente. Los nuevos datos del cliente son los siguientes: ");
                            encontrado.MostrarCliente(encontrado);
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        AgregoNombre(encontrado, ListaClientes, out ejecutando);
                        if (!ejecutando)
                        {
                            Console.Write("\nEl nombre se ha cambiado satisfactoriamente. Los nuevos datos del cliente son los siguientes: ");
                            encontrado.MostrarCliente(encontrado);
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        AgregoTarjeta(encontrado, ListaClientes, out ejecutando);
                        if (!ejecutando)
                        {
                            Console.Write("\nEl número de tarjeta se ha cambiado satisfactoriamente. Los nuevos datos del cliente son los siguientes: ");
                            encontrado.MostrarCliente(encontrado);
                            Console.ReadLine();
                        }
                        break;
                    case 4:
                        AgregoTelefono(encontrado, ListaClientes, out ejecutando);
                        if (!ejecutando)
                        {
                            Console.Write("\nEl teléfono se ha cambiado satisfactoriamente. Los nuevos datos del cliente son los siguientes: ");
                            encontrado.MostrarCliente(encontrado);
                            Console.ReadLine();
                        }
                        break;
                    case 5:
                        AgregoDireccion(encontrado, ListaClientes, out ejecutando);
                        if (!ejecutando)
                        {
                            Console.Write("\nLa dirección se ha cambiado satisfactoriamente. Los nuevos datos del cliente son los siguientes: ");
                            encontrado.MostrarCliente(encontrado);
                            Console.ReadLine();
                        }
                        break;
                    case 6:
                        AgregoFechaNac(encontrado, ListaClientes, out ejecutando);
                        if (!ejecutando)
                        {
                            Console.Write("\nLa fecha de nacimiento se ha cambiado satisfactoriamente. Los nuevos datos del cliente son los siguientes: ");
                            encontrado.MostrarCliente(encontrado);
                            Console.ReadLine();
                        }
                        break;
                    case 7:
                        ejecutando = false;
                        break;
                    default:
                        break;
                }
            }


        }

        //Método para agregar el documento del cliente
        public void AgregoDocumento(Cliente C, ArrayList ListaClientes, out bool ejecutando)
        {
            //Creación de un loop para volver a pedir el documento en caso de ingresar un número no válido
            ejecutando = true;
            bool ejecutando2 = true;
            while (ejecutando2)
            {
                //Se pide el número de documento del cliente
                Console.Write("\nIngrese el número documento (cédula o pasaporte) o presione 'S' para regresar: ");
                string docingresado = Console.ReadLine();
                if (presionarS(docingresado))
                {
                    ejecutando2 = false;
                    ejecutando = true;
                }
                else
                    try
                    {
                        C.Documento = docingresado;
                        ejecutando2 = false;
                        ejecutando = false;
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }
            }
        }

        //Método para eliminar los datos de un cliente
        public void EliminarCliente(Cliente encontrado, ArrayList ListaClientes, ArrayList ListaAlquileres)
        {
            bool tienealquiler = false;
            foreach (Alquiler A in ListaAlquileres)
            {
                if (A.Cliente == encontrado)
                {
                    tienealquiler = true;
                }
            }

            if (tienealquiler)
            {
                Console.Write("\nNo se puede eliminar el cliente ya que el mismo posee alquileres a su nombre.");
                Console.ReadLine();
            }
            else
            {
                Console.Write("\n¿Confirma que desea eliminar el cliente? <S/N>: ");
                if (presionarS(Console.ReadLine()))
                {
                    ListaClientes.Remove(encontrado);
                    Console.Write("\nSe ha eliminado el cliente.");
                }
                else
                    Console.Write("\nNo se ha eliminado el cliente");
            }
        }

        //Método para mostrar los datos de un cliente
        public void MostrarCliente(Cliente buscado)
        {
            //Console.WriteLine("*********************************************");
            Console.WriteLine("\nDocumento: \t\t{0}", buscado.documento);
            Console.WriteLine("Nombre: \t\t{0}", buscado.nombre);
            Console.WriteLine("Nº de tarjeta: \t\t{0}", buscado.tarjeta);
            Console.WriteLine("Teléfono: \t\t{0}", buscado.telefono);
            Console.WriteLine("Dirección: \t\t{0}", buscado.direccion);
            Console.WriteLine("Fecha de nacimiento: \t{0}", buscado.fecha_nac.ToShortDateString());
            //Console.WriteLine("*********************************************");
        }
    }
}
