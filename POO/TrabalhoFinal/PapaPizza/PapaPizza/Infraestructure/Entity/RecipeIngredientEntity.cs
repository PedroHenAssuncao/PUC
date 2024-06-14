using PapaPizza.Infraestructure.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaPizza.Infraestructure.Entity
{
    public class RecipeIngredientEntity : EntityBase
    {
        public Guid RecipeId { get; set; }

        public Guid IngredientId { get; set; }

        public int Amount { get; set; }

        public static RecipeIngredientEntity CreateRecipeIngredient(string[] fields)
        {
            var result = new RecipeIngredientEntity();

            result.Id = Guid.Parse(fields[0]);
            result.RecipeId = Guid.Parse(fields[1]);
            result.IngredientId = Guid.Parse(fields[2]);
            result.Amount = int.Parse(fields[3]);

            return result;
        }
    }
}
