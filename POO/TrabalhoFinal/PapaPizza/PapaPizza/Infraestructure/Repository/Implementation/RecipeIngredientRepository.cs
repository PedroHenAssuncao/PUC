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
    public class RecipeIngredientRepository : Repository<RecipeIngredientEntity>, IRecipeIngredientRepository
    {
        public override RecipeIngredientEntity? Parse(string objectString)
        {
            return RecipeIngredientEntity.CreateRecipeIngredient(objectString.Split(";"));
        }

        public override string Parse(RecipeIngredientEntity objectToParse)
        {
            return $"{objectToParse.Id};{objectToParse.RecipeId};{objectToParse.IngredientId};{objectToParse.Amount}";
        }
    }
}
