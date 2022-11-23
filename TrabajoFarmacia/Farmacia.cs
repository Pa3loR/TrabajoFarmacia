using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFarmacia
{
    internal class Farmacia
    {
        private string nombre;
        private ArrayList ventas;
        private ArrayList stockMedicamentos;
        private ArrayList empleados;

        public Farmacia(string nombre)
        {
            this.nombre = nombre;
            this.ventas = new ArrayList();
            this.stockMedicamentos = new ArrayList();
            this.empleados = new ArrayList();
        }

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

        public void showVentas()
        {
            foreach (Factura item in ventas)
                Console.WriteLine(item);
        }
        public void showEmpleados()
        {
            int i = 1;
            foreach (Employed item in empleados)
                Console.WriteLine(i++ + " " + item);
        }

        public void showStock()
        {
            int i = 1;
            foreach (Stock item in stockMedicamentos)
                Console.WriteLine(i++ + " " + item);
        }

        public void showStock(int cantMaxima)
        {
            int i = 1;
            foreach (Stock item in stockMedicamentos)
                if (!item.CheckStok(cantMaxima))
                    Console.WriteLine(i++ + " " + item);
        }

        public void SinStock()
        {
            int i = 1;
            foreach (Stock item in stockMedicamentos)
                if (item.IsEmptyStok())
                    Console.WriteLine(i++ + " " + item);
        }

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


        public void addCompra(Factura factura)
        {
            ventas.Add(factura);
        }

        public void addEmpleado(Employed empleado)
        {
            empleados.Add(empleado);
        }

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

        public void DeleteEmpleado(int documento)
        {
            int i = ToFindEmpleado(documento);
            if (i > -1)
            {
                empleados[i] = null;
                Console.WriteLine("Empleado despedido");
            }
            else
                Console.WriteLine("El documento del empleado entregado no existe");
        }

        public void DeleteCompra(string tiket)
        {
            int i = ToFindVenta(tiket);
            if (i > -1)
            {
                ventas[i] = null;
                Console.WriteLine("Compra ELiminada");
            }
            else
                throw new InvalidTiketExeption();
        }

        public void DeleteStok(int CodMedicamento)
        {
            int i = ToFindEmpleado(CodMedicamento);
            if (i > -1)
            {
                stockMedicamentos [i] = null;
                Console.WriteLine("Producto eliminado");
            }
            else
                Console.WriteLine("El Producto no existe en el stok");
        }

        public int ToFindEmpleado(int documento)
        {
            int i = 0;
            foreach (Employed item in ventas)
            {
                if (item.DNI == documento)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        public void AddStok(Medicamento medicine, int cantidad)
        {

        }

        private void Default()
        {
            nombre = "Farmacia";
            var vendedorUno = new Vendedor(1234567, 40548231, "Torres", "Oscar", 90000);
            var vendedorDos = new Vendedor(1234568, 35949556, "Roman", "Roberto", 91000);
            var farmaceutico = new Farmaceutico(35518211, "Aguirre", "Marcela", 12000);
            var mantenimiento = new Mantenimiento("Limpieza", 20777189, "Delolla", "Rosa", 600000);

            var ibu = new Medicamento(5554131, "Ibuprofeno 500mg", 500, "antiinflamatoria no esteroide (AINE)");
            var paracetamol = new Medicamento(8944533, "Ibuprofeno 500mg", 520, "acetaminofeno");
            var cloracepam = new Medicamento(1234533, "Clonex", 6200, "benzodiacepinas", "Gotero");
            var planB = new Medicamento(5554478, "Plan B One-Step", 1000, "levonorgestrel 0,75 mg", "Comprimido");
            var redusterol = new Medicamento(3564978, "redusterol", 1562, "Simvastatina", "Comprimido");
            var acovil = new Medicamento(99912978, "acovil", 2247, "ramipril", "Comprimido");

            var stokIbu = new Stock(ibu, 50);
            var stokParacetamol = new Stock(paracetamol, 60);
            var stokCloracepam = new Stock(cloracepam, 30);
            var stokPlanB = new Stock(planB, 20);
            var stokRedusterol = new Stock(redusterol, 10);
            var stokAcovil = new Stock(acovil, 2);

            var medicamentos = new Medicamentos(2, ibu);
            var medicamentosDos = new Medicamentos(5, planB);


        }

    }
    public class InvalidTiketExeption: Exception { }
}
