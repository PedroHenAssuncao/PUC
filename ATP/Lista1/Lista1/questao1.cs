using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1
{
    public static class questao1
    {
        public static void rodar()
        {
            double baseT = 0;
            double altura = 0;

            Console.WriteLine("Digite um valor para a base: ");
            baseT = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite um valor para a altura: ");
            altura = double.Parse(Console.ReadLine());

            Console.WriteLine("O perimetro do retangulo é: " + (baseT * 2 + altura * 2) );
            Console.WriteLine("A diagonal do retangulo é: " + Math.Sqrt(Math.Pow(baseT,2)+ Math.Pow(altura,2)));
            Console.WriteLine("A areea do retangulo é: " + baseT * altura);
        }
    }
}
