using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2
{
    public static class questao6
    {
        public static void rodar()
        {
            int numQuartos = 75;
            double descDiaria = 0.25;
            double valorDiaria = 0;
            double valorDdesc = 0;


            Console.WriteLine("Digite o valor da diaria: ");
            Console.Write("> ");

            var entrada = Console.ReadLine();

            valorDiaria = double.Parse(entrada);
            valorDdesc = valorDiaria * descDiaria;

            Console.WriteLine("Valor promocional: " + (valorDiaria - valorDdesc));
            Console.WriteLine("Valor promocional com 80% de ocupacao: " + (valorDiaria - valorDdesc) * (numQuartos * 0.8));
            Console.WriteLine("Valor total com 50% de ocupacao: " + valorDiaria * (numQuartos * 0.5));
            Console.WriteLine("Diferença entre os valores promocional e normal: " + ((valorDiaria - valorDdesc) * (numQuartos * 0.8) - valorDiaria * (numQuartos * 0.5)));
        }
    }
}
