using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista5
{
    public static class questao2
    {
        public static void rodar()
        {
            float[] notas = new float[10];

            PreencherNotas(notas);
            CalcularMediaEContarAcimaMedia(notas);
        }

        public static void PreencherNotas(float[] notas)
        {
            Console.WriteLine("Informe as notas dos alunos:");

            for (int i = 0; i < notas.Length; i++)
            {
                Console.Write($"Nota do aluno {i + 1}: ");
                float nota = float.Parse(Console.ReadLine());
                notas[i] = nota;
            }
        }

        public static void CalcularMediaEContarAcimaMedia(float[] notas)
        {
            float soma = 0;
            int countAcimaMedia = 0;

            foreach (float nota in notas)
            {
                soma += nota;
            }

            float media = soma / notas.Length;

            foreach (float nota in notas)
            {
                if (nota > media)
                {
                    countAcimaMedia++;
                }
            }

            Console.WriteLine($"Média da turma: {media}");
            Console.WriteLine($"Alunos com nota acima da média: {countAcimaMedia}");
        }
    }
}
