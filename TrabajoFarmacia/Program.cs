using System.Collections;
using TrabajoFarmacia;

internal class Program
{
    private static void Main(string[] args)
    {
        string s = "adasafafFFFF";
        Console.WriteLine(s.ToUpper());

        var vendedor = new Vendedor(1222222, 415164283, "herrera", "jose", 20000);
        var farm = new Farmaceutico(11111111, "herrera", "jose", 20000);
        var mant = new Mantenimiento("Limpieza", 12345678, "Gomez", "Fede", 4111);
        var medicine = new Medicamento(111111, "Paracetamol", 200, "Analgecico");
        Console.WriteLine(medicine);
        vendedor.DNI = 31111111;
        int i = 1;
        var list = new ArrayList() { vendedor, farm, mant };
        foreach (Employed empleado in list) Console.WriteLine($"{i++} - {empleado}");
        Medicamentos m = new Medicamentos(5, medicine);
        Console.WriteLine(m);
        m.Delete();
        Console.WriteLine(m);
        Console.WriteLine(m.GetImporte);
        m.Delete();
        Console.WriteLine(m);
        m.Delete();
        Console.WriteLine(m);
        m.Delete();
        Console.WriteLine(m);
        m.Delete();
        Console.WriteLine(m);
        m.Delete();
        Console.WriteLine(m);
        m.Add();
        Console.WriteLine(m);
    }
}