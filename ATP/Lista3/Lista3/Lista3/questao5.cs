using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3
{
    public static class questao5
    {
        public static void rodar()
        {
            double salario, somaSalario = 0, maiorSalario = double.MinValue;
            int numFilhos, somaFilhos = 0, numPessoas = 0, numPessoasAte100 = 0;

            Console.WriteLine("Digite o salário e o número de filhos de cada habitante (digite um salário negativo para encerrar):");

            while (true)// esse while faz com que a execução seja infinita
            {
                Console.Write("Salário: ");
                salario = double.Parse(Console.ReadLine());

                if (salario < 0)
                {
                    break;// utilizei o break para encerrar o looping
                }

                Console.Write("Número de filhos: ");
                numFilhos = int.Parse(Console.ReadLine());

                somaSalario += salario;
                somaFilhos += numFilhos;
                numPessoas++;

                if (salario > maiorSalario)
                {
                    maiorSalario = salario;
                }

                if (salario <= 100)
                {
                    numPessoasAte100++;
                }
            }

            double mediaSalario = somaSalario / numPessoas;
            double mediaFilhos = (double)somaFilhos / numPessoas;
            double percentualAte100 = (double)numPessoasAte100 / numPessoas * 100;

            // formatei as strings de modo a exibir apenas 2 casas decimais
            Console.WriteLine($"Média do salário: {mediaSalario.ToString("F2")}");
            Console.WriteLine($"Média do número de filhos: {mediaFilhos.ToString("F2")}");
            Console.WriteLine($"Maior salário: {maiorSalario.ToString("F2")}");
            Console.WriteLine($"Percentual de pessoas com salário até R$100,00: {percentualAte100.ToString("F2")}%");

        }
    }
}
