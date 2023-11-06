using System;

internal class Program
{
    private static void Main(string[] args)
    {
        char[] ordemCartas = new char[]{
            '4',
            '5',
            '6',
            '7',
            'Q',
            'J',
            'K',
            'A',
            '2',
            '3'
        };

        char[] ordemNaips = new char[]{
            'D',
            'S',
            'H',
            'C'
        };

        string[] entrada = Console.ReadLine().Split(' ');
        int numRodadas = int.Parse(entrada[0]);
        string manilha = entrada[1];
        char numManilha = manilha[0];
        int indexManilha = BuscaManilha(numManilha,ordemCartas);

        Jogador[] jogadores = new Jogador[4];

        jogadores[0] = new Jogador(Console.ReadLine());
        jogadores[1] = new Jogador(Console.ReadLine());
        jogadores[2] = new Jogador(Console.ReadLine());
        jogadores[3] = new Jogador(Console.ReadLine());

        for (int i = 0; i < numRodadas; i++)
        {
            string[] jogadas = Console.ReadLine().Split(' ');

            int indexVencedor = DecideRodada(jogadas, indexManilha, ordemCartas, ordemNaips);

            if (indexVencedor != -1)
            {
                jogadores[indexVencedor].rodadasVencidas++;
            }
        }

        Console.WriteLine(DefineVencedor(jogadores));

    }

    public static int BuscaManilha(char entrada, char[] ordemCartas)
    {
        int indexEntrada = Array.IndexOf(ordemCartas, entrada);

        if (indexEntrada == ordemCartas.Length - 1)
        {
            return 0;
        }

        return indexEntrada + 1;
    }

    public static int DecideRodada(string[] jogadas, int indexManilha, char[] cartas, char[] naips)
    {
        int indexVencedor = 0;

        string maiorJogada = jogadas[0];

        for (int i = 0; i < jogadas.Length; i++)
        {
            if (i == 0)
            {
                continue;
            }

            char numMaiorJogada = maiorJogada[0];
            char naipMaiorJogada = maiorJogada[1];

            char itemNumJogada = jogadas[i][0];
            char itemNaipJogada = jogadas[i][1];

            int indexMaior = Array.IndexOf(cartas, numMaiorJogada);
            int indexItem = Array.IndexOf(cartas, itemNumJogada);

            if (indexItem == indexManilha && indexMaior == indexManilha)
            {
                int indexNaipsMaior = Array.IndexOf(naips, naipMaiorJogada);
                int indexNaipsItem = Array.IndexOf(naips, itemNaipJogada);

                if (indexNaipsMaior > indexNaipsItem)
                {
                    continue;
                }
                else if(indexNaipsItem > indexNaipsMaior)
                {
                    indexVencedor = i;
                }
                else
                {
                    indexVencedor = -1;
                }
            }
            else if (indexItem == indexManilha || indexMaior == indexManilha)
            {
                if (indexMaior == indexManilha)
                {
                    continue;
                }
                else
                {
                    indexVencedor = i;
                }
            }
            else
            {
                if (indexMaior > indexItem)
                {
                    continue;
                }
                else if (indexItem > indexMaior)
                {
                    indexVencedor = i;
                }
                else
                {
                    indexVencedor = -1;
                }
            }
        }

        return indexVencedor;
    }

    public static string DefineVencedor(Jogador[] jogadores)
    {
        Jogador vencedor = jogadores[0];
        bool embuchou = false;

        foreach (var item in jogadores)
        {
            if (vencedor.Nome == item.Nome)
            {
                continue;
            }
            else
            {
                if ((vencedor.palpite - vencedor.rodadasVencidas) < (item.palpite - item.rodadasVencidas))
                {
                    embuchou = false;
                    continue;
                }
                else if((item.palpite - item.rodadasVencidas) < (vencedor.palpite - vencedor.rodadasVencidas))
                {
                    embuchou = false;
                    vencedor = item;
                }
                else
                {
                    embuchou = true;
                }
            }
        }

        if (embuchou == false)
        {
            return vencedor.Nome;
        }

        return "*";
    }
}

public class Jogador
{
    public string Nome { get; set; }

    public int palpite { get; set; }

    public int rodadasVencidas { get; set; }

    public Jogador(string entrada)
    {
        string[] aux = entrada.Split(' ');

        Nome = aux[0];
        palpite = int.Parse(aux[1]);
        rodadasVencidas = 0;
    }
}