using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lista_Modularizacao
{
    public class questao5
    {
        public static void rodar(){
            Console.WriteLine("Digite um valor: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite outro valor: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine(MDC(a,b));
        }

        public static int MDC(int a, int b) {
        // Se um dos números é zero, o MDC é o outro número
        if (a == 0) return b;
        if (b == 0) return a;

        // Aplica o algoritmo de Euclides
        while (b != 0) {
            int resto = a % b;
            a = b;
            b = resto;
        }

        return a;
    }
    }
}