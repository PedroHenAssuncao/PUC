int numeroVertices = int.Parse(Console.ReadLine());
int[,] matriz = new int[numeroVertices, numeroVertices];

for (int i = 0; i < numeroVertices; i++)
{
    IEnumerable<int> linha = Console.ReadLine().Split(' ').Select(x => int.Parse(x));

    for (int j = 0; j < numeroVertices; j++)
    {
        matriz[i, j] = linha.ElementAt(j);
    }
}

bool[] visitado = new bool[numeroVertices];
bool temCiclo = false;

for (int i = 0; i < numeroVertices && temCiclo != true; i++)
{
    if (!visitado[i])
    {
        if (BuscaProfundidade(i, -1, matriz, visitado, numeroVertices))
        {
            temCiclo = true;
        }
    }
}

if (temCiclo)
{
    Console.WriteLine("SIM");
}
else
{
    Console.WriteLine("NAO");
}

static bool BuscaProfundidade(int vertice, int pai, int[,] matriz, bool[] visitado, int N)
{
    visitado[vertice] = true;

    for (int i = 0; i < N; i++)
    {
        if (matriz[vertice, i] == 1)
        {
            if (!visitado[i])
            {
                if (BuscaProfundidade(i, vertice, matriz, visitado, N))
                {
                    return true;
                }
            }
            else if (i != pai)
            {
                return true;
            }
        }
    }

    return false;
}