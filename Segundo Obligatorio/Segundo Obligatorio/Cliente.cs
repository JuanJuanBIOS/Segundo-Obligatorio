using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    class Cliente
    {
        //Definición de atributos
        private int cedula;
        private int tarjeta;
        private string nombre;
        private int telefono;
        private string direccion;
        private string fecha_nac;

        //Definición de propiedades
        public int Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public int Tarjeta
        {
            get { return tarjeta; }
            set { tarjeta = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Fecha_nac
        {
            get { return fecha_nac; }
            set { fecha_nac = value; }
        }

        //Constructor completo
        public Cliente(int cedula, int tarjeta, string nombre, int telefono, string direccion, string fecha_nac)
        {
            cedula = this.cedula;
            tarjeta = this.tarjeta;
            nombre = this.nombre;
            telefono = this.telefono;
            direccion = this.direccion;
            fecha_nac = this.fecha_nac;
        }


    }
}
