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
        protected override RecipeEntity? Parse(string objectString)
        {
            return RecipeEntity.CreateRecipe(objectString.Split(";"));
        }

        protected override string Parse(RecipeEntity objectToParse)
        {
            return $"{objectToParse.Id};{objectToParse.Name};{objectToParse.Description};{objectToParse.DurationInMinutes}";
        }
    }
}
