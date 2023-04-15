using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3
{
    public static class questao6
    {
        public static void rodar()
        {
            Console.Write("Digite um número inteiro e positivo: ");
            int n = int.Parse(Console.ReadLine());

            double s = 0;
            for (int i = 1; i <= n; i++)
            {
                s += 1.0 / i;
                Console.Write("1/{0} + ", i);
            }

            Console.WriteLine("\n\nSoma final: {0}", s);
        }
    }
}
