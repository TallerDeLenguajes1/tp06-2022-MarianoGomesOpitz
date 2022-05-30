using System;

//Clase de empleado
public class Empleado
{
    private string nombre, apellido, cargo;
    private string estCivil, genero;
    private DateOnly fechaNac, fechaIngr;
    private double sueldoBasico;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public string EstCivil { get => estCivil; set => estCivil = value; }
    public string Genero { get => genero; set => genero = value; }
    public DateOnly FechaNac { get => fechaNac; set => fechaNac = value; }
    public DateOnly FechaIngr { get => fechaIngr; set => fechaIngr = value; }
    public double SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }
    public string Cargo { get => cargo; set => cargo = value; }

    //Carga de datos
    public Empleado(string nom, string ape, char civi,
    char gene, int carg, DateOnly nac, DateOnly ing, double suel)
    {
        nombre = nom;
        apellido = ape;
        estCivil = Convert.ToString((estado)civi);
        genero = Convert.ToString((gener)gene);
        cargo = Convert.ToString((cargos)carg);
        fechaNac = nac;
        fechaIngr = ing;
        sueldoBasico = suel;
    }
}

//Clase para funciones
class Funciones
{
    //Función para cargar datos
    public void cargarDatos(List<Empleado> lista)
    {
        var cant = Constantes.cantidad;
        string nom, ape;
        char civi, gene;
        DateOnly nac, ing;
        int dd, mm, yy, carg;
        double suel;
        for (int i = 0; i < cant; i++)
        {
            Console.WriteLine($"\n/-----Empleada\\o {i + 1}-----/");
            Console.WriteLine("\nIngrese el apellido:");
            ape = Console.ReadLine();
            Console.WriteLine("\nIngrese el nombre:");
            nom = Console.ReadLine();
            Console.WriteLine("\nIngrese el estado civil (Soltera\\o: S, en Pareja: P, Casada\\o: C, Viuda\\o: V)");
            civi = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine("\nIngrese el género (Masculino: M, Femenino: F)");
            gene = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine("\nFecha de nacimiento:");
            Console.WriteLine("Ingrese el día:");
            dd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el mes");
            mm = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el año:");
            yy = Convert.ToInt32(Console.ReadLine());
            nac = new DateOnly(yy, mm, dd);
            Console.WriteLine("\nFecha de ingreso:");
            Console.WriteLine("Ingrese el día:");
            dd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el mes");
            mm = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el año:");
            yy = Convert.ToInt32(Console.ReadLine());
            ing = new DateOnly(yy, mm, dd);
            Console.WriteLine("\nIngrese el sueldo:");
            suel = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nIngrese el cargo al que pertenece (Auxiliar: 1, Administrativo: 2, Ingeniero: 3, Especialista: 4, Investigador: 5):");
            carg = Convert.ToInt32(Console.ReadLine());

            var emple = new Empleado(nom, ape, civi, gene, carg, nac, ing, suel);

            lista.Add(emple);
        }
    }

    //Función para mostrar datos de un empleado
    public void mostrarDatos(Empleado emp, double plata, int anti, int ed, int jubi)
    {
        Console.WriteLine($"Apellido y nombre: {emp.Apellido} {emp.Nombre}");
        Console.WriteLine($"Estado civil: {emp.EstCivil}");
        Console.WriteLine($"Género: {emp.Genero}");
        Console.WriteLine($"Fecha de nacimiento: {emp.FechaNac}");
        Console.WriteLine($"Fecha de ingreso: {emp.FechaIngr}");
        Console.WriteLine($"Sueldo básico: ${emp.SueldoBasico}");
        Console.WriteLine($"Salario: ${plata}");
        Console.WriteLine($"Cargo: {emp.Cargo}");
        Console.WriteLine($"Antiguedad: {anti} años");
        Console.WriteLine($"Edad: {ed} años");
        Console.WriteLine($"Años que faltan para su jubilación: {jubi}");
    }
}

//Clase para variables constantes
class Constantes
{
    public const int cantidad = 3;
}

//Enum de cargos
public enum cargos
{
    Auxiliar = 1,
    Administrativo = 2,
    Ingeniero = 3,
    Especialista = 4,
    Investigador = 5
}

//Enum de estados civiles
public enum estado
{
    Soltero = 'S',
    Pareja = 'P',
    Casado = 'C',
    Viudo = 'V'
}

//Enum de géneros
public enum gener
{
    Masculino = 'M',
    Femenino = 'F'
}