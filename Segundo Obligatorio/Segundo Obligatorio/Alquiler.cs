using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Segundo_Obligatorio
{
    class Alquiler
    {
        //Definición de atributos
        private Vehiculo vehiculo;
        private Cliente cliente;
        private DateTime fecha_inicio;
        private DateTime fecha_fin;
        private double costo;
        private int codigo;

        //Definición de propiedades
        public DateTime Fecha_inicio
        {
            get { return Fecha_inicio; }
            set { fecha_inicio = value; }
        }

        public DateTime Fecha_fin
        {
            get { return fecha_fin; }
            set { fecha_fin = value; }
        }

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        //Constructor común
        public Alquiler(Cliente arrendador)
        {
            cliente = arrendador;
        }

        public static void RealizarAlquiler(ArrayList ListaClientes, ArrayList VehiculosAUX, ArrayList ListaAlquileres)
        {
            // Creación de un loop para que se siga ejecutando el menú realizar alquiler
            bool ejecutando = true;
            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("*********************************************");
                Console.WriteLine("            Realizar Alquiler");
                Console.WriteLine("\n********************************************* \n");

                //Se verifica que el listado de clientes tenga al menos un cliente
                if (ListaClientes.Count == 0)
                {
                    Console.Write("La base de datos no contiene ningún cliente. \nPara ingresar un nuevo cliente dirígase al mantenimiento de clientes desde el menú principal.");
                    Console.ReadLine();
                    ejecutando = false;
                }
                //Se verifica que el listado de vehículos tenga al menos un vehículo
                else if (VehiculosAUX.Count == 0)
                {
                    Console.Write("La base de datos no contiene ningún vehículo. \nPara ingresar un nuevo vehíiculo dirígase al mantenimiento de autos o utilitarios desde el menú principal.");
                    Console.ReadLine();
                    ejecutando = false;
                }
                else
                {
                    //Se pide el número de documento del cliente y se da la opción de volver al menú principal
                    Console.Write("Ingrese el número documento del cliente (cédula o pasaporte) o presione 'S' para regresar: ");
                    string documentoingresado = Console.ReadLine();

                    //Si se presionó "S" se sale del menú de mantenimiento de clientes
                    if (Cliente.presionarS(documentoingresado))
                        break;
                    else
                    {
                        //Si no se presionó "S" se busca al cliente para comprobar si que existe en la base de datos
                        Cliente arrendador = Cliente.BuscoCliente(documentoingresado, ListaClientes);
                        if (arrendador == null)
                        {
                            //Si no se encuentra en el listado de clientes, se informa la situación
                            Console.Write("\nEl cliente no se encuentra en la base de datos. \nPara ingresar un nuevo cliente dirígase al mantenimiento de clientes desde el menú principal.");
                            Console.ReadLine();
                        }
                        else
                        {
                            //Si se encuentra al cliente en la base de datos se ejecuta el método para agregar un alquiler
                            AgregoAlquiler(arrendador, ListaAlquileres, VehiculosAUX);
                        }
                    }
                }
            }
        }

        //Método para agregar un alquiler
        public static void AgregoAlquiler(Cliente arrendador, ArrayList ListaAlquileres, ArrayList VehiculosAUX)
        {
            //Creación de un loop para permitir que en cualquier parte del ingreso de los datos se pueda cancelar el mismo 
            bool ejecutando = true;
            while (ejecutando)
            {
                //Se intenta crear un alquiler nuevo con el arrendandor ingresado
                try
                {
                    Alquiler A = new Alquiler(arrendador);

                    //Se ejecuta el método para agregar un vehículo al alquiler
                    A.AgregoVehiculo(A, VehiculosAUX, ListaAlquileres, out ejecutando);
                    if (ejecutando)
                        break;

                    /*//Se ejecuta el método para agregar las fechas del alquiler
                    A.AgregoFechas(A, VehiculosAUX, ListaAlquileres, out ejecutando);
                    if (ejecutando)
                        break;*/

                    //Se ejecuta el método para agregar el costo del alquiler
                    A.AgregoCosto(A, VehiculosAUX, ListaAlquileres, out ejecutando);
                    if (ejecutando)
                        break;
                }
                catch
                {
                    Console.Write("ERROR - No se pudo ingresar el alquiler correctamente");
                    Console.ReadLine();
                }
            }
        }




        public void AgregoVehiculo(Alquiler A,ArrayList VehiculosAUX,ArrayList ListaAlquileres, out bool ejecutando)
        {
            //Creación de un loop para que se vuelva a pedir la matrícula en caso de que se ingrese una que no es válida
            ejecutando = true;
            bool ejecutando2 = true;
            while (ejecutando2)
            {
                //Se pide la matrícula del vehículo a alquilar
                Console.Write("\nIngrese la matrícula del vehículo o presione 'S' para salir: ");
                string matriculaingresada = Console.ReadLine();
                //Si se presionó S se retorna al paso anterior
                if (Cliente.presionarS(matriculaingresada))
                {
                    ejecutando2 = false;
                    ejecutando = true;
                }
                else
                {
                    //Si no se presionó S se busca el vehículo en el listado de vehículos
                    Vehiculo vehiculoingresado = Vehiculo.BuscoVehiculo(matriculaingresada, VehiculosAUX);
                    //Si no se encontró el vehículo se informa de la situación al usuario
                    if (vehiculoingresado == null)
                    {
                        Console.Write("\nLa matrícula ingresada no se encuentra en la base de datos.\n");
                        ejecutando = false;
                    }
                    //Si se encontró el vehículo se piden las fechas en las cuales se quiere realizar el alquiler
                    else
                    {
                        A.AgregoFechas(A, VehiculosAUX, ListaAlquileres, out ejecutando);
                        if (!ejecutando)
                        {
                            A.vehiculo = vehiculoingresado;
                            ejecutando2 = false;
                        }
                        else
                            ejecutando2 = false;
                    }
                }
            }
        }

        public void AgregoFechas(Alquiler A, ArrayList VehiculosAUX, ArrayList ListaAlquileres, out bool ejecutando)
        {
            //Creación de un loop para pedir de nuevo las fechas en caso de ingresar fechas no válidas
            ejecutando = true;
            bool ejecutando2 = true;
            while (ejecutando2)
            {
                //Se pide el ingreso de la fecha de inicio del alquiler
                Console.Write("\nIngrese la fecha de inicio del alquiler (DD/MM/AAA) o presione 'S' para salir: ");
                string fechainiingresada = Console.ReadLine();
                //Si se presionó S se sale de esta opción
                if (Cliente.presionarS(fechainiingresada))
                {
                    ejecutando2 = false;
                    ejecutando = true;
                    break;
                }
                else
                {
                    //Se intenta convertir la fecha ingresada por el usuario en un formato de fecha válido
                    DateTime fechaini;
                    bool esfechaini = DateTime.TryParse(fechainiingresada, out fechaini);
                    if (esfechaini)
                    {
                        //Si se pudo convertir a una fecha válida se intenta guardar el dato
                        try
                        {
                            A.Fecha_inicio = fechaini;
                            ejecutando2 = false;
                        }
                        //En caso de existir algún error como haber ingresado una fecha anterior a hoy se muestra el error correspondiente
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                    }
                    //Si no se ingresó una fecha válida se muestra el error
                    else
                    {
                        Console.Write("\nERROR - La fecha ingresada no es válida.\n");
                    }
                }
            }
            
            if (A.fecha_inicio > Convert.ToDateTime("01/01/0001"))
            {
                bool ejecutando3 = true;
                while (ejecutando3)
                {
                    //Se pide el ingreso de la fecha de fin del alquiler
                    Console.Write("\nIngrese la fecha de fin del alquiler (DD/MM/AAA) o presione 'S' para salir: ");
                    string fechafiningresada = Console.ReadLine();
                    //Si se presionó S se sale de esta opción
                    if (Cliente.presionarS(fechafiningresada))
                    {
                        ejecutando3 = false;
                        ejecutando = true;
                        break;
                    }
                    else
                    {
                        //Se intenta convertir la fecha ingresada por el usuario en un formato de fecha válido
                        DateTime fechafin;
                        bool esfechafin = DateTime.TryParse(fechafiningresada, out fechafin);
                        if (esfechafin)
                        {
                            //Si se pudo convertir a una fecha válida se intenta guardar el dato
                            try
                            {
                                A.Fecha_fin = fechafin;
                                ejecutando3 = false;
                                ejecutando = false;
                            }
                            //En caso de existir algún error como haber ingresado una fecha anterior a hoy se muestra el error correspondiente
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
        }

        public void AgregoCosto(Alquiler A,ArrayList VehiculosAUX,ArrayList ListaAlquileres, out bool ejecutando)
        {
            ejecutando = false;
        }





    }
}
