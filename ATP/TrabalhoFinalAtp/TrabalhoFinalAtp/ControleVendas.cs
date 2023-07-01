using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinalAtp
{
    public class ControleVendas
    {
        private readonly string _caminho = "RelatorioVendas.csv";

        private Estoque? _estoque = null;

        private string[,] _relatorioVendas = { };

        private string[,] _relatorioTotalVendas = { };

        public void InicializaEstoque()
        {
            _estoque = new Estoque();

            _estoque.InicializaEstoque();

            _relatorioTotalVendas = new string[_estoque.Produtos.Length, _estoque.Produtos.Length];

            for (int i = 0; i < _relatorioTotalVendas.GetLength(0); i++)
            {
                _relatorioTotalVendas[i, 0] = _estoque.Produtos[i];
                _relatorioTotalVendas[i, 1] = "0";
            }

            _relatorioVendas = new string[1, 3];

            _relatorioVendas[0, 0] = "Dia";
            _relatorioVendas[0, 1] = "Produto";
            _relatorioVendas[0, 2] = "Quantidade";
        }

        public bool RegistrarCompra(string produto, int qtde, string dia)
        {
            if (_estoque != null)
            {
                if (Array.IndexOf(_estoque.Produtos, produto) == -1)
                {
                    Console.WriteLine("O produto não Existe!!");
                    return false;
                }
                else if (!_estoque.VendaPermitida(produto, qtde))
                {
                    Console.WriteLine("Quantidade desejada excede o Estoque!!");
                    return false;
                }
                else
                {
                    if (VendaMesmoDiaEProduto(produto, dia))
                    {
                        RealizaVendaDiaEProdutoExiste(produto, dia, qtde);
                    }
                    else
                    {
                        RealizaVenda(produto, dia, qtde);
                    }

                    AtualizaRelatorioTotalVendas(produto, qtde);

                    _estoque.EfetivaCompra(produto, qtde);

                    return true;
                }
            }
            else
            {
                Console.WriteLine("Estoque ainda não Inicializado");

                return false;
            }
        }

        public bool RegistrarCompra(int produto, int qtde, string dia)
        {
            if (_estoque != null)
            {
                if (produto > _estoque.Produtos.Length)
                {
                    Console.WriteLine("O número do produto não existe!!!");

                    return false;
                }

                return RegistrarCompra(_estoque.Produtos[produto], qtde, dia);
            }
             else
            {
                Console.WriteLine("Estoque ainda não Inicializado");

                return false;
            }
        }

        public void RelatorioEstoque()
        {
            if (_estoque != null)
            {
                _estoque.ImprimirEstoque();
            }
            else
            {
                Console.WriteLine("O Estoque ainda não foi inicializado!!!");
            }
        }

        public void GerarArquivoVendas()
        {
            if (_estoque != null)
            {
                var relatorio = new StringBuilder();

                for (int i = 0; i < _relatorioVendas.GetLength(0); i++)
                {
                    relatorio.AppendLine(_relatorioVendas[i,0] + ";" + _relatorioVendas[i, 1] + ";" + _relatorioVendas[i, 2]);
                }

                using (var stream = new StreamWriter(_caminho,false,Encoding.UTF8))
                {
                    stream.Write(relatorio.ToString());
                }
            }
            else
            {
                Console.WriteLine("O Estoque ainda não foi inicializado!!!");
            }
        }

        public void ImprimirRelatorioVendas()
        {
            if (_estoque != null)
            {
                string texto = string.Empty;
                texto = texto.PadRight(32, '_');
                Console.WriteLine(texto);
                Console.WriteLine(string.Format("|{0,-10}{1,-10}{2,-10}|", "Dia", "Produto", "Quantidade") + "\t");
                for (int i = 0; i < _relatorioVendas.GetLength(0); i++)
                {
                    Console.Write(string.Format("|{0,-10}{1,-10}{2,-10}|", _relatorioVendas[i, 0], _relatorioVendas[i, 1], _relatorioVendas[i, 2]) + "\t");
                }
            }
            else
            {
                Console.WriteLine("O Estoque ainda não foi inicializado!!!");
            }
        }

        public void ImprimirRelatorioVendasTotal()
        {
            if (_estoque != null)
            {
                string texto = string.Empty;
                texto = texto.PadRight(22, '_');
                Console.WriteLine(texto);
                Console.WriteLine(string.Format("|{0,-10}{1,-10}|", "Produto", "Quantidade") + "\t");

                for (int i = 0; i < _relatorioTotalVendas.GetLength(0); i++)
                {
                    Console.Write(string.Format("|{0,-10}{1,-10}|", _relatorioTotalVendas[i, 0], _relatorioTotalVendas[i, 1]) + "\t");
                }
            }
            else
            {
                Console.WriteLine("O Estoque ainda não foi inicializado!!!");
            }
        }

        public void ExibirProdutosEmEstoque()
        {
            if (_estoque != null)
            {
                string texto = string.Empty;
                texto = texto.PadRight(22, '_');
                Console.WriteLine(texto);
                Console.WriteLine(string.Format("|{0,-10}{1,-10}|", "Produto", "Quantidade") + "\t");

                for (int i = 0; i < _estoque.Produtos.Length; i++)
                {
                    Console.Write(string.Format("|{0,-10}{1,-10}{2,-10}|", i+1,_relatorioTotalVendas[i, 0], _relatorioTotalVendas[i, 1]) + "\t");
                }
            }
            else
            {
                Console.WriteLine("O Estoque ainda não foi inicializado!!!");
            }
        }

        private bool VendaMesmoDiaEProduto(string produto, string dia)
        {
            for (int i = 0; i < _relatorioVendas.GetLength(0); i++)
            {
                if (_relatorioVendas[i, 0] == dia && _relatorioVendas[i, 1] == produto)
                {
                    return true;
                }
            }

            return false;
        }

        private void RealizaVendaDiaEProdutoExiste(string produto, string dia, int qtde)
        {
            for (int i = 0; i < _relatorioVendas.GetLength(0); i++)
            {
                if (_relatorioVendas[i, 0] == dia && _relatorioVendas[i, 1] == produto)
                {
                    _relatorioVendas[i, 2] = (int.Parse(_relatorioVendas[i, 2]) + qtde).ToString();
                }
            }
        }
    
        private void RealizaVenda(string produto, string dia, int qtde)
        {
            var aux = new string[_relatorioVendas.GetLength(0) + 1, 3];

            CopiaMatriz(_relatorioVendas, aux);

            aux[aux.Length - 1,0] = dia;
            aux[aux.Length - 1,1] = produto;
            aux[aux.Length - 1,2] = qtde.ToString();

            _relatorioVendas = aux;
        }

        private void AtualizaRelatorioTotalVendas(string produto, int qtde)
        {
            for (int i = 0; i < _relatorioTotalVendas.Length; i++)
            {
                if (_relatorioTotalVendas[i,0] == produto)
                {
                    _relatorioTotalVendas[i, 1] = (int.Parse(_relatorioTotalVendas[i, 1]) + qtde).ToString();
                }
            }
        }

        private void CopiaMatriz(string[,] matOrigem, string[,] matDestino)
        {
            for (int i = 0; i < matOrigem.GetLength(0); i++)
            {
                for (int j = 0; j < matOrigem.GetLength(1); j++)
                {
                    matDestino[i, j] = matOrigem[i, j];
                }
            }
        }
    }
}
