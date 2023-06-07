using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista6
{
    public static class questao7
    {
        private static readonly string _caminho = "D:\\Temp\\letras.txt";

        public static void rodar()
        {
            try
            {
                if (!File.Exists(_caminho))
                {
                    var stream = File.Create(_caminho);
                    stream.Close();
                    
                }
                Console.WriteLine("Digite a quantidade de letras a serem inseridas:");
                int quantidadeLetras = int.Parse(Console.ReadLine());

                InserirLetrasEmArquivo(quantidadeLetras);

                int quantidadeVogais = ContarVogais();

                Console.WriteLine("Quantidade de vogais: " + quantidadeVogais);
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao escrever no arquivo: " + e.Message);
            }


        }

        static void InserirLetrasEmArquivo(int quantidadeLetras)
        {
            Console.WriteLine("Digite as letras a serem inseridas:");

            try
            {

                using (StreamWriter sw = new StreamWriter(_caminho))
                {
                    for (int i = 0; i < quantidadeLetras; i++)
                    {
                        char letra = char.Parse(Console.ReadLine());
                        sw.WriteLine(letra);
                    }
                }

                Console.WriteLine("Letras inseridas no arquivo com sucesso!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao escrever no arquivo: " + e.Message);
            }
        }

        static int ContarVogais()
        {
            int quantidadeVogais = 0;

            try
            {
                using (StreamReader sr = new StreamReader(_caminho))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        foreach (char caractere in linha)
                        {
                            if (IsVogal(caractere))
                            {
                                quantidadeVogais++;
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + e.Message);
            }

            return quantidadeVogais;
        }

        static bool IsVogal(char caractere)
        {
            char letra = char.ToLower(caractere);
            return letra == 'a' || letra == 'e' || letra == 'i' || letra == 'o' || letra == 'u';
        }
    }
}
