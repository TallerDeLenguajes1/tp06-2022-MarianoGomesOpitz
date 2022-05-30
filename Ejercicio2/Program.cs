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

            var listaEmpleados = new List<Empleado>();

            int i;
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine($"\n/-----Empleada\\o {i + 1}-----/");
                Console.WriteLine("\nIngrese el apellido:");
                ape = Console.ReadLine();
                Console.WriteLine("\nIngrese el nombre:");
                nom = Console.ReadLine();
                Console.WriteLine("\nIngrese el estado civil (Soltera\\o: S, en Pareja: P, Casada\\o: C, Viuda\\o: V)");
                civi = Console.ReadKey().KeyChar;
                Console.WriteLine("\nIngrese el género (Masculino: M, Femenino: F)");
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
                Console.WriteLine("\nIngrese el sueldo:");
                suel = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nIngrese el cargo al que pertenece (Auxiliar: 1, Administrativo: 2, Ingeniero: 3, Especialista: 4, Investigador: 5):");
                carg = Convert.ToInt32(Console.ReadLine());

                var emple = new Empleado(nom, ape, civi, gene, carg, nac, ing, suel);

                listaEmpleados.Add(emple);
            }

            var antiguedad = new int[3];
            var edad = new int[3];
            var jubilacion = new int[3];
            var salario = new double[3];
            double adicional, montoTotal = 0;
            for (i = 0; i < 3; i++)
            {
                antiguedad[i] = DateTime.Now.Year - listaEmpleados[i].FechaIngr.Year;
                if (DateTime.Now.Month < listaEmpleados[i].FechaIngr.Month)
                {
                    antiguedad[i]--;
                }
                else
                {
                    if (DateTime.Now.Month == listaEmpleados[i].FechaIngr.Month && DateTime.Now.Day < listaEmpleados[i].FechaIngr.Day)
                    {
                        antiguedad[i]--;
                    }
                }

                ////////////////////////////////////////////////////////////////////

                edad[i] = DateTime.Now.Year - listaEmpleados[i].FechaNac.Year;
                if (DateTime.Now.Month < listaEmpleados[i].FechaNac.Month)
                {
                    edad[i]--;
                }
                else
                {
                    if (DateTime.Now.Month == listaEmpleados[i].FechaNac.Month && DateTime.Now.Day < listaEmpleados[i].FechaNac.Day)
                    {
                        edad[i]--;
                    }
                }

                ////////////////////////////////////////////////////////////////////

                if (Convert.ToString((gener)'M') == listaEmpleados[i].Genero)
                {
                    jubilacion[i] = 65 - edad[i];
                }
                else
                {
                    jubilacion[i] = 60 - edad[i];
                }

                ////////////////////////////////////////////////////////////////////
                adicional = 0;
                if (antiguedad[i] < 20)
                {
                    adicional = (listaEmpleados[i].SueldoBasico / 100) * antiguedad[i];
                }
                else
                {
                    adicional = (listaEmpleados[i].SueldoBasico / 100) * 20;
                }

                if (Convert.ToString((cargos)3) == listaEmpleados[i].Cargo || Convert.ToString((cargos)4) == listaEmpleados[i].Cargo)
                {
                    adicional += (adicional / 2);
                }

                if (Convert.ToString((estado)'C') == listaEmpleados[i].EstCivil)
                {
                    adicional += 15000;
                }

                salario[i] = listaEmpleados[i].SueldoBasico + adicional;
            }

            int jubiValor = jubilacion[0], jubiPosi = 0;
            for (i = 0; i < 3; i++)
            {
                if (jubiValor > jubilacion[i])
                {
                    jubiValor = jubilacion[i];
                    jubiPosi = i;
                }

                montoTotal += salario[i];
            }

            Console.WriteLine("\n/------Empleado más cercano a la jubilación------/");
            Console.WriteLine($"\n/------Información del empleado {jubiPosi + 1}------/");
            Console.WriteLine($"Apellido y nombre: {listaEmpleados[jubiPosi].Apellido} {listaEmpleados[jubiPosi].Nombre}");
            Console.WriteLine($"Estado civil: {listaEmpleados[jubiPosi].EstCivil}");
            Console.WriteLine($"Género: {listaEmpleados[jubiPosi].Genero}");
            Console.WriteLine($"Fecha de nacimiento: {listaEmpleados[jubiPosi].FechaNac}");
            Console.WriteLine($"Fecha de ingreso: {listaEmpleados[jubiPosi].FechaIngr}");
            Console.WriteLine($"Sueldo básico: ${listaEmpleados[jubiPosi].SueldoBasico}");
            Console.WriteLine($"Salario: ${salario[jubiPosi]}");
            Console.WriteLine($"Cargo: {listaEmpleados[jubiPosi].Cargo}");
            Console.WriteLine($"Antiguedad: {antiguedad[jubiPosi]} años");
            Console.WriteLine($"Edad: {edad[jubiPosi]} años");
            Console.WriteLine($"Años que faltan para su jubilación: {jubilacion[jubiPosi]}");

            Console.WriteLine($"\nMonto total que se paga en salarios: {montoTotal}");

        }
    }


}