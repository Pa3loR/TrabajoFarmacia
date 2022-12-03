using System.Collections;
using TrabajoFarmacia;

internal class Program
{
    private static void Main(string[] args)
    {
        var farmacia = new Farmacia("Belgrano");

        //CREACION DE LOS EMPLEADOS
        var vendedorUno = new Vendedor(1234567, 40548231, "Torres", "Oscar", 90000);
        var vendedorDos = new Vendedor(1234568, 35949556, "Roman", "Roberto", 91000);
        var farmaceutico = new Farmaceutico(35518211, "Aguirre", "Marcela", 12000);
        var mantenimiento = new Mantenimiento("Limpieza", 20777189, "Delolla", "Rosa", 600000);

        //SE AGREGAN LOS EMPLEADOS A LA FARMACIA
        farmacia.addEmpleado(vendedorUno);
        farmacia.addEmpleado(vendedorDos);
        farmacia.addEmpleado(farmaceutico);
        farmacia.addEmpleado(mantenimiento);

        //CREACION DE LOS MEDICAMENTO
        var ibu = new Medicamento(5554131, "Ibuprofeno 500mg", 500, "antiinflamatoria no esteroide (AINE)");
        var paracetamol = new Medicamento(8944533, "Ibuprofeno 500mg", 520, "acetaminofeno");
        var cloracepam = new Medicamento(1234533, "Clonex", 6200, "benzodiacepinas", "Gotero");
        var planB = new Medicamento(5554478, "Plan B One-Step", 1000, "levonorgestrel 0,75 mg", "Comprimido");
        var redusterol = new Medicamento(3564978, "redusterol", 1562, "Simvastatina", "Comprimido");
        var acovil = new Medicamento(99912978, "acovil", 2247, "ramipril", "Comprimido");
        var levotiroxina = new Medicamento(4566876, "levotiroxina", 1543, "Eutirox");
        var losartan = new Medicamento(989854, "losartán", 1675, "losartán potásico", "Comprimido");
        var metformina = new Medicamento(56741233, "metformina", 7000, "biguanidas");
        var alprazolam = new Medicamento(654411114, "alprazolam", 1209, "benzodiazepina", "Comprimido");
        var aspirina = new Medicamento(56548794, "aspirina", 126, "ácido acetilsalicílico", "Comprimido");
        var bisoprolol = new Medicamento(65654433, "bisoprolol", 2648, "bisoprolol ");

        //CREACION DEL STOCK
        var stockIbu = new Stock(ibu, 50);
        var stockParacetamol = new Stock(paracetamol, 60);
        var stockCloracepam = new Stock(cloracepam, 30);
        var stockPlanB = new Stock(planB, 20);
        var stockRedusterol = new Stock(redusterol, 10);
        var stockAcovil = new Stock(acovil, 2);
        var stockLevotiroxina = new Stock(levotiroxina, 20);
        var stockLosartan = new Stock(losartan, 30);
        var stockMetformina = new Stock(metformina, 6);
        var stockAlprazolam = new Stock(alprazolam, 8);
        var stockAspirina = new Stock(aspirina, 50);
        var stockBisoprolol = new Stock(bisoprolol, 1);

        //SE AGREGAN LOS STOCKS DISPONIBLES PARA  LA FARMACIA
        farmacia.addStok(stockIbu);
        farmacia.addStok(stockParacetamol);
        farmacia.addStok(stockCloracepam);
        farmacia.addStok(stockPlanB);
        farmacia.addStok(stockRedusterol);
        farmacia.addStok(stockAcovil);
        farmacia.addStok(stockLevotiroxina);
        farmacia.addStok(stockLosartan);
        farmacia.addStok(stockMetformina);
        farmacia.addStok(stockAlprazolam);
        farmacia.addStok(stockAspirina);
        farmacia.addStok(stockBisoprolol);

        //CREACION DE LOS PRODUCTOS QUE VAN AL CARRITO
        var medicamentos = new Medicamentos(2, ibu);
        var medicamentos2 = new Medicamentos(5, planB);
        var medicamentos3 = new Medicamentos(8, ibu);
        var medicamentos4 = new Medicamentos(9, cloracepam);
        var medicamentos5 = new Medicamentos(5, planB);
        var medicamentos6 = new Medicamentos(2, redusterol);
        var medicamentos7 = new Medicamentos(1, acovil);
        var medicamentos8 = new Medicamentos(3, acovil);
        var medicamentos9 = new Medicamentos(1, redusterol);

        //CREACION DEL LOS CARRITOS
        var carrito = new ArrayList { medicamentos, medicamentos2, medicamentos6, medicamentos7 };
        var carrito2 = new ArrayList { medicamentos3, medicamentos5, medicamentos8, medicamentos9 };
        var carrito3 = new ArrayList { medicamentos8, medicamentos6, medicamentos, medicamentos6 };
        var carrito4 = new ArrayList { medicamentos3, medicamentos2, medicamentos6, medicamentos8 };
        var carrito5 = new ArrayList { medicamentos4, medicamentos2, medicamentos3, medicamentos9 };

        //CREACION DE LAS COMPRAS DE LA FARMACIA
        var factura = new Factura("HA132456", new DateTime(2022, 9, 11, 7, 0, 0), vendedorUno);
        var factura2 = new Factura("H131312", new DateTime(2022, 11, 11, 12, 0, 0), vendedorDos, "Galeno");
        var factura3 = new Factura("HF32454", new DateTime(2022, 9, 11, 8, 0, 0), vendedorDos, "Simeco");
        var factura4 = new Factura("F412313", new DateTime(2022, 11, 11, 16, 0, 0), vendedorUno, "Ospic");
        var factura5 = new Factura("GH14123", new DateTime(2022, 12, 11, 13, 0, 0), vendedorUno, "Galeno");

        // AÑADO LOS CARRITOS EN LA FACTURA
        factura.AddMedicine(carrito);
        factura2.AddMedicine(carrito2);
        factura3.AddMedicine(carrito3);
        factura4.AddMedicine(carrito4);
        factura5.AddMedicine(carrito5);

        // AÑADO LAS VENTAS A FARMACIA
        farmacia.addCompra(factura);
        farmacia.addCompra(factura2);
        farmacia.addCompra(factura3);
        farmacia.addCompra(factura4);
        farmacia.addCompra(factura5);

        //SE PONE EN MARCHA EL SISTEMA
        Run(farmacia);
    }

