using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2
{
    public static class questao9
    {
        public static void rodar()
        {
            Console.WriteLine("Digite um símbolo: ");
            char simbolo = char.Parse(Console.ReadLine());

            switch (simbolo)
            {
                case '<':
                    Console.WriteLine("SINAL DE MENOR");
                    break;
                case '>':
                    Console.WriteLine("SINAL DE MAIOR");
                    break;
                case '=':
                    Console.WriteLine("SINAL DE IGUAL");
                    break;
                default:
                    Console.WriteLine("OUTRO SINAL");
                    break;
            }

            Console.ReadLine();
        }
    }
}
