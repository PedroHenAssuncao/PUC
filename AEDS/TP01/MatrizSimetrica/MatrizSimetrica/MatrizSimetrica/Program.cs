using System;
internal class Program
{
    private static void Main(string[] args)
    {
        string entrada = Console.ReadLine();
        var aux = entrada.Split(' ');
        int n = int.Parse(aux[0]);
        int m = int.Parse(aux[1]);

        if(n != m)
        {
            Console.WriteLine(0);
            return;
        }

        int[,] matriz = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            string[] linha = Console.ReadLine().Split(' ');

            for (int j = 0; j < n; j++)
            {
                matriz[i, j] = int.Parse(linha[j]);
            }
        }

        bool simetrica = VerificarSimetria(matriz, n, m);

        if (simetrica)
        {
            Console.WriteLine(1);
        }
        else
        {
            Console.WriteLine(0);
        }
    }

    private static bool VerificarSimetria(int[,] matriz, int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matriz[i, j] != matriz[j, i])
                {
                    return false;
                }
            }
        }
        return true;
    }
}