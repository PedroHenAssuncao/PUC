using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lista_Modularizacao
{
    public class questao9
    {
        public static void rodar() {
            Console.Write("Digite o número de alunos: ");
            int n = int.Parse(Console.ReadLine());
            double media = CalculaMediaAprovados(n);
            Console.WriteLine("Média das notas dos alunos aprovados: " + media);
        }

        public static double CalculaMediaAprovados(int n) {
            double somaNotas = 0;
            int numAprovados = 0;

            for (int i = 0; i < n; i++) {
                Console.Write("Digite a nota do aluno " + (i + 1) + ": ");
                double nota = double.Parse(Console.ReadLine());

                if (nota >= 6) {
                    somaNotas += nota;
                    numAprovados++;
                }
            }

            if (numAprovados == 0) {
                return 0;
            } else {
                return somaNotas / numAprovados;
            }
        }
        
    }
}