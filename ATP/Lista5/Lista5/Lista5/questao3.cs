using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista5
{
    public static class questao3
    {
        public static void rodar()
        {
            int[] vetor = new int[10]; 

            PreencherVetorX(vetor);
            var vetorNegativos = CopiarValoresNegativos(vetor);
            ExibirVetor(vetorNegativos);
        }

        static void PreencherVetorX(int[] vetor)
        {
            Console.WriteLine("Informe os valores do vetor X:");

            for (int i = 0; i < vetor.Length; i++)
            {
                Console.WriteLine((i + 1) + ": ");
                int valor = int.Parse(Console.ReadLine());
                vetor[i] = valor;
            }
        }

        static int[] CopiarValoresNegativos(int[] vetor)
        {
            int countNegativos = 0;

            // Conta quantos valores negativos existem no vetor
            foreach (int valor in vetor)
            {
                if (valor < 0)
                {
                    countNegativos++;
                }
            }

            // Cria um novo vetor com o tamanho exato para armazenar os valores negativos
            int[] vetorNegativos = new int[countNegativos];

            // Copia os valores negativos para o novo vetor
            int index = 0;
            foreach (int valor in vetor)
            {
                if (valor < 0)
                {
                    vetorNegativos[index] = valor;
                    index++;
                }
            }

            return vetorNegativos;
        }

        static void ExibirVetor(int[] vetor)
        {
            Console.WriteLine("Conteúdo do vetor:");

            foreach (int valor in vetor)
            {
                Console.WriteLine(valor);
            }
        }
    }
}
