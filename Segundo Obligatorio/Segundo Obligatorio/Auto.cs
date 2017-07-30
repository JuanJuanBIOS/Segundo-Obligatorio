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
        public Auto(string pmatricula, string pmarca, string pmodelo, int panio, int pcant_puertas, double pcosto_diario, string panclaje)
            : base(pmatricula, pmarca, pmodelo, panio, pcant_puertas, pcosto_diario)
        {
            Anclaje = panclaje;
        }

    }
}
