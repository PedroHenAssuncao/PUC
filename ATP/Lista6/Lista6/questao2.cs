using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista6
{
    public static class questao2
    {
        public static void rodar()
        {
            Console.WriteLine("Digite uma frase:");
            string frase = Console.ReadLine();

            string fraseSemVogais = RemoverVogais(frase);

            Console.WriteLine("Frase sem vogais: " + fraseSemVogais);
        }

        static string RemoverVogais(string texto)
        {
            string vogais = "aeiouAEIOU";
            string textoSemVogais = "";

            foreach (char caractere in texto)
            {
                if (!vogais.Contains(caractere))
                {
                    textoSemVogais += caractere;
                }
            }

            return textoSemVogais;
        }
    }
}
