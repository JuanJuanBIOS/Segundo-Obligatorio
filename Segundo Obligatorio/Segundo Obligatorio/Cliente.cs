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
        private string tarjeta;
        private string nombre;
        private int telefono;
        private string direccion;
        private string fecha_nac;
        List<Alquiler> ListaAlquieres;

        //Definición de propiedades
        public int Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public string Tarjeta
        {
            get { return tarjeta; }
            set
            {
                if (value.Length == 16 && Convert.ToInt64(value) < 9999999999999999 && Convert.ToInt64(value) > 0)
                    tarjeta = value;
                else
                    throw new Exception("La tarjeta de crédito debe constar de 16 números.");
            }
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

        //Constructor
        public Cliente(int pcedula, string ptarjeta/*, string pnombre, int ptelefono, string pdireccion, string pfecha_nac*/)
        {
            Cedula = pcedula;
            Tarjeta = ptarjeta;
            /*Nombre = pnombre;
            Telefono = ptelefono;
            Direccion = pdireccion;
            Fecha_nac = pfecha_nac;*/
        }




    }
}
