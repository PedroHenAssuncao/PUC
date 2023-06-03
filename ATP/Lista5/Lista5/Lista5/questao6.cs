using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista5
{
    public static class questao6
    {
        public static void rodar()
        {
            int[] temperaturas = new int[31];
            int maiorTemp = 0;
            int menorTemp = int.MaxValue;
            int somaTemperaturas = 0;
            float temperaturaMedia;
            int diasInferiorMedia = 0;

            // Leitura das temperaturas
            for (int i = 0; i < 31; i++)
            {
                Console.Write($"Digite a temperatura do dia {i + 1}: ");
                temperaturas[i] = int.Parse(Console.ReadLine());

                // Verifica a menor temperatura
                if (temperaturas[i] < menorTemp)
                {
                    menorTemp = temperaturas[i];
                }

                // Verifica a maior temperatura
                if (temperaturas[i] > maiorTemp)
                {
                    maiorTemp = temperaturas[i];
                }

                // Soma das temperaturas para o cálculo da média
                somaTemperaturas += temperaturas[i];
            }

            // Cálculo da média
            temperaturaMedia = (float)somaTemperaturas / 31;

            // Contagem dos dias com temperatura inferior à média
            foreach (int temperatura in temperaturas)
            {
                if (temperatura < temperaturaMedia)
                {
                    diasInferiorMedia++;
                }
            }

            // Impressão dos resultados
            Console.WriteLine($"Menor temperatura: {menorTemp}");
            Console.WriteLine($"Maior temperatura: {maiorTemp}");
            Console.WriteLine($"Temperatura média: {temperaturaMedia:F2}");
            Console.WriteLine($"Número de dias com temperatura inferior à média: {diasInferiorMedia}");
        }
    }
}
