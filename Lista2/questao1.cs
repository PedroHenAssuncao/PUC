using System;

namespace Lista2{

    public static class questao1{

        public static void rodar(){
            int num1;
            int num2;

            Console.WriteLine("digite o primeiro numero");

            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("digite o segundo numero");

            num2 = int.Parse(Console.ReadLine());

            if(num1 > num2){
                Console.WriteLine("O primeiro numero digitado é o maior");
            }
            else{
                Console.WriteLine("o segundo numero digitado é o maior");
            }
        }
    }
}