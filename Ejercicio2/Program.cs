// See https://aka.ms/new-console-template for more information
using System;

namespace Ejercicio2 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var cant = Constantes.cantidad;
            var listaEmpleados = new List<Empleado>();
            var f = new Funciones();
            f.cargarDatos(listaEmpleados);

            var antiguedad = new int[cant];
            var edad = new int[cant];
            var jubilacion = new int[cant];
            var salario = new double[cant];
            double adicional, montoTotal = 0;
            for (int i = 0; i < cant; i++)
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
            for (int i = 0; i < cant; i++)
            {
                if (jubiValor > jubilacion[i])
                {
                    jubiValor = jubilacion[i];
                    jubiPosi = i;
                }

                montoTotal += salario[i];
            }
            
            f.mostrarDatos(listaEmpleados[jubiPosi], salario[jubiPosi], antiguedad[jubiPosi], edad[jubiPosi], jubilacion[jubiPosi]);

            Console.WriteLine($"\nMonto total que se paga en salarios: {montoTotal}");

        }


    }

    class Funciones
    {
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

                lista.Add(emple);
            }
        }

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

    class Constantes
    {
        public const int cantidad = 3;
    }

}