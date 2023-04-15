using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3
{
    public static class questao3
    {
        public static void rodar()
        {
            int div3e9 = 0;
            int div2e5 = 0;

            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"Digite o {i}º número: ");
                int numero = int.Parse(Console.ReadLine());

                if (numero % 3 == 0 && numero % 9 == 0)
                {
                    Console.WriteLine($"{numero} é divisível por 3 e por 9");
                    div3e9++;
                }
                else if (numero % 2 == 0 && numero % 5 == 0)
                {
                    Console.WriteLine($"{numero} é divisível por 2 e por 5");
                    div2e5++;
                }
                else
                {
                    Console.WriteLine($"{numero} não é divisível pelos valores");
                }
            }

            Console.WriteLine($"Quantidade de números divisíveis por 3 e 9: {div3e9}");
            Console.WriteLine($"Quantidade de números divisíveis por 2 e 5: {div2e5}");

        }
    }
}