    //FUNNCION PARA CORRER LAS DIFERENTES OPCIONES 
    public static void Run(Farmacia farmacia) 
    {
        // limpia la pantalla cuando es invocado
        Console.Clear();
        switch (Menu()) // menu retorna la opcion elejida por el usuario
        {
            case 1:
                //agrega un compra
                AgregarCompraMedicine(farmacia);
                Run(farmacia);
                break;
            case 2:
                // borra una compra
                DeleteCompra(farmacia);
                Run(farmacia);
                break;
            case 3:
                // muestra en pantalla el porcentaje de compras por obrasocial de la primera quincena del mes elegido
                Pocentaje(farmacia);
                Run(farmacia);
                break;
            case 4:
                // imprime en pantalla la cantidad de ventas del vendedor deseado
                VentasxVendedor(farmacia);
                Run(farmacia);
                break;
            case 5:
                // añade un nuevo empleado
                AddEmpleado(farmacia);
                Run(farmacia);
                break;
            case 6:
                //elimina un empleado
                deleteEmpleado(farmacia);
                Run(farmacia);
                break;
            case 7:
                //imprime en pantalla los vedicamentos vendidos sin repetir
                listaMedicamentos(farmacia);
                Run(farmacia);
                break;
            case 8:
                // termina el programa 
                break;
            default:
                break;
        }
    }

    // LISTA LOS MEDICAMENTOS VENDIDOS SIN REPETIR 
    public static void listaMedicamentos(Farmacia farmacia)
    {
        Console.WriteLine(" ");
        Console.WriteLine("               MEDICAMENTOS VENDIDOS           ");
        Console.WriteLine("________________________________________________");
        Console.WriteLine(" ");
        farmacia.showMedicineSold(); //imprime la lista 
        Console.WriteLine(" ");
        Console.WriteLine("Presione cualquier tecla par volver la menu...");
        Console.ReadKey();
    }

