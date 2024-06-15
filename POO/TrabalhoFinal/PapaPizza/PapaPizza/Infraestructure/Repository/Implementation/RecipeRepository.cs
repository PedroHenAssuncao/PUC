using PapaPizza.Infraestructure.Entity;
using PapaPizza.Infraestructure.Repository.Implementation.Base;
using PapaPizza.Infraestructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Infraestructure.Repository.Implementation
{
    public class RecipeRepository : Repository<RecipeEntity>, IRecipeRepository
    {
        IRecipeIngredientRepository _recipeIngredientRepository;
        IIngredientRepository _ingredientRepository;

        public RecipeRepository(IRecipeIngredientRepository recipeIngredientRepository,
                                IIngredientRepository ingredientRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
            _ingredientRepository = ingredientRepository;
        }

        public List<IngredientEntity> GetIngredients(string recipeName)
        {
            var recipe = this.FindByName(recipeName);

            if (recipe == null)
            {
                return new List<IngredientEntity>();
            }

            var recipeIngredients = _recipeIngredientRepository.FindAll().Where(x => x.RecipeId == recipe.Id);

            List<IngredientEntity> result = new List<IngredientEntity>();

            foreach (var item in recipeIngredients)
            {
                var ingredient = _ingredientRepository.FindById(item.IngredientId);

                if (ingredient != null)
                {
                    result.Add(ingredient);
                }
            }

            return result;
        }

        public override bool Delete(string name)
        {
            var recipe = this.FindByName(name);

            if (recipe == null) throw new ArgumentException();

            var recipesIngredients = _recipeIngredientRepository.FindAll().Where(x => x.RecipeId == recipe.Id);

            foreach (var item in recipesIngredients)
            {
                _recipeIngredientRepository.Delete(item.Id);
            }

            return base.Delete(recipe.Id);
        }

        public override RecipeEntity? Parse(string objectString)
        {
            return RecipeEntity.CreateRecipe(objectString.Split(";"));
        }

        public override string Parse(RecipeEntity objectToParse)
        {
            return $"{objectToParse.Id};{objectToParse.Name};{objectToParse.Description};{objectToParse.DurationInMinutes}";
        }
    }
}
