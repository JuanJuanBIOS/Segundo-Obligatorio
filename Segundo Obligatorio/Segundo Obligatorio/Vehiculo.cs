using System;
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
                try
                {
                    anio = Convert.ToInt16(value);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }

        public int Cant_puertas
        {
            get { return cant_puertas; }
            set { cant_puertas = value; }
        }

        public double Costo_diario
        {
            get { return costo_diario; }
            set { costo_diario = value; }
        }



        //Método para agregar marca
        public void AgregoMarca(Vehiculo V, out bool ejecutando)
        {
            //Se pide marca
            Console.Write("\nIngrese la marca o presione 'S' para salir: ");
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
            Console.Write("\nIngrese el modelo o presione 'S' para salir: ");
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
                Console.Write("\nIngrese el año del vehículo o presione 'S' para salir: ");
                string anioingresado = Console.ReadLine();
                if (Cliente.presionarS(anioingresado))
                {
                    ejecutando2 = false;
                    ejecutando = true;
                }
                else
                {
                    V.Anio = Convert.ToInt16(anioingresado);
                    ejecutando2 = false;
                    ejecutando = false;

                }
            }
        }

        //Método para agregar Cantidad de puertas
        public void AgregoCant_puertas(Vehiculo V, out bool ejecutando)
        {
            //Se pide cantidad de puerta
            Console.Write("\nIngrese la cantidad de puertas o presione 'S' para salir: ");
            string cantidaddepuertas = Console.ReadLine();
            if (Cliente.presionarS(cantidaddepuertas))
                ejecutando = true;
            else
            {
                V.Cant_puertas = Convert.ToInt32(cantidaddepuertas);
                ejecutando = false;
            }
        }

        //Método para agregar Costo
        public void AgregoCosto_Diario(Vehiculo V, out bool ejecutando)
        {
            //Se pide modelo
            Console.Write("\nIngrese el costo diario del vehiculo 'S' para salir: ");
            string costoingresado = Console.ReadLine();
            if (Cliente.presionarS(costoingresado))
                ejecutando = true;
            else
            {
                V.Costo_diario = Convert.ToInt32(costoingresado);
                ejecutando = false;
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


        //Método para agregar Vehiculo
        public static void AgregoVehiculo(string matriculaingresada, ArrayList ListaVehiculo)
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


                    Console.Clear();
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("            Mantenimiento de vehículos");
                    Console.WriteLine("\n********************************************* \n");

                    Console.WriteLine("Los datos ingresados para el vehiculo son los siguientes: ");
                    Console.WriteLine("\nMatrícula: \t\t\t{0}", V.Matricula);
                    Console.WriteLine("\nModelo: \t\t\t{0}", V.Modelo);
                    Console.WriteLine("\nMarca: \t\t\t\t{0}", V.Marca);
                    Console.WriteLine("\nAño: \t\t\t\t{0}", V.Anio);
                    Console.WriteLine("\nCantidad de pueras: \t\t{0}", V.cant_puertas);
                    Console.WriteLine("\nCosto diario: \t\t\t{0}", V.costo_diario);


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


        //Metodo mostrar Vehiculo
        public void MostrarVehiculo(Vehiculo buscado)
        {
            if (buscado is Auto)
            {
                //Down-cast de vehículo a auto
                Auto autobuscado = (Auto)buscado;

                Console.WriteLine("\n*********************************************");
                Console.WriteLine("Los datos ingresados para el auto son los siguientes: ");
                Console.WriteLine("\nMatrícula: \t\t\t{0}", autobuscado.Matricula);
                Console.WriteLine("\nModelo: \t\t\t{0}", autobuscado.Modelo);
                Console.WriteLine("\nMarca: \t\t\t\t{0}", autobuscado.Marca);
                Console.WriteLine("\nAño: \t\t\t\t{0}", autobuscado.Anio);
                Console.WriteLine("\nCantidad de pueras: \t\t{0}", autobuscado.Cant_puertas);
                Console.WriteLine("\nCosto diario: \t\t\t{0}", autobuscado.Costo_diario);
                Console.WriteLine("\nAnclaje: \t\t\t{0}", autobuscado.Anclaje);
                Console.WriteLine("*********************************************");
            }
            else
            {
                //Down-cast de vehículo a utilitario
                Utilitario utilitariobuscado = (Utilitario)buscado;

                Console.WriteLine("\n*********************************************");
                Console.WriteLine("Los datos ingresados para el utilitario son los siguientes: ");
                Console.WriteLine("\nMatrícula: \t\t\t{0}", utilitariobuscado.Matricula);
                Console.WriteLine("\nModelo: \t\t\t{0}", utilitariobuscado.Modelo);
                Console.WriteLine("\nMarca: \t\t\t\t{0}", utilitariobuscado.Marca);
                Console.WriteLine("\nAño: \t\t\t\t{0}", utilitariobuscado.Anio);
                Console.WriteLine("\nCantidad de pueras: \t\t{0}", utilitariobuscado.Cant_puertas);
                Console.WriteLine("\nCosto diario: \t\t\t{0}", utilitariobuscado.Costo_diario);
                Console.WriteLine("\nTipo: \t\t\t{0}", utilitariobuscado.Tipo);
                Console.WriteLine("\nCapacidad de carga: \t\t\t{0}", utilitariobuscado.Capacidad);
                Console.WriteLine("*********************************************");
            }
        }
    }
}

