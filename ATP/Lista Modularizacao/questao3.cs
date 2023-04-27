using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lista_Modularizacao
{
    public static class questao3
    {

        public static void rodar(){

            Console.WriteLine("Ddigite squantos conjuntos serao digitao: ");
            int conjunto = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite quantos numeros serao digitados por conjunto: ");
            int num = int.Parse(Console.ReadLine());

            List<int> numeros = new List<int>();

            for (int i = 0; i < conjunto; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.WriteLine("digite um numero: ");
                    numeros.Add(int.Parse(Console.ReadLine()));
                }

                Console.WriteLine();
                ImprimeCrescente(numeros);
                numeros.Clear();
            }
        }

        public static void ImprimeCrescente(List<int> nums){

            foreach (var item in nums.OrderBy(x => x))
            {
                Console.WriteLine(item);
            }

        }
    }
}