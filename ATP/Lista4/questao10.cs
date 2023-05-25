using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lista_Modularizacao
{
    public class questao10
    {
        public static void rodar() {
            Console.Write("Digite a idade do nadador: ");
            int idade = int.Parse(Console.ReadLine());
            char categoria = RetornaCategoriaNadador(idade);
            Console.WriteLine("Categoria do nadador: " + categoria);
        }

        public static char RetornaCategoriaNadador(int idade) {
            if (idade >= 5 && idade <= 7) {
                return 'F';
            } else if (idade >= 8 && idade <= 10) {
                return 'E';
            } else if (idade >= 11 && idade <= 13) {
                return 'D';
            } else if (idade >= 14 && idade <= 15) {
                return 'C';
            } else if (idade >= 16 && idade <= 17) {
                return 'B';
            } else {
                return 'A';
            }
        }

    }
}