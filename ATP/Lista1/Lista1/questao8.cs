using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista1
{
    public static class questao8
    {
        public static void rodar()
        {
            // Solicita o número da conta corrente ao usuário
            Console.Write("Digite o número da conta corrente (3 dígitos): ");
            int contaCorrente = int.Parse(Console.ReadLine());
            int somaInversa = 0;
            int somaComPeso = 0;
            char[] aux;
            int inverso = 0;
            // Calcula o dígito verificador
            inverso = int.Parse(string.Format("{0}{1}{2}", contaCorrente.ToString().ElementAt(2), contaCorrente.ToString().ElementAt(1), contaCorrente.ToString().ElementAt(0)));
            somaInversa = contaCorrente + inverso;
            aux = somaInversa.ToString().ToArray();
            somaComPeso = (int.Parse(aux.ElementAt(0).ToString()) * 100) + int.Parse(aux.ElementAt(1).ToString()) * 10 + int.Parse(aux.ElementAt(2).ToString());
            int digitoVerificador = int.Parse(somaComPeso.ToString().Last().ToString());

            // Imprime o resultado na tela
            Console.WriteLine("O dígito verificador da conta corrente é: " + digitoVerificador);
        }
    }
}
