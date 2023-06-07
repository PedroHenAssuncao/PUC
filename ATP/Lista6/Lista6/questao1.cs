using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista6
{
    public static class questao1
    {
        public static void rodar()
        {
            Console.WriteLine("Digite uma frase:");
            string frase = Console.ReadLine();

            int contadorEspacos = 0;
            foreach (char caractere in frase)
            {
                if (caractere == ' ')
                {
                    contadorEspacos++;
                }
            }

            Console.WriteLine("Número de espaços em branco na frase: " + contadorEspacos);
        }
    }
}
