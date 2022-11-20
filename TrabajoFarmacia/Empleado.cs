using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFarmacia
{


    /// ********************************************************************************************************
    ///     ARCHIVO DONDE SE VAN A GUARDAR LAS CLASE  EMPLEADO Y SUS HIJOS IMPLEMENTANDO PRINCIPIOS DE Liskov 
    /// ********************************************************************************************************

    //          CLASE PADRE EMPLOYED (EMPLEADO) QUE NO PUEDE SER INSTANCIADO 
    internal abstract class Employed
    {
        // atributos que seran usados por las clases que heredan de employed
        protected int dni;
        protected string nombre;
        protected string apellido;
        protected int amount;

        // Constructor de Employed
        public Employed(int DNI, string Name, string LastName, int Amount)
        {
            this.dni = DNI;
            this.nombre = Name;
            this.apellido = LastName;
            this.amount = Amount;
        }

        // Metodos de get y set para los distintos atributos Cumpliendo las leyes de un objeto puro
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
            }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        // Al dni tiene un metodo set que habilita que no sea negativo o que tenga mas de 8 digitos
        public int DNI
        {
            get { return dni; }
            set
            {
                if (value < 0 || value > 99999999)
                    throw new ArgumentOutOfRangeException("El numero de dni no puede ser negativo o mayor a 8 digitos");
                dni = value;
            }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public override string ToString()
        {
            return "Nombre y apellido: " + nombre + " " + apellido + ", D.N.I :" + dni + ", sueldo: " + amount;
        }
    }

    //  CLASE VENDEDOR QUE ES UN TIPO DE EMPLOYED (EMPLEADO) 
    internal class Vendedor : Employed
    {
        // Atributos propios de la clase vendedor
        private int codigo;

        //Metodo de solo lectura para el codigo
        public int Codigo
        {
            get { return codigo; }
        }

        // CONSTRUCTOR
        public Vendedor(int codigo, int dni, string lastName, string name, int amount) : base(dni, name, lastName, amount)
        {
            this.codigo = codigo;
        }
        public override string ToString()
        {
            return "Empleado : Vendedor datos [" + codigo + ", " + base.ToString() + "]";
        }
    }

    //  CLASE FARMACEUTICO QUE ES UN TIPO DE EMPLOYED (EMPLEADO) 
    internal class Farmaceutico : Employed
    {
        // CONSTRUCTOR
        public Farmaceutico(int dni, string lastName, string name, int amount) : base(dni, name, lastName, amount) { }
        public override string ToString()
        {
            return "Empleado : Farmaceutico datos [" + base.ToString() + "]";
        }
    }

    //  CLASE MANTENIMIENTO QUE ES UN TIPO DE EMPLOYED (EMPLEADO) 
    internal class Mantenimiento : Employed
    {
        private string puesto;
        public string Puesto
        {
            set { puesto = value; }
            get { return puesto; }
        }
        // CONSTRUCTOR 
        public Mantenimiento(string puesto, int dni, string lastName, string name, int amount) : base(dni, name, lastName, amount) => this.puesto = puesto;

        public override string ToString()
        {
            return "Empleado : Mantenimiento en el puesto de " + puesto + ", informacion[" + base.ToString() + "]";
        }
    }
}

