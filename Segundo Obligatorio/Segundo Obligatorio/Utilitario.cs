using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    class Utilitario : Vehiculo
    {
        //Definición de atributos
        private int tipo;
        private double capacidad;

        //Definición de propiedades
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public double Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }
        }

        //Constructor completo
        public Utilitario(string matricula, string marca, string modelo, int anio, int cant_puertas, double costo_diario, int tipo, double capacidad)
            : base(matricula, marca, modelo, anio, cant_puertas, costo_diario)
        {
            tipo = this.tipo;
            capacidad = this.capacidad;
        }
    }
}
