using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista5
{
    public static class questao5
    {
        static int[] SortearNumeros()
        {
            Random random = new Random();
            int[] numerosSorteados = new int[3];

            for (int i = 0; i < 3; i++)
            {
                numerosSorteados[i] = random.Next(10, 50);
            }

            return numerosSorteados;
        }

        static void FazerTentativas(int[] numerosSorteados)
        {
            Console.WriteLine("Tente adivinhar um dos números sorteados (entre 10 e 50).");

            while (true)
            {
                Console.Write("Digite um número: ");
                int tentativa = int.Parse(Console.ReadLine());

                if (Array.IndexOf(numerosSorteados, tentativa) != -1)
                {
                    Console.WriteLine("Parabéns! Você acertou um dos números sorteados.");
                    break;
                }
                else
                {
                    Console.WriteLine("Tente novamente.");
                }
            }
        }

        public static void rodar()
        {
            int[] numerosSorteados = SortearNumeros();
            FazerTentativas(numerosSorteados);

            Console.ReadLine();
        }
    }
}
