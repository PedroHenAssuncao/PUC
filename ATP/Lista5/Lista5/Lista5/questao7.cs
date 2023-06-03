using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista5
{
    public static class questao7
    {
        public static void PreencherMatriz(int[,] matriz)
        {
            Random random = new Random();

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = random.Next(1, 10);
                }
            }
        }

        public static int SomaLinha(int[,] matriz, int linha)
        {
            int soma = 0;

            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                soma += matriz[linha, j];
            }

            return soma;
        }

        public static int SomaColuna(int[,] matriz, int coluna)
        {
            int soma = 0;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                soma += matriz[i, coluna];
            }

            return soma;
        }

        public static int SomaDiagonalPrincipal(int[,] matriz)
        {
            int soma = 0;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                soma += matriz[i, i];
            }

            return soma;
        }

        public static int SomaDiagonalSecundaria(int[,] matriz)
        {
            int soma = 0;
            int n = matriz.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                soma += matriz[i, n - 1 - i];
            }

            return soma;
        }

        public static int SomaTotal(int[,] matriz)
        {
            int soma = 0;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    soma += matriz[i, j];
                }
            }

            return soma;
        }

        public static void ImprimirMatriz(int[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void rodar()
        {
            int[,] matriz = new int[5, 5];

            PreencherMatriz(matriz);

            Console.WriteLine("Matriz:");
            ImprimirMatriz(matriz);

            Console.WriteLine("Soma da linha 4: " + SomaLinha(matriz, 3));
            Console.WriteLine("Soma da coluna 2: " + SomaColuna(matriz, 1));
            Console.WriteLine("Soma da diagonal principal: " + SomaDiagonalPrincipal(matriz));
            Console.WriteLine("Soma da diagonal secundária: " + SomaDiagonalSecundaria(matriz));
            Console.WriteLine("Soma total: " + SomaTotal(matriz));
        }
    }
}
