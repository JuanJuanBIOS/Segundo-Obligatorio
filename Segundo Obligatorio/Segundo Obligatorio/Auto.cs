using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Segundo_Obligatorio
{
    class Auto : Vehiculo
    {
        //Definición de atributos
        private string anclaje;

        //Definición de propiedades
        public string Anclaje
        {
            get { return anclaje; }
            set {anclaje = value; }
        }

        //Método para agredar anclaje
        public void AgregoAnclaje(Auto V, out bool ejecutando)
        {
            //Se pide marca
            Console.Write("\nIngrese la marca o presione 'S' para salir: ");
            string anclajeingresado = Console.ReadLine();
            if (Cliente.presionarS(anclajeingresado))
                ejecutando = true;
            else
            {
                V.Anclaje = anclajeingresado;
                ejecutando = false;
            }
        }


        //Constructor completo
        public Auto(string pmatricula, string pmarca, string pmodelo, int panio, int pcant_puertas, double pcosto_diario, string panclaje)
            : base(pmatricula, pmarca, pmodelo, panio, pcant_puertas, pcosto_diario)
        {
            Anclaje = panclaje;
        }


        //Método Mantenimineto de Autos
        public static void MantenimientoAutos(ArrayList ListaVehiculos)
        {
            // Creación de un loop para que se siga ejecutando el menú mantenimiento de autos
            bool ejecutando = true;
            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("*********************************************");
                Console.WriteLine("            Mantenimiento de Autos");
                Console.WriteLine("\n********************************************* \n");

                //Se pide el número de matricula y se da la opción de volver al menú principal
                Console.Write("Ingrese el número matrícula(3 letras mayúsculas y 4 dígitos)\n o presione 'S' para regresar: ");
                string matriculaingresada = Console.ReadLine();     
                               
                //Si se presionó "S" se sale del menú de mantenimiento de clientes
                if (Cliente.presionarS(matriculaingresada))
                    break;
                else
                {
                    //Si no se presionó "S" se busca al auto para comprobar si ya fue ingresado
                    if (BuscoVehiculo(matriculaingresada, ListaVehiculos) == null)
                    {
                        //Si no se encuentra en el listado de vehiculos, se pregunta si se quiere añadir
                        Console.Write("\nEl vehiculo no se encuentra en la base de datos. ¿Desea agregarlo? <S/N>: ");
                        if (Cliente.presionarS(Console.ReadLine()))
                        {
                            //Si se quiere añadir al auto, se ejecuta el método para añadirlo
                            //===============================>>>>>> Este metodo tendria que cambiarlo por agrego auto o extenderlo del vehículo. Tengo que averiguar como se hace.
                            AgregoAuto(matriculaingresada, ListaVehiculos);

                        }
                    }
                    else
                    {
                        Console.Write("\nEl auto ya se encuentra en la base de datos.");
                        Console.ReadLine();
                    }
                }
            }
        }


        //Método Agregar propiedades Auto
        public static void AgregoAuto(string matriculaingresada, ArrayList ListaVehiculo)
        {
            bool ejecutando = true;
            while (ejecutando)
            {
                //Se intenta crear un nuevo vehículo con la matricula 
                try
                {
                    //Se crea el vehículo con la matricula ingresada
                    Vehiculo V = new Vehiculo(matriculaingresada);

                    //Se ejecuta el método para agregar la marca del vehiculo
                    V.AgregoMarca(V, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar el modelo del vehiculo
                    V.AgregoModelo(V, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar el anio del vehiculo
                    V.AgregoAnio(V, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar la cantidad de puertas
                    V.AgregoCant_puertas(V, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar la costo
                    V.AgregoCosto_Diario(V, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar la costo
                    //V.AgregoAnclaje(V, out ejecutando);
                    //if (ejecutando)
                        //break;


                    Console.Clear();
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("            Mantenimiento de Autos");
                    Console.WriteLine("\n********************************************* \n");

                    V.MostrarVehiculo(V);


                    /*
                    Console.WriteLine("Los datos ingresados para el vehiculo son los siguientes: ");
                    Console.WriteLine("\nMatrícula: \t\t\t{0}", V.Matricula);
                    Console.WriteLine("\nModelo: \t\t\t{0}", V.Modelo);
                    Console.WriteLine("\nMarca: \t\t\t\t{0}", V.Marca);
                    Console.WriteLine("\nAño: \t\t\t\t{0}", V.Anio);
                    Console.WriteLine("\nCantidad de pueras: \t\t{0}", V.cant_puertas);
                    Console.WriteLine("\nCosto diario: \t\t\t{0}", V.costo_diario);

                     */

                    Console.Write("\n¿Confirma el ingreso de este cliente a la base de datos? <S/N> : ");
                    string opcion = Console.ReadLine();
                    if (opcion == "S" || opcion == "s")
                    {
                        ListaVehiculo.Add(V);
                        Console.Write("\nVehículo ingresado con éxito.");
                        Console.ReadLine();
                        //ejecutando = false;
                    }
                    else
                    {
                        Console.Write("\nNo se agregó el vehículo a la base de datos.");
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


    }
}
