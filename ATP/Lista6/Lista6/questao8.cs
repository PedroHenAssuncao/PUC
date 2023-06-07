using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista6
{
    public static class questao8
    {
        private static readonly string _caminho = "D:\\Temp\\resultado.txt";
        public static void rodar()
        {
            Console.WriteLine("Digite a quantidade de veículos da locadora:");
            int quantidadeVeiculos = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do aluguel por veículo:");
            double valorAluguel = double.Parse(Console.ReadLine());

            double faturamentoAnual = CalcularFaturamentoAnual(quantidadeVeiculos, valorAluguel);
            double valorMultasMensais = CalcularValorMultasMensais(quantidadeVeiculos, valorAluguel);
            double valorManutencaoAnual = CalcularValorManutencaoAnual(quantidadeVeiculos);

            Console.WriteLine("Faturamento anual: R$" + faturamentoAnual);
            Console.WriteLine("Valor das multas mensais: R$" + valorMultasMensais);
            Console.WriteLine("Valor da manutenção anual: R$" + valorManutencaoAnual);

            SalvarResultadosEmArquivo(faturamentoAnual, valorMultasMensais, valorManutencaoAnual);
        }

        static double CalcularFaturamentoAnual(int quantidadeVeiculos, double valorAluguel)
        {
            int quantidadeAlugueisMensais = quantidadeVeiculos / 3;
            double faturamentoMensal = quantidadeAlugueisMensais * valorAluguel;
            double faturamentoAnual = faturamentoMensal * 12;
            return faturamentoAnual;
        }

        static double CalcularValorMultasMensais(int quantidadeVeiculos, double valorAluguel)
        {
            int quantidadeAtrasosMensais = quantidadeVeiculos / 10;
            double valorMultasMensais = quantidadeAtrasosMensais * (valorAluguel * 0.2);
            return valorMultasMensais;
        }

        static double CalcularValorManutencaoAnual(int quantidadeVeiculos)
        {
            int quantidadeManutencoesAnuais = (int)(quantidadeVeiculos * 0.02);
            double valorManutencaoAnual = quantidadeManutencoesAnuais * 600;
            return valorManutencaoAnual;
        }

        static void SalvarResultadosEmArquivo(double faturamentoAnual, double valorMultasMensais, double valorManutencaoAnual)
        {
            try
            {
                if (!File.Exists(_caminho))
                {
                    var stream = File.Create(_caminho);
                    stream.Close();

                }
                using (StreamWriter sw = new StreamWriter(_caminho))
                {
                    sw.WriteLine("Faturamento anual: R$" + faturamentoAnual);
                    sw.WriteLine("Valor das multas mensais: R$" + valorMultasMensais);
                    sw.WriteLine("Valor da manutenção anual: R$" + valorManutencaoAnual);
                }

                Console.WriteLine("Resultados salvos no arquivo 'resultado.txt' com sucesso!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao salvar o arquivo: " + e.Message);
            }
        }
    }
}
