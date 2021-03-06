﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace Segundo_Obligatorio
{
    class Vehiculo
    {
        //Definición de atributos
        private string matricula;
        private string marca;
        private string modelo;
        private int anio;
        private int cant_puertas;
        private double costo_diario;


        //Definición de propiedades
        public string Matricula
        {
            get { return matricula; }
            set
            {
                //se verifica que sea 3 letras mayúsculas y 4 dígitos
                if (value.Length == 7 &&
                    Char.IsLetter(value, 0) &&
                    Char.IsUpper(value, 0) &&
                    Char.IsLetter(value, 1) &&
                    Char.IsUpper(value, 1) &&
                    Char.IsLetter(value, 2) &&
                    Char.IsUpper(value, 2) &&
                    Char.IsNumber(value, 3) &&
                    Char.IsNumber(value, 4) &&
                    Char.IsNumber(value, 5) &&
                    Char.IsNumber(value, 6))

                    matricula = value;

                else
                    throw new Exception("\nERROR - La matrícula ingresada no es válida. \nLa misma debe ser compuesta por 3 letras mayúsculas y 4 dígitos.");

            }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public int Anio
        {
            get { return anio; }
            set
            {
                //se verifica que el ano sea igual o menor al actual y mayor que 
                if (value <= Convert.ToInt16((DateTime.Today).Year) && value > 0)
                {
                    anio = value;

                }
                else
                {
                    throw new Exception("\nERROR - El año debe ser igual o menor al año actual");
                }
            }
        }


        public int Cant_puertas
        {
            get { return cant_puertas; }
            set
            {
                //Se verifica que la cantidad de puertas sea entre 1 y 5
                

                if (value < 6 && value > 0)
                {
                    cant_puertas = value;
                }
                else
                {
                    throw new Exception("\nERROR - La cantidad de puertas debe ser entre 1 y 5.");
                }
            }
        }


        public double Costo_diario
        {
            get { return costo_diario; }
            set
            {
                //Se verifica que el costo se mayor que 0
                if (value > 0)
                {
                    costo_diario = value;
                }
                else
                {
                    throw new Exception("\nERROR - El costo diario debe ser mayor a cero.");
                }
            }
        }


        //Método para agregar matricula
        public void AgregoMatricula(Vehiculo V, ArrayList ListaVehiculo, out bool ejecutando)
        {
            //Creación de un loop para volver a pedir el documento en caso de ingresar un número no válido
            ejecutando = true;
            bool ejecutando2 = true;
            while (ejecutando2)
            {
                //Se pide el número de matricula del vehículo
                Console.Write("\nIngrese la matrícula del vehículo o presione 'S' para regresar: ");
                string matriculaingresada = Console.ReadLine();
                if (Cliente.presionarS(matriculaingresada))
                {
                    ejecutando2 = false;
                    ejecutando = true;
                }
                else
                    try
                    {
                        V.Matricula = matriculaingresada;
                        ejecutando2 = false;
                        ejecutando = false;
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }
            }
        }


        //Método para agregar marca
        public void AgregoMarca(Vehiculo V, out bool ejecutando)
        {
            //Se pide marca
            Console.Write("\nIngrese la Marca o presione 'S' para salir: ");
            string marcaingresada = Console.ReadLine();
            if (Cliente.presionarS(marcaingresada))
                ejecutando = true;
            else
            {
                V.Marca = marcaingresada;
                ejecutando = false;
            }
        }

        //Método para agregar modelo
        public void AgregoModelo(Vehiculo V, out bool ejecutando)
        {
            //Se pide modelo
            Console.Write("\nIngrese el Modelo o presione 'S' para salir: ");
            string modeloingresado = Console.ReadLine();
            if (Cliente.presionarS(modeloingresado))
                ejecutando = true;
            else
            {
                V.Modelo = modeloingresado;
                ejecutando = false;
            }
        }

        //Método para agregar año del vehículo
        public void AgregoAnio(Vehiculo V, out bool ejecutando)
        {
            //Creación de un loop para volver el año en caso de ingresar un número no válido
            ejecutando = true;
            bool ejecutando2 = true;
            while (ejecutando2)
            {
                //Se pide el año del vehículo
                Console.Write("\nIngrese el Año del vehículo o presione 'S' para salir: ");
                string anioingresado = Console.ReadLine();
                if (Cliente.presionarS(anioingresado))
                {
                    ejecutando2 = false;
                    ejecutando = true;
                }
                else
                    try
                    {
                        V.Anio = Convert.ToInt32(anioingresado);
                        ejecutando2 = false;
                        ejecutando = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nERROR - Ingrese un valor numérico.");

                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }
            }
        }

        
        
        
        //Método para agregar Cantidad de puertas
        public void AgregoCant_puertas(Vehiculo V, out bool ejecutando)
        {
            //Creación de un loop para volver a pedir cantidad de puertas en caso de error
            ejecutando = true;
            bool ejecutando2 = true;
            while (ejecutando2)
            {
                //Se pide cantidad de puertas
                Console.Write("\nIngrese la Cantidad de puertas o presione 'S' para salir: ");
                string cantidaddepuertas = Console.ReadLine();
                if (Cliente.presionarS(cantidaddepuertas))
                {
                    ejecutando = true;
                    ejecutando2 = false;
                }
                else
                    try
                    {
                        V.Cant_puertas = Convert.ToInt16(cantidaddepuertas);
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


        //Método para agregar Costo
        public void AgregoCosto_Diario(Vehiculo V, out bool ejecutando)
        {
            //Creación de un loop para volver a pedir el costo en caso de error
            ejecutando = true;
            bool ejecutando2 = true;

            while (ejecutando2)
            {
                //Se pide costo
                Console.Write("\nIngrese el Costo diario del vehiculo 'S' para salir: ");
                string costoingresado = Console.ReadLine();
                if (Cliente.presionarS(costoingresado))
                {
                    ejecutando = true;
                    ejecutando2 = false;
                }
                else
                    try
                    {
                        V.Costo_diario = Convert.ToInt32(costoingresado);
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
        public Vehiculo(string pmatricula, string pmarca, string pmodelo, int panio, int pcant_puertas, double pcosto_diario)
        {
            Matricula = pmatricula;
            Marca = pmarca;
            Modelo = pmodelo;
            Anio = panio;
            Cant_puertas = pcant_puertas;
            Costo_diario = pcosto_diario;
        }

        //Constructor común

        public Vehiculo(string pmatricula)
        {
            Matricula = pmatricula;
        }


        //Método para buscar Vehículo
        public static Vehiculo BuscoVehiculo(string matriculaingresada, ArrayList ListaVehiculo)
        {
            foreach (Vehiculo V in ListaVehiculo)
            {
                if (V.Matricula == matriculaingresada)
                {
                    return V;
                }
            }
            return null;
        }


        //Metodo mostrar Vehiculo
        public void MostrarVehiculo(Vehiculo buscado)
        {
            if (buscado is Auto)
            {
                //Down-cast de vehículo a auto
                Auto autobuscado = (Auto)buscado;


                Console.WriteLine("Matrícula: \t\t{0}", autobuscado.Matricula);
                Console.WriteLine("Marca: \t\t\t{0}", autobuscado.Marca);
                Console.WriteLine("Modelo: \t\t{0}", autobuscado.Modelo);
                Console.WriteLine("Año: \t\t\t{0}", autobuscado.Anio);
                Console.WriteLine("Cantidad de pueras: \t{0}", autobuscado.Cant_puertas);
                Console.WriteLine("Costo diario: \t\t{0}", autobuscado.Costo_diario);
                Console.WriteLine("Anclaje: \t\t{0}", autobuscado.Anclaje);

            }
            else
            {
                //Down-cast de vehículo a utilitario
                Utilitario utilitariobuscado = (Utilitario)buscado;



                Console.WriteLine("Matrícula: \t\t{0}", utilitariobuscado.Matricula);
                Console.WriteLine("Marca: \t\t\t{0}", utilitariobuscado.Marca);
                Console.WriteLine("Modelo: \t\t{0}", utilitariobuscado.Modelo);
                Console.WriteLine("Año: \t\t\t{0}", utilitariobuscado.Anio);
                Console.WriteLine("Cantidad de pueras: \t{0}", utilitariobuscado.Cant_puertas);
                Console.WriteLine("Costo diario: \t\t{0}", utilitariobuscado.Costo_diario);
                Console.WriteLine("Tipo: \t\t\t{0}", utilitariobuscado.Tipo);
                Console.WriteLine("Capacidad de carga: \t{0}", utilitariobuscado.Capacidad);


            }
        }


        //Método para eliminar los Vehículo
        public void EliminarVehiculo(Vehiculo encontrado, ArrayList ListaVehiculos, ArrayList ListaAlquileres)
        {
            bool tienealquiler = false;
            foreach (Alquiler A in ListaAlquileres)
            {
                if (A.Vehiculo == encontrado)
                {
                    tienealquiler = true;
                }
            }

            if (tienealquiler)
            {
                Console.Write("\nNo se puede eliminar el Vehículo ya que el mismo posee alquileres a su nombre.");
                Console.ReadLine();
            }
            else
            {
                Console.Write("\n¿Confirma que desea eliminar el vehiculo? <S/N>: ");
                if (Cliente.presionarS(Console.ReadLine()))
                {
                    ListaVehiculos.Remove(encontrado);
                    Console.Write("\nSe ha eliminado el Vehículo.");
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("\nNo se ha eliminado el Vehículo");
                    Console.ReadKey();
                }
            }
        }


        //Método para modificar los vehículo
        public void ModificarVehiculo(Vehiculo encontrado, ArrayList ListaVehiculos)
        {
            if (encontrado is Auto)
            {
                //Down-cast de vehículo a auto
                Auto autobuscado = (Auto)encontrado;

                bool ejecutando = true;
                while (ejecutando)
                {
                    //Se muestran los datos del cliente y se pregunta qué dato se desea modificar
                    Console.Clear();
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("            Modificar Auto");
                    Console.WriteLine("\n********************************************* \n");

                    Console.WriteLine("1 - Matrícula: \t\t\t{0}", autobuscado.Matricula);
                    Console.WriteLine("2 - Marca: \t\t\t{0}", autobuscado.Marca);
                    Console.WriteLine("3 - Modelo: \t\t\t{0}", autobuscado.Modelo);
                    Console.WriteLine("4 - Año: \t\t\t{0}", autobuscado.Anio);
                    Console.WriteLine("5 - Cantidad de pueras: \t{0}", autobuscado.Cant_puertas);
                    Console.WriteLine("6 - Costo diario: \t\t{0}", autobuscado.Costo_diario);
                    Console.WriteLine("7 - Anclaje: \t\t\t{0}", autobuscado.Anclaje);
                    Console.WriteLine("8 - Salir");
                    Console.Write("\nDigite la opción deseada: ");

                    int opcion = 0;
                    bool esnumero = Int32.TryParse(Console.ReadLine(), out opcion);
                    //En caso de ingresar una opción no válida se muestra el error
                    if (!esnumero || opcion <= 0 || opcion > 8)
                    {
                        Console.Write("ERROR - La opción ingresada no es válida.");
                        Console.ReadLine();
                    }
                    //En caso de ingresar una opción válida se ejecutan los métodos dependiendo de la opción deseada
                    switch (opcion)
                    {
                        case 1:
                            AgregoMatricula(encontrado, ListaVehiculos, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nLa Matrícula se ha cambiado satisfactoriamente. Los nuevos datos del auto son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;
                        case 2:
                            AgregoMarca(encontrado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nLa Marca se ha cambiado satisfactoriamente. Los nuevos datos del auto son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;
                        case 3:
                            AgregoModelo(encontrado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nEl Modelo se ha cambiado satisfactoriamente. Los nuevos datos del auto son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;
                        case 4:
                            AgregoAnio(encontrado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nEl Año se ha cambiado satisfactoriamente. Los nuevos datos del auto son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;
                        case 5:
                            AgregoCant_puertas(encontrado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nLa Cantidad de puertas se ha cambiado satisfactoriamente. Los nuevos datos del auto son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;
                        case 6:
                            AgregoCosto_Diario(encontrado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nEl Costo diario se ha cambiado satisfactoriamente. Los nuevos datos del auto son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;

                        case 7:
                            autobuscado.AgregoAnclaje(autobuscado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nEl tipo de anclaje se ha cambiado satisfactoriamente. Los nuevos datos del auto son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;


                        case 8:
                            ejecutando = false;
                            break;
                        default:
                            break;
                    }
                }
            }

            else
            {
                //Down-cast de vehículo a utilitario
                Utilitario utilitariobuscado = (Utilitario)encontrado;

                bool ejecutando = true;
                while (ejecutando)
                {
                    //Se muestran los datos del cliente y se pregunta qué dato se desea modificar
                    Console.Clear();
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("            Modificar utilitario");
                    Console.WriteLine("\n********************************************* \n");


                    Console.WriteLine("1 - Matrícula: \t\t\t{0}", utilitariobuscado.Matricula);
                    Console.WriteLine("2 - Marca: \t\t\t{0}", utilitariobuscado.Marca);
                    Console.WriteLine("3 - Modelo: \t\t\t{0}", utilitariobuscado.Modelo);
                    Console.WriteLine("4 - Año: \t\t\t{0}", utilitariobuscado.Anio);
                    Console.WriteLine("5 - Cantidad de pueras: \t{0}", utilitariobuscado.Cant_puertas);
                    Console.WriteLine("6 - Costo diario: \t\t{0}", utilitariobuscado.Costo_diario);
                    Console.WriteLine("7 - Tipo: \t\t\t{0}", utilitariobuscado.Tipo);
                    Console.WriteLine("8 - Capacidad de carga:\t\t{0}", utilitariobuscado.Capacidad);
                    Console.WriteLine("9 - Salir");
                    Console.Write("\nDigite la opción deseada: ");

                    int opcion = 0;
                    bool esnumero = Int32.TryParse(Console.ReadLine(), out opcion);
                    //En caso de ingresar una opción no válida se muestra el error
                    if (!esnumero || opcion <= 0 || opcion > 9)
                    {
                        Console.Write("ERROR - La opción ingresada no es válida.");
                        Console.ReadLine();
                    }
                    //En caso de ingresar una opción válida se ejecutan los métodos dependiendo de la opción deseada
                    switch (opcion)
                    {
                        case 1:
                            AgregoMatricula(encontrado, ListaVehiculos, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nLa Matrícula se ha cambiado satisfactoriamente. Los nuevos datos del utilitario son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;
                        case 2:
                            AgregoMarca(encontrado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nLa Marca se ha cambiado satisfactoriamente. Los nuevos datos del utilitario son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;
                        case 3:
                            AgregoModelo(encontrado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nEl Modelo se ha cambiado satisfactoriamente. Los nuevos datos del utilitario son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;
                        case 4:
                            AgregoAnio(encontrado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nEl Año se ha cambiado satisfactoriamente. Los nuevos datos del utilitario son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;
                        case 5:
                            AgregoCant_puertas(encontrado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nLa Cantidad de puertas se ha cambiado satisfactoriamente. Los nuevos datos del utilitario son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;
                        case 6:
                            AgregoCosto_Diario(encontrado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nEl Costo diario se ha cambiado satisfactoriamente. Los nuevos datos del utilitario son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;

                        case 7:
                            utilitariobuscado.AgregoTipo(utilitariobuscado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nEl tipo se ha cambiado satisfactoriamente. Los nuevos datos del utilitario son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;

                        case 8:
                            utilitariobuscado.AgregoCapacidad(utilitariobuscado, out ejecutando);
                            if (!ejecutando)
                            {
                                Console.Write("\nLa capacidad se ha cambiado satisfactoriamente. Los nuevos datos del utilitario son los siguientes:\n");
                                encontrado.MostrarVehiculo(encontrado);
                                Console.ReadLine();
                            }
                            break;

                        case 9:
                            ejecutando = false;
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}