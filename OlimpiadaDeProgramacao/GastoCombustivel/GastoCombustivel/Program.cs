using System;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        int hora = int.Parse(Console.ReadLine());
        int velocidade = int.Parse(Console.ReadLine());
        int distancia = velocidade * hora;

        Console.WriteLine((distancia / 12.0).ToString("N3"));
    }
}