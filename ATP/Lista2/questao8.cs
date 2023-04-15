using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2
{
    public static class questao8
    {
        public static void rodar()
        {
            Console.WriteLine("Digite o salário atual do funcionário: ");
            double salario = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a opção desejada (A, B ou C): ");
            string opcao = Console.ReadLine();

            double novoSalario = 0;
            switch (opcao)
            {
                case "A":
                    novoSalario = salario * 1.08;
                    break;
                case "B":
                    novoSalario = salario * 1.11;
                    break;
                case "C":
                    if (salario <= 1000)
                    {
                        novoSalario = salario + 350;
                    }
                    else
                    {
                        novoSalario = salario + 200;
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    return;
            }

            Console.WriteLine($"O novo salário é {novoSalario:C2}");
            Console.ReadLine();
        }
    }
}
