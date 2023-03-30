using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1
{
    public static class questao3
    {
        public static void rodar()
        {
            double salario = 0;
            int kwGastos = 0;
            double valorKw = 0;
            double valorPagar = 0;

            Console.WriteLine("Digite o valor do salario minimo: ");
            Console.Write("> ");
            salario = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor gasto de kilawatts em 1 mes: ");
            Console.Write("> ");
            kwGastos = int.Parse(Console.ReadLine());

            valorKw = (salario / 7)/100;
            valorPagar = valorKw * kwGastos;

            Console.WriteLine("Cada Kilawatt vale: " + valorKw);
            Console.WriteLine("Valor dos kilawatts gatos desse mes: " + valorPagar);
            Console.WriteLine("Valor com desconto: " + (valorPagar - (valorPagar * 0.1)));
        }
    }
}
