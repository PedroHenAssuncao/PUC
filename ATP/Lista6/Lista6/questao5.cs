using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista6
{
    public static class questao5
    {
        public static void rodar()
        {
            Console.WriteLine("Digite o caminho do arquivo de texto:");
            string caminhoArquivo = Console.ReadLine();

            LerArquivoTexto(caminhoArquivo);
        }

        static void LerArquivoTexto(string caminhoArquivo)
        {
            try
            {
                using (StreamReader sr = new StreamReader(caminhoArquivo))
                {
                    int contadorLinhas = 0;
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(linha);
                        contadorLinhas++;
                    }

                    Console.WriteLine("Quantidade de linhas: " + contadorLinhas);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + e.Message);
            }
        }

    }
}
