using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3
{
    public static class questao9
    {
        public static void rodar()
        {
            double precoCompra, precoVenda, lucro, totalCompra = 0, totalVenda = 0, totalLucro = 0;
            int numMercadorias = 0, numLucroMenor10 = 0, numLucroEntre10e20 = 0, numLucroMaior20 = 0;

            Console.WriteLine("Digite o preço de compra e o preço de venda de cada mercadoria:");
            do
            {
                Console.Write("Preço de compra: ");
                precoCompra = double.Parse(Console.ReadLine());
                if (precoCompra > 0)
                {
                    Console.Write("Preço de venda: ");
                    precoVenda = double.Parse(Console.ReadLine());

                    lucro = (precoVenda - precoCompra) / precoCompra * 100;

                    if (lucro < 10)
                    {
                        numLucroMenor10++;
                    }
                    else if (lucro <= 20)
                    {
                        numLucroEntre10e20++;
                    }
                    else
                    {
                        numLucroMaior20++;
                    }

                    totalCompra += precoCompra;
                    totalVenda += precoVenda;
                    totalLucro += precoVenda - precoCompra;

                    numMercadorias++;
                }
            } while (precoCompra > 0);

            Console.WriteLine("\nResultado:");
            Console.WriteLine("Número de mercadorias: {0}", numMercadorias);
            Console.WriteLine("Número de mercadorias com lucro menor que 10%: {0}", numLucroMenor10);
            Console.WriteLine("Número de mercadorias com lucro entre 10% e 20%: {0}", numLucroEntre10e20);
            Console.WriteLine("Número de mercadorias com lucro maior que 20%: {0}", numLucroMaior20);
            Console.WriteLine("Valor total de compra: {0:F2}", totalCompra);
            Console.WriteLine("Valor total de venda: {0:F2}", totalVenda);
            Console.WriteLine("Lucro total: {0:F2}", totalLucro);
        }
    }
}
