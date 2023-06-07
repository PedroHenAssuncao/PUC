using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista6
{
    public static class questao6
    {
        public static void rodar()
        {
            Console.WriteLine("Digite um número inteiro:");
            int numero = int.Parse(Console.ReadLine());

            int somaDivisores = CalcularDivisores(numero);

            Console.WriteLine("Divisores do número: ");
            ImprimirDivisores(numero);

            Console.WriteLine("Soma dos divisores: " + somaDivisores);

            SalvarSomaDivisoresEmArquivo(somaDivisores);
        }

        static int CalcularDivisores(int numero)
        {
            int soma = 0;
            for (int i = 1; i <= numero; i++)
            {
                if (numero % i == 0)
                {
                    soma += i;
                }
            }
            return soma;
        }

        static void ImprimirDivisores(int numero)
        {
            for (int i = 1; i <= numero; i++)
            {
                if (numero % i == 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        static void SalvarSomaDivisoresEmArquivo(int somaDivisores)
        {
            Console.WriteLine("Digite o caminho do arquivo de texto para salvar a soma dos divisores:");
            string caminhoArquivo = Console.ReadLine();

            try
            {
                using (StreamWriter sw = new StreamWriter(caminhoArquivo))
                {
                    sw.WriteLine("Soma dos divisores: " + somaDivisores);
                }

                Console.WriteLine("Soma dos divisores salva no arquivo com sucesso!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao salvar o arquivo: " + e.Message);
            }
        }
    }
}
