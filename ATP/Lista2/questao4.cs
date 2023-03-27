using System;

namespace Lista2{

    public static class questao4{

        public static void rodar(){
            int anoN;
            int idade = 0;


            Console.WriteLine("Digite seu ano de nascimento: ");

            anoN = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Voce já fez aniversário esse ano (s/n): ");

            bool resposta = Console.ReadLine() == "s" ? true : false;

            idade = DateTime.Now.Year - anoN;

            if(resposta){

                Console.WriteLine(idade);

                if(idade >= 18){
                    Console.WriteLine("Parabens vc já tem idade para carteira de motorista");
                }
            }
            else{
                idade = idade - 1;

                Console.WriteLine(idade);

                if(idade >= 18){
                    Console.WriteLine("Parabens vc já tem idade para carteira de motorista");
                }
            }
        }
    }
}