using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3
{
    public static class questao1
    {
        public static void rodar()
        {
            Console.WriteLine("Digite uma sequência de valores inteiros separados por espaço: ");
            string[] valores = Console.ReadLine().Split(' ');
            /**
             * Para ler os valores em uma linha optei por dividir os valores usando " " e a partir disso gero uma string
             * */

            int positivos = 0;
            int negativos = 0;
            int zeros = 0;

            foreach (string valor in valores)// utilizei foreach para realizar o loop
            {
                int numero = int.Parse(valor);

                if (numero > 0)
                {
                    positivos++;
                }
                else if (numero < 0)
                {
                    negativos++;
                }
                else
                {
                    zeros++;
                }
            }

            Console.WriteLine($"Números positivos: {positivos}");
            Console.WriteLine($"Números negativos: {negativos}");
            Console.WriteLine($"Zeros: {zeros}");
        }
    }
}
