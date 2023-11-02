// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

bool sairDoLoop = false;

while (sairDoLoop != true)
{
    string[] entrada = Console.ReadLine().Split(' ');
    int H1 = int.Parse(entrada[0]);
    int M1 = int.Parse(entrada[1]);
    int H2 = int.Parse(entrada[2]);
    int M2 = int.Parse(entrada[3]);

    if (H1 == 0 && M1 == 0 && H2 == 0 && M2 == 0)
    {
        sairDoLoop = true;
    }
    else
    {
        TimeSpan horaAtual = new TimeSpan(H1, M1, 0);
        TimeSpan horaAlarme = new TimeSpan(H2, M2, 0);

        if (horaAlarme <= horaAtual)
        {
            horaAlarme = horaAlarme.Add(new TimeSpan(24, 0, 0));
        }

        TimeSpan tempoDormir = horaAlarme - horaAtual;
        int minutosDormir = (int)tempoDormir.TotalMinutes;

        Console.WriteLine(minutosDormir);
    }
}