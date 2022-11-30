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

        //METODO PARA LISTAR TODAS LAS VENTAS
        public void showVentas()
        {
            foreach (Factura item in ventas)
                Console.WriteLine(item);
        }

        //METODO QUE LISTA LOS MEDICAMENTOS  VENDIDOS SIN REPETIR
        public void showMedicineSold() 
        {
            var list = new HashSet<Medicamento>();
            foreach(Factura item in ventas) // AGREGA EN LA LISTA LOS MEDICAMENTOS
            {
                foreach (Medicamento medicine in item.MedicamentoSold()) 
                {
                    list.Add(medicine);
                }
            }
            foreach (Medicamento item in list)
                Console.WriteLine(item);
        }

        //METODO PARA LISTAR TODAS LOS EMPLEADOS
        public void showEmpleados()
        {
            int i = 1;
            foreach (Employed item in empleados)
                Console.WriteLine(i++ + " " + item);
        }

        //METODO PARA LISTAR TODOS LOS PRUCTOS EN STOCK
        public void showStock()
        {
            int i = 1;
            foreach (Stock item in stockMedicamentos)
                Console.WriteLine(i++ + " " + item);
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
        public void AddStok(Medicamento medicine, int cantidad)
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

        //DESPIDE UN EMPLEADO
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

        // ELIMINA UNA VENTA
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

        // BORRA UN PRODUCTO DEL STOCK CON SU CODIGO DE MEDICAMENTO
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

       

        private void Default()
        {
            nombre = "Farmacia";
            var vendedorUno = new Vendedor(1234567, 40548231, "Torres", "Oscar", 90000);
            var vendedorDos = new Vendedor(1234568, 35949556, "Roman", "Roberto", 91000);
            var farmaceutico = new Farmaceutico(35518211, "Aguirre", "Marcela", 12000);
            var mantenimiento = new Mantenimiento("Limpieza", 20777189, "Delolla", "Rosa", 600000);

            empleados.Add(vendedorUno);
            empleados.Add(vendedorDos);
            empleados.Add(farmaceutico);
            empleados.Add(mantenimiento);

            var ibu = new Medicamento(5554131, "Ibuprofeno 500mg", 500, "antiinflamatoria no esteroide (AINE)");
            var paracetamol = new Medicamento(8944533, "Ibuprofeno 500mg", 520, "acetaminofeno");
            var cloracepam = new Medicamento(1234533, "Clonex", 6200, "benzodiacepinas", "Gotero");
            var planB = new Medicamento(5554478, "Plan B One-Step", 1000, "levonorgestrel 0,75 mg", "Comprimido");
            var redusterol = new Medicamento(3564978, "redusterol", 1562, "Simvastatina", "Comprimido");
            var acovil = new Medicamento(99912978, "acovil", 2247, "ramipril", "Comprimido");
            var levotiroxina = new Medicamento(4566876, "levotiroxina", 1543, "Eutirox");
            var losartan =new Medicamento(989854, "losartán",1675, "losartán potásico","Comprimido");
            var metformina = new Medicamento(56741233, "metformina",7000, "biguanidas");
            var alprazolam = new Medicamento(654411114, "alprazolam",1209, "benzodiazepina", "Comprimido");
            var aspirina = new Medicamento(56548794, "aspirina",126, "ácido acetilsalicílico","Comprimido");
            var bisoprolol = new Medicamento(65654433, "bisoprolol", 2648, "bisoprolol ");

            var stokIbu = new Stock(ibu, 50);
            var stokParacetamol = new Stock(paracetamol, 60);
            var stokCloracepam = new Stock(cloracepam, 30);
            var stokPlanB = new Stock(planB, 20);
            var stokRedusterol = new Stock(redusterol, 10);
            var stokAcovil = new Stock(acovil, 2);
            var stockLevotiroxina = new Stock(levotiroxina, 20);
            var stockLosartan = new Stock(losartan, 30);
            var stockMetformina = new Stock(metformina, 6);
            var stockAlprazolam = new Stock(alprazolam,8);
            var stockAspirina = new Stock(aspirina, 50);
            var stockBisoprolol = new Stock(bisoprolol, 1);

            stockMedicamentos.Add(stokIbu);
            stockMedicamentos.Add(stokParacetamol);
            stockMedicamentos.Add(stokCloracepam);
            stockMedicamentos.Add(stokPlanB);
            stockMedicamentos.Add(stokRedusterol);
            stockMedicamentos.Add(stokAcovil);
            stockMedicamentos.Add(stockLevotiroxina);
            stockMedicamentos.Add(stockLosartan);
            stockMedicamentos.Add(stockMetformina);
            stockMedicamentos.Add(stockAlprazolam);
            stockMedicamentos.Add(stockAspirina);
            stockMedicamentos.Add(stockBisoprolol);


            var medicamentos = new Medicamentos(2, ibu);
            var medicamentos2 = new Medicamentos(5, planB);
            var medicamentos3 = new Medicamentos(8, ibu);
            var medicamentos4 = new Medicamentos(9, cloracepam);
            var medicamentos5 = new Medicamentos(5, planB);
            var medicamentos6 = new Medicamentos(2, redusterol);
            var medicamentos7 = new Medicamentos(1, acovil);
            var medicamentos8 = new Medicamentos(3, acovil);
            var medicamentos9 = new Medicamentos(1, redusterol);


            var carrito = new ArrayList { medicamentos , medicamentos2 , medicamentos6 , medicamentos7 };
            var carrito2 = new ArrayList { medicamentos3, medicamentos5, medicamentos8, medicamentos9 };
            var carrito3 = new ArrayList { medicamentos8, medicamentos6, medicamentos, medicamentos6 };
            var carrito4 = new ArrayList { medicamentos3, medicamentos2, medicamentos6, medicamentos8 };
            var carrito5 = new ArrayList { medicamentos4, medicamentos2, medicamentos3, medicamentos9 };

            var factura = new Factura("HA132456", new DateTime(2022, 10, 11, 7, 0, 0), vendedorUno);
            var factura2 = new Factura("H131312", new DateTime(2022, 11, 11, 12, 0, 0), vendedorDos, "Galeno");
            var factura3 = new Factura("HF32454", new DateTime(2022, 22, 11, 8, 0, 0), vendedorDos, "Simeco");
            var factura4 = new Factura("F412313", new DateTime(2022, 11, 11, 16, 0, 0), vendedorUno, "Ospic");
            var factura5 = new Factura("GH14123", new DateTime(2022, 12, 11, 13, 0, 0), vendedorUno,"Galeno");

            factura.AddMedicine(carrito);
            factura2.AddMedicine(carrito2);
            factura3.AddMedicine(carrito3);
            factura4.AddMedicine(carrito4);
            factura5.AddMedicine(carrito5);

            ventas.Add(factura);
            ventas.Add(factura2);
            ventas.Add(factura3);
            ventas.Add(factura4);
            ventas.Add(factura5);
        }

    }
    public class InvalidTiketExeption: Exception { }
}
