using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinalAtp
{
    public static class InteracaoUsuario
    {
        private static ControleVendas _controleVendas = new ControleVendas();

        public static void MenuUsuario()
        {
            bool sair = false;
            int opcao = 0;

            while (sair == false)
            {
                Console.WriteLine("============== MENU ==============");
                Console.WriteLine("1 – Importar arquivo de produtos");
                Console.WriteLine("2 – Registrar venda");
                Console.WriteLine("3 – Relatório de vendas");
                Console.WriteLine("4 – Relatório de estoque");
                Console.WriteLine("5 – Criar arquivo de vendas");
                Console.WriteLine("6 - Relatório de vendas totais");
                Console.WriteLine("7 - Sair");
                Console.WriteLine("==================================");
                Console.Write("Digite a opção desejada: ");

                try
                {
                    opcao = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("=========== IMPORTAR ARQUIVO DE PRODUTOS ===========");
                            Console.WriteLine();

                            _controleVendas.InicializaEstoque();

                            Console.WriteLine("Arquivo importado com sucesso!");
                            Console.WriteLine();
                            break;
                        case 2:
                            int numProd = 0;
                            int qtde = 0;
                            string nomeProduto = string.Empty;
                            string dia = string.Empty;

                            Console.WriteLine("=========== REGISTRAR VENDA ===========");
                            Console.WriteLine();

                            _controleVendas.ExibirProdutosEmEstoque();


                            Console.Write("Digite o número ou o nome do produto: ");
                            nomeProduto = Console.ReadLine();

                            Console.Write("Digite o dia do mês em que foi realizada a venda: ");
                            dia = Console.ReadLine();

                            Console.Write("Digite a quantidade vendida do produto: ");
                            qtde = int.Parse(Console.ReadLine());

                            if (int.TryParse(nomeProduto, out numProd))
                            {
                                _controleVendas.RegistrarCompra(numProd, qtde, dia);
                            }
                            else
                            {
                                _controleVendas.RegistrarCompra(nomeProduto, qtde, dia);
                            }

                            Console.WriteLine();
                            break;
                        case 3:
                            Console.WriteLine("==================== RELATORIO DE VENDAS ====================");
                            Console.WriteLine();

                            _controleVendas.ImprimirRelatorioVendas();

                            Console.WriteLine();
                            break;
                        case 4:
                            Console.WriteLine("=========== RELATÓRIO DE ESTOQUE ===========");
                            Console.WriteLine();

                            _controleVendas.RelatorioEstoque();

                            Console.WriteLine();
                            break;

                        case 5:
                            Console.WriteLine("=========== CRIAR ARQUIVO DE VENDAS ===========");
                            Console.WriteLine();

                            _controleVendas.GerarArquivoVendas();

                            Console.WriteLine("Arquivo gerado com sucesso");
                            break;

                        case 6:
                            Console.WriteLine("=========== RELATÓRIO VENDAS TOTAIS ===========");
                            Console.WriteLine();

                            _controleVendas.ImprimirRelatorioVendasTotal();

                            Console.WriteLine("Arquivo gerado com sucesso");
                            break;

                        case 7:
                            Console.WriteLine("============== ENCERRANDO ==============");
                            sair = true;
                            break;

                        default:
                            Console.WriteLine("Opção inválida. Tente novamente!");
                            Console.WriteLine();
                            break;
                    }
                }
                catch (System.FormatException ex)
                {
                    Console.WriteLine("Ops, parece que o que você digitou não é um número");
                }
            }
        }
    }
}