    //ELIMINA UN EMPLEADO
    public static void deleteEmpleado(Farmacia farmacia)
    {
        Console.WriteLine(" ");
        Console.WriteLine("            ELIMINAR UN EMPLEADO           ");
        Console.WriteLine("________________________________________________");
        Console.WriteLine(" ");
        string continuar;
        farmacia.showEmpleados(); // lista los empleados para que sea mas facil ingresar el codigo
        // un bucle por si quiere eliminar mas de un empleado
        do
        {
            int documento = GetIntegerVelue("Ingrese Documento del empleado: "); // Validacion para que sea del tipo entero
            int indice = farmacia.ToFindEmpleado(documento);// busca al empleado si existe devuelve su indice, sino   - 1
            if (indice < 0)
                Console.WriteLine("         El empleado No existe!");
            else
            {
                Console.WriteLine("Seguro que desea despedir al empleado?[N para no despedir]");
                string confirmacion = Console.ReadLine();
                if (!(confirmacion.ToLower() == "n")) // despues de una confirmacion depide al empleado
                {
                    farmacia.DeleteEmpleado(documento);
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Desea agregar un nuevo documento?[N para volver al menu]");
            continuar = Console.ReadLine();
        } while (!(continuar.ToLower() == "n"));
    }

    //AÑADE UN EMPLEADO A LA FARMACIA  
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
        // hace elegir entre las opciones en dar incorrecto  entra en el bucle
        do
        {
            option = GetIntegerVelue("Ingrese alguna de las opciones:");
        } while (!(option > 0 && option < 4));

        int documento;
        int isInvalid = -1;

        //el bucle es para confirmar si existe en ese caso vuelve a entrar en el bucle
        do 
        {
            documento = GetIntegerVelue("Ingrese Documento del nuevo empleado: ");
            isInvalid = farmacia.ToFindEmpleado(documento);
            if (isInvalid > -1)
                Console.WriteLine("Ese documento ya esta agregado");

        } while (isInvalid > -1);
        
        //solcita el nombre, apellido y sueldo ya que son datos que se comparte con todas las clases tipo de empleado

        Console.WriteLine("Ingrese nombre del nuevo empleado");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese apellido del nuevo empleado");
        string apellido = Console.ReadLine();
        int sueldo = GetIntegerVelue("Ingrese el sueldo correspondiente al nuevo empleado: ");
        
        // creo una variable employed y luego con polimorfismo se le asigna el tipo de empleado seleccionado
        Employed empleadoNuevo;
        switch (option) 
        {
            case 1:
                //caso vendedor tiene que pedir el codigo como dato adicional
                int codigo = GetIntegerVelue("Ingrese el codigo del nuevo Vendedor: ");
                // se instancia vendedor
                empleadoNuevo = new Vendedor(codigo, documento, apellido, nombre, sueldo);
                Console.WriteLine("     Vendedor Creado!");
                break;
            case 2:
                //caso farmaceutico como no tiene otra cosa lo instancia con los datos obtenidos
                empleadoNuevo = new Farmaceutico(documento, apellido, nombre, sueldo);
                Console.WriteLine("     Farmaceutico Creado!");
                break;
            case 3:
                // casp Mantenimiento se le solicita el puesto nomas
                Console.WriteLine("Ingrese el puesto del nuevo empleado de Mantenimiento");
                string puesto = Console.ReadLine();
                // ya con el dato faltante se instancia
                empleadoNuevo = new Mantenimiento(puesto, documento, apellido, nombre, sueldo);
                Console.WriteLine("     empleado de Mantenimiento Creado!");
                break;
            default:
                // Por defecto crea un farmaceutico
                empleadoNuevo = new Farmaceutico(documento, apellido, nombre, sueldo);
                Console.WriteLine("     Farmaceutico Creado!");
                break;
        }
        // muestra los datos para que sea mas facil de ver los datos agregados
        Console.WriteLine(empleadoNuevo);
        Console.WriteLine(" ");
        Console.WriteLine("DESEA AGREGAR AL NUEVO EMPLEADO? [N para no agregarlo]");
        string confirmacion = Console.ReadLine();
        if (!(confirmacion.ToLower() == "n"))// se pide una confirmacion si se quiere agregar al nuevo empleado
        {
            farmacia.addEmpleado(empleadoNuevo);
            Console.WriteLine("         Empleado Contratado!");
        }
        else // en el caso que se arrepienta o haya ingresado mal, no lo contrata
            Console.WriteLine("         El Empleado NO FUE Contratado!");
        Console.WriteLine(" ");
        Console.WriteLine("Presione cualquier tecla par volver la menu...");
        Console.ReadKey();
    }

    // FUNCION PARA AÑADIR UNA COMPRA EN LA FARMACIA
    public static void AgregarCompraMedicine(Farmacia farmacia)
    {
        string option="N"; // variable para ver si quiere hacer otra compra
        do
        {
            var listaProductos = new ArrayList(); // lista donde se agragaran los productos a agregar al carrito
            Console.WriteLine(" ");
            Console.WriteLine("       AÑADIR COMPRA DE MEDICAMENTOS           ");
            Console.WriteLine("________________________________________________");
            Console.WriteLine(" ");
            

            // COMPRUEVA EL TIKET DE COMPRA SI EXISTE O NO
            //  EN CASO DE EXISTIR LE PIDE QUE INGRESE OTRO CODIGO
            int isvalidCompra;
            string tiketFactura;
            // pide el numero de ticket hasta sea uno valido
            do
            {
                Console.WriteLine("Ingrese el Tiket de compra: ");
                tiketFactura = Console.ReadLine().ToUpper();
                isvalidCompra = farmacia.ToFindVenta(tiketFactura); // ve si existe una compra con ese numero de ticket
                if (isvalidCompra > -1) // >-1 es que existe
                    Console.WriteLine("     Esa Compra Ya existe!");
            } while (isvalidCompra > -1);

            //VALIDACIONES PARA EL VER EL EMPLEADO QUE LO VENDIO 

            int isValidEmpleado;
            int codVendedor;
            farmacia.showVendedores(); // muestra los vendedores disponible para que sa mas facil ingresarlo 
            do
            {
                codVendedor = GetIntegerVelue("Ingrese el documento del vendedor");
                isValidEmpleado = farmacia.ToFindEmpleado(codVendedor);
                if (!(isValidEmpleado > -1))
                    Console.WriteLine("     El empleado no existe!");
            } while (!(isValidEmpleado > -1));
            // una ves que se obtiene un dato de vendedor se copia para guardarlo en factura
            var empleado = farmacia.ObtenerVendedor(isValidEmpleado);

            //VALIDADCIONES PARA AGREGAR LA FECHA

            int dia = -1;
            int mes = -1;
            int anio = 2023;
            // hasta que no ponga una fecha con formato correcto no lo acepta
            do
            {
                anio = GetIntegerVelue("Ingrese Año: ");
                mes = GetIntegerVelue("Ingrese El Mes: ");
                dia = GetIntegerVelue("Ingrese el dia: ");
            } while (!(anio <= 2022 && mes < 13 && mes > 0 && dia > 0 && dia < 32));

            // crea la fecha con los datos solicitados
            var fechaCompra = new DateTime(anio, mes, dia);

            // PONE LOS PRODUCTOS PARA AGREGAR A LA COMPRA

            string addProduc = "N";
            do
            {
                Console.WriteLine(" ");
                Console.WriteLine("         Añadir producto             ");
                Console.WriteLine("______________________________________");
                Console.WriteLine(" ");
                farmacia.showStock(); // muestra los productos en stock
                Console.WriteLine(" ");


                int codMedicine = GetIntegerVelue("Ingrese el codigo del medicamento: ");
                int indiceStock = farmacia.ToFindStok(codMedicine);
                // ve si existe en el stock
                if (indiceStock > -1)
                {
                    // si existe tiene que comprobar que la cantidad solicitada sea valida
                    int cantMedicine;
                    // le pide que ingrese  un valor disponible
                    do
                    {
                        cantMedicine = GetIntegerVelue("Ingrese la cantidad del medicamento que quiere comprar: ");

                    } while (!farmacia.checkStokDisponibleBol(indiceStock, cantMedicine));

                    // ya con todo los datos correctos, saca la cantidad solicitadad del stock
                    farmacia.SacarDelStock(indiceStock, cantMedicine);

                    //y esa cantidad lo pone en la compra
                    var producto = new Medicamentos(cantMedicine, farmacia.obtenerMedicamento(indiceStock));
                    listaProductos.Add(producto);
                }
                // en caso que no este pone que no existe
                else
                    Console.WriteLine("     El medicamento solicitado NO EXISTE en el stock actual");

                // Pregunta por si se quiere seguir comprando mas productos
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

    // ELIMINA UNA COMPRA DE LAS VENTAS
    public static void DeleteCompra(Farmacia farmacia)
    {
        Console.WriteLine(" ");
        Console.WriteLine("                 ELIMINAR COMPRA          ");
        Console.WriteLine("________________________________________________");
        Console.WriteLine(" ");
         
        // muestra las ventas que hay en farmacia
        farmacia.showVentasSimplificado();
        string option = "y";
        string tiketFactura;
        // Bucle por si se quiere quitar mas de 1 compra
        do
        {
            //validaciones para que ingrese un dato correcto y que exista
            bool isInvalid = true;
            while (isInvalid)
            {
                try
                {
                    Console.WriteLine("Ingrese el tiket de la compra que desea eliminar: ");
                    tiketFactura = Console.ReadLine().ToUpper();
                    farmacia.DeleteCompra(tiketFactura);
                    isInvalid = false; // se creo sin problemas por eso false asi sale del bucle
                }
                catch (InvalidTiketExeption e)
                {
                    //en caso que no exista la compra
                    Console.WriteLine(e.Message);
                    Console.WriteLine(" ");
                    Console.WriteLine("     El tiket ingresado NO EXISTE!");
                    isInvalid = true; // es verdadero por que ocurrio la exepcion asi que entra en el bucle
                }
                catch (Exception e)
                {
                    Console.WriteLine("A Ocurrido un error");
                    isInvalid = true;// es verdadero por que ocurrio la exepcion asi que entra en el bucle
                }
            }
            // Pide una confirmacion para borrar
            Console.WriteLine("Desea eliminar otra compra? [Y/N] ");
            option = Console.ReadLine();
            Console.WriteLine(" ");
        } while (!(option.ToLower() == "n"));
        Console.WriteLine(" ");
        Console.WriteLine("Presione cualquier tecla par volver la menu...");
        Console.ReadKey();
    }

    //LISTA LAS VENTAS TOTALES DEL VENDEDOR DESEADO
    public static void VentasxVendedor(Farmacia farmacia) 
    {
        Console.WriteLine(" ");
        Console.WriteLine("           VENTAS REALIZADO POR VENDEDOR          ");
        Console.WriteLine("________________________________________________");
        Console.WriteLine(" ");
        int existVendedor = -1;
        int docVendedor; 
        // muestra la lista de vendedores disponibles
        farmacia.showVendedores();
        //Bucle hasta que el dato del vendedor sea correcto
        do 
        {
            docVendedor = GetIntegerVelue("Ingrese documento del vendedor: ");
            existVendedor = farmacia.ToFindEmpleado(docVendedor);
            if (existVendedor <= -1)
                Console.WriteLine("     El vendedor ingresado NO Existe");
        }while (existVendedor <= -1);
        // llama al metodo VentasXVendedor que lista la ventas totales
        farmacia.VentasXVendedor(docVendedor);
        Console.WriteLine(" ");
        Console.WriteLine("Presione cualquier tecla par volver la menu...");
        Console.ReadKey();
    }

    // FUNCION DEL MENU QUE RETORNA LA OPCION ELEJIDA POR EL USUARIO
    public static int Menu() 
    {
        string option;
        int optionInt;
        // el bucle esta hasta que elija una opcion coreccta entra las mostradas
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
         
        return optionInt; // devuelve la opcion
    }

    // FUNCION QUE DEVUELVE EL PORCENTAJE DE LAS VENTAS DE LA PRIMERA QUINCENA  DEL MES SOLICITADO
    public static void Pocentaje(Farmacia farmacia) 
    {
        Console.WriteLine(" ");
        Console.WriteLine("  Porcentaje de ventas en la primera quincena");
        Console.WriteLine("             del ultimo año(2022)");
        Console.WriteLine("_______________________________________________");
        Console.WriteLine(" ");
        farmacia.showVentas(); // muestra las ventas
        int mes=0;
        //entra en bucle hasta que el mes sea uno correcto
        do 
        {
            mes = GetIntegerVelue("Por favor el mes [1-12] que desea ver su porcentaje de ventas de obra social: ");
        } while (!(mes > 0 && mes < 13));
        // el metodo de la farmacia realiza el porcentaje del mes del año 2022
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
