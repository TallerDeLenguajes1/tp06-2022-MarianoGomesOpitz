// See https://aka.ms/new-console-template for more information




string inp;
double num;
int verif1 = 0;
Console.WriteLine("Ingrese un valor:");
do
{
    int verif2 = 0;
    if (verif1 > 0)
    {
        Console.WriteLine("\nEl valor ingresado debe ser distinto de 0, ingrese de nuevo");
    }
    do
    {
        if (verif2 > 0)
        {
            Console.WriteLine("\nEl valor ingresado no es un número, ingrese de nuevo:");
        }
        inp = Console.ReadLine();
        verif2++;
    } while (!Double.TryParse(inp, out num));
    verif1++;
} while (num == 0);


Calculadora operacion = new Calculadora(num);
int veri;
char cont;
do
{

    Console.WriteLine("\nIngrese la operación a realizar (+, -, *, /), o \"x\" para parar");
    veri = 0;
    do
    {
        if (veri > 0)
        {
            Console.WriteLine("\nEl termino ingresado no está reconocido, ingrese de nuevo");
        }
        cont = Console.ReadKey().KeyChar;
        veri++;
    } while (cont != '+' && cont != '-' && cont != '*' && cont != '/' && cont != 'x' && cont != 'X');

    switch (cont)
    {
        case '+':
            operacion.Sumar(num);
            break;

        case '-':
            operacion.Resta(num);
            break;

        case '*':
            operacion.Producto(num);
            break;

        case '/':
            operacion.Cociente(num);
            break;
    }
    Console.WriteLine($"\nValor actual: {operacion.Resultado}");
    if (operacion.Resultado == 0)
    {
        Console.WriteLine("\nEl valor a llegado a 0, fin del programa");
        break;
    }
} while (cont != 'x' && cont != 'X');
operacion.Limpiar();