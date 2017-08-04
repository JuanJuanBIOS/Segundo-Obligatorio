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
                    Char.IsLetter(value,0) &&
                    Char.IsUpper(value,0) &&
                    Char.IsLetter(value,1) &&
                    Char.IsUpper(value,1) &&
                    Char.IsLetter(value,2) &&
                    Char.IsUpper(value,2) &&
                    Char.IsNumber(value,3) &&
                    Char.IsNumber(value,4) &&
                    Char.IsNumber(value,5) &&
                    Char.IsNumber(value,6) )

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
            set { anio = value; }
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

                    //Se ejecuta el método para agregar nuevo vehículo
                    V.AgregoMatricula(V, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar la tarjeta de crédito del cliente
                    V.AgregoMarca(V, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar el teléfono del cliente
                    V.AgregoModelo(V, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar la dirección del cliente
                    V.AgregoCant_puertas(V, out ejecutando);
                    if (ejecutando)
                        break;

                    //Se ejecuta el método para agregar la fecha de nacimiento del cliente
                    C.AgregoFechaNac(C, out ejecutando);
                    if (ejecutando)
                        break;

                    Console.Clear();
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("            Mantenimiento de clientes");
                    Console.WriteLine("\n********************************************* \n");

                    Console.WriteLine("Los datos ingresados para el cliente son los siguientes: ");
                    Console.WriteLine("\nDocumento: \t\t{0}", C.documento);
                    Console.WriteLine("Nombre: \t\t{0}", C.nombre);
                    Console.WriteLine("Nº de tarjeta: \t\t{0}", C.tarjeta);
                    Console.WriteLine("Teléfono: \t\t{0}", C.telefono);
                    Console.WriteLine("Dirección: \t\t{0}", C.direccion);
                    Console.WriteLine("Fecha de nacimiento: \t{0}", C.fecha_nac.ToShortDateString());

                    Console.Write("\n¿Confirma el ingreso de este cliente a la base de datos? <S/N> : ");
                    string opcion = Console.ReadLine();
                    if (opcion == "S" || opcion == "s")
                    {
                        ListaClientes.Add(C);
                        Console.Write("\nCliente ingresado con éxito.");
                        Console.ReadLine();
                        //ejecutando = false;
                    }
                    else
                    {
                        Console.Write("\nNo se agregó el cliente a la base de datos.");
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

        //Método para agregar matricula
        public void AgregoMatricula(Vehiculo V, out bool ejecutando)
        {
            //Se pide matricula
            Console.Write("\nIngrese la matricula o presione 'S' para salir: ");
            string matriculaingresada = Console.ReadLine();
            if (Cliente.presionarS(matriculaingresada))
                ejecutando = true;
            else
            {
                V.Marca = matriculaingresada;
                ejecutando = false;
            }
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
                    try
                    {
                        V.Anio = Convert.ToInt16(anioingresado);
                        ejecutando2 = false;
                        ejecutando = false;
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }
            }
        }
    }
}
