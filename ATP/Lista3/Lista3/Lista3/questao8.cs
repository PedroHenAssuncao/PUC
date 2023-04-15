using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3
{
    public static class questao8
    {
        public static void rodar()
        {
            Console.Write("Digite o valor de L: ");
            int L = int.Parse(Console.ReadLine());

            int a = 0, b = 1, c = 0;

            while (a < L)
            {
                Console.Write(a + " ");
                c = a + b;
                a = b;
                b = c;
            }
        }
    }
}
