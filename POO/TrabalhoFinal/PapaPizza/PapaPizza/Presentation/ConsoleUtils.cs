using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaPizza.Core.AppEnums;

namespace PapaPizza.Presentation
{
    public static class ConsoleUtils
    {

        public static HomeOptionsEnum WelcomingScreen()
        {
            bool exit = false;
            HomeOptionsEnum result = HomeOptionsEnum.Exit;
            while (exit != true)
            {
                Console.WriteLine("  _____                    _____ _              \r\n |  __ \\                  |  __ (_)             \r\n | |__) |_ _ _ __   __ _  | |__) | __________ _ \r\n |  ___/ _` | '_ \\ / _` | |  ___/ |_  /_  / _` |\r\n | |  | (_| | |_) | (_| | | |   | |/ / / / (_| |\r\n |_|   \\__,_| .__/ \\__,_| |_|   |_/___/___\\__,_|\r\n            | |                                 \r\n            |_|                                 ");
                Console.WriteLine("\t+------------------------------------------+");
                Console.WriteLine("\t| Como podemos te ajudar hoje?             |");
                Console.WriteLine("\t| (1) Ver Lista de Ingredientes            |");
                Console.WriteLine("\t| (2) Ver Lista de Receitas                |");
                Console.WriteLine("\t| (3) Sair                                 |");
                Console.WriteLine("\t+------------------------------------------+");
                Console.Write("-> ");
                var opt = Console.ReadLine();

                if (opt == null)
                {
                    ErrorMensage("Nenhuma opção foi digitada!");
                }
                else
                {
                    int optInteger = 0;
                    bool isInt = int.TryParse(opt, out optInteger);

                    if (isInt == false)
                    {
                        ErrorMensage("O que foi digitado não é um número!");
                    }
                    else
                    {
                        switch (optInteger)
                        {
                            case (int)HomeOptionsEnum.ListIngredients:
                                result = (HomeOptionsEnum)optInteger;
                                exit = true;
                                break;
                            case (int)HomeOptionsEnum.ListRecipes:
                                result = (HomeOptionsEnum)optInteger;
                                exit = true;
                                break;
                            case (int)HomeOptionsEnum.Exit:
                                result = (HomeOptionsEnum)optInteger;
                                exit = true;
                                break;
                            default:
                                ErrorMensage("Opção invalida");
                                break;
                        }
                    }
                }
            }

            return result;
        }

        public static MenuOptionsIngredient MenuIngredient()
        {
            bool exit = false;
            MenuOptionsIngredient result = MenuOptionsIngredient.Exit;
            while (exit != true)
            {
                Console.WriteLine("\t+----------------------------------------------------+");
                Console.WriteLine("\t| O que deseja fazer com os ingredientes             |");
                Console.WriteLine("\t| (1) Criar                                          |");
                Console.WriteLine("\t| (2) Deletar                                        |");
                Console.WriteLine("\t| (3) Sair                                           |");
                Console.WriteLine("\t+----------------------------------------------------+");
                Console.Write("-> ");
                var opt = Console.ReadLine();

                if (opt == null)
                {
                    ErrorMensage("Nenhuma opção foi digitada!");
                }
                else
                {
                    int optInteger = 0;
                    bool isInt = int.TryParse(opt, out optInteger);

                    if (isInt == false)
                    {
                        ErrorMensage("O que foi digitado não é um número!");
                    }
                    else
                    {
                        switch (optInteger)
                        {
                            case (int)MenuOptionsIngredient.Create:
                                result = (MenuOptionsIngredient)optInteger;
                                exit = true;
                                break;
                            case (int)MenuOptionsIngredient.Delete:
                                result = (MenuOptionsIngredient)optInteger;
                                exit = true;
                                break;
                            case (int)MenuOptionsIngredient.Exit:
                                result = (MenuOptionsIngredient)optInteger;
                                exit = true;
                                break;
                            default:
                                ErrorMensage("Opção invalida");
                                break;
                        }
                    }
                }
            }

            return result;
        }

        public static MenuOptionsRecipe MenuRecipe()
        {
            bool exit = false;
            MenuOptionsRecipe result = MenuOptionsRecipe.Exit;
            while (exit != true)
            {
                Console.WriteLine("\t+------------------------------------------------+");
                Console.WriteLine("\t| O que deseja fazer com as receitas             |");
                Console.WriteLine("\t| (1) Criar                                      |");
                Console.WriteLine("\t| (2) Deletar                                    |");
                Console.WriteLine("\t| (3) Ver ingredientes                           |");
                Console.WriteLine("\t| (4) Atualizar Ingredientes                     |");
                Console.WriteLine("\t| (5) Sair                                       |");
                Console.WriteLine("\t+------------------------------------------------+");
                Console.Write("-> ");
                var opt = Console.ReadLine();

                if (opt == null)
                {
                    ErrorMensage("Nenhuma opção foi digitada!");
                }
                else
                {
                    int optInteger = 0;
                    bool isInt = int.TryParse(opt, out optInteger);

                    if (isInt == false)
                    {
                        ErrorMensage("O que foi digitado não é um número!");
                    }
                    else
                    {
                        switch (optInteger)
                        {
                            case (int)MenuOptionsRecipe.Create:
                                result = (MenuOptionsRecipe )optInteger;
                                exit = true;
                                break;
                            case (int)MenuOptionsRecipe.Delete:
                                result = (MenuOptionsRecipe)optInteger;
                                exit = true;
                                break;
                            case (int)MenuOptionsRecipe.Detail:
                                result = (MenuOptionsRecipe)optInteger;
                                exit = true;
                                break;
                            case (int)MenuOptionsRecipe.Update:
                                result = (MenuOptionsRecipe)optInteger;
                                exit = true;
                                break;
                            case (int)MenuOptionsRecipe.Exit:
                                result = (MenuOptionsRecipe)optInteger;
                                exit = true;
                                break;
                            default:
                                ErrorMensage("Opção invalida");
                                break;
                        }
                    }
                }
            }

            return result;
        }

        public static void ErrorMensage(string errorMessage)
        {
            Console.WriteLine("\t+------------------------------+");
            Console.WriteLine("\t| Um Erro ocorreu:             |");
            Console.WriteLine("\t+------------------------------+");
            Console.WriteLine($"\t{errorMessage}");
        }
    }
}
