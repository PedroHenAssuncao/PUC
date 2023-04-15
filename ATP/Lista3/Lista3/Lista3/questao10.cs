using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3
{
    public static class questao10
    {
        public static void rodar()
        {
            int candidato1 = 0, candidato2 = 0, candidato3 = 0, candidato4 = 0, nulos = 0, brancos = 0;
            int voto;

            Console.WriteLine("Digite o código do candidato (1 a 4) ou 5 para nulo ou 6 para branco. Digite 0 para finalizar:");

            do
            {
                voto = int.Parse(Console.ReadLine());

                switch (voto)
                {
                    case 1:
                        candidato1++;
                        break;
                    case 2:
                        candidato2++;
                        break;
                    case 3:
                        candidato3++;
                        break;
                    case 4:
                        candidato4++;
                        break;
                    case 5:
                        nulos++;
                        break;
                    case 6:
                        brancos++;
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Código inválido. Digite novamente:");
                        break;
                }
            } while (voto != 0);

            Console.WriteLine("Total de votos para o candidato 1: " + candidato1);
            Console.WriteLine("Total de votos para o candidato 2: " + candidato2);
            Console.WriteLine("Total de votos para o candidato 3: " + candidato3);
            Console.WriteLine("Total de votos para o candidato 4: " + candidato4);
            Console.WriteLine("Total de votos nulos: " + nulos);
            Console.WriteLine("Total de votos em branco: " + brancos);
        }
    }
}
