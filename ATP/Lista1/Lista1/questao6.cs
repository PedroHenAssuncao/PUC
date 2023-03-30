using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1
{
    public static class questao6
    {
        public static void rodar()
        {
            double A;
            double B;

            Console.WriteLine("Digite um valor para ser armazenado na variavel A: ");
            Console.Write("> ");
            A = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite um valor para ser armazenado na variavel B: ");
            Console.Write("> ");
            B = double.Parse(Console.ReadLine());

            double aux = A;
            A = B;
            B = aux;

            Console.WriteLine("Os valores das variaveis trocaram, A: " + A + " e B: " + B);
        }
    }
}
