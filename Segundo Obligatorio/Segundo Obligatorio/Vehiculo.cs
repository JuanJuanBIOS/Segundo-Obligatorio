using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            set { matricula = value; }
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
        public Vehiculo(string matricula, string marca, string modelo, int anio, int cant_puertas, double costo_diario)
        {
            matricula = this.matricula;
            marca = this.marca;
            modelo = this.modelo;
            anio = this.anio;
            cant_puertas = this.cant_puertas;
            costo_diario = this.costo_diario;
        }


    }
}
