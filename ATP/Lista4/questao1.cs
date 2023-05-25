using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lista_Modularizacao
{
    public static class questao1
    {

        public static void rodar(){

            string entrada = string.Empty;
            Console.WriteLine("Digite o numero de alunos");
            int numAlun = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < numAlun; i++)
            {
                Console.WriteLine("Digite as 3 nota do aluno {0}: ",i+1);
                int n1 = int.Parse(Console.ReadLine()); 
                int n2 = int.Parse(Console.ReadLine());
                int n3 = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o que deseja fazer (A/P): ");
                char chave = char.Parse(Console.ReadLine());
                CalculaMedia(chave,n1,n2,n3);
            }
        }

        public static void CalculaMedia(char chave, float n1, float n2, float n3){
            
            float media = 0;
            
            if(chave == 'a'){
                media = (n1+n2+n3)/3;
            }
            else{
                media = (n1*5+n2*3+n3*2)/3;
            }

            Console.WriteLine("A média do aluno é: " + media);
        }
    }
}