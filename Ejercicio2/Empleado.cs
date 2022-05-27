using System;

public class Empleado
{
    private string nombre, apellido, cargo;
    private string estCivil, genero;
    private DateOnly fechaNac, fechaIngr;
    private double sueldo;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public string EstCivil { get => estCivil; set => estCivil = value; }
    public string Genero { get => genero; set => genero = value; }
    public DateOnly FechaNac { get => fechaNac; set => fechaNac = value; }
    public DateOnly FechaIngr { get => fechaIngr; set => fechaIngr = value; }
    public double Sueldo { get => sueldo; set => sueldo = value; }
    public string Cargo { get => cargo; set => cargo = value; }

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
        sueldo = suel;
    }
}