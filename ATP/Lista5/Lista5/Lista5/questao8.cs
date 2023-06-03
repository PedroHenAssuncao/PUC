using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista5
{
    public static class questao8
    {
        public static void rodar()
        {
            int[,] matriz = new int[4, 4];

            questao7.PreencherMatriz(matriz);

            Console.WriteLine("Matriz:");
            questao7.ImprimirMatriz(matriz);

            int soma = SomaAbaixoDiagonalPrincipal(matriz);
            Console.WriteLine("Soma dos elementos abaixo da diagonal principal: " + soma);

            Console.WriteLine("Elementos da diagonal principal:");
            ImprimirDiagonalPrincipal(matriz);
        }

        public static int SomaAbaixoDiagonalPrincipal(int[,] matriz)
        {
            int soma = 0;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                soma += matriz[(i + 1) >= matriz.GetLength(0) ? 0 : i + 1, i];
                
            }

            return soma;
        }

        public static void ImprimirDiagonalPrincipal(int[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                Console.Write(matriz[i, i] + " ");
            }
            Console.WriteLine();
        }
    }
}
