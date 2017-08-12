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
        private static int secuencial = 0;

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

        public int Secuencial
        {
            get { return secuencial; }
            set { secuencial = value; }
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
                            //Si los formatos de fechas con correctos se hace la verificación de las mismas
                            if (A.VerificoFechas(A, ListaAlquileres, VehiculosAUX, fechaini, fechafin))
                                ejecutando2 = false;
                            else
                                ejecutando2 = true;                            
                        }
                    }
                }
            }
        }

        //Método para verificar las fechas ingresadas de alquiler
        public bool VerificoFechas(Alquiler A, ArrayList ListaAlquileres, ArrayList VehiculosAUX, DateTime fechaini, DateTime fechafin)
        {
            //Se comprueba que la fecha final no sea menor a la fecha inicial
            if (fechafin.Date < fechaini.Date)
            {
                Console.Write("\nERROR - La fecha final no puede ser menor a la fecha inicial.\n");
                return false;
            }
            //Se comprueba que el alquiler tenga una duración mínima de 1 día
            else if (fechafin == fechaini)
            {
                Console.Write("\nERROR - El alquiler debe ser de mínimo 1 día de duración.\n");
                return false;
            }
            else
            {
                //Si pasa las verificaciones anteriores se verifica que el vehículo no se encuentre alquilado en las fechas seleccionadas
                if (A.VehiculoAlquilado(A, ListaAlquileres, fechaini, fechafin))
                {
                    return false;
                }
                else
                {
                    //Si las fechas pasaron todos los controles anteriores se agregan al alquiler
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
        }

        //Método para verificar si el vehículo está alquilado
        public bool VehiculoAlquilado(Alquiler A, ArrayList ListaAlquileres, DateTime fechaini, DateTime fechafin)
        {
            //Se busca en la lista de alquileres
            foreach (Alquiler Alq in ListaAlquileres)
            {
                //Se compara el vehículo que se quiere alquilar con el vehículo de cada alquiler
                if (Alq.Vehiculo == A.Vehiculo)
                {
                    //Si el vehículo coincide y las fechas se solapan se muestra el error correspondiente
                    if (fechaini <= Alq.Fecha_fin && fechafin >= Alq.Fecha_inicio)
                    {
                        Console.Write("\nERROR - El vehículo se encuentra alquilado entre el {0} y el {1}.\n", Alq.Fecha_inicio.ToShortDateString(), Alq.Fecha_fin.ToShortDateString());
                        return true;
                    }
                }
                else
                    return false;
            }
            return false;
        }

        //Método para calcular costo del alquiler
        public void CalculoCosto(Alquiler A)
        {
            //Se calcula la duración en días del alquiler
            int duracion = (A.fecha_fin - A.fecha_inicio).Days;
            //Se carga el costo del alquiler multiplicando el costo diario por la cantidad de días
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
            //Se despliegan todos los datos del alquiler en pantalla
            Console.Clear();
            Console.WriteLine("*********************************************");
            Console.WriteLine("            CONFIRMAR ALQUILER");
            Console.WriteLine("*********************************************");
            Console.WriteLine("DATOS DEL CLIENTE");
            Cliente.MostrarCliente(A.Cliente);
            Console.WriteLine("\nDATOS DEL VEHÍCULO\n");
            Vehiculo.MostrarVehiculo(A.Vehiculo);
            Console.WriteLine("\nDATOS DEL ALQUILER");
            Console.WriteLine("Fecha inicio: \t\t{0}", A.Fecha_inicio.ToShortDateString());
            Console.WriteLine("Fecha fin: \t\t{0}", A.Fecha_fin.ToShortDateString());
            Console.WriteLine("Costo total: \t\t${0}", A.Costo);
            //Se pregunta si se confirma el alquiler
            Console.Write("\n¿Confirma el ingreso del alquiler con los datos anteriores? <S/N> : ");
            string opcion = Console.ReadLine();
            if (Cliente.presionarS(opcion))
            {
                //Si se confirma el alquiler se agrega a la lista de alquileres y se muestra el mensaje correpondiente
                secuencial = secuencial + 1; 
                //Se le asigna un código al alquiler recién confirmado el cual surge de sumarle 1 al secuencial
                try
                {
                    A.Codigo = secuencial;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    Console.ReadLine();
                }
                //Se agrega el alquiler y se muestra el mensaje indicando con qué código se agregó
                ListaAlquileres.Add(A);
                Console.Write("\nAlquiler ingresado con éxito con el código Nº {0}.", A.Codigo);
                Console.ReadLine();
            }
            else
            {
                //Si no se confirma el alquiler, no se agrega a la lista y se muestra el mensaje correpondiente
                Console.Write("\nNo se ingresó el alquiler a la base de datos.");
                Console.ReadLine();
            }
        }

        //Método para mostrar el listado de vehículos alquilados en una determinada fecha
        public static void VehiculosAlquilados(ArrayList ListaAlquileres)
        {
            bool ejecutando = true;
            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("*********************************************");
                Console.WriteLine("       LISTADO DE VEHÍCULOS ALQUILADOS");
                Console.WriteLine("*********************************************");

                //Se pide el ingreso de la fecha para la cual se quiere hacer la consulta y se da la opción de presionar S para salir
                Console.Write("\nIngrese la fecha que desea consultar (DD/MM/AAA) o presione 'S' para salir: ");
                string fechaingresada = Console.ReadLine();
                //Si se presionó S se sale de esta opción
                if (Cliente.presionarS(fechaingresada))
                {
                    ejecutando = false;
                }
                else
                {
                    //Se intenta convertir la fecha ingresada por el usuario en un formato de fecha válido
                    DateTime fecha;
                    bool esfecha = DateTime.TryParse(fechaingresada, out fecha);
                    if (esfecha)
                    {
                        //Si se pudo convertir a formato de fecha se busca en el listado de alquileres y se listan los vehículos alquilados en esa fecha
                        Console.WriteLine("\nLos vehículos alquilados en la fecha consultada son los siguientes:\n");
                        foreach (Alquiler A in ListaAlquileres)
                        {
                            if (fecha >= A.Fecha_inicio && fecha <= A.Fecha_fin)
                            {
                                if (A.Vehiculo is Auto)
                                    Console.Write("Auto - ");
                                else
                                    Console.Write("Utilitario - ");

                                Console.WriteLine("{0} - {1} {2} - {3} - Alquilado entre el {4} y el {5}\n", A.Vehiculo.Matricula, A.Vehiculo.Marca, A.Vehiculo.Modelo, A.Vehiculo.Anio, A.Fecha_inicio.ToShortDateString(), A.Fecha_fin.ToShortDateString());
                            }
                        }
                        Console.ReadLine();
                    }
                    //Si no se ingresó una fecha válida se muestra el error
                    else
                    {
                        Console.Write("\nERROR - La fecha ingresada no es válida.");
                    }
                }
            }
        }

        //Método para mostrar la recaudación de un vechículo
        public static void Recaudado(ArrayList ListaAlquileres, ArrayList VehiculosAUX)
        {
            bool ejecutando = true;
            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("*********************************************");
                Console.WriteLine("       RECAUDACIÓN POR VEHÍCULO");
                Console.WriteLine("*********************************************");

                //Se pide el ingreso de la matrícula para la cual se quiere hacer la consulta y se da la opción de presionar S para salir
                Console.Write("\nIngrese la matrícula que desea consultar o presione 'S' para salir: ");
                string matriculaingresada = Console.ReadLine();
                //Si se presionó S se sale de esta opción
                if (Cliente.presionarS(matriculaingresada))
                {
                    ejecutando = true;
                }
                else
                {
                    //Se busca el vehículo en el listado de vehículos y si no se encuentra se muestra el error
                    if (Vehiculo.BuscoVehiculo(matriculaingresada, VehiculosAUX) == null)
                    {
                        Console.Write("\nLa matrícula ingresada no se encuentra en la base de datos");
                        Console.ReadLine();
                    }
                    else
                    {
                        //Si el vehículo se encuentra en el listado se recorre el listado de alquileres y se va sumando el importe correpondiente a ese vehículo
                        double recaudacion = 0;
                        foreach (Alquiler A in ListaAlquileres)
                        {
                            if (matriculaingresada == A.Vehiculo.Matricula)
                            {
                                recaudacion = recaudacion + A.Costo;
                            }
                        }
                        //Se muestra lo total recaudado
                        Console.Write("\nEl total recaudado por el vehículo ingresado es de $ {0}", recaudacion);
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
