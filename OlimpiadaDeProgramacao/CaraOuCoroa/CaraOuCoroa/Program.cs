// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

bool sairDoLoop = false;

while (sairDoLoop != true)
{
    int N = int.Parse(Console.ReadLine());

    if (N == 0)
    {
        sairDoLoop = true;
    }
    else
    {
        string[] resultados = Console.ReadLine().Split(' ');
        int vitoriasMaria = 0;
        int vitoriasJoao = 0;

        for (int i = 0; i < N; i++)
        {
            int resultado = int.Parse(resultados[i]);
            if (resultado == 0)
            {
                vitoriasMaria++;
            }
            else
            {
                vitoriasJoao++;
            }
        }

        Console.WriteLine($"Mary won {vitoriasMaria} times and John won {vitoriasJoao} times");
    }
}