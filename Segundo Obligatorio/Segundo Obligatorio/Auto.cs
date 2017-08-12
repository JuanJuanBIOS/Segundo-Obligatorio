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

        //Método para agregar anclaje
        public void AgregoAnclaje(Auto V, out bool ejecutando)
        {
            //Se pide el anclaje
            Console.Write("\nIngrese el tipo de anclaje o presione 'S' para salir: ");
            Console.Write("\n1 - Cinturón");
            Console.Write("\n2 - ISOFIX");
            Console.Write("\n3 - Latch");
            Console.WriteLine();

            bool ejecutando2 = true;
            while (ejecutando2)
            {
                string anclajeingresado = Console.ReadLine();
                if (Cliente.presionarS(anclajeingresado))
                    ejecutando = true;
                else
                {
                    switch (anclajeingresado)
                    {
                        case "1":
                            V.Anclaje = "Cinturón";
                            ejecutando2 = false;
                            break;
                        case "2":
                            V.Anclaje = "ISOFIX";
                            ejecutando2 = false;
                            break;
                        case "3":
                            V.Anclaje = "Latch";
                            ejecutando2 = false;
                            break;
                        default:
                            Console.WriteLine("Ingrese valor dentro de las opciones");
                            break;
                    }
                }
            }
            ejecutando = false;
        }


        //Constructor completo
        public Auto(string pmatricula, string pmarca, string pmodelo, int panio, int pcant_puertas, double pcosto_diario, string panclaje)
            : base(pmatricula, pmarca, pmodelo, panio, pcant_puertas, pcosto_diario)
        {
            Anclaje = panclaje;
        }

        //Constructor común
         public Auto(string pmatricula)
            : base(pmatricula)
        {
            Matricula = pmatricula;
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
                Console.WriteLine("\n*********************************************");

                //Se pide el número de matricula y se da la opción de volver al menú principal
                Console.Write("Ingrese el número matrícula (3 letras mayúsculas y 4 dígitos)\n o presione 'S' para regresar: ");
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
                    Auto V = new Auto(matriculaingresada);

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

                    //Se ejecuta el método para agregar el costo
                    V.AgregoCosto_Diario(V, out ejecutando);
                    if (ejecutando)
                        break;

<<<<<<< HEAD
                    //Se ejecuta el método para agregar el anclaje
                    V.AgregoAnclaje(V, out ejecutando);
                    if (ejecutando)
                        break;
=======
                    //Se ejecuta el método para agregar la costo
                    //V.AgregoAnclaje(V, out ejecutando);
                    //if (ejecutando)
                        //break;
>>>>>>> fc8e51f5b9232de1808f2541431c21f89ec41c54


                    Console.Clear();
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("            Mantenimiento de Autos");

                    V.MostrarVehiculo(V);


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
