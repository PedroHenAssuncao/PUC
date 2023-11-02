using System;
internal class Program
{
    private static void Main(string[] args)
    {
        string[] entrada = Console.ReadLine().Split(' ');

        double x1 = double.Parse(entrada[0]);
        double y1 = double.Parse(entrada[1]);

        entrada = Console.ReadLine().Split(' ');

        double x2 = double.Parse(entrada[0]);
        double y2 = double.Parse(entrada[1]);

        double distancia = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

        Console.WriteLine(distancia.ToString("N4"));
    }
}