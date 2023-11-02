// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

bool sairDoLoop = false;

while (sairDoLoop != true)
{
    string[] input = Console.ReadLine().Split(' ');
    int N = int.Parse(input[0]);
    int M = int.Parse(input[1]);

    if (N == 0 && M == 0)
    {
        sairDoLoop = true;
    }
    else
    {
        int caracteristicas = 0;
        int[,] competicao = new int[N, M];

        for (int i = 0; i < N; i++)
        {
            string[] linha = Console.ReadLine().Split(' ');

            for (int j = 0; j < M; j++)
            {
                int valor = int.Parse(linha[j]);
                competicao[i,j] = valor;
            }
        }

        bool[] resolveuTudo = Enumerable.Repeat(true, M).ToArray();
        bool[] resolveuAoMenos1 = Enumerable.Repeat(false, M).ToArray();
        bool[] problemaResolvidoPorTodos = Enumerable.Repeat(true, N).ToArray();
        bool[] problemaUmaPessoa = Enumerable.Repeat(false, N).ToArray();

        for (int i = 0; i < N; i++)
        { 
            for (int j = 0; j < M; j++)
            {
                resolveuTudo[j] &= competicao[i, j] == 1;
                problemaResolvidoPorTodos[i] &= competicao[i, j] == 1;
                problemaUmaPessoa[i] |= competicao[i, j] == 1;
                resolveuAoMenos1[j] |= competicao[i, j] == 1;
            }
        
        }

        if (Array.TrueForAll(resolveuAoMenos1, x => x == true))
        {
            //Se Resolveu pelo menos um
            caracteristicas++;
        }
        if (!Array.Exists(resolveuTudo, x => x == true))
        {
            //Se Ninguém resolveu todos os problemas.
            caracteristicas++;
        }
        if (!Array.Exists(problemaResolvidoPorTodos, x => x == true))
        {
            //se Não há nenhum problema resolvido por todos
            caracteristicas++;
        }
        if (Array.TrueForAll(problemaUmaPessoa, x => x == true))
        {
            //Se Todo problema foi resolvido por pelo menos uma pessoa (não necessariamente a mesma).
            caracteristicas++;
        }

        Console.WriteLine(caracteristicas);
    }
}