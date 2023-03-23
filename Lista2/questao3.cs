using System;

namespace Lista2{

    public static class questao3{

        public static void rodar(){
            int a;
            int b;

            Console.WriteLine("digite o valor de a:");

            a = int.Parse(Console.ReadLine());

            Console.WriteLine("digite o valor de b:");

            b = int.Parse(Console.ReadLine());

            Console.WriteLine("x = " + -b/a );
        }
    }
}