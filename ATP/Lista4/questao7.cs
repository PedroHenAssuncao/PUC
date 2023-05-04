using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lista_Modularizacao
{
    public class questao7
    {
        public static void rodar(){
            double x = 0;
            try{
                while (true)
                {
                    Console.WriteLine("Digite N a qualuqer momento para sair");
                    Console.WriteLine("Digite a media do aluno: ");
                    x = double.Parse(Console.ReadLine());
                    ExibeConceito(x);
                }
            }
            catch(System.FormatException ex){
                return;
            }
        }

        public static void ExibeConceito(double media) {
            string conceito;

            if (media < 0) {
                conceito = "Média inválida";
            } else if (media <= 39) {
                conceito = "F";
            } else if (media <= 59) {
                conceito = "E";
            } else if (media <= 69) {
                conceito = "D";
            } else if (media <= 79) {
                conceito = "C";
            } else if (media <= 89) {
                conceito = "B";
            } else {
                conceito = "A";
            }

            Console.WriteLine("Conceito: " + conceito);
        }
    }
}