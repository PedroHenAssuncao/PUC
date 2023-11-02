// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int N = int.Parse(Console.ReadLine());
string[] entrada = Console.ReadLine().Split(' ');
int LMin = int.Parse(entrada[0]);
int LMax = int.Parse(entrada[1]);

entrada = Console.ReadLine().Split(' ');
int SMin = int.Parse(entrada[0]);
int SMax = int.Parse(entrada[1]);

if ((N >= LMin && N <= LMax) && (N >= SMin && N <= SMax))
{
    Console.WriteLine("possivel");
}
else
{
    Console.WriteLine("impossivel");
}