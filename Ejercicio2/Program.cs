// See https://aka.ms/new-console-template for more information
using System;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cant = Constantes.cantidad;
            var f = new Funciones();

            var listaEmpleados = new List<Empleado>();//Creo la lista
            f.cargarDatos(listaEmpleados);//Cargo los datos

            //Parte destinada a obtener información en base a los datos ingresados
            var antiguedad = new int[cant];
            var edad = new int[cant];
            var jubilacion = new int[cant];
            var salario = new double[cant];
            double adicional;
            for (int i = 0; i < cant; i++)
            {
                //Antiguedad del empleado
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

                //Edad del empleado
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

                //Años restantes para la jubilación del empleado
                if (Convert.ToString((gener)'M') == listaEmpleados[i].Genero)
                {
                    jubilacion[i] = 65 - edad[i];
                }
                else
                {
                    jubilacion[i] = 60 - edad[i];
                }

                //Salario total del empleado
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

            //Obtención del empleado más cercano a su jubilación y el monto total de salarios
            int jubiValor = jubilacion[0], jubiPosi = 0;
            double montoTotal = 0;
            for (int i = 0; i < cant; i++)
            {
                if (jubiValor > jubilacion[i])
                {
                    jubiValor = jubilacion[i];
                    jubiPosi = i;
                }

                montoTotal += salario[i];
            }

            //Muestra de datos del empleado más próximo a la jubilación
            Console.WriteLine("\n/---Información del empleado más cerca a la información---/");
            f.mostrarDatos(listaEmpleados[jubiPosi], salario[jubiPosi], antiguedad[jubiPosi], edad[jubiPosi], jubilacion[jubiPosi]);

            //Muestra del monto total de salarios
            Console.WriteLine($"\nMonto total que se paga en salarios: {montoTotal}");

        }
    }
}