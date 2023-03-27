using System;

namespace Lista2{

    public static class questao2{

        public static void rodar(){
            int num1;
            int num2;
            int soma = 0;

            Console.WriteLine("digite o primeiro numero");

            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("digite o segundo numero");

            num2 = int.Parse(Console.ReadLine());

            soma = num1 + num2;

            if(soma >= 10){
                Console.WriteLine(soma + 5);
            }
            else{
                Console.WriteLine(soma + 7);
            }
        }
    }
}