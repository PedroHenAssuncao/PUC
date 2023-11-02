using System;
internal class Program
{
    private static void Main(string[] args)
    {
        int quotaMensal = int.Parse(Console.ReadLine());

        int nMeses = int.Parse(Console.ReadLine());

        int totalCotas = quotaMensal * nMeses;

        for (int i = 0; i < nMeses; i++)
        {
            int usadoMes = int.Parse(Console.ReadLine());

            totalCotas -= usadoMes;
        }

        Console.WriteLine(totalCotas + quotaMensal);
    }
}