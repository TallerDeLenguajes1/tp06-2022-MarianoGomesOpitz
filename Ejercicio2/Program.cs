// See https://aka.ms/new-console-template for more information
using System;

namespace Ejercicio2 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nom, ape;
            char civi, gene;
            DateOnly nac, ing;
            int dd, mm, yy, carg;
            double suel;

            Console.WriteLine("\nIngrese su apellido:");
            nom = Console.ReadLine();
            Console.WriteLine("\nIngrese su nombre:");
            ape = Console.ReadLine();
            Console.WriteLine("\nIngrese su estado civil (Soltero: S, en Pareja: P, Casado: C, Viudo: V)");
            civi = Console.ReadKey().KeyChar;
            Console.WriteLine("\nIngrese su género (Masculino: M, Femenino: F, Otro: O)");
            gene = Console.ReadKey().KeyChar;
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
            Console.WriteLine("\nIngrese su sueldo:");
            suel = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nIngrese el cargo al que pertenece (Auxiliar: 1, Administrativo: 2, Ingeniero: 3, Especialista: 4, Investigador: 5):");
            carg = Convert.ToInt32(Console.ReadLine());

            var emple = new Empleado(nom, ape, civi, gene, carg, nac, ing, suel);

            Console.WriteLine($"Apellido y nombre: {emple.Apellido} {emple.Nombre}");
            Console.WriteLine($"Estado civil: {emple.EstCivil}");
            Console.WriteLine($"Género: {emple.Genero}");
            Console.WriteLine($"Fecha de nacimiento: {emple.FechaNac}");
            Console.WriteLine($"Fecha de ingreso: {emple.FechaIngr}");
            Console.WriteLine($"Sueldo: ${emple.Sueldo}");
            Console.WriteLine($"Cargo: {emple.Cargo}");
        }
    }


}
public enum cargos
{
    Auxiliar = 1,
    Administrativo = 2,
    Ingeniero = 3,
    Especialista = 4,
    Investigador = 5
}
public enum estado
{
    Soltero = 'S',
    Pareja = 'P',
    Casado = 'C',
    Viudo = 'V'
}
public enum gener
{
    Masculino = 'M',
    Femenino = 'F',
    Otro = 'O'
}