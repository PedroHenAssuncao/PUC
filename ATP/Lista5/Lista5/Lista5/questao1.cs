using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista5
{
    public static class questao1
    {
        public static void rodar()
        {
            int tamVetor = 20;
            int[] vetor = new int[tamVetor];
            int menorValor = int.MaxValue;
            int pos = 0;

            for (int i = 0; i < tamVetor; i++)
            {
                Console.WriteLine("Digite um numero para a posição " + i + " do vetor");
                vetor[i] = int.Parse(Console.ReadLine());

                if (menorValor > vetor[i])
                {
                    menorValor = vetor[i];
                    pos = i;
                }
            }

            Console.WriteLine("O menor valor do vetor é: " + menorValor + " e sua posição é: " + pos);
        }
    }
}
