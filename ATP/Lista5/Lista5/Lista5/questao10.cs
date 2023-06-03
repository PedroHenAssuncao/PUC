using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista5
{
    public static class questao10
    {
        public static void rodar()
        {
            int[,] matriz = new int[10, 10];

            questao7.PreencherMatriz(matriz);

            Console.WriteLine("Matriz original:");
            questao7.ImprimirMatriz(matriz);

            TrocarLinha(matriz, 2, 8);
            Console.WriteLine("Matriz após a troca da linha 2 com a linha 8:");
            questao7.ImprimirMatriz(matriz);

            TrocarColuna(matriz, 4, 10 - 1);
            Console.WriteLine("Matriz após a troca da coluna 4 com a coluna 10:");
            questao7.ImprimirMatriz(matriz);

            TrocarDiagonais(matriz);
            Console.WriteLine("Matriz após a troca da diagonal principal com a diagonal secundária:");
            questao7.ImprimirMatriz(matriz);

            TrocarLinhaColuna(matriz, 5, 10 - 1);
            Console.WriteLine("Matriz após a troca da linha 5 com a coluna 10:");
            questao7.ImprimirMatriz(matriz);
        }

        public static void TrocarLinha(int[,] matriz, int linha1, int linha2)
        {
            int tamanho = matriz.GetLength(1);

            for (int j = 0; j < tamanho; j++)
            {
                int temp = matriz[linha1, j];
                matriz[linha1, j] = matriz[linha2, j];
                matriz[linha2, j] = temp;
            }
        }

        public static void TrocarColuna(int[,] matriz, int coluna1, int coluna2)
        {
            int tamanho = matriz.GetLength(0);

            for (int i = 0; i < tamanho; i++)
            {
                int temp = matriz[i, coluna1];
                matriz[i, coluna1] = matriz[i, coluna2];
                matriz[i, coluna2] = temp;
            }
        }

        public static void TrocarDiagonais(int[,] matriz)
        {
            int tamanho = matriz.GetLength(0);

            for (int i = 0; i < tamanho; i++)
            {
                int temp = matriz[i, i];
                matriz[i, i] = matriz[i, tamanho - 1 - i];
                matriz[i, tamanho - 1 - i] = temp;
            }
        }

        public static void TrocarLinhaColuna(int[,] matriz, int linha, int coluna)
        {
            int tamanho = matriz.GetLength(0);

            for (int i = 0; i < tamanho; i++)
            {
                int temp = matriz[i, linha];
                matriz[i, linha] = matriz[i, coluna - 1];
                matriz[i, coluna - 1] = temp;
            }
        }
    }
}
