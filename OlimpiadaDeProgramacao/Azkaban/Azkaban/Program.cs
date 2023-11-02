internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

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

        Dictionary<char, int> ordemNaips = new Dictionary<char, int>() {
            { 'D', 1 },
            { 'S', 2 },
            { 'H', 3 },
            { 'C', 4 }
        };

        char[] naipes = { 'D', 'S', 'H', 'C' };

        string[] entrada = Console.ReadLine().Split(' ');
        int numRodadas = int.Parse(entrada[0]);
        string manilha = entrada[1];
        char numManilha = manilha[0];

        Jogador[] jogadores = new Jogador[4];

        jogadores[0] = new Jogador(Console.ReadLine());
        jogadores[1] = new Jogador(Console.ReadLine());
        jogadores[2] = new Jogador(Console.ReadLine());
        jogadores[3] = new Jogador(Console.ReadLine());

        for (int i = 0; i < numRodadas; i++)
        {
            string[] jogadas = Console.ReadLine().Split(' ');

            string maior = jogadas[0];

            for (int j = 0; j < jogadas.Length; j++)
            {
                if ()
                {

                }
            }
        }


    }

    public int BuscaManilha(char entrada, char[] ordemCartas)
    {
        int indexEntrada = Array.IndexOf(ordemCartas, entrada);

        if (indexEntrada == ordemCartas.Length - 1)
        {
            return 0;
        }

        return indexEntrada + 1;
    }

    public int DecideRodada(string[] jogadas, string manilha)
    {

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
    }
}