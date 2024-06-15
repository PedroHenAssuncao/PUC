using PapaPizza.Infraestructure.Entity;
using PapaPizza.Infraestructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Presentation
{
    public class RecipeCRUD
    {
        private IRecipeRepository _repository;
        private IIngredientRepository _ingredientRepository;
        private IRecipeIngredientRepository _recipeIngredientRepository;

        public RecipeCRUD(IRecipeRepository repository,
                          IIngredientRepository ingredientRepository,
                          IRecipeIngredientRepository recipeIngredientRepository)
        {
            _repository = repository;
            _ingredientRepository = ingredientRepository;
            _recipeIngredientRepository = recipeIngredientRepository;
        }

        public void listAll()
        {
            Console.Write("\n\t+-------------------+");
            Console.Write("\n\t| Exibindo Receitas |");
            Console.Write("\n\t+-------------------+");

            var ingredientes = _repository.FindAll();

            foreach (var item in ingredientes)
            {
                Console.WriteLine(_repository.Parse(item));
            }
        }

        public void delete()
        {
            bool empty = true;


            empty = !_repository.FindAll().Any();

            if (!empty)
            {
                listAll();

                Console.Write("\n\t+---------------------------------------+");
                Console.Write("\n\t| Digite o nome da receita para excluir |");
                Console.Write("\n\t+---------------------------------------+");
                Console.Write("-> ");
                string nome = Console.ReadLine();

                try
                {
                    _repository.Delete(nome);
                }
                catch(Exception ex)
                {
                    Console.Write("\n\t+------------------------------------+");
                    Console.Write("\n\t| Houve um erro ao deletar a receita |");
                    Console.Write("\n\t+------------------------------------+");
                }
            }
            else
            {
                Console.Write("\n\t+-----------------+");
                Console.Write("\n\t| Não há receitas |");
                Console.Write("\n\t+-----------------+");
            }
        }
    
        public void getIngredients(string name)
        {
            var recipe = _repository.FindByName(name);

            if (recipe == null) {

                Console.Write("\n\t+--------------------+");
                Console.Write("\n\t| Receita não Existe |");
                Console.Write("\n\t+--------------------+");

                return;
            }

            Console.Write("\n\t+-----------------------------------------+");
            Console.Write($"\n\t| Exibindo ingredientes da {recipe.Name}: |");
            Console.Write("\n\t+-----------------------------------------+");

            var ingredients = _repository.GetIngredients(recipe.Name);

            foreach (var item in ingredients)
            {
                Console.WriteLine(_ingredientRepository.Parse(item));
            }

            Console.WriteLine();
        }

        public void updateRecipe(string name)
        {
            IngredientCRUD ingredientCRUD = new IngredientCRUD(_ingredientRepository);

            var recipe = _repository.FindByName(name);

            if (recipe == null)
            {

                Console.Write("\n\t+--------------------+");
                Console.Write("\n\t| Receita não Existe |");
                Console.Write("\n\t+--------------------+");

                return;
            }

            bool sair = false;

            while (sair != true)
            {
                Console.Write("\n\t+-------------------------------------------+");
                Console.Write("\n\t| Deseja adicionar ou remover ingredientes? |");
                Console.Write("\n\t| (1)adicionar (2)remover (3)sair           |");
                Console.Write("\n\t+-------------------------------------------+");
                Console.Write("-> ");
                int opt = int.Parse(Console.ReadLine());

                if (opt == 1 || opt == 2)
                {
                    Console.Write("\n\t+-----------------------------------------+");
                    Console.Write($"\n\t| Exibindo ingredientes da {recipe.Name}: |");
                    Console.Write("\n\t+-----------------------------------------+");

                    var ingredients = _repository.GetIngredients(recipe.Name);

                    foreach (var item in ingredients)
                    {
                        Console.WriteLine(_ingredientRepository.Parse(item));
                    }

                    if (opt == 2)
                    {
                        Console.Write("\n\t+------------------------------+");
                        Console.Write("\n\t| Digite o nome do ingrediente |");
                        Console.Write("\n\t+------------------------------+");
                        Console.Write("-> ");
                        string ingredientName = Console.ReadLine();

                        var ingredient = _ingredientRepository.FindByName(ingredientName);

                        if (ingredient != null)
                        {
                            var deletRecipeIngredient = _recipeIngredientRepository.FindAll().Where(x => x.IngredientId == ingredient.Id && x.RecipeId == recipe.Id).First();

                            _recipeIngredientRepository.Delete(deletRecipeIngredient.Id);
                        }
                        else
                        {
                            Console.Write("\n\t+--------------------------+");
                            Console.Write("\n\t| O ingrediente não existe |");
                            Console.Write("\n\t+--------------------------+");
                        }
                    }
                    else
                    {
                        ingredientCRUD.listAll();
                        Console.WriteLine();
                        Console.WriteLine("Digite o nome do ingrediente");
                        Console.Write("-> ");
                        string nameIngredient = Console.ReadLine();
                        Console.WriteLine("Digite a quantidade");
                        Console.Write("-> ");
                        int quantidade = int.Parse(Console.ReadLine());

                        var ingredient = _ingredientRepository.FindByName(nameIngredient);

                        if (ingredient != null)
                        {

                            var newIngredient = new RecipeIngredientEntity()
                            {
                                Amount = quantidade,
                                RecipeId = recipe.Id,
                                IngredientId = ingredient.Id

                            };

                            _recipeIngredientRepository.Create(newIngredient);
                        }
                        else
                        {
                            Console.Write("\n\t+--------------------------+");
                            Console.Write("\n\t| O ingrediente não existe |");
                            Console.Write("\n\t+--------------------------+");
                        }
                    }
                }
                else
                {
                    sair = true;
                }
            }
        }

        public void create()
        {
            Console.Write("\n\t+--------------------------------------+");
            Console.Write("\n\t| Digite as informações do ingrediente |");
            Console.Write("\n\t+--------------------------------------+");

            RecipeEntity newRecipe = new RecipeEntity();

            var fields = newRecipe.GetType().GetFields();
            List<string> values = new List<string>();

            for (int i = 1; i < fields.Length; i++)
            {
                Console.WriteLine($"Digite o {fields[i].Name}");
                Console.Write("-> ");
                values.Add(Console.ReadLine());
            }

            try
            {
                newRecipe = _repository.Parse(newRecipe.Id.ToString() + ";" + string.Join(';', values));

                _repository.Create(newRecipe);

                addIngredients(newRecipe.Id, newRecipe.Name);
            }
            catch(ApplicationException ex)
            {
                Console.Write("\n\t+--------------------------------------------------+");
                Console.Write("\n\t| Houve um erro ao adcionar ingredientes a receita |");
                Console.Write("\n\t+--------------------------------------------------+");
            }
            catch (Exception ex)
            {
                Console.Write("\n\t+-----------------------------------+");
                Console.Write("\n\t| Houve um erro ao salvar a receita |");
                Console.Write("\n\t+-----------------------------------+");
            }
        }

        private void addIngredients(Guid recipeId, string name)
        {
            IngredientCRUD ingredientCRUD = new IngredientCRUD(_ingredientRepository);

            bool salvar = false;

            while (salvar != true)
            {
                try
                {
                    ingredientCRUD.listAll();
                    Console.WriteLine();
                    Console.WriteLine("Digite o nome do ingrediente");
                    Console.Write("-> ");
                    string nameIngredient = Console.ReadLine();
                    Console.WriteLine("Digite a quantidade");
                    Console.Write("-> ");
                    int quantidade = int.Parse(Console.ReadLine());

                    var ingredient = _ingredientRepository.FindByName(nameIngredient);

                    if (ingredient != null)
                    {

                        var newIngredient = new RecipeIngredientEntity()
                        {
                            Amount = quantidade,
                            RecipeId = recipeId,
                            IngredientId = ingredient.Id

                        };

                        _recipeIngredientRepository.Create(newIngredient);

                        Console.Write("\n\t+-----------------------------------------------------------+");
                        Console.Write("\n\t| Deseja Inserir mais ingredientes a receita? (1)Sim (2)Nao |");
                        Console.Write("\n\t+-----------------------------------------------------------+");
                        Console.Write("-> ");
                        int opt = int.Parse(Console.ReadLine());

                        if (opt != 1)
                        {
                            salvar = true;
                        }
                    }
                    else
                    {
                        Console.Write("\n\t+--------------------------+");
                        Console.Write("\n\t| O ingrediente não existe |");
                        Console.Write("\n\t+--------------------------+");
                    }
                }
                catch(Exception ex)
                {
                    throw new ApplicationException();
                }
            }
        }
    }
}
