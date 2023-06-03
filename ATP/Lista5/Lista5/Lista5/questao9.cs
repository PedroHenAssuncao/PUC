using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista5
{
    public static class questao9
    {
        public static void rodar()
        {
            int[,] matrizA = new int[4, 6];
            int[,] matrizB = new int[4, 6];

            questao7.PreencherMatriz(matrizA);
            questao7.PreencherMatriz(matrizB);

            Console.WriteLine("Matriz A:");
            questao7.ImprimirMatriz(matrizA);

            Console.WriteLine("Matriz B:");
            questao7.ImprimirMatriz(matrizB);

            int[,] matrizSoma = CalcularSoma(matrizA, matrizB);
            Console.WriteLine("Matriz Soma (A + B):");
            questao7.ImprimirMatriz(matrizSoma);

            int[,] matrizDiferenca = CalcularDiferenca(matrizA, matrizB);
            Console.WriteLine("Matriz Diferença (A - B):");
            questao7.ImprimirMatriz(matrizDiferenca);
        }

        public static int[,] CalcularSoma(int[,] matrizA, int[,] matrizB)
        {
            int[,] matrizSoma = new int[matrizA.GetLength(0), matrizA.GetLength(1)];

            for (int i = 0; i < matrizA.GetLength(0); i++)
            {
                for (int j = 0; j < matrizA.GetLength(1); j++)
                {
                    matrizSoma[i, j] = matrizA[i, j] + matrizB[i, j];
                }
            }

            return matrizSoma;
        }

        public static int[,] CalcularDiferenca(int[,] matrizA, int[,] matrizB)
        {
            int[,] matrizDiferenca = new int[matrizA.GetLength(0), matrizA.GetLength(1)];

            for (int i = 0; i < matrizA.GetLength(0); i++)
            {
                for (int j = 0; j < matrizA.GetLength(1); j++)
                {
                    matrizDiferenca[i, j] = matrizA[i, j] - matrizB[i, j];
                }
            }

            return matrizDiferenca;
        }
    }
}
