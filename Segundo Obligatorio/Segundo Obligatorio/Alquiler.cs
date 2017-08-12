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
        private static int secuencial;

        //Definición de propiedades
        public Vehiculo Vehiculo
        {
            get { return vehiculo; }
            set { vehiculo = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public DateTime Fecha_inicio
        {
            get { return fecha_inicio; }
            set
            {
                if (value.Date >= DateTime.Now.Date)
                {
                    fecha_inicio = value;
                }
                else
                {
                    throw new Exception("\nERROR - La fecha de inicio no puede ser anterior a hoy.");
                } 
            }
        }

        public DateTime Fecha_fin
        {
            get { return fecha_fin; }
            set
            {
                if (value.Date >= DateTime.Now.Date)
                {
                    fecha_fin = value;
                }
                else
                {
                    throw new Exception("\nERROR - La fecha de fin no puede ser anterior a hoy.");
                }
            }
        }

        public double Costo
        {
            get { return costo; }
            set
            {
                if (value > 0)
                {
                    costo = value;
                }
                else
                {
                    throw new Exception("\nERROR - El costo debe ser mayor a cero.");
                }
            }
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

        //Constructor completo
        public Alquiler(Vehiculo pV, Cliente pC, DateTime pfechaini, DateTime pfechafin, double pcosto, int pcodigo)
        {
            Vehiculo = pV;
            Cliente = pC;
            Fecha_inicio = pfechaini;
            Fecha_fin = pfechafin;
            Costo = pcosto;
            Codigo = pcodigo;
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
                        //Si no se presionó "S" se busca al cliente para comprobar si existe en la base de datos
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

                    //Se ejecuta el método para agregar las fechas del alquiler
                    A.AgregoFechas(A, VehiculosAUX, ListaAlquileres, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar el costo del alquiler
                    A.CalculoCosto(A);

                    //Se ejecuta el método para confirmar el alquiler
                    A.ConfirmarAlquiler(A, ListaAlquileres);
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
            ejecutando = false;
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
                        A.vehiculo = vehiculoingresado;
                        ejecutando2 = false;
                    }
                }
            }
        }

        public void AgregoFechas(Alquiler A, ArrayList VehiculosAUX, ArrayList ListaAlquileres, out bool ejecutando)
        {
            //Creación de un loop para pedir de nuevo las fechas en caso de ingresar fechas no válidas
            ejecutando = false;
            bool ejecutando2 = true;
            while (ejecutando2)
            {
                //Se pide el ingreso de la fecha de inicio del alquiler
                Console.Write("\nIngrese la fecha de inicio del alquiler (DD/MM/AAA) o presione 'S' para salir: ");
                string fechainiingresada = Console.ReadLine();
                if (Cliente.presionarS(fechainiingresada))
                {
                    ejecutando2 = false;
                    ejecutando = true;
                    break;
                }

                //Se intenta convertir la fecha ingresada por el usuario en un formato de fecha válido
                DateTime fechaini;
                bool esfechaini = DateTime.TryParse(fechainiingresada, out fechaini);
                //Si no se pudo convertir se muestra el mensaje de error
                if (!esfechaini)
                {
                    Console.Write("\nERROR - La fecha ingresada no es válida.\n");
                }
                else
                {
                    bool ejecutando3 = true;
                    while (ejecutando3)
                    {
                        //Se pide el ingreso de la fecha de fin del alquiler
                        Console.Write("\nIngrese la fecha de fin del alquiler (DD/MM/AAA) o presione 'S' para salir: ");
                        string fechafiningresada = Console.ReadLine();
                        if (Cliente.presionarS(fechafiningresada))
                        {
                            ejecutando2 = false;
                            ejecutando3 = false;
                            ejecutando = true;
                            break;
                        }

                        //Se intenta convertir la fecha ingresada por el usuario en un formato de fecha válido
                        DateTime fechafin;
                        bool esfechafin = DateTime.TryParse(fechafiningresada, out fechafin);
                        //Si no se pudo convertir se muestra el mensaje de error
                        if (!esfechafin)
                        {
                            Console.Write("\nERROR - La fecha ingresada no es válida.\n");
                        }
                        else
                        {
                            ejecutando3 = false;
                            if (A.VerificoFechas(A, ListaAlquileres, VehiculosAUX, fechaini, fechafin))
                                ejecutando2 = false;
                            else
                                ejecutando2 = true;                            
                        }
                    }
                }
            }
        }


        public bool VerificoFechas(Alquiler A, ArrayList ListaAlquileres, ArrayList VehiculosAUX, DateTime fechaini, DateTime fechafin)
        {
            if (fechafin.Date<fechaini.Date)
            {
                Console.Write("\nERROR - La fecha final no puede ser menor a la fecha inicial.\n");
                return false;
            }
            else if (fechafin == fechaini)
            {
                Console.Write("\nERROR - El alquiler debe ser de mínimo 1 día de duración.\n");
                return false;
            }
            else
            {
                
                try
                {
                    A.Fecha_inicio = fechaini;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    return false;
                }
                try
                {
                    A.fecha_fin = fechafin;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    return false;
                }
                return true;
            }
        }

        public bool VehiculoAlquilado(Alquiler A, ArrayList ListaAlquileres, DateTime fechaini, DateTime fechafin)
        {
            foreach (Alquiler Alq in ListaAlquileres)
            {
                if (Alq.Vehiculo == A.Vehiculo)
                {
                    if (fechaini >= Alq.Fecha_fin || fechafin <= Alq.Fecha_inicio)
                    {
                        return false;
                    }
                    
                    return true;
                }
            }
            return true;
        }


        public void CalculoCosto(Alquiler A)
        {
            int duracion = (A.fecha_fin - A.fecha_inicio).Days;
            try
            {
                A.Costo = duracion * A.Vehiculo.Costo_diario;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                Console.ReadLine();
            }
        }

        //Método para confirmar el alquiler
        public void ConfirmarAlquiler(Alquiler A, ArrayList ListaAlquileres)
        {
            Console.Clear();
            Console.WriteLine("*********************************************");
            Console.WriteLine("            CONFIRMAR ALQUILER");
            Console.WriteLine("*********************************************");
            Console.WriteLine("DATOS DEL CLIENTE");
            Cliente.MostrarCliente(A.Cliente);
            Console.WriteLine("\nDATOS DEL VEHÍCULO");
            Vehiculo.MostrarVehiculo(A.Vehiculo);
            Console.WriteLine("\nDATOS DEL ALQUILER");
            //Console.WriteLine("*********************************************");
            Console.WriteLine("\nCódigo: \t\t{0}", A.Codigo);
            Console.WriteLine("Fecha inicio: \t\t{0}", A.Fecha_inicio.ToShortDateString());
            Console.WriteLine("Fecha fin: \t\t{0}", A.Fecha_fin.ToShortDateString());
            Console.WriteLine("Costo total: \t\t{0}", A.Costo);
            //Console.WriteLine("*********************************************");

            Console.Write("\n¿Confirma el ingreso del alquiler con los datos anteriores? <S/N> : ");
            string opcion = Console.ReadLine();
            if (Cliente.presionarS(opcion))
            {
                ListaAlquileres.Add(A);
                Console.Write("\nAlquiler ingresado con éxito.");
                Console.ReadLine();
            }
            else
            {
                Console.Write("\nNo se ingresó el alquiler a la base de datos.");
                Console.ReadLine();
            }
        }
    }
}
