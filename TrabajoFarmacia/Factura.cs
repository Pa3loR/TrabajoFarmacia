using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFarmacia
{
    /// ******************************
    ///     CLASE Facturacion 
    /// ******************************
    internal class Factura
    {
        // Atributos privados de Facturacion 
        private string tiketFactura;
        private DateTime fechaHora;
        private string prestacion;
        private Vendedor vendedor;
        private ArrayList carrito = new ArrayList();
        private int total = 0;

        // Constructor para cuando tiente una lista de compras
        public Factura(string tiket, DateTime hora, Vendedor Vendedor, ArrayList list, string prestacion = "Particular")
        {
            this.tiketFactura = tiket;
            this.fechaHora = hora;
            this.prestacion = prestacion;
            this.vendedor = Vendedor;
            foreach (var item in list)
            {
                carrito.Add(item);
            }
            GeneratorImporte();
        }
        // Constructor para cuando aun no se ingreso ningun producto 
        public Factura(string tiket, DateTime hora, Vendedor Vendedor, string prestacion = "Particular")
        {
            this.tiketFactura = tiket;
            this.fechaHora = hora;
            this.prestacion = prestacion;
            this.vendedor = Vendedor;
        }

        //  METODOS DE GET AND SET

        public int ImporteTotal { get { return total; } }
        // otra forma de emplear pero no funciona en sharpdeveloper public int ImporteTotal() => total;

        public string TiketFactura { get { return tiketFactura; } }

        public DateTime Fecha
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }
        public Vendedor Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        // METODO PARA AGREGAR MEDICAMENTOS AL CARRITO

        public void AddMedicine(Medicamentos medicine)
        {
            carrito.Add(medicine);
            GeneratorImporte();
        }

        public void AddMedicine(ArrayList list)
        {
            foreach (Medicamentos item in list)
                carrito.Add(item);
            GeneratorImporte();
        }

        // METODO PARA BUSCAR MEDICAMENTO en forma secuencial
        public bool ToFindMedicine(Medicamento medicine) // Me retorna un booleano
        {
            foreach (Medicamentos item in carrito)
            {
                if (item.Medicine == medicine)
                    return true;
            }
            return false;
        }
        public int ToFindMedicine(int CodMedicine)// Me retorna el indice sino un -1 para cuando no lo encuentra
        {
            int index = 0;
            foreach (Medicamentos item in carrito)
            {

                if (item.Medicine.Codigo == CodMedicine)
                    return index;
                index++;
            }
            return -1;
        }

        // METODO PARA ELIMINAR PRODUCTOS DEL CARRITO
        public void QuitarDelCarrito(int codMedicine)
        {
            int index = ToFindMedicine(codMedicine);
            //si retorna -1 no lo econtro
            if (index == -1)
                Console.WriteLine("Medicamento no existe en la factura actual");
            else
            {
                carrito.RemoveAt(index);
                GeneratorImporte();
                Console.WriteLine("Medicamento eliminado de la lista de compra");
            }
        }

        // METODO PARA ELISTAR TODOS LOS PRODUCTOS EN LA FACTURA
        public void ShowCompra()
        {
            int i = 0;
            foreach (Medicamentos item in carrito)
                Console.WriteLine(i++ + " " + item);
            // el toString de medicamentos  esta sobreescrito para qe se muestre cantidad y nombre comercial
        }
        // METODO PARA MODIFICAR CUALQUIER ELEMENTOS atrabes del codigo del producto
        public void ModificarCompra(int codMedicine, int cantidad)
        {
            int i = ToFindMedicine(codMedicine);
            if (!(i > -1))
                Console.WriteLine("Medicamento no existe en la factura actual");
            else
            {
                var item = carrito[i] as Medicamentos;
                item.Cantidad = cantidad;
                carrito[i] = item;
                GeneratorImporte();// Actualizo el importe
            }
        }

        // Este metodo es una sobrecarga del anterios y  es para cuando tambien o solo se quiere modificar el Producto
        public void ModificarCompra(int codMedicine, Medicamento medicine, int cantidad = -1)
        {
            int i = ToFindMedicine(codMedicine);
            if (!(i > -1))
                Console.WriteLine("Medicamento no existe en la factura actual");
            else
            {
                if (carrito[i] is Medicamentos && carrito != null)
                {
                    var item = carrito[i] as Medicamentos;
                    if (cantidad != -1)
                        item.Cantidad = cantidad;
                    item.Medicine = medicine;
                    carrito[i] = item;
                    GeneratorImporte(); // Actualizo el importe
                }
            }
        }

        // METODO PARA AÑADIR UN CANTIDAD O SOLO 1 A UN PRODUCTO EXISTENTE EN LA FACTURA
        public void AddCant(int codMedicine, int cant = 1)
        {
            int i = ToFindMedicine(codMedicine);
            if (i > -1)
                Console.WriteLine("Medicamento no existe en la factura actual");
            else
            {
                var item = carrito[i] as Medicamentos;
                item.Add(cant);
                carrito[i] = item;
                GeneratorImporte();// Actualizo el importe
            }
        }

        // METODO PARA QUITAR UN CANTIDAD O SOLO 1 A UN PRODUCTO EXISTENTE EN LA FACTURA
        public void DeleteCant(int codMedicine, int cant = 1)
        {
            int i = ToFindMedicine(codMedicine);
            if (i > -1)
                Console.WriteLine("Medicamento no existe en la factura actual");
            else
            {
                var item = carrito[i] as Medicamentos;
                item.Delete(cant);
                carrito[i] = item;
                GeneratorImporte();
            }
        }

        // METODO PARA GENERAR EL IMPORTE TOTAL DE LA FACTURA
        private void GeneratorImporte()
        {
            total = 0;
            foreach (Medicamentos medicamentos in carrito)
            {
                total += Convert.ToInt16(medicamentos.GetImporte);
            }
        }

        // SOBREESCRIMIENTO
        public override bool Equals(object? obj) // devuelve true solo si el tiket de factura es igual
        {
            return obj is Factura factura &&
                   tiketFactura == factura.tiketFactura;
        }

        public override string ToString()
        {
            return " obra social" + prestacion + "importe" + total + "código de vendedor" + vendedor.Codigo + "fecha y hora de venta " + fechaHora + "nro de ticket-factura" + tiketFactura;
        }
    }
}
