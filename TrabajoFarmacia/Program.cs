using System.Collections;
using TrabajoFarmacia;

internal class Program
{
    private static void Main(string[] args)
    {
        var farmacia = new Farmacia("Belgrano");
        farmacia.Default();
        Run(farmacia);
    }

    public static void Run(Farmacia farmacia) 
    {
        Console.Clear();
        switch (Menu())
        {
            case 1:
                AgregarCompraMedicine(farmacia);
                Run(farmacia);
                break;
            case 2:
                DeleteCompra(farmacia);
                Run(farmacia);
                break;
            case 3:
                Pocentaje(farmacia);
                Run(farmacia);
                break;
            case 4:
                VentasxVendedor(farmacia);
                Run(farmacia);
                break;
            case 5:
                AddEmpleado(farmacia);
                Run(farmacia);
                break;
            case 6:
                deleteEmpleado(farmacia);
                Run(farmacia);
                break;
            case 7:
                //listaMedicamentos();
                break;
            case 8:
                break;
            default:
                break;
        }
    }

    private static void deleteEmpleado(Farmacia farmacia)
    {
        Console.WriteLine(" ");
        Console.WriteLine("            ELIMINAR UN EMPLEADO           ");
        Console.WriteLine("________________________________________________");
        Console.WriteLine(" ");
        string continuar;
        farmacia.showEmpleados();
        do
        {
            int documento = GetIntegerVelue("Ingrese Documento del empleado: ");
            int indice = farmacia.ToFindEmpleado(documento);
            if (indice < 0)
                Console.WriteLine("         El empleado No existe!");
            else
            {
                Console.WriteLine("Seguro que desea despedir al empleado?[N para no despedir]");
                string confirmacion = Console.ReadLine();
                if (!(confirmacion.ToLower() == "n"))
                {
                    farmacia.DeleteEmpleado(documento);
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Desea agregar un nuevo documento?[N para volver al menu]");
            continuar = Console.ReadLine();
        } while (!(continuar.ToLower() == "n"));
    }

    public static void AddEmpleado(Farmacia farmacia)
    {
        Console.WriteLine(" ");
        Console.WriteLine("            AÑADIR UN NUEVO EMPLEADO           ");
        Console.WriteLine("________________________________________________");
        Console.WriteLine(" ");
        Console.WriteLine("1- Añadir Vendedor");
        Console.WriteLine("2- Añadir Farmaceutico");
        Console.WriteLine("3- Añadir Mantenimiento");
        int option;
        do
        {
            option = GetIntegerVelue("Ingrese alguna de las opciones:");
        } while (!(option > 0 && option < 4));

        int documento;
        int isInvalid = -1;
        do 
        {
            documento = GetIntegerVelue("Ingrese Documento del nuevo empleado: ");
            isInvalid = farmacia.ToFindEmpleado(documento);
            if (isInvalid > -1)
                Console.WriteLine("Ese documento ya esta agregado");

        } while (isInvalid > -1);
        Console.WriteLine("Ingrese nombre del nuevo empleado");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese apellido del nuevo empleado");
        string apellido = Console.ReadLine();
        int sueldo = GetIntegerVelue("Ingrese el sueldo correspondiente al nuevo empleado: ");
        Employed empleadoNuevo;
        switch (option) 
        {
            case 1:
                int codigo = GetIntegerVelue("Ingrese el codigo del nuevo Vendedor: ");
                empleadoNuevo = new Vendedor(codigo, documento, apellido, nombre, sueldo);
                Console.WriteLine("     Vendedor Creado!");
                break;
            case 2:
                empleadoNuevo = new Farmaceutico(documento, apellido, nombre, sueldo);
                Console.WriteLine("     Farmaceutico Creado!");
                break;
            case 3:
                Console.WriteLine("Ingrese el puesto del nuevo empleado de Mantenimiento");
                string puesto = Console.ReadLine();
                empleadoNuevo = new Mantenimiento(puesto, documento, apellido, nombre, sueldo);
                Console.WriteLine("     empleado de Mantenimiento Creado!");
                break;
            default:
                // Por defecto crea un farmaceutico
                empleadoNuevo = new Farmaceutico(documento, apellido, nombre, sueldo);
                Console.WriteLine("     Farmaceutico Creado!");
                break;
        }
        Console.WriteLine(empleadoNuevo);
        Console.WriteLine("DESEA AGREGAR AL NUEVO EMPLEADO? [N para no agregarlo]");
        string confirmacion = Console.ReadLine();
        if (!(confirmacion.ToLower() == "n"))
        {
            farmacia.addEmpleado(empleadoNuevo);
            Console.WriteLine("         Empleado Contratado!");
        }
        else
            Console.WriteLine("         El Empleado NO FUE Contratado!");
        Console.WriteLine(" ");
        Console.WriteLine("Presione cualquier tecla par volver la menu...");
        Console.ReadKey();
    }

    public static void AgregarCompraMedicine(Farmacia farmacia)
    {
        string option="N";
        do
        {
            var listaProductos = new ArrayList();
            Console.WriteLine(" ");
            Console.WriteLine("       AÑADIR COMPRA DE MEDICAMENTOS           ");
            Console.WriteLine("________________________________________________");
            Console.WriteLine(" ");
            

            // COMPRUEVA EL TIKET DE COMPRA SI EXISTE O NO
            //  EN CASO DE EXISTIR LE PIDE QUE INGRESE OTRO CODIGO
            int isvalidCompra;
            string tiketFactura;
            do
            {
                Console.WriteLine("Ingrese el Tiket de compra: ");
                tiketFactura = Console.ReadLine().ToUpper();
                isvalidCompra = farmacia.ToFindVenta(tiketFactura);
                if (isvalidCompra > -1)
                    Console.WriteLine("     Esa Compra Ya existe!");
            } while (isvalidCompra > -1);

            //VALIDACIONES PARA EL VER EL EMPLEADO QUE LO VENDIO 

            int isValidEmpleado;
            int codVendedor;
            do
            {
                farmacia.showVendedores();
                codVendedor = GetIntegerVelue("Ingrese el documento del vendedor");
                isValidEmpleado = farmacia.ToFindEmpleado(codVendedor);
                if (!(isValidEmpleado > -1))
                    Console.WriteLine("     El empleado no existe!");
            } while (!(isValidEmpleado > -1));

            var empleado = farmacia.ObtenerVendedor(isValidEmpleado);

            //VALIDADCIONES PARA AGREGAR LA FECHA

            int dia = -1;
            int mes = -1;
            int anio = 2023;
            do
            {
                anio = GetIntegerVelue("Ingrese Año: ");
                mes = GetIntegerVelue("Ingrese El Mes: ");
                dia = GetIntegerVelue("Ingrese el dia: ");
            } while (!(anio <= 2022 && mes < 13 && mes > 0 && dia > 0 && dia < 32));

            var fechaCompra = new DateTime(anio, mes, dia);

            // PONE LOS PRODUCTOS PARA AGREGAR A LA COMPRA

            string addProduc = "N";
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("         Añadir producto             ");
                Console.WriteLine("______________________________________");
                Console.WriteLine(" ");
                farmacia.showStock();
                Console.WriteLine(" ");


                int codMedicine = GetIntegerVelue("Ingrese el codigo del medicamento: ");
                int indiceStock = farmacia.ToFindStok(codMedicine);
                if (indiceStock > -1)
                {
                    int cantMedicine;
                    do
                    {
                        cantMedicine = GetIntegerVelue("Ingrese la cantidad del medicamento que quiere comprar: ");

                    } while (!farmacia.checkStokDisponibleBol(indiceStock, cantMedicine));

                    farmacia.SacarDelStock(indiceStock, cantMedicine);
                    var producto = new Medicamentos(cantMedicine, farmacia.obtenerMedicamento(indiceStock));
                    listaProductos.Add(producto);
                }
                else
                    Console.WriteLine("     El medicamento solicitado NO EXISTE en el stock actual");

                Console.WriteLine("Desea Continuar agregando Medicamentos? [Presione N para no continuar]");
                addProduc = Console.ReadLine();

            } while (addProduc.ToLower() != "n");
            // Se crea la Variable factura
            Factura factura;

            // PREGUNTA SI TIENE OBRA SOCIAL PARA SABER CUAL CONSTRUCTOR USAR
            Console.WriteLine("Posee Obra social?[Y/N]");
            string existObra = Console.ReadLine();
            if (existObra.ToLower() == "n")
                factura = new Factura(tiketFactura, fechaCompra, empleado as Vendedor, listaProductos);
            else
            {
                Console.WriteLine("Ingrese el nombre de la Obra Social: ");
                string obraSocial = Console.ReadLine();
                factura = new Factura(tiketFactura, fechaCompra, empleado as Vendedor, listaProductos,obraSocial);
            }

            // LE MUESTRA EL IMPORTE TOTAL DE LA COMPRA
            Console.WriteLine("La Factura fue creado con exito!");
            Console.WriteLine(" ");
            Console.WriteLine("         El IMPORTE DE LA COMPRA ES DE : $" + factura.ImporteTotal);
            Console.WriteLine(" ");

            // LE PREGUNTA PARA CONFIRMAR LA COMPRA 
            Console.WriteLine("Desea Realizar la compra? [Y/N] ");
            string realizarCompra = Console.ReadLine();

            // SI ES AFIRMATIVO LO AGREGA A LA LISTA DE COMPRAS DE LA FARMACIA 
            if (!(realizarCompra.ToLower() == "n"))
            {
                farmacia.addCompra(factura);
                Console.WriteLine("     Compra AÑADIDA CON EXITO!");
                Console.WriteLine(" ");
            }

            // PREGUNTA SI SE DESEA AGREGAR OTRA COMPRA
            Console.WriteLine("Desea Agregar otra compra? [Presione N para ir al menu]");
            option = Console.ReadLine();
        } while (option.ToLower() != "n");
    }

    public static void DeleteCompra(Farmacia farmacia)
    {
        Console.WriteLine(" ");
        Console.WriteLine("                 ELIMINAR COMPRA          ");
        Console.WriteLine("________________________________________________");
        Console.WriteLine(" ");
       
        farmacia.showVentasSimplificado();
        string option = "y";
        string tiketFactura;
        do
        {
            bool isInvalid = true;
            while (isInvalid)
            {
                try
                {
                    Console.WriteLine("Ingrese el tiket de la compra que desea eliminar: ");
                    tiketFactura = Console.ReadLine().ToUpper();
                    farmacia.DeleteCompra(tiketFactura);
                    isInvalid = false;
                }
                catch (InvalidTiketExeption e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(" ");
                    Console.WriteLine("     El tiket ingresado NO EXISTE!");
                    isInvalid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("A Ocurrido un error");
                    isInvalid = true;
                }
            }
            Console.WriteLine("Desea eliminar otra compra? [Y/N] ");
            option = Console.ReadLine();
            Console.WriteLine(" ");
        } while (!(option.ToLower() == "n"));
        Console.WriteLine(" ");
        Console.WriteLine("Presione cualquier tecla par volver la menu...");
        Console.ReadKey();
    }
    public static void VentasxVendedor(Farmacia farmacia) 
    {
        Console.WriteLine(" ");
        Console.WriteLine("           VENTAS REALIZADO POR VENDEDOR          ");
        Console.WriteLine("________________________________________________");
        Console.WriteLine(" ");
        int existVendedor = -1;
        int docVendedor;
        farmacia.showVendedores();
        do 
        {
            docVendedor = GetIntegerVelue("Ingrese documento del vendedor: ");
            existVendedor = farmacia.ToFindEmpleado(docVendedor);
            if (existVendedor <= -1)
                Console.WriteLine("     El vendedor ingresado NO Existe");
        }while (existVendedor <= -1);
        farmacia.VentasXVendedor(docVendedor);
        Console.WriteLine(" ");
        Console.WriteLine("Presione cualquier tecla par volver la menu...");
        Console.ReadKey();
    }

    public static int Menu() 
    {
        string option;
        int optionInt;
        do
        {
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                                                         * ");
            Console.WriteLine("*            Bienvenido al menu de la Farmacia            *");
            Console.WriteLine("*                                                         * ");
            Console.WriteLine("***********************************************************");
            Console.WriteLine(" ");
            Console.WriteLine("1- Añadir una nueva compra de Medicamento");
            Console.WriteLine("2- Eliminar una compra.");
            Console.WriteLine("3- Porcentaje de ventas de la primera quincena");
            Console.WriteLine("4- Lista de ventas por Vendedor");
            Console.WriteLine("5- Agregar empleado");
            Console.WriteLine("6- Eliminar Empleado");
            Console.WriteLine("7- Lista de medicamentos vendidos ");
            Console.WriteLine("8- Exit");

            Console.WriteLine("Por favor ingrese alguna de las opciones anteriores:");
            option = Console.ReadLine();

        } while (!(int.TryParse(option, out optionInt) && optionInt > 0 && optionInt < 9));
         
        return optionInt;
    }

    public static void Pocentaje(Farmacia farmacia) 
    {
        Console.WriteLine(" ");
        Console.WriteLine("  Porcentaje de ventas en la primera quincena");
        Console.WriteLine("             del ultimo año(2022)");
        Console.WriteLine("_______________________________________________");
        Console.WriteLine(" ");
        farmacia.showVentas();
        int mes=0;
        do 
        {
            mes = GetIntegerVelue("Por favor el mes [1-12] que desea ver su porcentaje de ventas de obra social: ");
        } while (!(mes > 0 && mes < 13));
        farmacia.PorcentajeObraSocial(mes);
        Console.WriteLine(" ");
        Console.WriteLine("Presione cualquier tecla par volver la menu...");
        Console.ReadKey();
    }

    //  FUNCION PARA VALIDAR UN TIPO DE DATO INGRESADO POR EL USUARIO, QUE PEDIRA 
    // EL REINGRESO DE DATOS HASTA QUE SEA VALIDO
    public static int GetIntegerVelue(string msj)
    {
        string userData;
        int dataInt = 0;
        bool isDataInvalid = false;
        while (!isDataInvalid)
        {
            Console.WriteLine(msj);
            userData = Console.ReadLine();
            if (!int.TryParse(userData, out dataInt))
                Console.WriteLine("Tipo De Dato INVALIDO. VUELVA A INGRESAR!");
            else
                isDataInvalid = true;
        }
        return dataInt;
    }
}
