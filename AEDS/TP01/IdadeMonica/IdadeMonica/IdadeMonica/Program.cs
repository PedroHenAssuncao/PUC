using System;
internal class Program
{
    private static void Main(string[] args)
    {
        int idadeMonica = int.Parse(Console.ReadLine());
        int idadeA = int.Parse(Console.ReadLine());
        int idadeB = int.Parse(Console.ReadLine());
        int idadeC = idadeMonica - (idadeA + idadeB);

        if (idadeA > idadeB && idadeA > idadeC)
        {
            Console.WriteLine(idadeA);
        }
        else if (idadeB > idadeA && idadeB > idadeC)
        {
            Console.WriteLine(idadeB);
        }
        else
        {
            Console.WriteLine(idadeC);
        }
    }
}