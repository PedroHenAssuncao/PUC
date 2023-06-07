using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista6
{
    public static class questao9
    {
        private static readonly string _caminho = "D:\\Temp\\alunos.txt";

        public static void rodar()
        {
            try
            {
                if (!File.Exists(_caminho))
                {
                    var stream = File.Create(_caminho);
                    stream.Close();

                }

                Console.WriteLine("Bem-vindo ao sistema de cadastro de alunos!");

                bool continuar = true;

                while (continuar)
                {
                    Console.WriteLine();
                    Console.WriteLine("Escolha uma opção:");
                    Console.WriteLine("1. Inserir dados de alunos");
                    Console.WriteLine("2. Ler dados de alunos de um arquivo");
                    Console.WriteLine("3. Sair");

                    int opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            InserirDadosAlunos();
                            break;
                        case 2:
                            LerDadosAlunos();
                            break;
                        case 3:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        static void InserirDadosAlunos()
        {
            Console.WriteLine("Digite a quantidade de alunos:");
            int quantidadeAlunos = int.Parse(Console.ReadLine());

            List<Aluno> alunos = new List<Aluno>();

            for (int i = 0; i < quantidadeAlunos; i++)
            {
                Console.WriteLine("Digite a matrícula do aluno:");
                string matricula = Console.ReadLine();

                Console.WriteLine("Digite o telefone do aluno:");
                string telefone = Console.ReadLine();

                Aluno aluno = new Aluno(matricula, telefone);
                alunos.Add(aluno);
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(_caminho))
                {
                    foreach (Aluno aluno in alunos)
                    {
                        sw.WriteLine(aluno.Matricula + "," + aluno.Telefone);
                    }
                }

                Console.WriteLine("Dados dos alunos salvos no arquivo 'alunos.txt' com sucesso!");
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao salvar o arquivo: " + e.Message);
            }
        }

        static void LerDadosAlunos()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_caminho))
                {
                    Console.WriteLine("Dados dos alunos armazenados no arquivo:");
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(',');

                        if (dados.Length == 2)
                        {
                            string matricula = dados[0];
                            string telefone = dados[1];

                            Console.WriteLine("Matrícula: " + matricula + ", Telefone: " + telefone);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo: " + e.Message);
            }
        }
    }
}
