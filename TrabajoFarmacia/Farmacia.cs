using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// ***************************
///     CLASE FARMACIA 
/// ***************************
namespace TrabajoFarmacia
{
    internal class Farmacia
    {
        //ATRIBUTOS
        private string nombre;
        private ArrayList ventas;
        private ArrayList stockMedicamentos;
        private ArrayList empleados;

        //CONSTRUCTOR
        public Farmacia(string nombre)
        {
            this.nombre = nombre;
            this.ventas = new ArrayList();
            this.stockMedicamentos = new ArrayList();
            this.empleados = new ArrayList();
        }
        //METODO GET DEL NOMBRE (SOLO LECTURA)
        public string Nombre { get { return nombre; } }

        // METODO QUE DEVUELVE UN EMPLEADO DE LA LISTA DE EMPLEADOS
        public Employed ObtenerEmpleado(int indice) 
        {
            var empleado = empleados[indice] as Employed;
            return empleado;
        }
        // DEVUELVE UN VENDEDOR
        public Vendedor ObtenerVendedor(int indice) 
        {
            if (empleados[indice] is Vendedor)
                return empleados[indice] as Vendedor;
            return null;
        }
        // METODO QUE DEVUELVE UN Medicamento DE LA LISTA DE Stock
        public Medicamento obtenerMedicamento(int indice) 
        {
            if (stockMedicamentos[indice] is Stock) 
            {
                Stock item = stockMedicamentos[indice] as Stock;
                if(item.Medicine is Medicamento) 
                    return item.Medicine;
            }
            return null;
        }

