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
        public Utilitario(string pmatricula, string pmarca, string pmodelo, int panio, int pcant_puertas, double pcosto_diario, int ptipo, double pcapacidad)
            : base(pmatricula, pmarca, pmodelo, panio, pcant_puertas, pcosto_diario)
        {
            Tipo = ptipo;
            Capacidad = pcapacidad;
        }
    }
}
