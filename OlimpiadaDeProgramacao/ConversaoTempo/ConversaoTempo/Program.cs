// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int segundos = int.Parse(Console.ReadLine());

int horas = segundos / 3600;
segundos %= 3600;
int minutos = segundos / 60;
segundos %= 60;

Console.WriteLine(string.Format("{0}:{1}:{2}",horas,minutos,segundos));