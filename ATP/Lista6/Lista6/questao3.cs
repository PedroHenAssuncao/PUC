using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista6
{
    public static class questao3
    {
        public static void rodar()
        {
            Console.WriteLine("Digite uma string:");
            string texto = Console.ReadLine();

            string textoCodificado = CodificarCesar(texto, 3);

            Console.WriteLine("Nova string codificada: " + textoCodificado);
        }

        static string CodificarCesar(string texto, int deslocamento)
        {
            string textoCodificado = "";

            foreach (char caractere in texto)
            {
                if (char.IsLetter(caractere))
                {
                    char letraInicial = char.IsUpper(caractere) ? 'A' : 'a';
                    char letraCodificada = (char)(((caractere - letraInicial + deslocamento) % 26) + letraInicial);
                    textoCodificado += letraCodificada;
                }
                else
                {
                    textoCodificado += caractere;
                }
            }

            return textoCodificado;
        }
    }
}
