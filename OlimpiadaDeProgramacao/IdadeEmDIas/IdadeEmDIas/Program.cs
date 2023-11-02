// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int idadeEmDias = int.Parse(Console.ReadLine());

int anos = idadeEmDias / 365;
idadeEmDias %= 365;
int meses = idadeEmDias / 30;
int dias = idadeEmDias % 30;

Console.WriteLine($"{anos} ano(s)");
Console.WriteLine($"{meses} mes(es)");
Console.WriteLine($"{dias} dia(s)");