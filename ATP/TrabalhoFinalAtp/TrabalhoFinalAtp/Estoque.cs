﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinalAtp
{
    public class Estoque
    {
        private string _caminho = "D:\\Desenvolvimento\\Puc\\ATP\\TrabalhoFinalAtp\\TrabalhoFinalAtp\\ArquivosEstoqueEVendas\\Estoque.csv";

        public string[] Produtos { get; private set; } = Array.Empty<string>();
        public int[] Quantidade { get; private set; } = Array.Empty<int>();

        public bool InicializaEstoque()
        {
            try
            {
                string estoque = string.Empty;
                int i = 0;

                using (var stream = new StreamReader(_caminho))
                {
                    estoque = stream.ReadToEnd().Replace("\r", "");
                }

                var aux = estoque.Split('\n');

                Produtos = new string[aux.Length - 1];
                Quantidade = new int[aux.Length - 1];

                foreach (var linha in aux)
                {
                    if (linha != null)
                    {
                        var produto = linha.Split(';');
                        int qtde = 0;

                        if (int.TryParse(produto[1], out qtde))
                        {
                            Produtos[i] = produto[0];
                            Quantidade[i] = qtde;

                            i++;
                        }
                    }
                }

                return true;
            }
            catch(System.IO.FileNotFoundException ex) {
                Console.WriteLine("Arquivo de Estoque não Existe!!");
                Console.WriteLine("Por favor crie e tente novamente!!");

                return false;
            }
        }

        public bool VendaPermitida(string produto, int qtde)
        {
            if (Produtos != Array.Empty<string>() && Quantidade != Array.Empty<int>())
            {
                int index = Array.IndexOf(Produtos, produto);

                if (index == -1)
                {
                    return false;
                }
                else
                {
                    return Quantidade[index] - qtde > 0 ? true : false;
                }
            }
            else
            {
                return false;
            }
        }
    
        public bool EfetivaCompra(string produto, int qtde)
        {
            int index = Array.IndexOf(Produtos, produto);

            if (index == -1)
            {
                return false;
            }
            else
            {
                Quantidade[index] -= qtde;

                //SalvarEstoque();

                return true;
            }
        }
    
        public void SalvarEstoque()
        {
            var estoque = new StringBuilder();

            estoque.AppendLine("Produtos;Quantidade");

            for (int i = 0; i < Produtos.Length; i++)
            {
                if (i == Produtos.Length - 1)
                {
                    estoque.Append(Produtos[i] + ";" + Quantidade[i]);
                }
                else
                {
                    estoque.AppendLine(Produtos[i] + ";" + Quantidade[i]);
                }
               
            }

            using (var stream = new StreamWriter(_caminho, false, Encoding.UTF8))
            {
                stream.Write(estoque.ToString());
            }
            
        }

        public void ImprimirEstoque()
        {
            string texto = string.Empty;
            texto = texto.PadRight(24, '_');
            Console.WriteLine(texto);
            Console.WriteLine(string.Format("|{0,-10}| {1,10}|", "Produtos", "Quantidade") + "\t");
            for (int i = 0; i < Produtos.Length; i++)
            {
                Console.WriteLine(string.Format("|{0,-10}| {1,-10}|", Produtos[i], Quantidade[i]) + "\t");
            }
            
        }
    }
}
