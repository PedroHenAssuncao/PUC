﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinalAtp
{
    public class Estoque
    {
        private string _caminhoDados = string.Empty;

        private int Colunas
        {
            get
            {
                return EstoqueMatriz.GetLength(0);
            }
        }

        private int Linhas 
        { 
            get 
            {
                return EstoqueMatriz.GetLength(1);
            } 
        }

        public string[,] EstoqueMatriz { get; private set; } = new string[0,0];

        public string[] Produtos { get; private set; } = new string[0];

        public Estoque(string caminho) { 
        
            _caminhoDados = caminho;
            InicializaEstoque();
        }

        public void RecuperaDados()
        {
            try
            {
                var conteudo = string.Empty;

                using (StreamReader reader = new StreamReader(_caminhoDados))
                {
                    conteudo = reader.ReadToEnd();
                }

                var numColunas = conteudo.Split('\n').Count();

                EstoqueMatriz = new string[numColunas,Enum.GetValues(typeof(DadosProdutos)).Length];

                PreencheMatriz(conteudo);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void RealizaCompra(int id)
        {
            bool exists = false;

            for (int i = 0; i < Colunas; i++)
            {
                if (EstoqueMatriz[i, (int)DadosProdutos.Id] == id.ToString())
                {
                    var aux = EstoqueMatriz[i, (int)DadosProdutos.Quantidade];
                    EstoqueMatriz[i,(int)DadosProdutos.Quantidade] = (int.Parse(aux) - 1).ToString();
                    exists = true;
                }
            }

            if (exists == true)
            {
                AtualizaArquivo();
            }
        }

        public void RealizaCompra(string nomeProduto)
        {
            bool exists = false;

            for (int i = 0; i < Colunas; i++)
            {
                if (EstoqueMatriz[i, (int)DadosProdutos.Produto] == nomeProduto)
                {
                    var aux = EstoqueMatriz[i, (int)DadosProdutos.Quantidade];
                    EstoqueMatriz[i, (int)DadosProdutos.Quantidade] = (int.Parse(aux) - 1).ToString();
                    exists = true;
                }
            }

            if (exists == true)
            {
                AtualizaArquivo();
            }
        }

        private void InicializaEstoque()
        {
            if (!File.Exists(_caminhoDados))
            {
                var stream = File.Create(_caminhoDados);
                stream.Close();

                return;
            }

            RecuperaDados();

            AtualizaVetorProdutos();
        }

        private void AtualizaArquivo()
        {
            using (StreamWriter writer = new StreamWriter(_caminhoDados,false))
            {
                for (int i = 0; i < Colunas; i++)
                {
                    writer.WriteLine(string.Join(';', EstoqueMatriz.GetValue(i)));
                }
            }
        }

        private void PreencheMatriz(string conteudo)
        {
            var colunas = conteudo.Split('\n');

            for (int i = 0; i < colunas.Length; i++)
            {
                var linhas = colunas[i].Split(';');

                for (int j = 0; j < linhas.Length; j++)
                {
                    EstoqueMatriz[i, j] = linhas[j];
                }
            }
        }
    
        private void AtualizaVetorProdutos()
        {
            Produtos = new string[Colunas];

            for (int i = 0; i < Colunas; i++)
            {
                Produtos[i] = EstoqueMatriz[i, 0];
            }
        }
    }
}