        //METODO PARA BUSCAR UN STOCK CON EL CODIGO DEL MEDICAMENTO
        //              RETORNA EL INDICE SI LO ENCUENTRA SINO -1
        public int ToFindStok(int CodMedicine)
        {
            int i = 0;
            foreach (Stock item in stockMedicamentos)
            {
                if (item.Medicine.Codigo == CodMedicine)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        //METODO PARA BUSCAR UNA VENTA CON EL TIKET DE LA VENTA
        //              RETORNA EL INDICE SI LO ENCUENTRA SINO -1
        public int ToFindVenta(string tiket)
        {
            int i = 0;
            foreach (Factura item in ventas)
            {
                if (item.TiketFactura == tiket)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        //METODO PARA BUSCAR UN EMPLEADO ATRAVES DE SU DOCUMENTO
        //              RETORNA EL INDICE SI LO ENCUENTRA SINO -1
        public int ToFindEmpleado(int documento)
        {
            int i = 0;
            foreach (Employed item in empleados)
            {
                if (item.DNI == documento)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public int ToFindVendedor(int documento)
        {
            int i = 0;
            foreach (Employed item in empleados)
            {
                if (item.DNI == documento && item is Vendedor)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        //METODO PARA LISTAR TODAS LAS VENTAS
        public void showVentas()
        {
            int i = 1;
            Console.WriteLine("----- Lista de Ventas -----");
            Console.WriteLine(" ");
            foreach (Factura item in ventas)
                Console.WriteLine("     "+i++ +") "+item);
        }
        public void showVentasSimplificado() 
        {
            int i = 1;
            Console.WriteLine("----- Lista de Ventas -----");
            Console.WriteLine(" ");
            foreach (Factura item in ventas)
                Console.WriteLine("     " + i++ + ") tiket[" + item.TiketFactura+"] importe total: $ "+item.ImporteTotal+" Vendido por: "+item.Vendedor.Codigo+", fecha: "+item.Fecha.Day+"/"+ item.Fecha.Month+"/"+item.Fecha.Year);
        }
        //METODO QUE LISTA LOS MEDICAMENTOS  VENDIDOS SIN REPETIR
        public void showMedicineSold() 
        {
            var list = new HashSet<Medicamento>();
            int i = 1;
            foreach(Factura item in ventas) // AGREGA EN LA LISTA LOS MEDICAMENTOS
            {
                foreach (Medicamento medicine in item.MedicamentoSold()) 
                {
                    list.Add(medicine);
                }
            }
            foreach (Medicamento item in list)
            {
                Console.WriteLine("     "+i++ +") Medicamento: "+item.Codigo+", nombre comercial: "+item.NombreComercial+", Precio: $"+item.Precio+", presentacion: "+ item.Presentacion);
            }
        }

        //METODO PARA LISTAR TODAS LOS EMPLEADOS
        public void showEmpleados()
        {
            int i = 1;
            Console.WriteLine("----- Lista de Empleados -----");
            Console.WriteLine(" ");
            foreach (Employed item in empleados)
            {
                Console.WriteLine(i++ + ") " + item);
            }
        }
        //lISTA LOS EMPLEADOS QUE SON VENDEDORES:
        public void showVendedores()
        {
            int i = 1;
            Console.WriteLine("----- Lista de Vendedores -----");
            Console.WriteLine(" ");
            foreach (Employed item in empleados)
            {
                if (item is Vendedor)
                {
                    Console.WriteLine("     "+i++ + " Documento: " + item.DNI + ", Nombre: " + item.Nombre + ", Apellido:" + item.Apellido);
                    Console.WriteLine(" ");
                }
            }
        }
        //METODO PARA LISTAR TODOS LOS PRUCTOS EN STOCK
        public void showStock()
        {
            int i = 1;
            Console.WriteLine("----- Lista de Medicamentos en stock -----");
            Console.WriteLine(" ");
            foreach (Stock item in stockMedicamentos)
                Console.WriteLine("     "+i++ + ")  codigo:" + item.Medicine.Codigo +", nombre: "+item.Medicine.NombreComercial+ ", precio: [$ "+ item.Medicine.Precio+"]");
        }

        //      METODO PARA LISTAR TODOS LOS PRUCTOS EN STOCK QUE TENGAN MAS DE LA CANTIDAD SOLICITADA
        public void showStock(int cantMaxima)
        {
            int i = 1;
            foreach (Stock item in stockMedicamentos)
                if (!item.CheckStok(cantMaxima))
                    Console.WriteLine(i++ + " " + item);
        }

        // METODO QUE MUESTRA LOS PRODUCTOS SIN STOCK
        public void SinStock()
        {
            int i = 1;
            foreach (Stock item in stockMedicamentos)
                if (item.IsEmptyStok())
                    Console.WriteLine(i++ + " " + item);
        }

        // VERIFICA SI UN STOCK ESTA DISPONIBLE Y SI EXISTE
        public int CheckStokDisponible(int codMedicamento, int cantidad)
        {
            int i = ToFindStok(codMedicamento);
            if (!(i > -1))
            {
                Console.WriteLine("El producto no existe en el stock actual");
                return -1;
            }
            else
            {
                var item = stockMedicamentos[i] as Stock;
                if (item.CheckStok(cantidad))
                    return i;
                else
                {
                    Console.WriteLine("La cantidad Solicitada es insuficiente, por favor ingreser un numero menor a ", item.CantDisponible);
                    return -2;
                }
            }
        }

        // SOBRECARGA DEL METODO ANTERIOR para que retorne un booleano
         public bool checkStokDisponibleBol(int indice,int cantidad) 
        {
            var item = stockMedicamentos[indice] as Stock;
            if (item.CheckStok(cantidad))
                return true;
            else
            {
                Console.WriteLine("La cantidad Solicitada es insuficiente, por favor ingreser un numero menor a "+ item.CantDisponible);
                return false;
            }
        }

        // AÑADE UNA COMPRA EN VENTAS
        public void addCompra(Factura factura)
        {
            ventas.Add(factura);
        }

        //AÑADE UN EMPLEADO A LA LISTA DE EMPLEADOS
        public void addEmpleado(Employed empleado)
        {
            empleados.Add(empleado);
        }

        //AÑADE UN NUEVO STOCK
        public void addStok(Stock producto)
        {
            int i = ToFindStok(producto.Medicine.Codigo);
            if (i > -1)
            {
                var item = stockMedicamentos[i] as Stock;
                item.Add(producto.CantDisponible);
                stockMedicamentos[i] = item;
            }
            else
                stockMedicamentos.Add(producto);
        }
        //    T  AÑADE UN STOCK CON UN MEDICAMENTO Y LA CANTIDAD
        public void addStok(Medicamento medicine, int cantidad)
        {
            int i = ToFindStok(medicine.Codigo);
            if (i > -1)
            {
                var item = stockMedicamentos[i] as Stock;
                item.Add(cantidad);
                stockMedicamentos[i] = item;
            }
            else 
            {
                var producto = new Medicamentos(cantidad, medicine);
                stockMedicamentos.Add(producto);
            }
        }
        
        //DEVUELVE LA CANTIDAD DE VENTAS REALIZADO POR UN VENDEDOR CON SU DOCUMENTO
        public void VentasXVendedor(int documento) 
        {
            int count= 0;
            foreach(Factura item in ventas)
            {
                if (item.Vendedor.DNI == documento)
                {
                    count += 1;
                }
            }
            var vendedor = empleados[ToFindEmpleado(documento)] as Employed;
            Console.WriteLine("El vendedor: "+vendedor.Nombre+", con documento "+vendedor.DNI+" realizo "+ count+" ventas totales");
        }

        //DESPIDE UN EMPLEADO
        public void DeleteEmpleado(int documento)
        {
            int i = ToFindEmpleado(documento);
            if (i > -1)
            {
                empleados.RemoveAt(i);
                Console.WriteLine("Empleado despedido");
            }
            else
                Console.WriteLine("El documento del empleado entregado no existe");
        }

        // ELIMINA UNA VENTA
        public void DeleteCompra(string tiket)
        {
            int i = ToFindVenta(tiket);
            if (i > -1)
            {
                ventas.RemoveAt(i);
                Console.WriteLine("Compra ELiminada");
            }
            else
                throw new InvalidTiketExeption();
        }
        //ORDENAMIENTO DE VENTAS POR FECHA Pero por alguna razon no me toma el intercambio
        //public void ordenFechaVenta()
        //{
        //    int rounds = 0;
        //    bool swp = false;
        //    while (!swp)
        //    {
        //        swp = true;
        //        for (int i = 0; i < ventas.Count - 1 - rounds; i++)
        //        {
        //            var item = ventas[i] as Factura;
        //            var itemNext = ventas[i + 1] as Factura;
        //            if (!(item.CompareToFecha(itemNext.Fecha)))
        //            {
        //                var aux = ventas[i + 1];
        //                ventas[i + 1] = ventas[i];
        //                ventas[i + 1] = aux;
        //            }
        //        }
        //        rounds++;
        //    }

        //}

        //LISTA EL IMPORTE DE TODAS LAS VENTAS GASTA UNA DETERMINADA FECHA

        // BORRA UN PRODUCTO DEL STOCK CON SU CODIGO DE MEDICAMENTO

        public void DeleteStok(int CodMedicamento)
        {
            int i = ToFindEmpleado(CodMedicamento);
            if (i > -1)
            {
                stockMedicamentos.RemoveAt(i);
                Console.WriteLine("Producto eliminado");
            }
            else
                Console.WriteLine("El Producto no existe en el stok");
        }
        // Saca una cantidad del stock
        public void SacarDelStock(int indice, int cantidad) 
        {
            var item = stockMedicamentos[indice] as Stock ;
            item.Delete(cantidad);
            stockMedicamentos[indice] = item;
        }
        
        //METODO PARA SACAR EL PORCENTAJE DE OBRAS SOCIALES EN UN MES CON RESPECTO A LAS QUE NO TIENEN DE ESE MISMO MES
        public void PorcentajeObraSocial(int mes)
        {
            int cantObraSocial = 0;
            int cantVentas = 0;
            foreach (Factura venta in ventas) 
            {
                if (venta.Fecha.Month == mes && venta.Fecha.Year == 2022)
                {
                    cantVentas++;
                    if (venta.Presentacion.ToLower() != "particular" && venta.Fecha.Day > 0 && venta.Fecha.Day < 15)
                        cantObraSocial++;
                }
            }
            double result;
            if (!(cantVentas == 0))
                result = ((double)cantObraSocial / (double)cantVentas) * 100;
            else
                result = 0;
            Console.WriteLine("El porcentaje de la primera quincena del mes "+mes+" es: "+result+" %");
        }
    }
    public class InvalidTiketExeption: Exception { }
}
