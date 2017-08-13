using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Segundo_Obligatorio
{
    class Utilitario : Vehiculo
    {
        //Definición de atributos
        private string tipo;
        private double capacidad;

        //Definición de propiedades
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
 
        public double Capacidad
        {
            get { return capacidad; }
            set {

                //Se verifica que la capacidad sea mayor que 0
                if (value > 0)
                {
                    capacidad = value;
                }
                else
                {
                    throw new Exception("\nERROR - La capacidad debe ser mayor a cero.");
                }
            }
        }


        //Método para agregar tipo
        public void AgregoTipo(Utilitario U, out bool ejecutando)
        {
            //Se pide el tipo
            Console.Write("\nIngrese el Tipo de utilitario o presione 'S' para salir: ");
            Console.Write("\n1 - Furgoneta");
            Console.Write("\n2 - Pickup");;
            Console.WriteLine();

            bool ejecutando2 = true;
            while (ejecutando2)
            {
                string tipoingresado = Console.ReadLine();
                if (Cliente.presionarS(tipoingresado))
                    ejecutando = true;
                else
                {
                    switch (tipoingresado)
                    {
                        case "1":
                            U.Tipo = "Furgoneta";
                            ejecutando2 = false;
                            break;
                        case "2":
                            U.Tipo = "Pickup";
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


        //Método para agregar Capacidad
        public void AgregoCapacidad(Utilitario U, out bool ejecutando)
        {
            //Creacion de un loop para volver a pedir la capacidad de carga en caso de error
            ejecutando = true;
            bool ejecutando2 = true;

            while (ejecutando2)
            {
                //Se pide capacidad
                Console.Write("\nIngrese la Capacidad de carga en Kg del utilitario o presione 'S' para salir: ");
                string capacidadingresada = Console.ReadLine();
                if (Cliente.presionarS(capacidadingresada))
                {
                    ejecutando = true;
                    ejecutando2 = false;
                }
                else
                    try
                    {
                        U.Capacidad = Convert.ToInt32(capacidadingresada);
                        ejecutando = false;
                        ejecutando2 = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nERROR - Ingrese un valor numérico");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }
                }
            }


        //Constructor completo
        public Utilitario(string pmatricula, string pmarca, string pmodelo, int panio, int pcant_puertas, double pcosto_diario, string ptipo, double pcapacidad)
            : base(pmatricula, pmarca, pmodelo, panio, pcant_puertas, pcosto_diario)
        {
            Tipo = ptipo;
            Capacidad = pcapacidad;
        }

         //Constructor común
         public Utilitario(string pmatricula)
            : base(pmatricula)
        {
            Matricula = pmatricula;
        }

         //Método Mantenimineto de Utilitarios
         public static void MantenimientoUtilitarios(ArrayList ListaVehiculos, ArrayList ListaAlquileres)
         {
             // Creación de un loop para que se siga ejecutando el menú mantenimiento de autos
             bool ejecutando = true;
             while (ejecutando)
             {
                 Console.Clear();
                 Console.WriteLine("*********************************************");
                 Console.WriteLine("            Mantenimiento de Utilitarios");
                 Console.WriteLine("*********************************************");



                 //Creación de un loop para volver a ingresar matrícula si no es válida
                 bool ejecutando2 = true;
                 string matriculaingresada = "";

                 while (ejecutando2)
                 {
                     //Se pide el número de matrícula y se da la opción de volver al menú principal
                     Console.Write("\nIngrese el número matrícula (3 letras mayúsculas y 4 dígitos)\n o presione 'S' para regresar: ");
                     
                     //Ingreso de datos sin mayusculas
                     string ingreso = Console.ReadLine();
                     string aux = ingreso.ToUpper();

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
                         
                         //Si se ingerso matricula de auto se deplega mensaje

                         if (BuscoVehiculo(matriculaingresada, ListaVehiculos) is Auto)
                         {
                             Console.WriteLine("La matrícula ingresada corresponde a un Auto, en caso de querer modificarlo, salga al menú principal y luego ingerese en Mantenimiento de Autos");
                             ejecutando2 = true;
                         }
                         
                         //Si no se presionó "S" se busca al auto para comprobar si ya fue ingresado
                         if (BuscoVehiculo(matriculaingresada, ListaVehiculos) == null)
                         {
                             //Si no se encuentra en el listado de vehiculos, se pregunta si se quiere añadir
                             Console.Write("\nEl vehiculo no se encuentra en la base de datos. ¿Desea agregarlo? <S/N>: ");
                             if (Cliente.presionarS(Console.ReadLine()))
                             {
                                 //Si se quiere añadir al auto, se ejecuta el método para añadirlo
                                 AgregoUtilitario(matriculaingresada, ListaVehiculos);
                             }
                         }
                         else if (BuscoVehiculo(matriculaingresada, ListaVehiculos) is Utilitario)
                         {

                             //Si se encontró el utilitario, se muestran los datos y se pregunta qué se quiere hacer, si eliminarlo o modificarlo
                             Utilitario encontrado = (Utilitario)Vehiculo.BuscoVehiculo(matriculaingresada, ListaVehiculos);

                             Console.WriteLine("\nEl Utiliraio ya se encuentra en la base de datos.");
                             Console.WriteLine("Los datos del Utilitario ingresado son los siguientes: ");
                             encontrado.MostrarVehiculo(encontrado);
                             Console.WriteLine("\n1 - Modificar datos del Utilitario");
                             Console.WriteLine("2 - Eliminar Utilitario");
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
                                     //Si se seleccionó la opción para modificar los datos del utilitario se llama al método para hacerlo
                                     case 1:
                                         encontrado.ModificarVehiculo(encontrado, ListaVehiculos);
                                         ejecutando3 = false;
                                         break;
                                     //Si se seleccionó la opción para eliminar el utilitario se llama al método para hacerlo
                                     case 2:
                                         encontrado.EliminarVehiculo(encontrado, ListaVehiculos, ListaAlquileres);
                                         ejecutando3 = false;
                                         break;
                                     case 3:ejecutando3 = false;
                                         
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



         //Método Agregar propiedades UtilitarioAuto
         public static void AgregoUtilitario(string matriculaingresada, ArrayList ListaVehiculo)
         {
             bool ejecutando = true;
             while (ejecutando)
             {
                 //Se intenta crear un nuevo vehículo con la matricula 
                 try
                 {
                     //Se crea el vehículo con la matricula ingresada
                     Utilitario V = new Utilitario(matriculaingresada);

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

                     //Se ejecuta el método para agregar la carga
                     V.AgregoCapacidad(V, out ejecutando);
                     if (ejecutando)
                         break;

                     //Se ejecuta el método para agregar el tipo
                     V.AgregoTipo(V, out ejecutando);
                     if (ejecutando)
                         break;


                     Console.Clear();
                     Console.WriteLine("*********************************************");
                     Console.WriteLine("         Mantenimiento de Utilitarios");

                     Console.WriteLine("\n*********************************************");
                     Console.WriteLine("\nLos datos ingresados para el utilitario son los siguientes: ");
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
