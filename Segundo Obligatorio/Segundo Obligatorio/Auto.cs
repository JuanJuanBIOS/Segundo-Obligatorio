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
            set { anclaje = value; }
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
                Console.Write("Ingrese el número matrícula (3 letras mayúsculas y 4 dígitos) o presione 'S' para regresar: ");
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
                            AgregoVehiculo(matriculaingresada, ListaVehiculos);
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



        }
    }