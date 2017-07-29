using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public Auto(string matricula, string marca, string modelo, int anio, int cant_puertas, double costo_diario, string anclaje)
            : base(matricula, marca, modelo, anio, cant_puertas, costo_diario)
        {
            anclaje = this.anclaje;
        }

    }
}
