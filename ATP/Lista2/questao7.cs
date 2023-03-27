using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2
{
    public static class questao7
    {
        public static void rodar()
        {
            double x = 0;

            Console.WriteLine("Digite um valor de X: ");
            Console.Write("> ");
            var entrada = Console.ReadLine();

            x = double.Parse(entrada);

            if (x <= 1)
            {
                Console.WriteLine(1);
            }
            else if (x > 1 && x <= 2)
            {
                Console.WriteLine(2);
            }
            else if (x > 2 && x <= 3)
            {
                Console.WriteLine(Math.Pow(x, 2));
            }
            else
            {
                Console.WriteLine(Math.Pow(x, 3));
            }
        }
    }
}
