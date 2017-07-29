using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    class Alquiler
    {
        //Definición de atributos
        private Vehiculo vehiculo;
        private Cliente cliente;
        private string fecha_inicio;
        private string fecha_fin;
        private double costo;
        private int codigo;

        //Definición de propiedades
        public string Fecha_inicio
        {
            get { return Fecha_inicio; }
            set { fecha_inicio = value; }
        }

        public string Fecha_fin
        {
            get { return fecha_fin; }
            set { fecha_fin = value; }
        }

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
    }
}
