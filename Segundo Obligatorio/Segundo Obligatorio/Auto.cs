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

                 //Creación de un loop para volver a ingresar matrícula si no es válida
                 bool ejecutando2 = true;
                 string matriculaingresada = "";

                 while (ejecutando2)
                 {
                     //Se pide el número de matrícula y se da la opción de volver al menú principal
                     Console.Write("\nIngrese el número matrícula (3 letras mayúsculas y 4 dígitos)\n o presione 'S' para regresar: ");
                     string aux = Console.ReadLine();

                     if (Cliente.presionarS(aux))
                     {
                         ejecutando2 = false;
                         ejecutando = false;

                     }

                     else
                     {

                         try
                         {
                             Vehiculo test = new Vehiculo(aux);
                             matriculaingresada = aux;
                             ejecutando2 = false;

                         }
                         catch (Exception error)
                         {
                             Console.Write(error.Message);
                         }


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
                             //Si se encontró el auto se muestran los datos y se pregunta qué se quiere hacer, si eliminarlo o modificarlo
                             Vehiculo encontrado = (Auto)encontrado;
                             encontrado = BuscoVehiculo(matriculaingresada, ListaVehiculos);
                             Console.WriteLine("\nEl Auto ya se encuentra en la base de datos.");
                             Console.WriteLine("Los datos del Auto ingresado son los siguientes: ");
                             encontrado.MostrarVehiculo(encontrado);
                             Console.WriteLine("\n1 - Modificar datos del Auto");
                             Console.WriteLine("2 - Eliminar Auto");
                             Console.WriteLine("3 - Salir");

                             //Creación de un loop para que se siga preguntando qué se desea hacer si se ingresa una opción no válida
                             bool ejecutando3 = true;
                             while (ejecutando3)
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
                                         encontrado.ModificarAuto(encontrado, ListaVehiculos);
                                         ejecutando2 = false;
                                         break;
                                     //Si se seleccionó la opción para eliminar el cliente se llama al método para hacerlo
                                     case 2:
                                         encontrado.EliminarVehiculo(encontrado, ListaVehiculos, ListaAlquileres);
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


                    //Se ejecuta el método para agregar el anclaje
                    V.AgregoAnclaje(V, out ejecutando);
                    if (ejecutando)
                        break;

                    Console.Clear();
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("            Mantenimiento de Autos");
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("Los datos ingresados para el auto son los siguientes: ");
                    //Se muestran propiedades del vehículo
                    V.MostrarVehiculo(V);
                    Console.WriteLine("*********************************************");


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
