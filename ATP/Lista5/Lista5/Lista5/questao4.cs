using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista5
{
    public static class questao4
    {
        public static void rodar()
        {
            int[] vetorX = new int[10];
            int[] vetorY = new int[10];

            PreencherVetoresXY(vetorX, vetorY);
            int[] vetorIntercalado = IntercalarVetores(vetorX, vetorY);
            Console.WriteLine("VetorX: ");
            ExibirVetor(vetorX);
            Console.WriteLine("Vetory: ");
            ExibirVetor(vetorY);
            Console.WriteLine("Vetor Intercalado: ");
            ExibirVetor(vetorIntercalado);
        }

        static void PreencherVetoresXY(int[] vetorX, int[] vetorY)
        {
            Random random= new Random();

            for (int i = 0; i < vetorX.Length; i++)
            {
                vetorX[i] = random.Next(0, 10);
            }

            for (int i = 0; i < vetorY.Length; i++)
            {
                vetorY[i] = random.Next(0,10);
            }
        }

        static int[] IntercalarVetores(int[] vetorX, int[] vetorY)
        {
            int tamanho = vetorX.Length + vetorY.Length;
            int[] vetorIntercalado = new int[tamanho];

            int indexX = 0;
            int indexY = 0;

            for (int i = 0; i < tamanho; i++)
            {
                if (i % 2 == 0 && indexX < vetorX.Length)
                {
                    vetorIntercalado[i] = vetorX[indexX];
                    indexX++;
                }
                else if (indexY < vetorY.Length)
                {
                    vetorIntercalado[i] = vetorY[indexY];
                    indexY++;
                }
            }

            return vetorIntercalado;
        }

        static void ExibirVetor(int[] vetor)
        {
            Console.WriteLine("Conteúdo do vetor:");

            foreach (int valor in vetor)
            {
                Console.Write("[" + valor + "] ");
            }

            Console.WriteLine();
        }

    }
}
