using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFarmacia
{
    /// ******************************
    ///     CLASE MEDICAMENTO  
    /// ******************************
    internal class Medicamento
    {
        // Atributos de la clase (privadas)
        private int codigo;
        private int precio;
        private string nombreComercial;
        private string droga;
        private string nombreLaboratorio;
        private string presentacion;

        //CONSTRUCTOR

        public Medicamento(int Codigo, string nameMedicine, int amount, string Droga, string Presentacion = "Capsulas", string NameLab = "Sin Definir")
        {
            codigo = Codigo;
            nombreComercial = nameMedicine;
            precio = amount;
            droga = Droga;
            presentacion = Presentacion;
            nombreLaboratorio = NameLab;
        }
        // METODOS DE GET y SET

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public string NombreComercial
        {
            get { return nombreComercial; }
            set { nombreComercial = value; }
        }
        public string NombreLaboratorio
        {
            get { return nombreLaboratorio; }
            set { nombreLaboratorio = value; }
        }
        public string Droga
        {
            get { return droga; }
            set { droga = value; }
        }
        //DE SOLO LECTURA 
        public int Codigo { get { return codigo; } }
        public string Presentacion { get { return presentacion; } }

        // SOBREESCRIBIENDO TO STRING
        public override string ToString()
        {
            return "Medicamento [" + nombreComercial + ", droga:  " + droga + ", presentacion: " + presentacion + ", laboratorio: " + nombreLaboratorio + "] PRECIO: $" + precio + " pesos";
        }
        public override bool Equals(object? obj)
        {
            return obj is Medicamento medicamento &&
                  codigo == medicamento.Codigo;
        }

    }

    /// *****************************************************************************
    ///     CLASE MEDICAMENTOS QUE GUARDA VARIAS CANTIDADES DE MEDICAMENTOS
    /// *****************************************************************************
    internal class Medicamentos
    {
        // Atributos de la clase (privadas)
        private int cantidad;
        private Medicamento medicine;
        private int importe;

        //CONSTRUCTOR

        public Medicamentos(int cantidad, Medicamento medicine)
        {
            this.cantidad = cantidad;
            this.medicine = medicine;
            GenerarImporte();
        }
        // SOLO  LECTURA  Y ESCRITURA
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                GenerarImporte();
            }
        }
        public Medicamento Medicine
        {
            get { return medicine; }
            set { medicine = value; }
        }

        //METODO PARA AGREGAR CANTIDAD UN  CARRITO
        public void Add()
        {
            cantidad++;
            GenerarImporte();
        }
            // PARA CUANDO QUIERE AGREMAS DE UNO
        public void Add(int cant)
        {
            cantidad += cant;
            GenerarImporte();
        }

        // METODO PARA ELIMINAR UN PRODUCTO DEL CARRITO
        public void Delete()
        {
            if (cantidad > 0)
            {
                cantidad--;
                GenerarImporte();
            }
            else Console.WriteLine("No queda ningun elemento para quitar");
        }

            //SI QUIERE QUITAR MAS DE UNO
        public void Delete(int cant)
        {
            cantidad -= cant;
            GenerarImporte();
        }
        // BORRA TODO LA CANTIDAD DEL PRODUCTO
        public void AllDelete()
        {
            cantidad = 0;
            GenerarImporte();
        }

        //private void generarImporte() => importe = cantidad * medicine.Precio;
        private void GenerarImporte()
        {
            importe = cantidad * medicine.Precio;
        }

        // public int GetImporte() => importe;
        public int GetImporte
        {
            get
            {
                GenerarImporte();
                return importe;
            }
        }

        //SOBREESCRIBIMIENTO

        public override string ToString()
        {
            return "Cantidad : " + cantidad + " de " + medicine.NombreComercial;
        }

        public override bool Equals(object? obj)
        {
            return obj is Medicamentos medicamentos &&
                  medicine == medicamentos.medicine;
        }
    }
}
