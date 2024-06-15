using PapaPizza.Core;
using PapaPizza.Infraestructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Presentation
{
    public class PapaPizaApp
    {
        private IngredientCRUD _ingredientCRUD;
        private RecipeCRUD _recipeCRUD;

        public PapaPizaApp(IRecipeIngredientRepository recipeIngredientRepository,
                           IIngredientRepository ingredientRepository,
                           IRecipeRepository recipeRepository)
        {
            _ingredientCRUD = new IngredientCRUD(ingredientRepository);
            _recipeCRUD = new RecipeCRUD(recipeRepository, ingredientRepository, recipeIngredientRepository);
        }

        public void RunApp()
        {
            bool sair = false;

            AppEnums.HomeOptionsEnum homeOpt = AppEnums.HomeOptionsEnum.Exit;
            AppEnums.MenuOptionsIngredient ingredientOpt = AppEnums.MenuOptionsIngredient.Exit;
            AppEnums.MenuOptionsRecipe recipeOpt = AppEnums.MenuOptionsRecipe.Exit;

            while (sair != true)
            {
                try
                {
                    homeOpt = ConsoleUtils.WelcomingScreen();

                    switch (homeOpt)
                    {
                        case AppEnums.HomeOptionsEnum.ListIngredients:
                            _ingredientCRUD.listAll();
                            ingredientOpt = ConsoleUtils.MenuIngredient();
                            switch (ingredientOpt)
                            {
                                case AppEnums.MenuOptionsIngredient.Create:
                                    _ingredientCRUD.create();
                                    break;
                                case AppEnums.MenuOptionsIngredient.Delete:
                                    _ingredientCRUD.delete();
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case AppEnums.HomeOptionsEnum.ListRecipes:
                            _recipeCRUD.listAll();
                            recipeOpt = ConsoleUtils.MenuRecipe();
                            switch (recipeOpt)
                            {
                                case AppEnums.MenuOptionsRecipe.Create:
                                    _recipeCRUD.create();
                                    break;
                                case AppEnums.MenuOptionsRecipe.Delete:
                                    _recipeCRUD.delete();
                                    break;
                                case AppEnums.MenuOptionsRecipe.Detail:
                                    _recipeCRUD.getIngredients();
                                    break;
                                case AppEnums.MenuOptionsRecipe.Update:
                                    _recipeCRUD.updateRecipe();
                                    break;
                                case AppEnums.MenuOptionsRecipe.Exit:
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case AppEnums.HomeOptionsEnum.Exit:
                            sair = true;
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    ConsoleUtils.ErrorMensage(ex.Message);
                }
            }
        }
    }
}
