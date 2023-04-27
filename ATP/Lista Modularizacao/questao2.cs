using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lista_Modularizacao
{
    public static class questao2
    {
        public static void rodar(){
            MediaSalario();
        }

        public static void MediaSalario(){

            int cont = 0;
            float total = 0;
            
            try{
                while (true){
                    Console.WriteLine("Digite o salario (digite N para fechar):");
                    total += float.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o numero de filhos: ");
                    cont += int.Parse(Console.ReadLine());

                    cont++;
                }
            }
            catch(System.FormatException ex){
                Console.WriteLine("Media de salario da população: " + total/cont);
            }
            
        }
    }
}