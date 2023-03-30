using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1
{
    public static class questao2
    {
        public static void rodar()
        {
            double cateto1 = 0;
            double cateto2 = 0;

            Console.WriteLine("Digite um valor para o cateto 1: ");
            cateto1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite um valor para cateto 2: ");
            cateto2 = double.Parse(Console.ReadLine());

            Console.WriteLine("A hipotenusa é: " + Math.Sqrt(Math.Pow(cateto1, 2) + Math.Pow(cateto2, 2)));
        }
    }
}
