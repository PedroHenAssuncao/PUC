using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinalAtp
{
    public class ControleVendas
    {
        private int Colunas
        {
            get
            {
                return VendasMatriz.GetLength(0);
            }
        }

        private int Linhas
        {
            get
            {
                return VendasMatriz.GetLength(1);
            }
        }

        private Estoque _estoque;

        public string[,] VendasMatriz { get; private set; } = new string[0, 0];

        public string[,] VendasTotal { get; private set; } = new string[0, 0];

        public ControleVendas(string caminho)
        {
            _estoque = new Estoque(caminho);
            InicializaControleVendas();
        }

        private void InicializaControleVendas()
        {
            VendasTotal = new string[_estoque.Colunas, 3];
            VendasMatriz = new string[1, _estoque.Colunas + 1];

            VendasMatriz[0, 0] = "Dia";

            for (int i = 0; i < _estoque.Colunas; i++)
            {
                var produto = _estoque.Produtos[i].Split(';');

                VendasTotal[i, ((int)DadosProdutos.Id)] = produto[0];
                VendasTotal[i, ((int)DadosProdutos.Produto)] = produto[1];
                VendasTotal[i, ((int)DadosProdutos.Quantidade)] = "0";

                VendasMatriz[0,i + 1] = produto[1];
            }

            
        }

        public void RealizaCompra(int id, int qtde, int dia)
        {
            if (_estoque.VendaValida(id,qtde))
            {
                int numProd = 0;

                for (int i = 0; i < _estoque.Colunas; i++)
                {
                    if (VendasTotal[i, (int)DadosProdutos.Id] == id.ToString())
                    {
                        VendasTotal[i, (int)DadosProdutos.Quantidade] = (int.Parse(VendasTotal[i, (int)DadosProdutos.Quantidade]) + qtde).ToString();
                        numProd = i;
                    } 
                }

                CadastraNovaVenda(numProd, dia.ToString(), qtde);

                _estoque.RealizaCompra(id,qtde);
            }
        }

        public void RealizaCompra(string nomeProduto, int qtde, int dia)
        {
            if (_estoque.VendaValida(nomeProduto, qtde))
            {
                int numProd = 0;
                for (int i = 0; i < _estoque.Colunas; i++)
                {
                    if (VendasTotal[i, (int)DadosProdutos.Produto].ToLower() == nomeProduto.ToLower())
                    {
                        VendasTotal[i, (int)DadosProdutos.Quantidade] = (int.Parse(VendasTotal[i, (int)DadosProdutos.Quantidade]) + qtde).ToString();
                        numProd = i;
                    }
                }

                CadastraNovaVenda(numProd, dia.ToString(), qtde);

                _estoque.RealizaCompra(nomeProduto, qtde);
            }
        }
    
        public void ExibeEstoque()
        {
            Console.WriteLine("\n");

            string texto = string.Empty;
            texto = texto.PadRight(49, '_');

            Console.WriteLine("\t{0}",texto);
            Console.WriteLine("\t|{0,15}|{1,15}|{2,15}|",DadosProdutos.Id.ToString(),DadosProdutos.Produto.ToString(),DadosProdutos.Quantidade.ToString());

            for (int i = 0; i < _estoque.Colunas; i++)
            {
                Console.WriteLine("\t|{0,15}|{1,15}|{2,15}|",
                    _estoque.EstoqueMatriz[i, (int)DadosProdutos.Id],
                    _estoque.EstoqueMatriz[i, (int)DadosProdutos.Produto],
                    _estoque.EstoqueMatriz[i, (int)DadosProdutos.Quantidade]);
            }
        }

        public void ExibeVendas()
        {
            Console.WriteLine("\n");

            string texto = string.Empty;
            texto = texto.PadRight(56, '_');

            Console.WriteLine("\t{0}", texto);
            Console.WriteLine("\t|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|",
                "Dia",
                _estoque.Produtos[0],
                _estoque.Produtos[1],
                _estoque.Produtos[2],
                _estoque.Produtos[3]
                );

            for (int i = 0; i < Colunas; i++)
            {
                Console.WriteLine("\t|{0,10}|{1,10}|{2,10}|{3,10}|{4,10}|",
                    VendasMatriz[i, 0],
                    VendasMatriz[i, 1],
                    VendasMatriz[i, 2],
                    VendasMatriz[i, 3],
                    VendasMatriz[i, 4]
                    );
            }
        }

        public void GeraArquivoTotalVendas(string caminho)
        {
            if (Path.GetExtension(caminho).Contains("csv"))
            {
                using (StreamWriter writer = new StreamWriter(caminho, false))
                {
                    writer.WriteLine(DadosProdutos.Id.ToString() + ";" + DadosProdutos.Produto.ToString() + ";" + DadosProdutos.Quantidade.ToString());
                    for (int i = 0; i < Colunas; i++)
                    {
                        writer.WriteLine(string.Join(';', VendasTotal.GetValue(i)));
                    }
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                string texto = string.Empty;
                texto = texto.PadRight(49, '_');

                sb.AppendLine(texto);
                sb.AppendLine(string.Format("|{0,15}|{1,15}|{2,15}|", DadosProdutos.Id.ToString(), DadosProdutos.Produto.ToString(), DadosProdutos.Quantidade.ToString()));

                for (int i = 0; i < _estoque.Colunas; i++)
                {
                    sb.AppendLine(string.Format("|{ 0,15}|{ 1,15}|{ 2,15}| ",
                                    VendasTotal[i, (int)DadosProdutos.Id],
                                    VendasTotal[i, (int)DadosProdutos.Produto],
                                    VendasTotal[i, (int)DadosProdutos.Quantidade]));
                }
            }
            
        }

        private void CadastraNovaVenda(int numProduto, string dia, int qtde)
        {
            bool diaJaCadastrado = false;

            for (int i = 0; i < Colunas; i++)
            {
                if (VendasMatriz[i, 0] == dia)
                {
                    var aux = VendasMatriz[i, numProduto + 1];

                    VendasMatriz[i, numProduto + 1] = string.IsNullOrEmpty(aux) ? qtde.ToString() : (int.Parse(aux) + qtde).ToString();
                    diaJaCadastrado = true;
                }
            }

            if (diaJaCadastrado == false)
            {
                string[,] novaMatriz = new string[Colunas + 1, Linhas];

                PreencheMatriz(novaMatriz);

                for (int i = 0; i < _estoque.Colunas; i++)
                {
                    novaMatriz[Colunas + 1, i + 1] = "";
                }

                novaMatriz[Colunas + 1, 0] = dia;
                novaMatriz[Colunas + 1, numProduto + 1] = qtde.ToString();

                VendasMatriz = novaMatriz;
            }
        }

        private void PreencheMatriz(string[,] matrizPreencher)
        {
            for (int i = 0; i < Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {
                    matrizPreencher[i, j] = VendasMatriz[i, j];
                }
            }
        }
    }
}
