using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista6
{
    public static class questao10
    {
        private static readonly string _caminho = "D:\\Temp\\numeros.txt";

        public static void rodar()
        {
            try
            {
                if (!File.Exists(_caminho))
                {
                    var stream = File.Create(_caminho);
                    stream.Close();

                }

                double valorMaximo = double.MinValue;
                double valorMinimo = double.MaxValue;
                double soma = 0;
                int quantidadeValores = 0;

                using (StreamReader sr = new StreamReader(_caminho))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        if (double.TryParse(linha, out double valor))
                        {
                            valorMaximo = Math.Max(valorMaximo, valor);
                            valorMinimo = Math.Min(valorMinimo, valor);
                            soma += valor;
                            quantidadeValores++;
                        }
                    }
                }

                if (quantidadeValores > 0)
                {
                    double media = soma / quantidadeValores;

                    Console.WriteLine("Valor máximo: " + valorMaximo);
                    Console.WriteLine("Valor mínimo: " + valorMinimo);
                    Console.WriteLine("Média: " + media);
                }
                else
                {
                    Console.WriteLine("O arquivo não contém números em ponto flutuante. Por favor preencha o arquivo: " + _caminho);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + e.Message);
            }
        }
    }
}
