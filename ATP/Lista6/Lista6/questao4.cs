using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista6
{
    public static class questao4
    {
        public static void rodar()
        {
            Console.WriteLine("Digite o caminho do arquivo de texto:");
            string caminhoArquivo = Console.ReadLine();

            int quantidadeCaracteresA = ContarCaracteresA(caminhoArquivo);

            Console.WriteLine("Quantidade de caracteres 'a': " + quantidadeCaracteresA);
        }

        static int ContarCaracteresA(string caminhoArquivo)
        {
            int quantidade = 0;

            try
            {
                using (StreamReader sr = new StreamReader(caminhoArquivo))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        quantidade += ContarCaracteresAEmLinha(linha);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + e.Message);
            }

            return quantidade;
        }

        static int ContarCaracteresAEmLinha(string linha)
        {
            int quantidade = 0;
            foreach (char caractere in linha)
            {
                if (char.ToLower(caractere) == 'a')
                {
                    quantidade++;
                }
            }
            return quantidade;
        }
    }
}
